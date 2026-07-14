using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

/// <summary>
/// Submission details of the form.
/// </summary>
[Serializable]
public record FormSubmission : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The submission unique identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required int Id { get; set; }

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

    [JsonPropertyName("status")]
    public required SubmissionStatus Status { get; set; }

    /// <summary>
    /// The submission URL.
    /// </summary>
    [JsonPropertyName("url")]
    public required string Url { get; set; }

    /// <summary>
    /// Dynamic document content variables of the submission.
    /// </summary>
    [JsonPropertyName("variables")]
    public Dictionary<string, object?>? Variables { get; set; }

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
