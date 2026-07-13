using Docuseal.Core;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record UpdateSubmissionParams
{
    /// <summary>
    /// The unique identifier of the submission.
    /// </summary>
    [JsonIgnore]
    public required int Id { get; set; }

    /// <summary>
    /// The name of the submission.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The date and time when the submission will expire and no longer be available. Pass `null` to remove the expiration.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("expire_at")]
    public Optional<string?> ExpireAt { get; set; }

    /// <summary>
    /// Set `true` to archive the submission or `false` to unarchive it.
    /// </summary>
    [Optional]
    [JsonPropertyName("archived")]
    public bool? Archived { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
