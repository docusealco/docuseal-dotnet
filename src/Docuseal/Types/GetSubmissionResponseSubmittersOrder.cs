using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(GetSubmissionResponseSubmittersOrder.GetSubmissionResponseSubmittersOrderSerializer)
)]
[Serializable]
public readonly record struct GetSubmissionResponseSubmittersOrder : IStringEnum
{
    public static readonly GetSubmissionResponseSubmittersOrder Random = new(Values.Random);

    public static readonly GetSubmissionResponseSubmittersOrder Preserved = new(Values.Preserved);

    public GetSubmissionResponseSubmittersOrder(string value)
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
    public static GetSubmissionResponseSubmittersOrder FromCustom(string value)
    {
        return new GetSubmissionResponseSubmittersOrder(value);
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

    public static bool operator ==(GetSubmissionResponseSubmittersOrder value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetSubmissionResponseSubmittersOrder value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetSubmissionResponseSubmittersOrder value) =>
        value.Value;

    public static explicit operator GetSubmissionResponseSubmittersOrder(string value) =>
        new(value);

    internal class GetSubmissionResponseSubmittersOrderSerializer
        : JsonConverter<GetSubmissionResponseSubmittersOrder>
    {
        public override GetSubmissionResponseSubmittersOrder Read(
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
            return new GetSubmissionResponseSubmittersOrder(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetSubmissionResponseSubmittersOrder value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetSubmissionResponseSubmittersOrder ReadAsPropertyName(
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
            return new GetSubmissionResponseSubmittersOrder(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetSubmissionResponseSubmittersOrder value,
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
