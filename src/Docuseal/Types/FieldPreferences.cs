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
    [Nullable, Optional]
    [JsonPropertyName("font_size")]
    public Optional<int?> FontSize { get; set; }

    /// <summary>
    /// Font type of the field value.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("font_type")]
    public Optional<string?> FontType { get; set; }

    /// <summary>
    /// Font family of the field value.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("font")]
    public Optional<string?> Font { get; set; }

    /// <summary>
    /// Font color of the field value.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("color")]
    public Optional<string?> Color { get; set; }

    /// <summary>
    /// Field box background color.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("background")]
    public Optional<string?> Background { get; set; }

    /// <summary>
    /// Horizontal alignment of the field text value.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("align")]
    public Optional<string?> Align { get; set; }

    /// <summary>
    /// Vertical alignment of the field text value.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("valign")]
    public Optional<string?> Valign { get; set; }

    /// <summary>
    /// The data format for different field types.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("format")]
    public Optional<string?> Format { get; set; }

    /// <summary>
    /// Price value of the payment field. Only for payment fields.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("price")]
    public Optional<double?> Price { get; set; }

    /// <summary>
    /// Currency value of the payment field. Only for payment fields.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("currency")]
    public Optional<string?> Currency { get; set; }

    /// <summary>
    /// Indicates if the field is masked on the document.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("mask")]
    public Optional<bool?> Mask { get; set; }

    /// <summary>
    /// An array of signature reasons to choose from.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("reasons")]
    public Optional<IEnumerable<string>?> Reasons { get; set; }

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
