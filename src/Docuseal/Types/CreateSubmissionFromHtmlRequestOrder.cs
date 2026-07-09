using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateSubmissionFromHtmlRequestOrder.CreateSubmissionFromHtmlRequestOrderSerializer)
)]
[Serializable]
public readonly record struct CreateSubmissionFromHtmlRequestOrder : IStringEnum
{
    public static readonly CreateSubmissionFromHtmlRequestOrder Preserved = new(Values.Preserved);

    public static readonly CreateSubmissionFromHtmlRequestOrder Random = new(Values.Random);

    public CreateSubmissionFromHtmlRequestOrder(string value)
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
    public static CreateSubmissionFromHtmlRequestOrder FromCustom(string value)
    {
        return new CreateSubmissionFromHtmlRequestOrder(value);
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

    public static bool operator ==(CreateSubmissionFromHtmlRequestOrder value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateSubmissionFromHtmlRequestOrder value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateSubmissionFromHtmlRequestOrder value) =>
        value.Value;

    public static explicit operator CreateSubmissionFromHtmlRequestOrder(string value) =>
        new(value);

    internal class CreateSubmissionFromHtmlRequestOrderSerializer
        : JsonConverter<CreateSubmissionFromHtmlRequestOrder>
    {
        public override CreateSubmissionFromHtmlRequestOrder Read(
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
            return new CreateSubmissionFromHtmlRequestOrder(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateSubmissionFromHtmlRequestOrder value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateSubmissionFromHtmlRequestOrder ReadAsPropertyName(
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
            return new CreateSubmissionFromHtmlRequestOrder(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateSubmissionFromHtmlRequestOrder value,
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
