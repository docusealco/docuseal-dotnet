using Docuseal.Core;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record GetSubmittersParams
{
    /// <summary>
    /// The submission ID allows you to receive only the submitters related to that specific submission.
    /// </summary>
    [JsonIgnore]
    public int? SubmissionId { get; set; }

    /// <summary>
    /// Filter submitters on name, email or phone partial match.
    /// </summary>
    [JsonIgnore]
    public string? Q { get; set; }

    /// <summary>
    /// Filter submitters by unique slug.
    /// </summary>
    [JsonIgnore]
    public string? Slug { get; set; }

    /// <summary>
    /// The date and time string value to filter submitters that completed the submission after the specified date and time.
    /// </summary>
    [JsonIgnore]
    public DateTime? CompletedAfter { get; set; }

    /// <summary>
    /// The date and time string value to filter submitters that completed the submission before the specified date and time.
    /// </summary>
    [JsonIgnore]
    public DateTime? CompletedBefore { get; set; }

    /// <summary>
    /// The unique application-specific identifier provided for a submitter when initializing a signature request. It allows you to receive only submitters with a specified external ID.
    /// </summary>
    [JsonIgnore]
    public string? ExternalId { get; set; }

    /// <summary>
    /// The number of submitters to return. Default value is 10. Maximum value is 100.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// The unique identifier of the submitter to start the list from. It allows you to receive only submitters with an ID greater than the specified value. Pass ID value from the `pagination.next` response to load the next batch of submitters.
    /// </summary>
    [JsonIgnore]
    public int? After { get; set; }

    /// <summary>
    /// The unique identifier of the submitter to end the list with. It allows you to receive only submitters with an ID less than the specified value.
    /// </summary>
    [JsonIgnore]
    public int? Before { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
