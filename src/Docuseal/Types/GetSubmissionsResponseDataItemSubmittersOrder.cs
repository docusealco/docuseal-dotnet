using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(GetSubmissionsResponseDataItemSubmittersOrder.GetSubmissionsResponseDataItemSubmittersOrderSerializer)
)]
[Serializable]
public readonly record struct GetSubmissionsResponseDataItemSubmittersOrder : IStringEnum
{
    public static readonly GetSubmissionsResponseDataItemSubmittersOrder Random = new(
        Values.Random
    );

    public static readonly GetSubmissionsResponseDataItemSubmittersOrder Preserved = new(
        Values.Preserved
    );

    public GetSubmissionsResponseDataItemSubmittersOrder(string value)
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
    public static GetSubmissionsResponseDataItemSubmittersOrder FromCustom(string value)
    {
        return new GetSubmissionsResponseDataItemSubmittersOrder(value);
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
        GetSubmissionsResponseDataItemSubmittersOrder value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GetSubmissionsResponseDataItemSubmittersOrder value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(GetSubmissionsResponseDataItemSubmittersOrder value) =>
        value.Value;

    public static explicit operator GetSubmissionsResponseDataItemSubmittersOrder(string value) =>
        new(value);

    internal class GetSubmissionsResponseDataItemSubmittersOrderSerializer
        : JsonConverter<GetSubmissionsResponseDataItemSubmittersOrder>
    {
        public override GetSubmissionsResponseDataItemSubmittersOrder Read(
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
            return new GetSubmissionsResponseDataItemSubmittersOrder(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetSubmissionsResponseDataItemSubmittersOrder value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetSubmissionsResponseDataItemSubmittersOrder ReadAsPropertyName(
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
            return new GetSubmissionsResponseDataItemSubmittersOrder(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetSubmissionsResponseDataItemSubmittersOrder value,
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
