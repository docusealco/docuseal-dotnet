using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(SubmitterCreateResultStatus.SubmitterCreateResultStatusSerializer))]
[Serializable]
public readonly record struct SubmitterCreateResultStatus : IStringEnum
{
    public static readonly SubmitterCreateResultStatus Completed = new(Values.Completed);

    public static readonly SubmitterCreateResultStatus Declined = new(Values.Declined);

    public static readonly SubmitterCreateResultStatus Opened = new(Values.Opened);

    public static readonly SubmitterCreateResultStatus Sent = new(Values.Sent);

    public static readonly SubmitterCreateResultStatus Awaiting = new(Values.Awaiting);

    public SubmitterCreateResultStatus(string value)
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
    public static SubmitterCreateResultStatus FromCustom(string value)
    {
        return new SubmitterCreateResultStatus(value);
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

    public static bool operator ==(SubmitterCreateResultStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubmitterCreateResultStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubmitterCreateResultStatus value) => value.Value;

    public static explicit operator SubmitterCreateResultStatus(string value) => new(value);

    internal class SubmitterCreateResultStatusSerializer
        : JsonConverter<SubmitterCreateResultStatus>
    {
        public override SubmitterCreateResultStatus Read(
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
            return new SubmitterCreateResultStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubmitterCreateResultStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubmitterCreateResultStatus ReadAsPropertyName(
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
            return new SubmitterCreateResultStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubmitterCreateResultStatus value,
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
