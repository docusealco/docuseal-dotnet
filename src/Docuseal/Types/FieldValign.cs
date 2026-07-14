using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(FieldValign.FieldValignSerializer))]
[Serializable]
public readonly record struct FieldValign : IStringEnum
{
    public static readonly FieldValign Top = new(Values.Top);

    public static readonly FieldValign Center = new(Values.Center);

    public static readonly FieldValign Bottom = new(Values.Bottom);

    public FieldValign(string value)
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
    public static FieldValign FromCustom(string value)
    {
        return new FieldValign(value);
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

    public static bool operator ==(FieldValign value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FieldValign value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FieldValign value) => value.Value;

    public static explicit operator FieldValign(string value) => new(value);

    internal class FieldValignSerializer : JsonConverter<FieldValign>
    {
        public override FieldValign Read(
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
            return new FieldValign(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FieldValign value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FieldValign ReadAsPropertyName(
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
            return new FieldValign(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FieldValign value,
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
        public const string Top = "top";

        public const string Center = "center";

        public const string Bottom = "bottom";
    }
}
