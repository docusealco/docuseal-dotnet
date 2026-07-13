using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(SubmissionUpdateResultSource.SubmissionUpdateResultSourceSerializer))]
[Serializable]
public readonly record struct SubmissionUpdateResultSource : IStringEnum
{
    public static readonly SubmissionUpdateResultSource Invite = new(Values.Invite);

    public static readonly SubmissionUpdateResultSource Bulk = new(Values.Bulk);

    public static readonly SubmissionUpdateResultSource Api = new(Values.Api);

    public static readonly SubmissionUpdateResultSource Embed = new(Values.Embed);

    public static readonly SubmissionUpdateResultSource Link = new(Values.Link);

    public SubmissionUpdateResultSource(string value)
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
    public static SubmissionUpdateResultSource FromCustom(string value)
    {
        return new SubmissionUpdateResultSource(value);
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

    public static bool operator ==(SubmissionUpdateResultSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubmissionUpdateResultSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubmissionUpdateResultSource value) => value.Value;

    public static explicit operator SubmissionUpdateResultSource(string value) => new(value);

    internal class SubmissionUpdateResultSourceSerializer
        : JsonConverter<SubmissionUpdateResultSource>
    {
        public override SubmissionUpdateResultSource Read(
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
            return new SubmissionUpdateResultSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubmissionUpdateResultSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubmissionUpdateResultSource ReadAsPropertyName(
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
            return new SubmissionUpdateResultSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubmissionUpdateResultSource value,
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
