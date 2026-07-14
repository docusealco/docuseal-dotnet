using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record CreateSubmissionDocumentFieldParams : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Name of the field.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Type of the field (e.g., text, signature, date, initials).
    /// </summary>
    [JsonPropertyName("type")]
    public FieldType? Type { get; set; }

    /// <summary>
    /// Role name of the signer.
    /// </summary>
    [JsonPropertyName("role")]
    public string? Role { get; set; }

    /// <summary>
    /// Indicates if the field is required.
    /// </summary>
    [JsonPropertyName("required")]
    public bool? Required { get; set; }

    /// <summary>
    /// Field title displayed to the user instead of the name, shown on the signing form. Supports Markdown.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Field description displayed on the signing form. Supports Markdown.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// List of areas where the field is located in the document.
    /// </summary>
    [JsonPropertyName("areas")]
    public IEnumerable<CreateSubmissionDocumentFieldAreaParams>? Areas { get; set; }

    /// <summary>
    /// An array of option values for 'select' field type.
    /// </summary>
    [JsonPropertyName("options")]
    public IEnumerable<string>? Options { get; set; }

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
