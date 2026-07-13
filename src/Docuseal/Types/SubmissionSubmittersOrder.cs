using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(SubmissionSubmittersOrder.SubmissionSubmittersOrderSerializer))]
[Serializable]
public readonly record struct SubmissionSubmittersOrder : IStringEnum
{
    public static readonly SubmissionSubmittersOrder Random = new(Values.Random);

    public static readonly SubmissionSubmittersOrder Preserved = new(Values.Preserved);

    public SubmissionSubmittersOrder(string value)
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
    public static SubmissionSubmittersOrder FromCustom(string value)
    {
        return new SubmissionSubmittersOrder(value);
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

    public static bool operator ==(SubmissionSubmittersOrder value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubmissionSubmittersOrder value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubmissionSubmittersOrder value) => value.Value;

    public static explicit operator SubmissionSubmittersOrder(string value) => new(value);

    internal class SubmissionSubmittersOrderSerializer : JsonConverter<SubmissionSubmittersOrder>
    {
        public override SubmissionSubmittersOrder Read(
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
            return new SubmissionSubmittersOrder(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubmissionSubmittersOrder value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubmissionSubmittersOrder ReadAsPropertyName(
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
            return new SubmissionSubmittersOrder(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubmissionSubmittersOrder value,
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
