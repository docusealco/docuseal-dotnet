using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record TemplateFieldArea : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// X coordinate of the area where the field is located in the document.
    /// </summary>
    [JsonPropertyName("x")]
    public required double X { get; set; }

    /// <summary>
    /// Y coordinate of the area where the field is located in the document.
    /// </summary>
    [JsonPropertyName("y")]
    public required double Y { get; set; }

    /// <summary>
    /// Width of the area where the field is located in the document.
    /// </summary>
    [JsonPropertyName("w")]
    public required double W { get; set; }

    /// <summary>
    /// Height of the area where the field is located in the document.
    /// </summary>
    [JsonPropertyName("h")]
    public required double H { get; set; }

    /// <summary>
    /// Unique identifier of the attached document where the field is located.
    /// </summary>
    [JsonPropertyName("attachment_uuid")]
    public required string AttachmentUuid { get; set; }

    /// <summary>
    /// Page number of the attached document where the field is located.
    /// </summary>
    [JsonPropertyName("page")]
    public required int Page { get; set; }

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
