using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record AddDocumentToTemplateRequestDocument : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Document name. Random uuid will be assigned when not specified.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Base64-encoded content of the PDF or DOCX file or downloadable file URL. Leave it empty if you create a new document using HTML param.
    /// </summary>
    [JsonPropertyName("file")]
    public string? File { get; set; }

    /// <summary>
    /// HTML template with field tags. Leave it empty if you add a document via PDF or DOCX base64 encoded file param or URL.
    /// </summary>
    [JsonPropertyName("html")]
    public string? Html { get; set; }

    /// <summary>
    /// Position of the document. By default will be added as the last document in the template.
    /// </summary>
    [JsonPropertyName("position")]
    public int? Position { get; set; }

    /// <summary>
    /// Set to `true` to replace existing document with a new file at `position`. Existing document fields will be transferred to the new document if it doesn't contain any fields.
    /// </summary>
    [JsonPropertyName("replace")]
    public bool? Replace { get; set; }

    /// <summary>
    /// Set to `true` to remove existing document at given `position` or with given `name`.
    /// </summary>
    [JsonPropertyName("remove")]
    public bool? Remove { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
