using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateSubmissionFromPdfResponseSource.CreateSubmissionFromPdfResponseSourceSerializer)
)]
[Serializable]
public readonly record struct CreateSubmissionFromPdfResponseSource : IStringEnum
{
    public static readonly CreateSubmissionFromPdfResponseSource Invite = new(Values.Invite);

    public static readonly CreateSubmissionFromPdfResponseSource Bulk = new(Values.Bulk);

    public static readonly CreateSubmissionFromPdfResponseSource Api = new(Values.Api);

    public static readonly CreateSubmissionFromPdfResponseSource Embed = new(Values.Embed);

    public static readonly CreateSubmissionFromPdfResponseSource Link = new(Values.Link);

    public CreateSubmissionFromPdfResponseSource(string value)
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
    public static CreateSubmissionFromPdfResponseSource FromCustom(string value)
    {
        return new CreateSubmissionFromPdfResponseSource(value);
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

    public static bool operator ==(CreateSubmissionFromPdfResponseSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateSubmissionFromPdfResponseSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateSubmissionFromPdfResponseSource value) =>
        value.Value;

    public static explicit operator CreateSubmissionFromPdfResponseSource(string value) =>
        new(value);

    internal class CreateSubmissionFromPdfResponseSourceSerializer
        : JsonConverter<CreateSubmissionFromPdfResponseSource>
    {
        public override CreateSubmissionFromPdfResponseSource Read(
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
            return new CreateSubmissionFromPdfResponseSource(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateSubmissionFromPdfResponseSource value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateSubmissionFromPdfResponseSource ReadAsPropertyName(
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
            return new CreateSubmissionFromPdfResponseSource(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateSubmissionFromPdfResponseSource value,
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
