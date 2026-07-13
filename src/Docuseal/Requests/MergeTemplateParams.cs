using Docuseal.Core;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record MergeTemplateParams
{
    /// <summary>
    /// An array of template ids to merge into a new template.
    /// </summary>
    [JsonPropertyName("template_ids")]
    public IEnumerable<int> TemplateIds { get; set; } = new List<int>();

    /// <summary>
    /// Template name. Existing name with (Merged) suffix will be used if not specified.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The name of the folder in which the merged template should be placed.
    /// </summary>
    [Optional]
    [JsonPropertyName("folder_name")]
    public string? FolderName { get; set; }

    /// <summary>
    /// Your application-specific unique string key to identify this template within your app.
    /// </summary>
    [Optional]
    [JsonPropertyName("external_id")]
    public string? ExternalId { get; set; }

    /// <summary>
    /// Set to `true` to make the template available via a shared link. This will allow anyone with the link to create a submission from this template.
    /// </summary>
    [Optional]
    [JsonPropertyName("shared_link")]
    public bool? SharedLink { get; set; }

    /// <summary>
    /// An array of submitter role names to be used in the merged template.
    /// </summary>
    [Optional]
    [JsonPropertyName("roles")]
    public IEnumerable<string>? Roles { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
