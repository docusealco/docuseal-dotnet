using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateSubmissionFromPdfResponseStatus.CreateSubmissionFromPdfResponseStatusSerializer)
)]
[Serializable]
public readonly record struct CreateSubmissionFromPdfResponseStatus : IStringEnum
{
    public static readonly CreateSubmissionFromPdfResponseStatus Completed = new(Values.Completed);

    public static readonly CreateSubmissionFromPdfResponseStatus Declined = new(Values.Declined);

    public static readonly CreateSubmissionFromPdfResponseStatus Expired = new(Values.Expired);

    public static readonly CreateSubmissionFromPdfResponseStatus Pending = new(Values.Pending);

    public CreateSubmissionFromPdfResponseStatus(string value)
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
    public static CreateSubmissionFromPdfResponseStatus FromCustom(string value)
    {
        return new CreateSubmissionFromPdfResponseStatus(value);
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

    public static bool operator ==(CreateSubmissionFromPdfResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateSubmissionFromPdfResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateSubmissionFromPdfResponseStatus value) =>
        value.Value;

    public static explicit operator CreateSubmissionFromPdfResponseStatus(string value) =>
        new(value);

    internal class CreateSubmissionFromPdfResponseStatusSerializer
        : JsonConverter<CreateSubmissionFromPdfResponseStatus>
    {
        public override CreateSubmissionFromPdfResponseStatus Read(
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
            return new CreateSubmissionFromPdfResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateSubmissionFromPdfResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateSubmissionFromPdfResponseStatus ReadAsPropertyName(
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
            return new CreateSubmissionFromPdfResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateSubmissionFromPdfResponseStatus value,
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
