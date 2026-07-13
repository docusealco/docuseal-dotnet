using Docuseal.Core;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record UpdateTemplateDocumentsParams
{
    /// <summary>
    /// The unique identifier of the document template.
    /// </summary>
    [JsonIgnore]
    public required int Id { get; set; }

    /// <summary>
    /// The list of documents to add or replace in the template.
    /// </summary>
    [JsonPropertyName("documents")]
    public IEnumerable<UpdateTemplateDocumentsDocumentParams>? Documents { get; set; }

    /// <summary>
    /// Set to `true` to merge all existing and new documents into a single PDF document in the template.
    /// </summary>
    [JsonPropertyName("merge")]
    public bool? Merge { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
