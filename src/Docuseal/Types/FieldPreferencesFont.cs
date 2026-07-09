using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(FieldPreferencesFont.FieldPreferencesFontSerializer))]
[Serializable]
public readonly record struct FieldPreferencesFont : IStringEnum
{
    public static readonly FieldPreferencesFont Times = new(Values.Times);

    public static readonly FieldPreferencesFont Helvetica = new(Values.Helvetica);

    public static readonly FieldPreferencesFont Courier = new(Values.Courier);

    public FieldPreferencesFont(string value)
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
    public static FieldPreferencesFont FromCustom(string value)
    {
        return new FieldPreferencesFont(value);
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

    public static bool operator ==(FieldPreferencesFont value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FieldPreferencesFont value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FieldPreferencesFont value) => value.Value;

    public static explicit operator FieldPreferencesFont(string value) => new(value);

    internal class FieldPreferencesFontSerializer : JsonConverter<FieldPreferencesFont>
    {
        public override FieldPreferencesFont Read(
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
            return new FieldPreferencesFont(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FieldPreferencesFont value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FieldPreferencesFont ReadAsPropertyName(
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
            return new FieldPreferencesFont(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FieldPreferencesFont value,
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
