using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record TemplateField : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier of the field.
    /// </summary>
    [JsonPropertyName("uuid")]
    public required string Uuid { get; set; }

    /// <summary>
    /// Unique identifier of the submitter that filled the field.
    /// </summary>
    [JsonPropertyName("submitter_uuid")]
    public required string SubmitterUuid { get; set; }

    /// <summary>
    /// Field name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Type of the field (e.g., text, signature, date, initials).
    /// </summary>
    [JsonPropertyName("type")]
    public required TemplateFieldType Type { get; set; }

    /// <summary>
    /// Indicates if the field is required.
    /// </summary>
    [JsonPropertyName("required")]
    public required bool Required { get; set; }

    [JsonPropertyName("preferences")]
    public TemplateFieldPreferences? Preferences { get; set; }

    /// <summary>
    /// List of areas where the field is located in the document.
    /// </summary>
    [JsonPropertyName("areas")]
    public IEnumerable<TemplateFieldArea> Areas { get; set; } = new List<TemplateFieldArea>();

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
