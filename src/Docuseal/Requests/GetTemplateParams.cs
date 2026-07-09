using Docuseal.Core;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record GetTemplateParams
{
    /// <summary>
    /// The unique identifier of the document template.
    /// </summary>
    [JsonIgnore]
    public required int Id { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
