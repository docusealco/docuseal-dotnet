using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record Template : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier of the document template.
    /// </summary>
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Unique slug of the document template.
    /// </summary>
    [JsonPropertyName("slug")]
    public required string Slug { get; set; }

    /// <summary>
    /// The name of the template.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Template preferences.
    /// </summary>
    [JsonPropertyName("preferences")]
    public Dictionary<string, object?> Preferences { get; set; } =
        new Dictionary<string, object?>();

    /// <summary>
    /// List of documents attached to the template.
    /// </summary>
    [JsonPropertyName("schema")]
    public IEnumerable<SchemaDocument> Schema { get; set; } = new List<SchemaDocument>();

    /// <summary>
    /// List of fields to be filled in the template.
    /// </summary>
    [JsonPropertyName("fields")]
    public IEnumerable<Field> Fields { get; set; } = new List<Field>();

    /// <summary>
    /// Schema of the dynamic document content variables used in the template.
    /// </summary>
    [JsonPropertyName("variables_schema")]
    public Dictionary<string, object?> VariablesSchema { get; set; } =
        new Dictionary<string, object?>();

    /// <summary>
    /// The list of submitters for the template.
    /// </summary>
    [JsonPropertyName("submitters")]
    public IEnumerable<TemplateSubmitter> Submitters { get; set; } = new List<TemplateSubmitter>();

    /// <summary>
    /// Unique identifier of the author of the template.
    /// </summary>
    [JsonPropertyName("author_id")]
    public required int AuthorId { get; set; }

    /// <summary>
    /// Date and time when the template was archived.
    /// </summary>
    [Nullable]
    [JsonPropertyName("archived_at")]
    public string? ArchivedAt { get; set; }

    /// <summary>
    /// The date and time when the template was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; set; }

    /// <summary>
    /// The date and time when the template was last updated.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required string UpdatedAt { get; set; }

    /// <summary>
    /// Source of the template.
    /// </summary>
    [JsonPropertyName("source")]
    public required TemplateSource Source { get; set; }

    /// <summary>
    /// Your application-specific unique string key to identify this template within your app.
    /// </summary>
    [Nullable]
    [JsonPropertyName("external_id")]
    public string? ExternalId { get; set; }

    /// <summary>
    /// Unique identifier of the folder where the template is located.
    /// </summary>
    [JsonPropertyName("folder_id")]
    public required int FolderId { get; set; }

    /// <summary>
    /// Folder name where the template is located.
    /// </summary>
    [JsonPropertyName("folder_name")]
    public required string FolderName { get; set; }

    /// <summary>
    /// Indicates if the template is accessible by link.
    /// </summary>
    [Optional]
    [JsonPropertyName("shared_link")]
    public bool? SharedLink { get; set; }

    [JsonPropertyName("author")]
    public required User Author { get; set; }

    /// <summary>
    /// List of documents attached to the template.
    /// </summary>
    [JsonPropertyName("documents")]
    public IEnumerable<TemplateDocument> Documents { get; set; } = new List<TemplateDocument>();

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
