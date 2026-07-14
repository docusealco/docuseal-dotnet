using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

/// <summary>
/// Submitted form data object.
/// </summary>
[Serializable]
public record FormData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The submitter's unique identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    /// <summary>
    /// The unique submission identifier.
    /// </summary>
    [JsonPropertyName("submission_id")]
    public required int SubmissionId { get; set; }

    /// <summary>
    /// The submitter's email address.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// The submitter's phone number, formatted according to the E.164 standard.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// The submitter's name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The user agent string that provides information about the submitter's web browser.
    /// </summary>
    [JsonPropertyName("ua")]
    public string? Ua { get; set; }

    /// <summary>
    /// The submitter's IP address.
    /// </summary>
    [JsonPropertyName("ip")]
    public string? Ip { get; set; }

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
    /// The reason provided by the submitter for declining the signing form.
    /// </summary>
    [JsonPropertyName("decline_reason")]
    public string? DeclineReason { get; set; }

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
    /// Your application-specific unique string key to identify the submitter.
    /// </summary>
    [JsonPropertyName("external_id")]
    public string? ExternalId { get; set; }

    [JsonPropertyName("status")]
    public required SubmitterStatus Status { get; set; }

    /// <summary>
    /// The role name of the submitter.
    /// </summary>
    [JsonPropertyName("role")]
    public required string Role { get; set; }

    /// <summary>
    /// Metadata object with additional submitter information.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    /// <summary>
    /// Submitter preferences.
    /// </summary>
    [JsonPropertyName("preferences")]
    public Dictionary<string, object?> Preferences { get; set; } =
        new Dictionary<string, object?>();

    /// <summary>
    /// An array of the filled values submitted by the submitter.
    /// </summary>
    [JsonPropertyName("values")]
    public IEnumerable<FieldValue> Values { get; set; } = new List<FieldValue>();

    /// <summary>
    /// An array of the completed documents.
    /// </summary>
    [JsonPropertyName("documents")]
    public IEnumerable<Document> Documents { get; set; } = new List<Document>();

    /// <summary>
    /// Audit log file URL.
    /// </summary>
    [JsonPropertyName("audit_log_url")]
    public string? AuditLogUrl { get; set; }

    /// <summary>
    /// The submission URL.
    /// </summary>
    [JsonPropertyName("submission_url")]
    public required string SubmissionUrl { get; set; }

    [JsonPropertyName("template")]
    public required TemplateSummary Template { get; set; }

    [JsonPropertyName("submission")]
    public required FormSubmission Submission { get; set; }

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
