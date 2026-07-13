using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(SubmissionListItemSource.SubmissionListItemSourceSerializer))]
[Serializable]
public readonly record struct SubmissionListItemSource : IStringEnum
{
    public static readonly SubmissionListItemSource Invite = new(Values.Invite);

    public static readonly SubmissionListItemSource Bulk = new(Values.Bulk);

    public static readonly SubmissionListItemSource Api = new(Values.Api);

    public static readonly SubmissionListItemSource Embed = new(Values.Embed);

    public static readonly SubmissionListItemSource Link = new(Values.Link);

    public SubmissionListItemSource(string value)
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
    public static SubmissionListItemSource FromCustom(string value)
    {
        return new SubmissionListItemSource(value);
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

    public static bool operator ==(SubmissionListItemSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubmissionListItemSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubmissionListItemSource value) => value.Value;

    public static explicit operator SubmissionListItemSource(string value) => new(value);

    internal class SubmissionListItemSourceSerializer : JsonConverter<SubmissionListItemSource>
    {
        public override SubmissionListItemSource Read(
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
            return new SubmissionListItemSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubmissionListItemSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubmissionListItemSource ReadAsPropertyName(
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
            return new SubmissionListItemSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubmissionListItemSource value,
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
