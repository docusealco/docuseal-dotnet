using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(SubmissionSubmitterStatus.SubmissionSubmitterStatusSerializer))]
[Serializable]
public readonly record struct SubmissionSubmitterStatus : IStringEnum
{
    public static readonly SubmissionSubmitterStatus Completed = new(Values.Completed);

    public static readonly SubmissionSubmitterStatus Declined = new(Values.Declined);

    public static readonly SubmissionSubmitterStatus Opened = new(Values.Opened);

    public static readonly SubmissionSubmitterStatus Sent = new(Values.Sent);

    public static readonly SubmissionSubmitterStatus Awaiting = new(Values.Awaiting);

    public SubmissionSubmitterStatus(string value)
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
    public static SubmissionSubmitterStatus FromCustom(string value)
    {
        return new SubmissionSubmitterStatus(value);
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

    public static bool operator ==(SubmissionSubmitterStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubmissionSubmitterStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubmissionSubmitterStatus value) => value.Value;

    public static explicit operator SubmissionSubmitterStatus(string value) => new(value);

    internal class SubmissionSubmitterStatusSerializer : JsonConverter<SubmissionSubmitterStatus>
    {
        public override SubmissionSubmitterStatus Read(
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
            return new SubmissionSubmitterStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubmissionSubmitterStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubmissionSubmitterStatus ReadAsPropertyName(
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
            return new SubmissionSubmitterStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubmissionSubmitterStatus value,
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
        public const string Completed = "completed";

        public const string Declined = "declined";

        public const string Opened = "opened";

        public const string Sent = "sent";

        public const string Awaiting = "awaiting";
    }
}
