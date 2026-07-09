using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateSubmissionFromPdfResponseSubmittersItemStatus.CreateSubmissionFromPdfResponseSubmittersItemStatusSerializer)
)]
[Serializable]
public readonly record struct CreateSubmissionFromPdfResponseSubmittersItemStatus : IStringEnum
{
    public static readonly CreateSubmissionFromPdfResponseSubmittersItemStatus Completed = new(
        Values.Completed
    );

    public static readonly CreateSubmissionFromPdfResponseSubmittersItemStatus Declined = new(
        Values.Declined
    );

    public static readonly CreateSubmissionFromPdfResponseSubmittersItemStatus Opened = new(
        Values.Opened
    );

    public static readonly CreateSubmissionFromPdfResponseSubmittersItemStatus Sent = new(
        Values.Sent
    );

    public static readonly CreateSubmissionFromPdfResponseSubmittersItemStatus Awaiting = new(
        Values.Awaiting
    );

    public CreateSubmissionFromPdfResponseSubmittersItemStatus(string value)
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
    public static CreateSubmissionFromPdfResponseSubmittersItemStatus FromCustom(string value)
    {
        return new CreateSubmissionFromPdfResponseSubmittersItemStatus(value);
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

    public static bool operator ==(
        CreateSubmissionFromPdfResponseSubmittersItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateSubmissionFromPdfResponseSubmittersItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateSubmissionFromPdfResponseSubmittersItemStatus value
    ) => value.Value;

    public static explicit operator CreateSubmissionFromPdfResponseSubmittersItemStatus(
        string value
    ) => new(value);

    internal class CreateSubmissionFromPdfResponseSubmittersItemStatusSerializer
        : JsonConverter<CreateSubmissionFromPdfResponseSubmittersItemStatus>
    {
        public override CreateSubmissionFromPdfResponseSubmittersItemStatus Read(
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
            return new CreateSubmissionFromPdfResponseSubmittersItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateSubmissionFromPdfResponseSubmittersItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateSubmissionFromPdfResponseSubmittersItemStatus ReadAsPropertyName(
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
            return new CreateSubmissionFromPdfResponseSubmittersItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateSubmissionFromPdfResponseSubmittersItemStatus value,
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
