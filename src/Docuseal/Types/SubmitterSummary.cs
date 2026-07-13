using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record SubmitterSummary : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Submitter unique ID number.
    /// </summary>
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Submission unique ID number.
    /// </summary>
    [JsonPropertyName("submission_id")]
    public required int SubmissionId { get; set; }

    /// <summary>
    /// Submitter UUID.
    /// </summary>
    [JsonPropertyName("uuid")]
    public required string Uuid { get; set; }

    /// <summary>
    /// The email address of the submitter.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Unique key to be used in the form signing link and embedded form.
    /// </summary>
    [JsonPropertyName("slug")]
    public required string Slug { get; set; }

    /// <summary>
    /// The date and time when the signing request was sent to the submitter.
    /// </summary>
    [JsonPropertyName("sent_at")]
    public string? SentAt { get; set; }

    /// <summary>
    /// The date and time when the submitter opened the signing form.
    /// </summary>
    [JsonPropertyName("opened_at")]
    public string? OpenedAt { get; set; }

    /// <summary>
    /// The date and time when the submitter completed the signing form.
    /// </summary>
    [JsonPropertyName("completed_at")]
    public string? CompletedAt { get; set; }

    /// <summary>
    /// The date and time when the submitter declined the signing form.
    /// </summary>
    [JsonPropertyName("declined_at")]
    public string? DeclinedAt { get; set; }

    /// <summary>
    /// The date and time when the submitter was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; set; }

    /// <summary>
    /// The date and time when the submitter was last updated.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required string UpdatedAt { get; set; }

    /// <summary>
    /// The name of the submitter.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The phone number of the submitter.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// Your application-specific unique string key to identify this submitter within your app.
    /// </summary>
    [JsonPropertyName("external_id")]
    public string? ExternalId { get; set; }

    /// <summary>
    /// The status of signing request for the submitter.
    /// </summary>
    [JsonPropertyName("status")]
    public required SubmitterSummaryStatus Status { get; set; }

    /// <summary>
    /// The role of the submitter in the signing process.
    /// </summary>
    [JsonPropertyName("role")]
    public required string Role { get; set; }

    /// <summary>
    /// Metadata object with additional submitter information.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?> Metadata { get; set; } = new Dictionary<string, object?>();

    /// <summary>
    /// Submitter preferences.
    /// </summary>
    [JsonPropertyName("preferences")]
    public Dictionary<string, object?> Preferences { get; set; } =
        new Dictionary<string, object?>();

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
