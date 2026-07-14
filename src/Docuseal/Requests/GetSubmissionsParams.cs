using Docuseal.Core;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record GetSubmissionsParams
{
    /// <summary>
    /// The template ID allows you to receive only the submissions created from that specific template.
    /// </summary>
    [JsonIgnore]
    public int? TemplateId { get; set; }

    /// <summary>
    /// Filter submissions by status.
    /// </summary>
    [JsonIgnore]
    public SubmissionStatus? Status { get; set; }

    /// <summary>
    /// Filter submissions based on submitter's name, email or phone partial match.
    /// </summary>
    [JsonIgnore]
    public string? Q { get; set; }

    /// <summary>
    /// Filter submissions by unique slug.
    /// </summary>
    [JsonIgnore]
    public string? Slug { get; set; }

    /// <summary>
    /// Filter submissions by template folder name.
    /// </summary>
    [JsonIgnore]
    public string? TemplateFolder { get; set; }

    /// <summary>
    /// Returns only archived submissions when `true` and only active submissions when `false`.
    /// </summary>
    [JsonIgnore]
    public bool? Archived { get; set; }

    /// <summary>
    /// The number of submissions to return. Default value is 10. Maximum value is 100.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// The unique identifier of the submission to start the list from. It allows you to receive only submissions with an ID greater than the specified value. Pass ID value from the `pagination.next` response to load the next batch of submissions.
    /// </summary>
    [JsonIgnore]
    public int? After { get; set; }

    /// <summary>
    /// The unique identifier of the submission that marks the end of the list. It allows you to receive only submissions with an ID less than the specified value.
    /// </summary>
    [JsonIgnore]
    public int? Before { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
