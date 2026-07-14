using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(FieldFont.FieldFontSerializer))]
[Serializable]
public readonly record struct FieldFont : IStringEnum
{
    public static readonly FieldFont Times = new(Values.Times);

    public static readonly FieldFont Helvetica = new(Values.Helvetica);

    public static readonly FieldFont Courier = new(Values.Courier);

    public FieldFont(string value)
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
    public static FieldFont FromCustom(string value)
    {
        return new FieldFont(value);
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

    public static bool operator ==(FieldFont value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(FieldFont value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(FieldFont value) => value.Value;

    public static explicit operator FieldFont(string value) => new(value);

    internal class FieldFontSerializer : JsonConverter<FieldFont>
    {
        public override FieldFont Read(
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
            return new FieldFont(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FieldFont value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FieldFont ReadAsPropertyName(
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
            return new FieldFont(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FieldFont value,
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
        public const string Times = "Times";

        public const string Helvetica = "Helvetica";

        public const string Courier = "Courier";
    }
}
