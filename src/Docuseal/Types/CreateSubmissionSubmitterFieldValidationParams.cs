using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Docuseal;

/// <summary>
/// Field validation rules.
/// </summary>
[Serializable]
public record CreateSubmissionSubmitterFieldValidationParams : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// HTML field validation pattern string based on https://developer.mozilla.org/en-US/docs/Web/HTML/Attributes/pattern specification.
    /// </summary>
    [Optional]
    [JsonPropertyName("pattern")]
    public string? Pattern { get; set; }

    /// <summary>
    /// A custom error message to display on validation failure.
    /// </summary>
    [Optional]
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// Minimum allowed number value or date depending on field type.
    /// </summary>
    [Optional]
    [JsonPropertyName("min")]
    public OneOf<double, string>? Min { get; set; }

    /// <summary>
    /// Maximum allowed number value or date depending on field type.
    /// </summary>
    [Optional]
    [JsonPropertyName("max")]
    public OneOf<double, string>? Max { get; set; }

    /// <summary>
    /// Increment step for number field. Pass 1 to accept only integers, or 0.01 to accept decimal currency.
    /// </summary>
    [Optional]
    [JsonPropertyName("step")]
    public double? Step { get; set; }

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
