using Docuseal.Core;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record UpdateSubmitterParams
{
    /// <summary>
    /// The unique identifier of the submitter.
    /// </summary>
    [JsonIgnore]
    public required int Id { get; set; }

    /// <summary>
    /// The name of the submitter.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The email address of the submitter.
    /// </summary>
    [Optional]
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// The phone number of the submitter, formatted according to the E.164 standard.
    /// </summary>
    [Optional]
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// An object with pre-filled values for the submission. Use field names for keys of the object. For more configurations see `fields` param.
    /// </summary>
    [Optional]
    [JsonPropertyName("values")]
    public Dictionary<string, object?>? Values { get; set; }

    /// <summary>
    /// Your application-specific unique string key to identify this submitter within your app.
    /// </summary>
    [Optional]
    [JsonPropertyName("external_id")]
    public string? ExternalId { get; set; }

    /// <summary>
    /// Set `true` to re-send signature request emails.
    /// </summary>
    [Optional]
    [JsonPropertyName("send_email")]
    public bool? SendEmail { get; set; }

    /// <summary>
    /// Set `true` to re-send signature request via phone number SMS.
    /// </summary>
    [Optional]
    [JsonPropertyName("send_sms")]
    public bool? SendSms { get; set; }

    /// <summary>
    /// Specify Reply-To address to use in the notification emails.
    /// </summary>
    [Optional]
    [JsonPropertyName("reply_to")]
    public string? ReplyTo { get; set; }

    /// <summary>
    /// Pass `true` to mark submitter as completed and auto-signed via API.
    /// </summary>
    [Optional]
    [JsonPropertyName("completed")]
    public bool? Completed { get; set; }

    /// <summary>
    /// Metadata object with additional submitter information.
    /// </summary>
    [Optional]
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    /// <summary>
    /// Submitter specific URL to redirect to after the submission completion.
    /// </summary>
    [Optional]
    [JsonPropertyName("completed_redirect_url")]
    public string? CompletedRedirectUrl { get; set; }

    /// <summary>
    /// Set to `true` to require phone 2FA verification via a one-time code sent to the phone number in order to access the documents.
    /// </summary>
    [Optional]
    [JsonPropertyName("require_phone_2fa")]
    public bool? RequirePhone2Fa { get; set; }

    /// <summary>
    /// Set to `true` to require email 2FA verification via a one-time code sent to the email address in order to access the documents.
    /// </summary>
    [Optional]
    [JsonPropertyName("require_email_2fa")]
    public bool? RequireEmail2Fa { get; set; }

    [Optional]
    [JsonPropertyName("message")]
    public UpdateSubmitterMessageParams? Message { get; set; }

    /// <summary>
    /// A list of configurations for template document form fields.
    /// </summary>
    [Optional]
    [JsonPropertyName("fields")]
    public IEnumerable<UpdateSubmitterFieldParams>? Fields { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
