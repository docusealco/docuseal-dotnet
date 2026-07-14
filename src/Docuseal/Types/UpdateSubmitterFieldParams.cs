using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Docuseal;

[Serializable]
public record UpdateSubmitterFieldParams : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Document template field name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("default_value")]
    public OneOf<
        string,
        int,
        double,
        bool,
        IEnumerable<OneOf<string, int, double, bool>>
    >? DefaultValue { get; set; }

    /// <summary>
    /// Default value of the field as a plain string. Alias of `default_value` that takes precedence when both are provided.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value { get; set; }

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
    public UpdateSubmitterFieldValidationParams? Validation { get; set; }

    [JsonPropertyName("preferences")]
    public UpdateSubmitterFieldPreferencesParams? Preferences { get; set; }

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
