using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(SubmitterSummaryStatus.SubmitterSummaryStatusSerializer))]
[Serializable]
public readonly record struct SubmitterSummaryStatus : IStringEnum
{
    public static readonly SubmitterSummaryStatus Completed = new(Values.Completed);

    public static readonly SubmitterSummaryStatus Declined = new(Values.Declined);

    public static readonly SubmitterSummaryStatus Opened = new(Values.Opened);

    public static readonly SubmitterSummaryStatus Sent = new(Values.Sent);

    public static readonly SubmitterSummaryStatus Awaiting = new(Values.Awaiting);

    public SubmitterSummaryStatus(string value)
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
    public static SubmitterSummaryStatus FromCustom(string value)
    {
        return new SubmitterSummaryStatus(value);
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

    public static bool operator ==(SubmitterSummaryStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubmitterSummaryStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubmitterSummaryStatus value) => value.Value;

    public static explicit operator SubmitterSummaryStatus(string value) => new(value);

    internal class SubmitterSummaryStatusSerializer : JsonConverter<SubmitterSummaryStatus>
    {
        public override SubmitterSummaryStatus Read(
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
            return new SubmitterSummaryStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubmitterSummaryStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubmitterSummaryStatus ReadAsPropertyName(
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
            return new SubmitterSummaryStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubmitterSummaryStatus value,
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
