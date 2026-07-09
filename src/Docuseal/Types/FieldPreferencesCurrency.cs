using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(FieldPreferencesCurrency.FieldPreferencesCurrencySerializer))]
[Serializable]
public readonly record struct FieldPreferencesCurrency : IStringEnum
{
    public static readonly FieldPreferencesCurrency Usd = new(Values.Usd);

    public static readonly FieldPreferencesCurrency Eur = new(Values.Eur);

    public static readonly FieldPreferencesCurrency Gbp = new(Values.Gbp);

    public static readonly FieldPreferencesCurrency Cad = new(Values.Cad);

    public static readonly FieldPreferencesCurrency Aud = new(Values.Aud);

    public FieldPreferencesCurrency(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static FieldPreferencesCurrency FromCustom(string value)
    {
        return new FieldPreferencesCurrency(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(FieldPreferencesCurrency value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FieldPreferencesCurrency value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FieldPreferencesCurrency value) => value.Value;

    public static explicit operator FieldPreferencesCurrency(string value) => new(value);

    internal class FieldPreferencesCurrencySerializer : JsonConverter<FieldPreferencesCurrency>
    {
        public override FieldPreferencesCurrency Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new FieldPreferencesCurrency(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FieldPreferencesCurrency value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FieldPreferencesCurrency ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new FieldPreferencesCurrency(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FieldPreferencesCurrency value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Usd = "USD";

        public const string Eur = "EUR";

        public const string Gbp = "GBP";

        public const string Cad = "CAD";

        public const string Aud = "AUD";
    }
}
