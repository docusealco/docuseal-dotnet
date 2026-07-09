using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(FieldPreferencesValign.FieldPreferencesValignSerializer))]
[Serializable]
public readonly record struct FieldPreferencesValign : IStringEnum
{
    public static readonly FieldPreferencesValign Top = new(Values.Top);

    public static readonly FieldPreferencesValign Center = new(Values.Center);

    public static readonly FieldPreferencesValign Bottom = new(Values.Bottom);

    public FieldPreferencesValign(string value)
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
    public static FieldPreferencesValign FromCustom(string value)
    {
        return new FieldPreferencesValign(value);
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

    public static bool operator ==(FieldPreferencesValign value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FieldPreferencesValign value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FieldPreferencesValign value) => value.Value;

    public static explicit operator FieldPreferencesValign(string value) => new(value);

    internal class FieldPreferencesValignSerializer : JsonConverter<FieldPreferencesValign>
    {
        public override FieldPreferencesValign Read(
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
            return new FieldPreferencesValign(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FieldPreferencesValign value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FieldPreferencesValign ReadAsPropertyName(
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
            return new FieldPreferencesValign(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FieldPreferencesValign value,
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
