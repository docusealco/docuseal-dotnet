using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

/// <summary>
/// Submitter preferences.
/// </summary>
[Serializable]
public record CreateSubmissionsFromEmailsResponseSubmitterPreferences : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Indicates whether the signature request email should be sent.
    /// </summary>
    [JsonPropertyName("send_email")]
    public bool? SendEmail { get; set; }

    /// <summary>
    /// Indicates whether the signature request should be sent via SMS.
    /// </summary>
    [JsonPropertyName("send_sms")]
    public bool? SendSms { get; set; }

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
