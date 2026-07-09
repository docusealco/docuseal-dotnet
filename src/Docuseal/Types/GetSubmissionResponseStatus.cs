using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(GetSubmissionResponseStatus.GetSubmissionResponseStatusSerializer))]
[Serializable]
public readonly record struct GetSubmissionResponseStatus : IStringEnum
{
    public static readonly GetSubmissionResponseStatus Completed = new(Values.Completed);

    public static readonly GetSubmissionResponseStatus Declined = new(Values.Declined);

    public static readonly GetSubmissionResponseStatus Expired = new(Values.Expired);

    public static readonly GetSubmissionResponseStatus Pending = new(Values.Pending);

    public GetSubmissionResponseStatus(string value)
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
    public static GetSubmissionResponseStatus FromCustom(string value)
    {
        return new GetSubmissionResponseStatus(value);
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

    public static bool operator ==(GetSubmissionResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetSubmissionResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetSubmissionResponseStatus value) => value.Value;

    public static explicit operator GetSubmissionResponseStatus(string value) => new(value);

    internal class GetSubmissionResponseStatusSerializer
        : JsonConverter<GetSubmissionResponseStatus>
    {
        public override GetSubmissionResponseStatus Read(
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
            return new GetSubmissionResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetSubmissionResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetSubmissionResponseStatus ReadAsPropertyName(
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
            return new GetSubmissionResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetSubmissionResponseStatus value,
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
