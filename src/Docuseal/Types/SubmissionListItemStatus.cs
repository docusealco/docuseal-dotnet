using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(SubmissionListItemStatus.SubmissionListItemStatusSerializer))]
[Serializable]
public readonly record struct SubmissionListItemStatus : IStringEnum
{
    public static readonly SubmissionListItemStatus Completed = new(Values.Completed);

    public static readonly SubmissionListItemStatus Declined = new(Values.Declined);

    public static readonly SubmissionListItemStatus Expired = new(Values.Expired);

    public static readonly SubmissionListItemStatus Pending = new(Values.Pending);

    public SubmissionListItemStatus(string value)
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
    public static SubmissionListItemStatus FromCustom(string value)
    {
        return new SubmissionListItemStatus(value);
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

    public static bool operator ==(SubmissionListItemStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubmissionListItemStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubmissionListItemStatus value) => value.Value;

    public static explicit operator SubmissionListItemStatus(string value) => new(value);

    internal class SubmissionListItemStatusSerializer : JsonConverter<SubmissionListItemStatus>
    {
        public override SubmissionListItemStatus Read(
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
            return new SubmissionListItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubmissionListItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubmissionListItemStatus ReadAsPropertyName(
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
            return new SubmissionListItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubmissionListItemStatus value,
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
