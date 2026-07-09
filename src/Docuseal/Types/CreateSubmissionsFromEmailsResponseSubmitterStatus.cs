using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateSubmissionsFromEmailsResponseSubmitterStatus.CreateSubmissionsFromEmailsResponseSubmitterStatusSerializer)
)]
[Serializable]
public readonly record struct CreateSubmissionsFromEmailsResponseSubmitterStatus : IStringEnum
{
    public static readonly CreateSubmissionsFromEmailsResponseSubmitterStatus Completed = new(
        Values.Completed
    );

    public static readonly CreateSubmissionsFromEmailsResponseSubmitterStatus Declined = new(
        Values.Declined
    );

    public static readonly CreateSubmissionsFromEmailsResponseSubmitterStatus Opened = new(
        Values.Opened
    );

    public static readonly CreateSubmissionsFromEmailsResponseSubmitterStatus Sent = new(
        Values.Sent
    );

    public static readonly CreateSubmissionsFromEmailsResponseSubmitterStatus Awaiting = new(
        Values.Awaiting
    );

    public CreateSubmissionsFromEmailsResponseSubmitterStatus(string value)
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
    public static CreateSubmissionsFromEmailsResponseSubmitterStatus FromCustom(string value)
    {
        return new CreateSubmissionsFromEmailsResponseSubmitterStatus(value);
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
        CreateSubmissionsFromEmailsResponseSubmitterStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateSubmissionsFromEmailsResponseSubmitterStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateSubmissionsFromEmailsResponseSubmitterStatus value
    ) => value.Value;

    public static explicit operator CreateSubmissionsFromEmailsResponseSubmitterStatus(
        string value
    ) => new(value);

    internal class CreateSubmissionsFromEmailsResponseSubmitterStatusSerializer
        : JsonConverter<CreateSubmissionsFromEmailsResponseSubmitterStatus>
    {
        public override CreateSubmissionsFromEmailsResponseSubmitterStatus Read(
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
            return new CreateSubmissionsFromEmailsResponseSubmitterStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateSubmissionsFromEmailsResponseSubmitterStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateSubmissionsFromEmailsResponseSubmitterStatus ReadAsPropertyName(
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
            return new CreateSubmissionsFromEmailsResponseSubmitterStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateSubmissionsFromEmailsResponseSubmitterStatus value,
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
