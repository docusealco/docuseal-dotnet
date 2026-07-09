using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(FieldPreferencesBackground.FieldPreferencesBackgroundSerializer))]
[Serializable]
public readonly record struct FieldPreferencesBackground : IStringEnum
{
    public static readonly FieldPreferencesBackground Black = new(Values.Black);

    public static readonly FieldPreferencesBackground White = new(Values.White);

    public static readonly FieldPreferencesBackground Blue = new(Values.Blue);

    public FieldPreferencesBackground(string value)
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
    public static FieldPreferencesBackground FromCustom(string value)
    {
        return new FieldPreferencesBackground(value);
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

    public static bool operator ==(FieldPreferencesBackground value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FieldPreferencesBackground value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FieldPreferencesBackground value) => value.Value;

    public static explicit operator FieldPreferencesBackground(string value) => new(value);

    internal class FieldPreferencesBackgroundSerializer : JsonConverter<FieldPreferencesBackground>
    {
        public override FieldPreferencesBackground Read(
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
            return new FieldPreferencesBackground(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FieldPreferencesBackground value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FieldPreferencesBackground ReadAsPropertyName(
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
            return new FieldPreferencesBackground(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FieldPreferencesBackground value,
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
