using Docuseal.Core;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record CreateTemplateFromDocxParams
{
    /// <summary>
    /// Name of the template.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Your application-specific unique string key to identify this template within your app. Existing template with specified `external_id` will be updated with a new document.
    /// </summary>
    [JsonPropertyName("external_id")]
    public string? ExternalId { get; set; }

    /// <summary>
    /// The folder's name in which the template should be created.
    /// </summary>
    [JsonPropertyName("folder_name")]
    public string? FolderName { get; set; }

    /// <summary>
    /// Set to `true` to make the template available via a shared link. This will allow anyone with the link to create a submission from this template.
    /// </summary>
    [JsonPropertyName("shared_link")]
    public bool? SharedLink { get; set; }

    /// <summary>
    /// An array of DOCX documents to create a template.
    /// </summary>
    [JsonPropertyName("documents")]
    public IEnumerable<CreateTemplateFromDocxRequestDocument> Documents { get; set; } =
        new List<CreateTemplateFromDocxRequestDocument>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
