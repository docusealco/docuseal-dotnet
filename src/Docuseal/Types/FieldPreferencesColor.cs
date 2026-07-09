using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(FieldPreferencesColor.FieldPreferencesColorSerializer))]
[Serializable]
public readonly record struct FieldPreferencesColor : IStringEnum
{
    public static readonly FieldPreferencesColor Black = new(Values.Black);

    public static readonly FieldPreferencesColor White = new(Values.White);

    public static readonly FieldPreferencesColor Blue = new(Values.Blue);

    public FieldPreferencesColor(string value)
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
    public static FieldPreferencesColor FromCustom(string value)
    {
        return new FieldPreferencesColor(value);
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

    public static bool operator ==(FieldPreferencesColor value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FieldPreferencesColor value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FieldPreferencesColor value) => value.Value;

    public static explicit operator FieldPreferencesColor(string value) => new(value);

    internal class FieldPreferencesColorSerializer : JsonConverter<FieldPreferencesColor>
    {
        public override FieldPreferencesColor Read(
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
            return new FieldPreferencesColor(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FieldPreferencesColor value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FieldPreferencesColor ReadAsPropertyName(
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
            return new FieldPreferencesColor(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FieldPreferencesColor value,
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
        public const string Black = "black";

        public const string White = "white";

        public const string Blue = "blue";
    }
}
