using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(GetSubmittersResponseDataItemStatus.GetSubmittersResponseDataItemStatusSerializer)
)]
[Serializable]
public readonly record struct GetSubmittersResponseDataItemStatus : IStringEnum
{
    public static readonly GetSubmittersResponseDataItemStatus Completed = new(Values.Completed);

    public static readonly GetSubmittersResponseDataItemStatus Declined = new(Values.Declined);

    public static readonly GetSubmittersResponseDataItemStatus Opened = new(Values.Opened);

    public static readonly GetSubmittersResponseDataItemStatus Sent = new(Values.Sent);

    public static readonly GetSubmittersResponseDataItemStatus Awaiting = new(Values.Awaiting);

    public GetSubmittersResponseDataItemStatus(string value)
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
    public static GetSubmittersResponseDataItemStatus FromCustom(string value)
    {
        return new GetSubmittersResponseDataItemStatus(value);
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

    public static bool operator ==(GetSubmittersResponseDataItemStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetSubmittersResponseDataItemStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetSubmittersResponseDataItemStatus value) =>
        value.Value;

    public static explicit operator GetSubmittersResponseDataItemStatus(string value) => new(value);

    internal class GetSubmittersResponseDataItemStatusSerializer
        : JsonConverter<GetSubmittersResponseDataItemStatus>
    {
        public override GetSubmittersResponseDataItemStatus Read(
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
            return new GetSubmittersResponseDataItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetSubmittersResponseDataItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetSubmittersResponseDataItemStatus ReadAsPropertyName(
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
            return new GetSubmittersResponseDataItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetSubmittersResponseDataItemStatus value,
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
