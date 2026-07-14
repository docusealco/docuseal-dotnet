using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record Pagination : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Items count.
    /// </summary>
    [JsonPropertyName("count")]
    public required int Count { get; set; }

    /// <summary>
    /// The ID of the item after which the next page starts.
    /// </summary>
    [JsonPropertyName("next")]
    public int? Next { get; set; }

    /// <summary>
    /// The ID of the item before which the previous page ends.
    /// </summary>
    [JsonPropertyName("prev")]
    public int? Prev { get; set; }

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
