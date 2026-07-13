using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(SubmissionCreateResultSource.SubmissionCreateResultSourceSerializer))]
[Serializable]
public readonly record struct SubmissionCreateResultSource : IStringEnum
{
    public static readonly SubmissionCreateResultSource Invite = new(Values.Invite);

    public static readonly SubmissionCreateResultSource Bulk = new(Values.Bulk);

    public static readonly SubmissionCreateResultSource Api = new(Values.Api);

    public static readonly SubmissionCreateResultSource Embed = new(Values.Embed);

    public static readonly SubmissionCreateResultSource Link = new(Values.Link);

    public SubmissionCreateResultSource(string value)
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
    public static SubmissionCreateResultSource FromCustom(string value)
    {
        return new SubmissionCreateResultSource(value);
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

    public static bool operator ==(SubmissionCreateResultSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubmissionCreateResultSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubmissionCreateResultSource value) => value.Value;

    public static explicit operator SubmissionCreateResultSource(string value) => new(value);

    internal class SubmissionCreateResultSourceSerializer
        : JsonConverter<SubmissionCreateResultSource>
    {
        public override SubmissionCreateResultSource Read(
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
            return new SubmissionCreateResultSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubmissionCreateResultSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubmissionCreateResultSource ReadAsPropertyName(
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
            return new SubmissionCreateResultSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubmissionCreateResultSource value,
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
