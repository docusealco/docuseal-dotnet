using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(CreateSubmissionRequestOrder.CreateSubmissionRequestOrderSerializer))]
[Serializable]
public readonly record struct CreateSubmissionRequestOrder : IStringEnum
{
    public static readonly CreateSubmissionRequestOrder Preserved = new(Values.Preserved);

    public static readonly CreateSubmissionRequestOrder Random = new(Values.Random);

    public CreateSubmissionRequestOrder(string value)
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
    public static CreateSubmissionRequestOrder FromCustom(string value)
    {
        return new CreateSubmissionRequestOrder(value);
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

    public static bool operator ==(CreateSubmissionRequestOrder value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateSubmissionRequestOrder value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateSubmissionRequestOrder value) => value.Value;

    public static explicit operator CreateSubmissionRequestOrder(string value) => new(value);

    internal class CreateSubmissionRequestOrderSerializer
        : JsonConverter<CreateSubmissionRequestOrder>
    {
        public override CreateSubmissionRequestOrder Read(
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
            return new CreateSubmissionRequestOrder(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateSubmissionRequestOrder value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateSubmissionRequestOrder ReadAsPropertyName(
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
            return new CreateSubmissionRequestOrder(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateSubmissionRequestOrder value,
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
