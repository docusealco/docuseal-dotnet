using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(UpdateSubmissionResponseStatus.UpdateSubmissionResponseStatusSerializer))]
[Serializable]
public readonly record struct UpdateSubmissionResponseStatus : IStringEnum
{
    public static readonly UpdateSubmissionResponseStatus Completed = new(Values.Completed);

    public static readonly UpdateSubmissionResponseStatus Declined = new(Values.Declined);

    public static readonly UpdateSubmissionResponseStatus Expired = new(Values.Expired);

    public static readonly UpdateSubmissionResponseStatus Pending = new(Values.Pending);

    public UpdateSubmissionResponseStatus(string value)
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
    public static UpdateSubmissionResponseStatus FromCustom(string value)
    {
        return new UpdateSubmissionResponseStatus(value);
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

    public static bool operator ==(UpdateSubmissionResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateSubmissionResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateSubmissionResponseStatus value) => value.Value;

    public static explicit operator UpdateSubmissionResponseStatus(string value) => new(value);

    internal class UpdateSubmissionResponseStatusSerializer
        : JsonConverter<UpdateSubmissionResponseStatus>
    {
        public override UpdateSubmissionResponseStatus Read(
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
            return new UpdateSubmissionResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateSubmissionResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateSubmissionResponseStatus ReadAsPropertyName(
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
            return new UpdateSubmissionResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateSubmissionResponseStatus value,
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
