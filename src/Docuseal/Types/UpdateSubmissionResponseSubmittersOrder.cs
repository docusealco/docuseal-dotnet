using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(UpdateSubmissionResponseSubmittersOrder.UpdateSubmissionResponseSubmittersOrderSerializer)
)]
[Serializable]
public readonly record struct UpdateSubmissionResponseSubmittersOrder : IStringEnum
{
    public static readonly UpdateSubmissionResponseSubmittersOrder Random = new(Values.Random);

    public static readonly UpdateSubmissionResponseSubmittersOrder Preserved = new(
        Values.Preserved
    );

    public UpdateSubmissionResponseSubmittersOrder(string value)
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
    public static UpdateSubmissionResponseSubmittersOrder FromCustom(string value)
    {
        return new UpdateSubmissionResponseSubmittersOrder(value);
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

    public static bool operator ==(UpdateSubmissionResponseSubmittersOrder value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UpdateSubmissionResponseSubmittersOrder value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UpdateSubmissionResponseSubmittersOrder value) =>
        value.Value;

    public static explicit operator UpdateSubmissionResponseSubmittersOrder(string value) =>
        new(value);

    internal class UpdateSubmissionResponseSubmittersOrderSerializer
        : JsonConverter<UpdateSubmissionResponseSubmittersOrder>
    {
        public override UpdateSubmissionResponseSubmittersOrder Read(
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
            return new UpdateSubmissionResponseSubmittersOrder(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateSubmissionResponseSubmittersOrder value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateSubmissionResponseSubmittersOrder ReadAsPropertyName(
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
            return new UpdateSubmissionResponseSubmittersOrder(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateSubmissionResponseSubmittersOrder value,
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
