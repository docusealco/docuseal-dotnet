#!/bin/sh
# Regenerates src/Docuseal/DocusealClient.g.cs from the DocuSeal OpenAPI spec.
# Usage: ./generate-types.sh [path-or-url-to-openapi-json]
set -e

cd "$(dirname "$0")"

SPEC="${1:-https://console.docuseal.com/openapi.yml?format=json}"
TMP_DIR="$(mktemp -d)"
trap 'rm -rf "$TMP_DIR"' EXIT

case "$SPEC" in
  http*) curl -sf "$SPEC" -o "$TMP_DIR/openapi.json" ;;
  *) cp "$SPEC" "$TMP_DIR/openapi.json" ;;
esac

# NSwag does not support OpenAPI 3.1 yet: downgrade the spec to 3.0.
# Also drop webhook payload schemas (the SDK exposes only the REST client)
# and the legacy POST /submissions operation: CreateSubmissionAsync is
# hand-written against the newer /submissions/init endpoint instead.
python3 - "$TMP_DIR/openapi.json" << 'PY'
import json, sys

path = sys.argv[1]
spec = json.load(open(path))

def convert(node):
    if isinstance(node, dict):
        node_type = node.get("type")
        if isinstance(node_type, list):
            non_null = [t for t in node_type if t != "null"]
            if len(non_null) == 1:
                node["type"] = non_null[0]
                if "null" in node_type:
                    node["nullable"] = True
        examples = node.get("examples")
        if isinstance(examples, list) and examples:
            node["example"] = examples[0]
            del node["examples"]
        for value in list(node.values()):
            convert(value)
    elif isinstance(node, list):
        for value in node:
            convert(value)

convert(spec)
spec["openapi"] = "3.0.3"
spec.pop("webhooks", None)
spec["paths"]["/submissions"].pop("post", None)

# NSwag names inline schemas "Fields2"/"Anonymous" with unstable counters,
# so extract every inline object into a named component with a deterministic
# path-derived name (CreateSubmissionRequestSubmittersItem, ...) locally.
def pascal(name):
    return "".join(part.capitalize() for part in name.split("_"))

schemas = spec.setdefault("components", {}).setdefault("schemas", {})

def extract(schema, name):
    if not isinstance(schema, dict):
        return schema
    for prop, value in list(schema.get("properties", {}).items()):
        schema["properties"][prop] = extract(value, name + pascal(prop))
    if isinstance(schema.get("items"), dict):
        schema["items"] = extract(schema["items"], name + "Item")
    if schema.get("type") == "object" and "properties" in schema:
        assert name not in schemas, name
        schemas[name] = schema
        return {"$ref": "#/components/schemas/" + name}
    return schema

for name, component in list(schemas.items()):
    for prop, value in list(component.get("properties", {}).items()):
        component["properties"][prop] = extract(value, name + pascal(prop))
    if isinstance(component.get("items"), dict):
        component["items"] = extract(component["items"], name + "Item")

json.dump(spec, open(path, "w"))
PY

command -v dotnet > /dev/null || export DOTNET_ROOT="$HOME/.dotnet" PATH="$HOME/.dotnet:$PATH"

npx -y nswag openapi2csclient \
  "/input:$TMP_DIR/openapi.json" \
  /output:src/Docuseal/DocusealClient.g.cs \
  /namespace:Docuseal \
  /ClassName:DocusealClient \
  /JsonLibrary:SystemTextJson \
  /GenerateOptionalParameters:true \
  /GenerateClientInterfaces:true \
  /OperationGenerationMode:SingleClientFromOperationId \
  /ExceptionClass:DocusealException > /dev/null
