using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(FieldAlign.FieldAlignSerializer))]
[Serializable]
public readonly record struct FieldAlign : IStringEnum
{
    public static readonly FieldAlign Left = new(Values.Left);

    public static readonly FieldAlign Center = new(Values.Center);

    public static readonly FieldAlign Right = new(Values.Right);

    public FieldAlign(string value)
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
    public static FieldAlign FromCustom(string value)
    {
        return new FieldAlign(value);
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

    public static bool operator ==(FieldAlign value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(FieldAlign value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FieldAlign value) => value.Value;

    public static explicit operator FieldAlign(string value) => new(value);

    internal class FieldAlignSerializer : JsonConverter<FieldAlign>
    {
        public override FieldAlign Read(
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
            return new FieldAlign(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FieldAlign value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FieldAlign ReadAsPropertyName(
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
            return new FieldAlign(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FieldAlign value,
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
