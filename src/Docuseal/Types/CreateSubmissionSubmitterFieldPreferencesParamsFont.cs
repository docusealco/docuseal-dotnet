using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateSubmissionSubmitterFieldPreferencesParamsFont.CreateSubmissionSubmitterFieldPreferencesParamsFontSerializer)
)]
[Serializable]
public readonly record struct CreateSubmissionSubmitterFieldPreferencesParamsFont : IStringEnum
{
    public static readonly CreateSubmissionSubmitterFieldPreferencesParamsFont Times = new(
        Values.Times
    );

    public static readonly CreateSubmissionSubmitterFieldPreferencesParamsFont Helvetica = new(
        Values.Helvetica
    );

    public static readonly CreateSubmissionSubmitterFieldPreferencesParamsFont Courier = new(
        Values.Courier
    );

    public CreateSubmissionSubmitterFieldPreferencesParamsFont(string value)
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
    public static CreateSubmissionSubmitterFieldPreferencesParamsFont FromCustom(string value)
    {
        return new CreateSubmissionSubmitterFieldPreferencesParamsFont(value);
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
        CreateSubmissionSubmitterFieldPreferencesParamsFont value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateSubmissionSubmitterFieldPreferencesParamsFont value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateSubmissionSubmitterFieldPreferencesParamsFont value
    ) => value.Value;

    public static explicit operator CreateSubmissionSubmitterFieldPreferencesParamsFont(
        string value
    ) => new(value);

    internal class CreateSubmissionSubmitterFieldPreferencesParamsFontSerializer
        : JsonConverter<CreateSubmissionSubmitterFieldPreferencesParamsFont>
    {
        public override CreateSubmissionSubmitterFieldPreferencesParamsFont Read(
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
            return new CreateSubmissionSubmitterFieldPreferencesParamsFont(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateSubmissionSubmitterFieldPreferencesParamsFont value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateSubmissionSubmitterFieldPreferencesParamsFont ReadAsPropertyName(
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
            return new CreateSubmissionSubmitterFieldPreferencesParamsFont(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateSubmissionSubmitterFieldPreferencesParamsFont value,
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
        public const string Times = "Times";

        public const string Helvetica = "Helvetica";

        public const string Courier = "Courier";
    }
}
