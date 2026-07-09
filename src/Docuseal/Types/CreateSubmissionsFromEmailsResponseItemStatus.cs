using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateSubmissionsFromEmailsResponseItemStatus.CreateSubmissionsFromEmailsResponseItemStatusSerializer)
)]
[Serializable]
public readonly record struct CreateSubmissionsFromEmailsResponseItemStatus : IStringEnum
{
    public static readonly CreateSubmissionsFromEmailsResponseItemStatus Completed = new(
        Values.Completed
    );

    public static readonly CreateSubmissionsFromEmailsResponseItemStatus Declined = new(
        Values.Declined
    );

    public static readonly CreateSubmissionsFromEmailsResponseItemStatus Opened = new(
        Values.Opened
    );

    public static readonly CreateSubmissionsFromEmailsResponseItemStatus Sent = new(Values.Sent);

    public static readonly CreateSubmissionsFromEmailsResponseItemStatus Awaiting = new(
        Values.Awaiting
    );

    public CreateSubmissionsFromEmailsResponseItemStatus(string value)
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
    public static CreateSubmissionsFromEmailsResponseItemStatus FromCustom(string value)
    {
        return new CreateSubmissionsFromEmailsResponseItemStatus(value);
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
        CreateSubmissionsFromEmailsResponseItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateSubmissionsFromEmailsResponseItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateSubmissionsFromEmailsResponseItemStatus value) =>
        value.Value;

    public static explicit operator CreateSubmissionsFromEmailsResponseItemStatus(string value) =>
        new(value);

    internal class CreateSubmissionsFromEmailsResponseItemStatusSerializer
        : JsonConverter<CreateSubmissionsFromEmailsResponseItemStatus>
    {
        public override CreateSubmissionsFromEmailsResponseItemStatus Read(
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
            return new CreateSubmissionsFromEmailsResponseItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateSubmissionsFromEmailsResponseItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateSubmissionsFromEmailsResponseItemStatus ReadAsPropertyName(
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
            return new CreateSubmissionsFromEmailsResponseItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateSubmissionsFromEmailsResponseItemStatus value,
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
