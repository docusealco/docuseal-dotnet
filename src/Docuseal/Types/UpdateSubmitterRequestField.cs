using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Docuseal;

[Serializable]
public record UpdateSubmitterRequestField : IJsonOnDeserialized
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
    [JsonPropertyName("readonly")]
    public bool? Readonly { get; set; }

    /// <summary>
    /// Set `true` to make the field required.
    /// </summary>
    [JsonPropertyName("required")]
    public bool? Required { get; set; }

    [JsonPropertyName("validation")]
    public FieldValidation? Validation { get; set; }

    [JsonPropertyName("preferences")]
    public FieldPreferences? Preferences { get; set; }

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
