using Docuseal.Core;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record CreateTemplateFromHtmlParams
{
    /// <summary>
    /// HTML template with field tags.
    /// </summary>
    [Optional]
    [JsonPropertyName("html")]
    public string? Html { get; set; }

    /// <summary>
    /// HTML template of the header to be displayed on every page.
    /// </summary>
    [Optional]
    [JsonPropertyName("html_header")]
    public string? HtmlHeader { get; set; }

    /// <summary>
    /// HTML template of the footer to be displayed on every page.
    /// </summary>
    [Optional]
    [JsonPropertyName("html_footer")]
    public string? HtmlFooter { get; set; }

    /// <summary>
    /// Template name. Random uuid will be assigned when not specified.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Page size. Letter 8.5 x 11 will be assigned when not specified.
    /// </summary>
    [Optional]
    [JsonPropertyName("size")]
    public CreateTemplateFromHtmlRequestSize? Size { get; set; }

    /// <summary>
    /// Your application-specific unique string key to identify this template within your app. Existing template with specified `external_id` will be updated with a new HTML.
    /// </summary>
    [Optional]
    [JsonPropertyName("external_id")]
    public string? ExternalId { get; set; }

    /// <summary>
    /// The folder's name in which the template should be created.
    /// </summary>
    [Optional]
    [JsonPropertyName("folder_name")]
    public string? FolderName { get; set; }

    /// <summary>
    /// Set to `true` to make the template available via a shared link. This will allow anyone with the link to create a submission from this template.
    /// </summary>
    [Optional]
    [JsonPropertyName("shared_link")]
    public bool? SharedLink { get; set; }

    /// <summary>
    /// The list of documents built from HTML. Can be used to create a template with multiple documents. Leave `documents` param empty when using a top-level `html` param for a template with a single document.
    /// </summary>
    [Optional]
    [JsonPropertyName("documents")]
    public IEnumerable<CreateTemplateFromHtmlDocumentParams>? Documents { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
