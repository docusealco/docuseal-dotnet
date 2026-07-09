using Docuseal.Core;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record GetSubmitterParams
{
    /// <summary>
    /// The unique identifier of the submitter.
    /// </summary>
    [JsonIgnore]
    public required int Id { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
