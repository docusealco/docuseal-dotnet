using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Docuseal;

[Serializable]
public record CreateSubmissionSubmitterFieldParams : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Document template field name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Default value of the field. Use base64 encoded file or a public URL to the image file to set default signature or image fields.
    /// </summary>
    [Optional]
    [JsonPropertyName("default_value")]
    public OneOf<
        string,
        double,
        bool,
        IEnumerable<OneOf<string, double, bool>>
    >? DefaultValue { get; set; }

    /// <summary>
    /// Set `true` to make it impossible for the submitter to edit predefined field value.
    /// </summary>
    [Optional]
    [JsonPropertyName("readonly")]
    public bool? Readonly { get; set; }

    /// <summary>
    /// Set `true` to make the field required.
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

    [Optional]
    [JsonPropertyName("validation")]
    public CreateSubmissionSubmitterFieldValidationParams? Validation { get; set; }

    [Optional]
    [JsonPropertyName("preferences")]
    public CreateSubmissionSubmitterFieldPreferencesParams? Preferences { get; set; }

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
