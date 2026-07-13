using Docuseal.Core;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record UpdateTemplateParams
{
    /// <summary>
    /// The unique identifier of the document template.
    /// </summary>
    [JsonIgnore]
    public required int Id { get; set; }

    /// <summary>
    /// The name of the template.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The folder's name to which the template should be moved.
    /// </summary>
    [Optional]
    [JsonPropertyName("folder_name")]
    public string? FolderName { get; set; }

    /// <summary>
    /// An array of submitter role names to update the template with.
    /// </summary>
    [Optional]
    [JsonPropertyName("roles")]
    public IEnumerable<string>? Roles { get; set; }

    /// <summary>
    /// Set `false` to unarchive template.
    /// </summary>
    [Optional]
    [JsonPropertyName("archived")]
    public bool? Archived { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
