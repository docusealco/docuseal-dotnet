using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record CreateSubmissionFromPdfResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Submission unique ID number.
    /// </summary>
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Submission name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The list of submitters.
    /// </summary>
    [JsonPropertyName("submitters")]
    public IEnumerable<CreateSubmissionFromPdfResponseSubmitter> Submitters { get; set; } =
        new List<CreateSubmissionFromPdfResponseSubmitter>();

    /// <summary>
    /// The source of the submission.
    /// </summary>
    [JsonPropertyName("source")]
    public required CreateSubmissionFromPdfResponseSource Source { get; set; }

    /// <summary>
    /// The order of submitters.
    /// </summary>
    [JsonPropertyName("submitters_order")]
    public required CreateSubmissionFromPdfResponseSubmittersOrder SubmittersOrder { get; set; }

    /// <summary>
    /// The status of the submission.
    /// </summary>
    [JsonPropertyName("status")]
    public required CreateSubmissionFromPdfResponseStatus Status { get; set; }

    /// <summary>
    /// The one-off submission document files.
    /// </summary>
    [JsonPropertyName("schema")]
    public IEnumerable<CreateSubmissionFromPdfResponseSchemaDocument>? Schema { get; set; }

    /// <summary>
    /// List of fields to be filled in the one-off submission.
    /// </summary>
    [JsonPropertyName("fields")]
    public IEnumerable<TemplateField>? Fields { get; set; }

    /// <summary>
    /// Specify the expiration date and time after which the submission becomes unavailable for signature.
    /// </summary>
    [JsonPropertyName("expire_at")]
    public required string ExpireAt { get; set; }

    /// <summary>
    /// The date and time when the submission was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; set; }

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
