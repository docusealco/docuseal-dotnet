using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(SubmissionUpdateResultSubmittersOrder.SubmissionUpdateResultSubmittersOrderSerializer)
)]
[Serializable]
public readonly record struct SubmissionUpdateResultSubmittersOrder : IStringEnum
{
    public static readonly SubmissionUpdateResultSubmittersOrder Random = new(Values.Random);

    public static readonly SubmissionUpdateResultSubmittersOrder Preserved = new(Values.Preserved);

    public SubmissionUpdateResultSubmittersOrder(string value)
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
    public static SubmissionUpdateResultSubmittersOrder FromCustom(string value)
    {
        return new SubmissionUpdateResultSubmittersOrder(value);
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

    public static bool operator ==(SubmissionUpdateResultSubmittersOrder value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubmissionUpdateResultSubmittersOrder value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubmissionUpdateResultSubmittersOrder value) =>
        value.Value;

    public static explicit operator SubmissionUpdateResultSubmittersOrder(string value) =>
        new(value);

    internal class SubmissionUpdateResultSubmittersOrderSerializer
        : JsonConverter<SubmissionUpdateResultSubmittersOrder>
    {
        public override SubmissionUpdateResultSubmittersOrder Read(
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
            return new SubmissionUpdateResultSubmittersOrder(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubmissionUpdateResultSubmittersOrder value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubmissionUpdateResultSubmittersOrder ReadAsPropertyName(
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
            return new SubmissionUpdateResultSubmittersOrder(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubmissionUpdateResultSubmittersOrder value,
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
        public const string Random = "random";

        public const string Preserved = "preserved";
    }
}
