using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateTemplateDocumentFieldPreferencesParamsBackground.CreateTemplateDocumentFieldPreferencesParamsBackgroundSerializer)
)]
[Serializable]
public readonly record struct CreateTemplateDocumentFieldPreferencesParamsBackground : IStringEnum
{
    public static readonly CreateTemplateDocumentFieldPreferencesParamsBackground Black = new(
        Values.Black
    );

    public static readonly CreateTemplateDocumentFieldPreferencesParamsBackground White = new(
        Values.White
    );

    public static readonly CreateTemplateDocumentFieldPreferencesParamsBackground Blue = new(
        Values.Blue
    );

    public CreateTemplateDocumentFieldPreferencesParamsBackground(string value)
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
    public static CreateTemplateDocumentFieldPreferencesParamsBackground FromCustom(string value)
    {
        return new CreateTemplateDocumentFieldPreferencesParamsBackground(value);
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
        CreateTemplateDocumentFieldPreferencesParamsBackground value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateTemplateDocumentFieldPreferencesParamsBackground value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateTemplateDocumentFieldPreferencesParamsBackground value
    ) => value.Value;

    public static explicit operator CreateTemplateDocumentFieldPreferencesParamsBackground(
        string value
    ) => new(value);

    internal class CreateTemplateDocumentFieldPreferencesParamsBackgroundSerializer
        : JsonConverter<CreateTemplateDocumentFieldPreferencesParamsBackground>
    {
        public override CreateTemplateDocumentFieldPreferencesParamsBackground Read(
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
            return new CreateTemplateDocumentFieldPreferencesParamsBackground(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTemplateDocumentFieldPreferencesParamsBackground value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateTemplateDocumentFieldPreferencesParamsBackground ReadAsPropertyName(
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
            return new CreateTemplateDocumentFieldPreferencesParamsBackground(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTemplateDocumentFieldPreferencesParamsBackground value,
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
