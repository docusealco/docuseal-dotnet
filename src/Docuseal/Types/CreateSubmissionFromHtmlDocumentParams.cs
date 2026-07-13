using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record CreateSubmissionFromHtmlDocumentParams : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Document name. Random uuid will be assigned when not specified.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// HTML document content with field tags.
    /// </summary>
    [JsonPropertyName("html")]
    public required string Html { get; set; }

    /// <summary>
    /// HTML document content of the header to be displayed on every page.
    /// </summary>
    [Optional]
    [JsonPropertyName("html_header")]
    public string? HtmlHeader { get; set; }

    /// <summary>
    /// HTML document content of the footer to be displayed on every page.
    /// </summary>
    [Optional]
    [JsonPropertyName("html_footer")]
    public string? HtmlFooter { get; set; }

    /// <summary>
    /// Page size. Letter 8.5 x 11 will be assigned when not specified.
    /// </summary>
    [Optional]
    [JsonPropertyName("size")]
    public CreateSubmissionFromHtmlDocumentParamsSize? Size { get; set; }

    /// <summary>
    /// Document position in the submission. If not specified, the document will be added in the order it appears in the documents array.
    /// </summary>
    [Optional]
    [JsonPropertyName("position")]
    public int? Position { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
