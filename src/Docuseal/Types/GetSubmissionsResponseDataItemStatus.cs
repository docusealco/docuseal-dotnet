using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(GetSubmissionsResponseDataItemStatus.GetSubmissionsResponseDataItemStatusSerializer)
)]
[Serializable]
public readonly record struct GetSubmissionsResponseDataItemStatus : IStringEnum
{
    public static readonly GetSubmissionsResponseDataItemStatus Completed = new(Values.Completed);

    public static readonly GetSubmissionsResponseDataItemStatus Declined = new(Values.Declined);

    public static readonly GetSubmissionsResponseDataItemStatus Expired = new(Values.Expired);

    public static readonly GetSubmissionsResponseDataItemStatus Pending = new(Values.Pending);

    public GetSubmissionsResponseDataItemStatus(string value)
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
    public static GetSubmissionsResponseDataItemStatus FromCustom(string value)
    {
        return new GetSubmissionsResponseDataItemStatus(value);
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

    public static bool operator ==(GetSubmissionsResponseDataItemStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetSubmissionsResponseDataItemStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetSubmissionsResponseDataItemStatus value) =>
        value.Value;

    public static explicit operator GetSubmissionsResponseDataItemStatus(string value) =>
        new(value);

    internal class GetSubmissionsResponseDataItemStatusSerializer
        : JsonConverter<GetSubmissionsResponseDataItemStatus>
    {
        public override GetSubmissionsResponseDataItemStatus Read(
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
            return new GetSubmissionsResponseDataItemStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetSubmissionsResponseDataItemStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetSubmissionsResponseDataItemStatus ReadAsPropertyName(
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
            return new GetSubmissionsResponseDataItemStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetSubmissionsResponseDataItemStatus value,
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
        public const string Completed = "completed";

        public const string Declined = "declined";

        public const string Expired = "expired";

        public const string Pending = "pending";
    }
}
