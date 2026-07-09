using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record CreateSubmissionFromPdfRequestDocumentFieldArea : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// X-coordinate of the field area.
    /// </summary>
    [JsonPropertyName("x")]
    public required double X { get; set; }

    /// <summary>
    /// Y-coordinate of the field area.
    /// </summary>
    [JsonPropertyName("y")]
    public required double Y { get; set; }

    /// <summary>
    /// Width of the field area.
    /// </summary>
    [JsonPropertyName("w")]
    public required double W { get; set; }

    /// <summary>
    /// Height of the field area.
    /// </summary>
    [JsonPropertyName("h")]
    public required double H { get; set; }

    /// <summary>
    /// Page number of the field area. Starts from 1.
    /// </summary>
    [JsonPropertyName("page")]
    public required int Page { get; set; }

    /// <summary>
    /// Option string value for 'radio' and 'multiple' select field types.
    /// </summary>
    [JsonPropertyName("option")]
    public string? Option { get; set; }

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
