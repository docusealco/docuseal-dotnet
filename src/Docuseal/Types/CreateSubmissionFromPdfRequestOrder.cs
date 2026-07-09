using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateSubmissionFromPdfRequestOrder.CreateSubmissionFromPdfRequestOrderSerializer)
)]
[Serializable]
public readonly record struct CreateSubmissionFromPdfRequestOrder : IStringEnum
{
    public static readonly CreateSubmissionFromPdfRequestOrder Preserved = new(Values.Preserved);

    public static readonly CreateSubmissionFromPdfRequestOrder Random = new(Values.Random);

    public CreateSubmissionFromPdfRequestOrder(string value)
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
    public static CreateSubmissionFromPdfRequestOrder FromCustom(string value)
    {
        return new CreateSubmissionFromPdfRequestOrder(value);
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

    public static bool operator ==(CreateSubmissionFromPdfRequestOrder value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateSubmissionFromPdfRequestOrder value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateSubmissionFromPdfRequestOrder value) =>
        value.Value;

    public static explicit operator CreateSubmissionFromPdfRequestOrder(string value) => new(value);

    internal class CreateSubmissionFromPdfRequestOrderSerializer
        : JsonConverter<CreateSubmissionFromPdfRequestOrder>
    {
        public override CreateSubmissionFromPdfRequestOrder Read(
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
            return new CreateSubmissionFromPdfRequestOrder(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateSubmissionFromPdfRequestOrder value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateSubmissionFromPdfRequestOrder ReadAsPropertyName(
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
            return new CreateSubmissionFromPdfRequestOrder(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateSubmissionFromPdfRequestOrder value,
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
        public const string Preserved = "preserved";

        public const string Random = "random";
    }
}
