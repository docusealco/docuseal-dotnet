using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(GetSubmissionsResponseDataItemSource.GetSubmissionsResponseDataItemSourceSerializer)
)]
[Serializable]
public readonly record struct GetSubmissionsResponseDataItemSource : IStringEnum
{
    public static readonly GetSubmissionsResponseDataItemSource Invite = new(Values.Invite);

    public static readonly GetSubmissionsResponseDataItemSource Bulk = new(Values.Bulk);

    public static readonly GetSubmissionsResponseDataItemSource Api = new(Values.Api);

    public static readonly GetSubmissionsResponseDataItemSource Embed = new(Values.Embed);

    public static readonly GetSubmissionsResponseDataItemSource Link = new(Values.Link);

    public GetSubmissionsResponseDataItemSource(string value)
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
    public static GetSubmissionsResponseDataItemSource FromCustom(string value)
    {
        return new GetSubmissionsResponseDataItemSource(value);
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

    public static bool operator ==(GetSubmissionsResponseDataItemSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetSubmissionsResponseDataItemSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetSubmissionsResponseDataItemSource value) =>
        value.Value;

    public static explicit operator GetSubmissionsResponseDataItemSource(string value) =>
        new(value);

    internal class GetSubmissionsResponseDataItemSourceSerializer
        : JsonConverter<GetSubmissionsResponseDataItemSource>
    {
        public override GetSubmissionsResponseDataItemSource Read(
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
            return new GetSubmissionsResponseDataItemSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetSubmissionsResponseDataItemSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetSubmissionsResponseDataItemSource ReadAsPropertyName(
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
            return new GetSubmissionsResponseDataItemSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetSubmissionsResponseDataItemSource value,
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
        public const string Invite = "invite";

        public const string Bulk = "bulk";

        public const string Api = "api";

        public const string Embed = "embed";

        public const string Link = "link";
    }
}
