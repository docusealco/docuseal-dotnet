using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Docuseal;

[Serializable]
public record SubmitterValue : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Document template field name.
    /// </summary>
    [JsonPropertyName("field")]
    public required string Field { get; set; }

    /// <summary>
    /// Pre-filled value of the field.
    /// </summary>
    [JsonPropertyName("value")]
    public required OneOf<
        string,
        double,
        bool,
        IEnumerable<OneOf<string, double, bool>>
    > Value { get; set; }

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
