using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(FieldPreferencesAlign.FieldPreferencesAlignSerializer))]
[Serializable]
public readonly record struct FieldPreferencesAlign : IStringEnum
{
    public static readonly FieldPreferencesAlign Left = new(Values.Left);

    public static readonly FieldPreferencesAlign Center = new(Values.Center);

    public static readonly FieldPreferencesAlign Right = new(Values.Right);

    public FieldPreferencesAlign(string value)
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
    public static FieldPreferencesAlign FromCustom(string value)
    {
        return new FieldPreferencesAlign(value);
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

    public static bool operator ==(FieldPreferencesAlign value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FieldPreferencesAlign value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FieldPreferencesAlign value) => value.Value;

    public static explicit operator FieldPreferencesAlign(string value) => new(value);

    internal class FieldPreferencesAlignSerializer : JsonConverter<FieldPreferencesAlign>
    {
        public override FieldPreferencesAlign Read(
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
            return new FieldPreferencesAlign(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FieldPreferencesAlign value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FieldPreferencesAlign ReadAsPropertyName(
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
            return new FieldPreferencesAlign(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FieldPreferencesAlign value,
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
        public const string Left = "left";

        public const string Center = "center";

        public const string Right = "right";
    }
}
