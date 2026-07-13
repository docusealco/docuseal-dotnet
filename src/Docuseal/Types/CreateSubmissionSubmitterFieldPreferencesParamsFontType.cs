using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateSubmissionSubmitterFieldPreferencesParamsFontType.CreateSubmissionSubmitterFieldPreferencesParamsFontTypeSerializer)
)]
[Serializable]
public readonly record struct CreateSubmissionSubmitterFieldPreferencesParamsFontType : IStringEnum
{
    public static readonly CreateSubmissionSubmitterFieldPreferencesParamsFontType Bold = new(
        Values.Bold
    );

    public static readonly CreateSubmissionSubmitterFieldPreferencesParamsFontType Italic = new(
        Values.Italic
    );

    public static readonly CreateSubmissionSubmitterFieldPreferencesParamsFontType BoldItalic = new(
        Values.BoldItalic
    );

    public CreateSubmissionSubmitterFieldPreferencesParamsFontType(string value)
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
    public static CreateSubmissionSubmitterFieldPreferencesParamsFontType FromCustom(string value)
    {
        return new CreateSubmissionSubmitterFieldPreferencesParamsFontType(value);
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
        CreateSubmissionSubmitterFieldPreferencesParamsFontType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateSubmissionSubmitterFieldPreferencesParamsFontType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateSubmissionSubmitterFieldPreferencesParamsFontType value
    ) => value.Value;

    public static explicit operator CreateSubmissionSubmitterFieldPreferencesParamsFontType(
        string value
    ) => new(value);

    internal class CreateSubmissionSubmitterFieldPreferencesParamsFontTypeSerializer
        : JsonConverter<CreateSubmissionSubmitterFieldPreferencesParamsFontType>
    {
        public override CreateSubmissionSubmitterFieldPreferencesParamsFontType Read(
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
            return new CreateSubmissionSubmitterFieldPreferencesParamsFontType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateSubmissionSubmitterFieldPreferencesParamsFontType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateSubmissionSubmitterFieldPreferencesParamsFontType ReadAsPropertyName(
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
            return new CreateSubmissionSubmitterFieldPreferencesParamsFontType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateSubmissionSubmitterFieldPreferencesParamsFontType value,
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
        public const string Bold = "bold";

        public const string Italic = "italic";

        public const string BoldItalic = "bold_italic";
    }
}
