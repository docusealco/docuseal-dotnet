using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(GetSubmissionsResponseSubmissionSubmittersOrder.GetSubmissionsResponseSubmissionSubmittersOrderSerializer)
)]
[Serializable]
public readonly record struct GetSubmissionsResponseSubmissionSubmittersOrder : IStringEnum
{
    public static readonly GetSubmissionsResponseSubmissionSubmittersOrder Random = new(
        Values.Random
    );

    public static readonly GetSubmissionsResponseSubmissionSubmittersOrder Preserved = new(
        Values.Preserved
    );

    public GetSubmissionsResponseSubmissionSubmittersOrder(string value)
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
    public static GetSubmissionsResponseSubmissionSubmittersOrder FromCustom(string value)
    {
        return new GetSubmissionsResponseSubmissionSubmittersOrder(value);
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
        GetSubmissionsResponseSubmissionSubmittersOrder value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetSubmissionsResponseSubmissionSubmittersOrder value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(GetSubmissionsResponseSubmissionSubmittersOrder value) =>
        value.Value;

    public static explicit operator GetSubmissionsResponseSubmissionSubmittersOrder(string value) =>
        new(value);

    internal class GetSubmissionsResponseSubmissionSubmittersOrderSerializer
        : JsonConverter<GetSubmissionsResponseSubmissionSubmittersOrder>
    {
        public override GetSubmissionsResponseSubmissionSubmittersOrder Read(
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
            return new GetSubmissionsResponseSubmissionSubmittersOrder(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetSubmissionsResponseSubmissionSubmittersOrder value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetSubmissionsResponseSubmissionSubmittersOrder ReadAsPropertyName(
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
            return new GetSubmissionsResponseSubmissionSubmittersOrder(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetSubmissionsResponseSubmissionSubmittersOrder value,
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
