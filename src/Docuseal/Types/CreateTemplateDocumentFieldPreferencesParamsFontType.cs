using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateTemplateDocumentFieldPreferencesParamsFontType.CreateTemplateDocumentFieldPreferencesParamsFontTypeSerializer)
)]
[Serializable]
public readonly record struct CreateTemplateDocumentFieldPreferencesParamsFontType : IStringEnum
{
    public static readonly CreateTemplateDocumentFieldPreferencesParamsFontType Bold = new(
        Values.Bold
    );

    public static readonly CreateTemplateDocumentFieldPreferencesParamsFontType Italic = new(
        Values.Italic
    );

    public static readonly CreateTemplateDocumentFieldPreferencesParamsFontType BoldItalic = new(
        Values.BoldItalic
    );

    public CreateTemplateDocumentFieldPreferencesParamsFontType(string value)
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
    public static CreateTemplateDocumentFieldPreferencesParamsFontType FromCustom(string value)
    {
        return new CreateTemplateDocumentFieldPreferencesParamsFontType(value);
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
        CreateTemplateDocumentFieldPreferencesParamsFontType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateTemplateDocumentFieldPreferencesParamsFontType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateTemplateDocumentFieldPreferencesParamsFontType value
    ) => value.Value;

    public static explicit operator CreateTemplateDocumentFieldPreferencesParamsFontType(
        string value
    ) => new(value);

    internal class CreateTemplateDocumentFieldPreferencesParamsFontTypeSerializer
        : JsonConverter<CreateTemplateDocumentFieldPreferencesParamsFontType>
    {
        public override CreateTemplateDocumentFieldPreferencesParamsFontType Read(
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
            return new CreateTemplateDocumentFieldPreferencesParamsFontType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTemplateDocumentFieldPreferencesParamsFontType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateTemplateDocumentFieldPreferencesParamsFontType ReadAsPropertyName(
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
            return new CreateTemplateDocumentFieldPreferencesParamsFontType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTemplateDocumentFieldPreferencesParamsFontType value,
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
