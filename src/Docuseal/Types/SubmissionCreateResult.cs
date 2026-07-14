using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record SubmissionCreateResult : IJsonOnDeserialized
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
    /// Submission name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The list of submitters.
    /// </summary>
    [JsonPropertyName("submitters")]
    public IEnumerable<SubmitterCreateResult> Submitters { get; set; } =
        new List<SubmitterCreateResult>();

    /// <summary>
    /// The source of the submission.
    /// </summary>
    [JsonPropertyName("source")]
    public required SubmissionSource Source { get; set; }

    /// <summary>
    /// The order of submitters.
    /// </summary>
    [JsonPropertyName("submitters_order")]
    public required SubmittersOrder SubmittersOrder { get; set; }

    /// <summary>
    /// The status of the submission.
    /// </summary>
    [JsonPropertyName("status")]
    public required SubmissionStatus Status { get; set; }

    /// <summary>
    /// The one-off submission document files.
    /// </summary>
    [JsonPropertyName("schema")]
    public IEnumerable<SchemaDocument>? Schema { get; set; }

    /// <summary>
    /// List of fields to be filled in the one-off submission.
    /// </summary>
    [JsonPropertyName("fields")]
    public IEnumerable<Field>? Fields { get; set; }

    /// <summary>
    /// The date and time when the submission will expire and no longer be available for signing.
    /// </summary>
    [JsonPropertyName("expire_at")]
    public string? ExpireAt { get; set; }

    /// <summary>
    /// The date and time when the submission was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; set; }

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
