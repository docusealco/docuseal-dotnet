using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(FieldFontType.FieldFontTypeSerializer))]
[Serializable]
public readonly record struct FieldFontType : IStringEnum
{
    public static readonly FieldFontType Bold = new(Values.Bold);

    public static readonly FieldFontType Italic = new(Values.Italic);

    public static readonly FieldFontType BoldItalic = new(Values.BoldItalic);

    public FieldFontType(string value)
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
    public static FieldFontType FromCustom(string value)
    {
        return new FieldFontType(value);
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

    public static bool operator ==(FieldFontType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FieldFontType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FieldFontType value) => value.Value;

    public static explicit operator FieldFontType(string value) => new(value);

    internal class FieldFontTypeSerializer : JsonConverter<FieldFontType>
    {
        public override FieldFontType Read(
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
            return new FieldFontType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FieldFontType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FieldFontType ReadAsPropertyName(
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
            return new FieldFontType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FieldFontType value,
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
        public const string Bold = "bold";

        public const string Italic = "italic";

        public const string BoldItalic = "bold_italic";
    }
}
