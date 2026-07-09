using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(GetSubmissionsResponseSubmissionSource.GetSubmissionsResponseSubmissionSourceSerializer)
)]
[Serializable]
public readonly record struct GetSubmissionsResponseSubmissionSource : IStringEnum
{
    public static readonly GetSubmissionsResponseSubmissionSource Invite = new(Values.Invite);

    public static readonly GetSubmissionsResponseSubmissionSource Bulk = new(Values.Bulk);

    public static readonly GetSubmissionsResponseSubmissionSource Api = new(Values.Api);

    public static readonly GetSubmissionsResponseSubmissionSource Embed = new(Values.Embed);

    public static readonly GetSubmissionsResponseSubmissionSource Link = new(Values.Link);

    public GetSubmissionsResponseSubmissionSource(string value)
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
    public static GetSubmissionsResponseSubmissionSource FromCustom(string value)
    {
        return new GetSubmissionsResponseSubmissionSource(value);
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

    public static bool operator ==(GetSubmissionsResponseSubmissionSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetSubmissionsResponseSubmissionSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetSubmissionsResponseSubmissionSource value) =>
        value.Value;

    public static explicit operator GetSubmissionsResponseSubmissionSource(string value) =>
        new(value);

    internal class GetSubmissionsResponseSubmissionSourceSerializer
        : JsonConverter<GetSubmissionsResponseSubmissionSource>
    {
        public override GetSubmissionsResponseSubmissionSource Read(
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
            return new GetSubmissionsResponseSubmissionSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetSubmissionsResponseSubmissionSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetSubmissionsResponseSubmissionSource ReadAsPropertyName(
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
            return new GetSubmissionsResponseSubmissionSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetSubmissionsResponseSubmissionSource value,
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
