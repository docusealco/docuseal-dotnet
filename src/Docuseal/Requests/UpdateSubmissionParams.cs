using Docuseal.Core;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record UpdateSubmissionParams
{
    /// <summary>
    /// The name of the submission.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The date and time when the submission will expire and no longer be available. Pass `null` to remove the expiration.
    /// </summary>
    [JsonPropertyName("expire_at")]
    public string? ExpireAt { get; set; }

    /// <summary>
    /// Set `true` to archive the submission or `false` to unarchive it.
    /// </summary>
    [JsonPropertyName("archived")]
    public bool? Archived { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
