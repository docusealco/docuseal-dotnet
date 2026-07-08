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

# Drop webhook payload schemas (the SDK exposes only the REST client) and
# the legacy POST /submissions operation: CreateSubmissionAsync is
# hand-written against the newer /submissions/init endpoint instead.
# Inline object schemas are extracted into components with deterministic
# path-derived names - otherwise NSwag names them "Fields2"/"Anonymous"
# with unstable counters.
ruby - "$TMP_DIR/openapi.json" << 'RB'
require 'json'

path = ARGV[0]
spec = JSON.parse(File.read(path))

spec.delete('webhooks')
spec['paths']['/submissions'].delete('post')

schemas = spec['components']['schemas']

def pascal(name)
  name.split('_').map(&:capitalize).join
end

def extract(schema, name, schemas)
  return schema unless schema.is_a?(Hash)

  (schema['properties'] || {}).each do |prop, value|
    schema['properties'][prop] = extract(value, name + pascal(prop), schemas)
  end

  schema['items'] = extract(schema['items'], name + 'Item', schemas) if schema['items'].is_a?(Hash)

  if schema['type'] == 'object' && schema.key?('properties')
    raise "duplicate component name: #{name}" if schemas.key?(name)

    schemas[name] = schema
    return { '$ref' => "#/components/schemas/#{name}" }
  end

  schema
end

schemas.to_a.each do |name, component|
  (component['properties'] || {}).each do |prop, value|
    component['properties'][prop] = extract(value, name + pascal(prop), schemas)
  end

  component['items'] = extract(component['items'], name + 'Item', schemas) if component['items'].is_a?(Hash)
end

File.write(path, JSON.generate(spec))
RB

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
