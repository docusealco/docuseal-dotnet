using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace Docuseal;

/// <summary>
/// Field display preferences.
/// </summary>
[Serializable]
public record CreateSubmissionSubmitterFieldPreferencesParams : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Font size of the field value in pixels.
    /// </summary>
    [JsonPropertyName("font_size")]
    public int? FontSize { get; set; }

    /// <summary>
    /// Font type of the field value.
    /// </summary>
    [JsonPropertyName("font_type")]
    public FieldFontType? FontType { get; set; }

    /// <summary>
    /// Font family of the field value.
    /// </summary>
    [JsonPropertyName("font")]
    public FieldFont? Font { get; set; }

    /// <summary>
    /// Font color of the field value.
    /// </summary>
    [JsonPropertyName("color")]
    public string? Color { get; set; }

    /// <summary>
    /// Field box background color.
    /// </summary>
    [JsonPropertyName("background")]
    public string? Background { get; set; }

    /// <summary>
    /// Horizontal alignment of the field text value.
    /// </summary>
    [JsonPropertyName("align")]
    public FieldAlign? Align { get; set; }

    /// <summary>
    /// Vertical alignment of the field text value.
    /// </summary>
    [JsonPropertyName("valign")]
    public FieldValign? Valign { get; set; }

    /// <summary>
    /// The data format for different field types.<br/>- Date field: accepts formats such as DD/MM/YYYY (default: MM/DD/YYYY).<br/>- Signature field: accepts drawn, typed, drawn_or_typed (default), or upload.<br/>- Number field: accepts currency formats such as usd, eur, gbp.
    /// </summary>
    [JsonPropertyName("format")]
    public string? Format { get; set; }

    /// <summary>
    /// Price value of the payment field. Only for payment fields.
    /// </summary>
    [JsonPropertyName("price")]
    public double? Price { get; set; }

    /// <summary>
    /// Currency value of the payment field. Only for payment fields.
    /// </summary>
    [JsonPropertyName("currency")]
    public Currency? Currency { get; set; }

    /// <summary>
    /// Set `true` to make sensitive data masked on the document.
    /// </summary>
    [JsonPropertyName("mask")]
    public OneOf<int, bool>? Mask { get; set; }

    /// <summary>
    /// An array of signature reasons to choose from.
    /// </summary>
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
