using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateSubmissionFromPdfResponseSubmittersOrder.CreateSubmissionFromPdfResponseSubmittersOrderSerializer)
)]
[Serializable]
public readonly record struct CreateSubmissionFromPdfResponseSubmittersOrder : IStringEnum
{
    public static readonly CreateSubmissionFromPdfResponseSubmittersOrder Random = new(
        Values.Random
    );

    public static readonly CreateSubmissionFromPdfResponseSubmittersOrder Preserved = new(
        Values.Preserved
    );

    public CreateSubmissionFromPdfResponseSubmittersOrder(string value)
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
    public static CreateSubmissionFromPdfResponseSubmittersOrder FromCustom(string value)
    {
        return new CreateSubmissionFromPdfResponseSubmittersOrder(value);
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

    public static bool operator ==(
        CreateSubmissionFromPdfResponseSubmittersOrder value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateSubmissionFromPdfResponseSubmittersOrder value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateSubmissionFromPdfResponseSubmittersOrder value) =>
        value.Value;

    public static explicit operator CreateSubmissionFromPdfResponseSubmittersOrder(string value) =>
        new(value);

    internal class CreateSubmissionFromPdfResponseSubmittersOrderSerializer
        : JsonConverter<CreateSubmissionFromPdfResponseSubmittersOrder>
    {
        public override CreateSubmissionFromPdfResponseSubmittersOrder Read(
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
            return new CreateSubmissionFromPdfResponseSubmittersOrder(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateSubmissionFromPdfResponseSubmittersOrder value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateSubmissionFromPdfResponseSubmittersOrder ReadAsPropertyName(
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
            return new CreateSubmissionFromPdfResponseSubmittersOrder(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateSubmissionFromPdfResponseSubmittersOrder value,
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
