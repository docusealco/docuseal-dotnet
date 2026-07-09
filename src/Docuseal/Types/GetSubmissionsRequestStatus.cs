using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(GetSubmissionsRequestStatus.GetSubmissionsRequestStatusSerializer))]
[Serializable]
public readonly record struct GetSubmissionsRequestStatus : IStringEnum
{
    public static readonly GetSubmissionsRequestStatus Pending = new(Values.Pending);

    public static readonly GetSubmissionsRequestStatus Completed = new(Values.Completed);

    public static readonly GetSubmissionsRequestStatus Declined = new(Values.Declined);

    public static readonly GetSubmissionsRequestStatus Expired = new(Values.Expired);

    public GetSubmissionsRequestStatus(string value)
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
    public static GetSubmissionsRequestStatus FromCustom(string value)
    {
        return new GetSubmissionsRequestStatus(value);
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

    public static bool operator ==(GetSubmissionsRequestStatus value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetSubmissionsRequestStatus value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetSubmissionsRequestStatus value) => value.Value;

    public static explicit operator GetSubmissionsRequestStatus(string value) => new(value);

    internal class GetSubmissionsRequestStatusSerializer
        : JsonConverter<GetSubmissionsRequestStatus>
    {
        public override GetSubmissionsRequestStatus Read(
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
            return new GetSubmissionsRequestStatus(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetSubmissionsRequestStatus value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetSubmissionsRequestStatus ReadAsPropertyName(
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
            return new GetSubmissionsRequestStatus(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetSubmissionsRequestStatus value,
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
        public const string Pending = "pending";

        public const string Completed = "completed";

        public const string Declined = "declined";

        public const string Expired = "expired";
    }
}
