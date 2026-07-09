using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(GetTemplatesResponseDataItemSource.GetTemplatesResponseDataItemSourceSerializer)
)]
[Serializable]
public readonly record struct GetTemplatesResponseDataItemSource : IStringEnum
{
    public static readonly GetTemplatesResponseDataItemSource Native = new(Values.Native);

    public static readonly GetTemplatesResponseDataItemSource Api = new(Values.Api);

    public static readonly GetTemplatesResponseDataItemSource Embed = new(Values.Embed);

    public GetTemplatesResponseDataItemSource(string value)
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
    public static GetTemplatesResponseDataItemSource FromCustom(string value)
    {
        return new GetTemplatesResponseDataItemSource(value);
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

    public static bool operator ==(GetTemplatesResponseDataItemSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetTemplatesResponseDataItemSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetTemplatesResponseDataItemSource value) => value.Value;

    public static explicit operator GetTemplatesResponseDataItemSource(string value) => new(value);

    internal class GetTemplatesResponseDataItemSourceSerializer
        : JsonConverter<GetTemplatesResponseDataItemSource>
    {
        public override GetTemplatesResponseDataItemSource Read(
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
            return new GetTemplatesResponseDataItemSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetTemplatesResponseDataItemSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetTemplatesResponseDataItemSource ReadAsPropertyName(
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
            return new GetTemplatesResponseDataItemSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetTemplatesResponseDataItemSource value,
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
        public const string Native = "native";

        public const string Api = "api";

        public const string Embed = "embed";
    }
}
