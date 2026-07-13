using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record CreateSubmissionFromPdfDocumentParams : IJsonOnDeserialized
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
    /// Base64-encoded content of the PDF file or downloadable file URL.
    /// </summary>
    [JsonPropertyName("file")]
    public required string File { get; set; }

    /// <summary>
    /// Fields are optional if you use {{...}} text tags to define fields in the document.
    /// </summary>
    [JsonPropertyName("fields")]
    public IEnumerable<CreateSubmissionDocumentFieldParams>? Fields { get; set; }

    /// <summary>
    /// Document position in the submission. If not specified, the document will be added in the order it appears in the documents array.
    /// </summary>
    [JsonPropertyName("position")]
    public int? Position { get; set; }

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
