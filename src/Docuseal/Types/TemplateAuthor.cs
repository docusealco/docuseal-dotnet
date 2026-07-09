using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[Serializable]
public record TemplateAuthor : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier of the author.
    /// </summary>
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    /// <summary>
    /// First name of the author.
    /// </summary>
    [JsonPropertyName("first_name")]
    public required string FirstName { get; set; }

    /// <summary>
    /// Last name of the author.
    /// </summary>
    [JsonPropertyName("last_name")]
    public required string LastName { get; set; }

    /// <summary>
    /// Author email.
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
