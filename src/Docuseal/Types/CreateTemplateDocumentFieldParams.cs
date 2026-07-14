using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record CreateTemplateDocumentFieldParams : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Name of the field.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Type of the field (e.g., text, signature, date, initials).
    /// </summary>
    [Optional]
    [JsonPropertyName("type")]
    public FieldType? Type { get; set; }

    /// <summary>
    /// Role name of the signer.
    /// </summary>
    [Optional]
    [JsonPropertyName("role")]
    public string? Role { get; set; }

    /// <summary>
    /// Indicates if the field is required.
    /// </summary>
    [Optional]
    [JsonPropertyName("required")]
    public bool? Required { get; set; }

    /// <summary>
    /// Field title displayed to the user instead of the name, shown on the signing form. Supports Markdown.
    /// </summary>
    [Optional]
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Field description displayed on the signing form. Supports Markdown.
    /// </summary>
    [Optional]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// List of areas where the field is located in the document.
    /// </summary>
    [Optional]
    [JsonPropertyName("areas")]
    public IEnumerable<CreateTemplateDocumentFieldAreaParams>? Areas { get; set; }

    /// <summary>
    /// An array of option values for 'select' field type.
    /// </summary>
    [Optional]
    [JsonPropertyName("options")]
    public IEnumerable<string>? Options { get; set; }

    [Optional]
    [JsonPropertyName("validation")]
    public CreateTemplateDocumentFieldValidationParams? Validation { get; set; }

    [Optional]
    [JsonPropertyName("preferences")]
    public CreateTemplateDocumentFieldPreferencesParams? Preferences { get; set; }

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
