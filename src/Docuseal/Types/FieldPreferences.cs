using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

/// <summary>
/// Field display preferences.
/// </summary>
[Serializable]
public record FieldPreferences : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Font size of the field value in pixels.
    /// </summary>
    [Optional]
    [JsonPropertyName("font_size")]
    public int? FontSize { get; set; }

    /// <summary>
    /// Font type of the field value.
    /// </summary>
    [Optional]
    [JsonPropertyName("font_type")]
    public string? FontType { get; set; }

    /// <summary>
    /// Font family of the field value.
    /// </summary>
    [Optional]
    [JsonPropertyName("font")]
    public string? Font { get; set; }

    /// <summary>
    /// Font color of the field value.
    /// </summary>
    [Optional]
    [JsonPropertyName("color")]
    public string? Color { get; set; }

    /// <summary>
    /// Field box background color.
    /// </summary>
    [Optional]
    [JsonPropertyName("background")]
    public string? Background { get; set; }

    /// <summary>
    /// Horizontal alignment of the field text value.
    /// </summary>
    [Optional]
    [JsonPropertyName("align")]
    public string? Align { get; set; }

    /// <summary>
    /// Vertical alignment of the field text value.
    /// </summary>
    [Optional]
    [JsonPropertyName("valign")]
    public string? Valign { get; set; }

    /// <summary>
    /// The data format for different field types.
    /// </summary>
    [Optional]
    [JsonPropertyName("format")]
    public string? Format { get; set; }

    /// <summary>
    /// Price value of the payment field. Only for payment fields.
    /// </summary>
    [Optional]
    [JsonPropertyName("price")]
    public double? Price { get; set; }

    /// <summary>
    /// Currency value of the payment field. Only for payment fields.
    /// </summary>
    [Optional]
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    /// Indicates if the field is masked on the document.
    /// </summary>
    [Optional]
    [JsonPropertyName("mask")]
    public bool? Mask { get; set; }

    /// <summary>
    /// An array of signature reasons to choose from.
    /// </summary>
    [Optional]
    [JsonPropertyName("reasons")]
    public IEnumerable<string>? Reasons { get; set; }

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
