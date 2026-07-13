using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(SubmissionUpdateResultStatus.SubmissionUpdateResultStatusSerializer))]
[Serializable]
public readonly record struct SubmissionUpdateResultStatus : IStringEnum
{
    public static readonly SubmissionUpdateResultStatus Completed = new(Values.Completed);

    public static readonly SubmissionUpdateResultStatus Declined = new(Values.Declined);

    public static readonly SubmissionUpdateResultStatus Expired = new(Values.Expired);

    public static readonly SubmissionUpdateResultStatus Pending = new(Values.Pending);

    public SubmissionUpdateResultStatus(string value)
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
    public static SubmissionUpdateResultStatus FromCustom(string value)
    {
        return new SubmissionUpdateResultStatus(value);
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

    public static bool operator ==(SubmissionUpdateResultStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubmissionUpdateResultStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubmissionUpdateResultStatus value) => value.Value;

    public static explicit operator SubmissionUpdateResultStatus(string value) => new(value);

    internal class SubmissionUpdateResultStatusSerializer
        : JsonConverter<SubmissionUpdateResultStatus>
    {
        public override SubmissionUpdateResultStatus Read(
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
            return new SubmissionUpdateResultStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubmissionUpdateResultStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubmissionUpdateResultStatus ReadAsPropertyName(
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
            return new SubmissionUpdateResultStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubmissionUpdateResultStatus value,
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

        public const string Expired = "expired";

        public const string Pending = "pending";
    }
}
