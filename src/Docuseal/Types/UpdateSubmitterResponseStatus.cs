using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(UpdateSubmitterResponseStatus.UpdateSubmitterResponseStatusSerializer))]
[Serializable]
public readonly record struct UpdateSubmitterResponseStatus : IStringEnum
{
    public static readonly UpdateSubmitterResponseStatus Completed = new(Values.Completed);

    public static readonly UpdateSubmitterResponseStatus Declined = new(Values.Declined);

    public static readonly UpdateSubmitterResponseStatus Opened = new(Values.Opened);

    public static readonly UpdateSubmitterResponseStatus Sent = new(Values.Sent);

    public static readonly UpdateSubmitterResponseStatus Awaiting = new(Values.Awaiting);

    public UpdateSubmitterResponseStatus(string value)
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
    public static UpdateSubmitterResponseStatus FromCustom(string value)
    {
        return new UpdateSubmitterResponseStatus(value);
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

    public static bool operator ==(UpdateSubmitterResponseStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateSubmitterResponseStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateSubmitterResponseStatus value) => value.Value;

    public static explicit operator UpdateSubmitterResponseStatus(string value) => new(value);

    internal class UpdateSubmitterResponseStatusSerializer
        : JsonConverter<UpdateSubmitterResponseStatus>
    {
        public override UpdateSubmitterResponseStatus Read(
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
            return new UpdateSubmitterResponseStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateSubmitterResponseStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateSubmitterResponseStatus ReadAsPropertyName(
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
            return new UpdateSubmitterResponseStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateSubmitterResponseStatus value,
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
