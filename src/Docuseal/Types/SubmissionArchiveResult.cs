using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record SubmissionArchiveResult : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Submission unique ID number.
    /// </summary>
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Date and time when the submission was archived.
    /// </summary>
    [JsonPropertyName("archived_at")]
    public string? ArchivedAt { get; set; }

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
