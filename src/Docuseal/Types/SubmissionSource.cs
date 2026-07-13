using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(SubmissionSource.SubmissionSourceSerializer))]
[Serializable]
public readonly record struct SubmissionSource : IStringEnum
{
    public static readonly SubmissionSource Invite = new(Values.Invite);

    public static readonly SubmissionSource Bulk = new(Values.Bulk);

    public static readonly SubmissionSource Api = new(Values.Api);

    public static readonly SubmissionSource Embed = new(Values.Embed);

    public static readonly SubmissionSource Link = new(Values.Link);

    public SubmissionSource(string value)
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
    public static SubmissionSource FromCustom(string value)
    {
        return new SubmissionSource(value);
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

    public static bool operator ==(SubmissionSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubmissionSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubmissionSource value) => value.Value;

    public static explicit operator SubmissionSource(string value) => new(value);

    internal class SubmissionSourceSerializer : JsonConverter<SubmissionSource>
    {
        public override SubmissionSource Read(
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
            return new SubmissionSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubmissionSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubmissionSource ReadAsPropertyName(
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
            return new SubmissionSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubmissionSource value,
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
