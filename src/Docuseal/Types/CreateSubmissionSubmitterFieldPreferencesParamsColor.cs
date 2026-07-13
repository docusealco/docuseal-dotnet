using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateSubmissionSubmitterFieldPreferencesParamsColor.CreateSubmissionSubmitterFieldPreferencesParamsColorSerializer)
)]
[Serializable]
public readonly record struct CreateSubmissionSubmitterFieldPreferencesParamsColor : IStringEnum
{
    public static readonly CreateSubmissionSubmitterFieldPreferencesParamsColor Black = new(
        Values.Black
    );

    public static readonly CreateSubmissionSubmitterFieldPreferencesParamsColor White = new(
        Values.White
    );

    public static readonly CreateSubmissionSubmitterFieldPreferencesParamsColor Blue = new(
        Values.Blue
    );

    public CreateSubmissionSubmitterFieldPreferencesParamsColor(string value)
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
    public static CreateSubmissionSubmitterFieldPreferencesParamsColor FromCustom(string value)
    {
        return new CreateSubmissionSubmitterFieldPreferencesParamsColor(value);
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
        CreateSubmissionSubmitterFieldPreferencesParamsColor value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateSubmissionSubmitterFieldPreferencesParamsColor value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateSubmissionSubmitterFieldPreferencesParamsColor value
    ) => value.Value;

    public static explicit operator CreateSubmissionSubmitterFieldPreferencesParamsColor(
        string value
    ) => new(value);

    internal class CreateSubmissionSubmitterFieldPreferencesParamsColorSerializer
        : JsonConverter<CreateSubmissionSubmitterFieldPreferencesParamsColor>
    {
        public override CreateSubmissionSubmitterFieldPreferencesParamsColor Read(
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
            return new CreateSubmissionSubmitterFieldPreferencesParamsColor(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateSubmissionSubmitterFieldPreferencesParamsColor value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateSubmissionSubmitterFieldPreferencesParamsColor ReadAsPropertyName(
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
            return new CreateSubmissionSubmitterFieldPreferencesParamsColor(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateSubmissionSubmitterFieldPreferencesParamsColor value,
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
        public const string Black = "black";

        public const string White = "white";

        public const string Blue = "blue";
    }
}
