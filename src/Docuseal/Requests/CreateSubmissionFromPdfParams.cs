using Docuseal.Core;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record CreateSubmissionFromPdfParams
{
    /// <summary>
    /// Name of the document submission.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Set `false` to disable signature request emails sending.
    /// </summary>
    [Optional]
    [JsonPropertyName("send_email")]
    public bool? SendEmail { get; set; }

    /// <summary>
    /// Set `true` to send signature request via phone number and SMS.
    /// </summary>
    [Optional]
    [JsonPropertyName("send_sms")]
    public bool? SendSms { get; set; }

    /// <summary>
    /// Pass 'random' to send signature request emails to all parties right away. The order is 'preserved' by default so the second party will receive a signature request email only after the document is signed by the first party.
    /// </summary>
    [Optional]
    [JsonPropertyName("order")]
    public SubmittersOrder? Order { get; set; }

    /// <summary>
    /// Specify URL to redirect to after the submission completion.
    /// </summary>
    [Optional]
    [JsonPropertyName("completed_redirect_url")]
    public string? CompletedRedirectUrl { get; set; }

    /// <summary>
    /// Specify BCC address to send signed documents to after the completion.
    /// </summary>
    [Optional]
    [JsonPropertyName("bcc_completed")]
    public string? BccCompleted { get; set; }

    /// <summary>
    /// Specify Reply-To address to use in the notification emails.
    /// </summary>
    [Optional]
    [JsonPropertyName("reply_to")]
    public string? ReplyTo { get; set; }

    /// <summary>
    /// Specify the expiration date and time after which the submission becomes unavailable for signature.
    /// </summary>
    [Optional]
    [JsonPropertyName("expire_at")]
    public string? ExpireAt { get; set; }

    /// <summary>
    /// An optional array of template IDs to use in the submission along with the provided documents. This can be used to create multi-document submissions when some of the required documents exist within templates.
    /// </summary>
    [Optional]
    [JsonPropertyName("template_ids")]
    public IEnumerable<int>? TemplateIds { get; set; }

    /// <summary>
    /// An array of PDF documents to create a submission.
    /// </summary>
    [JsonPropertyName("documents")]
    public IEnumerable<CreateSubmissionFromPdfDocumentParams> Documents { get; set; } =
        new List<CreateSubmissionFromPdfDocumentParams>();

    /// <summary>
    /// The list of submitters for the submission.
    /// </summary>
    [JsonPropertyName("submitters")]
    public IEnumerable<CreateSubmissionSubmitterParams> Submitters { get; set; } =
        new List<CreateSubmissionSubmitterParams>();

    [Optional]
    [JsonPropertyName("message")]
    public CreateSubmissionMessageParams? Message { get; set; }

    /// <summary>
    /// Remove PDF form fields from the documents.
    /// </summary>
    [Optional]
    [JsonPropertyName("flatten")]
    public bool? Flatten { get; set; }

    /// <summary>
    /// Set `true` to merge the documents into a single PDF file.
    /// </summary>
    [Optional]
    [JsonPropertyName("merge_documents")]
    public bool? MergeDocuments { get; set; }

    /// <summary>
    /// Pass `false` to disable the removal of {{text}} tags from the PDF. This can be used along with transparent text tags for faster and more robust PDF processing.
    /// </summary>
    [Optional]
    [JsonPropertyName("remove_tags")]
    public bool? RemoveTags { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
