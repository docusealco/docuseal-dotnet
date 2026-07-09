using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record SubmissionCreatedByUser : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier of the user who created the submission.
    /// </summary>
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    /// <summary>
    /// The first name of the user who created the submission.
    /// </summary>
    [JsonPropertyName("first_name")]
    public required string FirstName { get; set; }

    /// <summary>
    /// The last name of the user who created the submission.
    /// </summary>
    [JsonPropertyName("last_name")]
    public required string LastName { get; set; }

    /// <summary>
    /// The email address of the user who created the submission.
    /// </summary>
    [JsonPropertyName("email")]
    public required string Email { get; set; }

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
