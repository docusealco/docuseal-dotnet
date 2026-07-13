using Docuseal.Core;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record CreateTemplateFromPdfParams
{
    /// <summary>
    /// Name of the template.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The folder's name in which the template should be created.
    /// </summary>
    [Optional]
    [JsonPropertyName("folder_name")]
    public string? FolderName { get; set; }

    /// <summary>
    /// Your application-specific unique string key to identify this template within your app. Existing template with specified `external_id` will be updated with a new PDF.
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
    /// An array of PDF documents to create a template.
    /// </summary>
    [JsonPropertyName("documents")]
    public IEnumerable<CreateTemplateFromPdfDocumentParams> Documents { get; set; } =
        new List<CreateTemplateFromPdfDocumentParams>();

    /// <summary>
    /// Remove PDF form fields from the documents.
    /// </summary>
    [Optional]
    [JsonPropertyName("flatten")]
    public bool? Flatten { get; set; }

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
