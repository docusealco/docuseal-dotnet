using Docuseal.Core;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record GetSubmissionDocumentsParams
{
    /// <summary>
    /// When `true`, merges all documents into a single PDF.
    /// </summary>
    [JsonIgnore]
    public bool? Merge { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
