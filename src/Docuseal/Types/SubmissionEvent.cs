using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record SubmissionEvent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Submission event unique ID number.
    /// </summary>
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Unique identifier of the submitter that triggered the event.
    /// </summary>
    [JsonPropertyName("submitter_id")]
    public required int SubmitterId { get; set; }

    /// <summary>
    /// Event type.
    /// </summary>
    [JsonPropertyName("event_type")]
    public required SubmissionEventType EventType { get; set; }

    /// <summary>
    /// Date and time when the event was triggered.
    /// </summary>
    [JsonPropertyName("event_timestamp")]
    public required string EventTimestamp { get; set; }

    /// <summary>
    /// Additional event details object.
    /// </summary>
    [Optional]
    [JsonPropertyName("data")]
    public Dictionary<string, object?>? Data { get; set; }

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
