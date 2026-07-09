using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateSubmissionFromDocxRequestOrder.CreateSubmissionFromDocxRequestOrderSerializer)
)]
[Serializable]
public readonly record struct CreateSubmissionFromDocxRequestOrder : IStringEnum
{
    public static readonly CreateSubmissionFromDocxRequestOrder Preserved = new(Values.Preserved);

    public static readonly CreateSubmissionFromDocxRequestOrder Random = new(Values.Random);

    public CreateSubmissionFromDocxRequestOrder(string value)
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
    public static CreateSubmissionFromDocxRequestOrder FromCustom(string value)
    {
        return new CreateSubmissionFromDocxRequestOrder(value);
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

    public static bool operator ==(CreateSubmissionFromDocxRequestOrder value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateSubmissionFromDocxRequestOrder value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateSubmissionFromDocxRequestOrder value) =>
        value.Value;

    public static explicit operator CreateSubmissionFromDocxRequestOrder(string value) =>
        new(value);

    internal class CreateSubmissionFromDocxRequestOrderSerializer
        : JsonConverter<CreateSubmissionFromDocxRequestOrder>
    {
        public override CreateSubmissionFromDocxRequestOrder Read(
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
            return new CreateSubmissionFromDocxRequestOrder(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateSubmissionFromDocxRequestOrder value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateSubmissionFromDocxRequestOrder ReadAsPropertyName(
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
            return new CreateSubmissionFromDocxRequestOrder(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateSubmissionFromDocxRequestOrder value,
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
