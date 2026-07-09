using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(GetSubmissionResponseSubmitterStatus.GetSubmissionResponseSubmitterStatusSerializer)
)]
[Serializable]
public readonly record struct GetSubmissionResponseSubmitterStatus : IStringEnum
{
    public static readonly GetSubmissionResponseSubmitterStatus Completed = new(Values.Completed);

    public static readonly GetSubmissionResponseSubmitterStatus Declined = new(Values.Declined);

    public static readonly GetSubmissionResponseSubmitterStatus Opened = new(Values.Opened);

    public static readonly GetSubmissionResponseSubmitterStatus Sent = new(Values.Sent);

    public static readonly GetSubmissionResponseSubmitterStatus Awaiting = new(Values.Awaiting);

    public GetSubmissionResponseSubmitterStatus(string value)
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
    public static GetSubmissionResponseSubmitterStatus FromCustom(string value)
    {
        return new GetSubmissionResponseSubmitterStatus(value);
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

    public static bool operator ==(GetSubmissionResponseSubmitterStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetSubmissionResponseSubmitterStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetSubmissionResponseSubmitterStatus value) =>
        value.Value;

    public static explicit operator GetSubmissionResponseSubmitterStatus(string value) =>
        new(value);

    internal class GetSubmissionResponseSubmitterStatusSerializer
        : JsonConverter<GetSubmissionResponseSubmitterStatus>
    {
        public override GetSubmissionResponseSubmitterStatus Read(
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
            return new GetSubmissionResponseSubmitterStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetSubmissionResponseSubmitterStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetSubmissionResponseSubmitterStatus ReadAsPropertyName(
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
            return new GetSubmissionResponseSubmitterStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetSubmissionResponseSubmitterStatus value,
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
