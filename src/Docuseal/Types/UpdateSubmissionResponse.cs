using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record UpdateSubmissionResponse : IJsonOnDeserialized
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
    /// Name of the document submission.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Unique slug of the submission.
    /// </summary>
    [JsonPropertyName("slug")]
    public required string Slug { get; set; }

    /// <summary>
    /// The source of the submission.
    /// </summary>
    [JsonPropertyName("source")]
    public required UpdateSubmissionResponseSource Source { get; set; }

    /// <summary>
    /// The order of submitters.
    /// </summary>
    [JsonPropertyName("submitters_order")]
    public required UpdateSubmissionResponseSubmittersOrder SubmittersOrder { get; set; }

    /// <summary>
    /// Audit log file URL.
    /// </summary>
    [JsonPropertyName("audit_log_url")]
    public string? AuditLogUrl { get; set; }

    /// <summary>
    /// Combined PDF file URL with documents and Audit Log.
    /// </summary>
    [JsonPropertyName("combined_document_url")]
    public string? CombinedDocumentUrl { get; set; }

    /// <summary>
    /// The date and time when the submission was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; set; }

    /// <summary>
    /// The date and time when the submission was last updated.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required string UpdatedAt { get; set; }

    /// <summary>
    /// The date and time when the submission was archived.
    /// </summary>
    [JsonPropertyName("archived_at")]
    public string? ArchivedAt { get; set; }

    /// <summary>
    /// The list of submitters.
    /// </summary>
    [JsonPropertyName("submitters")]
    public IEnumerable<GetSubmissionResponseSubmitter> Submitters { get; set; } =
        new List<GetSubmissionResponseSubmitter>();

    [JsonPropertyName("template")]
    public SubmissionTemplate? Template { get; set; }

    [JsonPropertyName("created_by_user")]
    public SubmissionCreatedByUser? CreatedByUser { get; set; }

    /// <summary>
    /// An array of completed or signed documents of the submission.
    /// </summary>
    [JsonPropertyName("documents")]
    public IEnumerable<CompletedDocument> Documents { get; set; } = new List<CompletedDocument>();

    /// <summary>
    /// The status of the submission.
    /// </summary>
    [JsonPropertyName("status")]
    public required UpdateSubmissionResponseStatus Status { get; set; }

    /// <summary>
    /// Object with custom metadata.
    /// </summary>
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?> Metadata { get; set; } = new Dictionary<string, object?>();

    /// <summary>
    /// The date and time when the submission was completed.
    /// </summary>
    [JsonPropertyName("completed_at")]
    public string? CompletedAt { get; set; }

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
