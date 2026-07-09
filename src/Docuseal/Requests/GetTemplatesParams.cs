using Docuseal.Core;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record GetTemplatesParams
{
    /// <summary>
    /// Filter templates based on the name partial match.
    /// </summary>
    [JsonIgnore]
    public string? Q { get; set; }

    /// <summary>
    /// Filter templates by unique slug.
    /// </summary>
    [JsonIgnore]
    public string? Slug { get; set; }

    /// <summary>
    /// The unique application-specific identifier provided for the template via API or Embedded template form builder. It allows you to receive only templates with your specified external ID.
    /// </summary>
    [JsonIgnore]
    public string? ExternalId { get; set; }

    /// <summary>
    /// Filter templates by folder name.
    /// </summary>
    [JsonIgnore]
    public string? Folder { get; set; }

    /// <summary>
    /// List only archived templates instead of active ones.
    /// </summary>
    [JsonIgnore]
    public bool? Archived { get; set; }

    /// <summary>
    /// List templates shared with test mode.
    /// </summary>
    [JsonIgnore]
    public bool? Shared { get; set; }

    /// <summary>
    /// The number of templates to return. Default value is 10. Maximum value is 100.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// The unique identifier of the template to start the list from. It allows you to receive only templates with an ID greater than the specified value. Pass ID value from the `pagination.next` response to load the next batch of templates.
    /// </summary>
    [JsonIgnore]
    public int? After { get; set; }

    /// <summary>
    /// The unique identifier of the template to end the list with. It allows you to receive only templates with an ID less than the specified value.
    /// </summary>
    [JsonIgnore]
    public int? Before { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
