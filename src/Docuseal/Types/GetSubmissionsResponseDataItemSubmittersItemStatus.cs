using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(GetSubmissionsResponseDataItemSubmittersItemStatus.GetSubmissionsResponseDataItemSubmittersItemStatusSerializer)
)]
[Serializable]
public readonly record struct GetSubmissionsResponseDataItemSubmittersItemStatus : IStringEnum
{
    public static readonly GetSubmissionsResponseDataItemSubmittersItemStatus Completed = new(
        Values.Completed
    );

    public static readonly GetSubmissionsResponseDataItemSubmittersItemStatus Declined = new(
        Values.Declined
    );

    public static readonly GetSubmissionsResponseDataItemSubmittersItemStatus Opened = new(
        Values.Opened
    );

    public static readonly GetSubmissionsResponseDataItemSubmittersItemStatus Sent = new(
        Values.Sent
    );

    public static readonly GetSubmissionsResponseDataItemSubmittersItemStatus Awaiting = new(
        Values.Awaiting
    );

    public GetSubmissionsResponseDataItemSubmittersItemStatus(string value)
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
    public static GetSubmissionsResponseDataItemSubmittersItemStatus FromCustom(string value)
    {
        return new GetSubmissionsResponseDataItemSubmittersItemStatus(value);
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
        GetSubmissionsResponseDataItemSubmittersItemStatus value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetSubmissionsResponseDataItemSubmittersItemStatus value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        GetSubmissionsResponseDataItemSubmittersItemStatus value
    ) => value.Value;

    public static explicit operator GetSubmissionsResponseDataItemSubmittersItemStatus(
        string value
    ) => new(value);

    internal class GetSubmissionsResponseDataItemSubmittersItemStatusSerializer
        : JsonConverter<GetSubmissionsResponseDataItemSubmittersItemStatus>
    {
        public override GetSubmissionsResponseDataItemSubmittersItemStatus Read(
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
            return new GetSubmissionsResponseDataItemSubmittersItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetSubmissionsResponseDataItemSubmittersItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetSubmissionsResponseDataItemSubmittersItemStatus ReadAsPropertyName(
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
            return new GetSubmissionsResponseDataItemSubmittersItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetSubmissionsResponseDataItemSubmittersItemStatus value,
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
