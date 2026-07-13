using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record CreateTemplateFromDocxDocumentParams : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Name of the document.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Base64-encoded content of the DOCX file or downloadable file URL.
    /// </summary>
    [JsonPropertyName("file")]
    public required string File { get; set; }

    /// <summary>
    /// Set to `true` to make the document dynamic. When enabled, the DOCX document content can be edited or use [[variables]] in the template editor.
    /// </summary>
    [Optional]
    [JsonPropertyName("dynamic")]
    public bool? Dynamic { get; set; }

    /// <summary>
    /// Fields are optional if you use {{...}} text tags to define fields in the document.
    /// </summary>
    [Optional]
    [JsonPropertyName("fields")]
    public IEnumerable<CreateTemplateDocumentFieldParams>? Fields { get; set; }

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
