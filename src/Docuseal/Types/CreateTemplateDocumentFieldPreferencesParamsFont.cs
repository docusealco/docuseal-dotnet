using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateTemplateDocumentFieldPreferencesParamsFont.CreateTemplateDocumentFieldPreferencesParamsFontSerializer)
)]
[Serializable]
public readonly record struct CreateTemplateDocumentFieldPreferencesParamsFont : IStringEnum
{
    public static readonly CreateTemplateDocumentFieldPreferencesParamsFont Times = new(
        Values.Times
    );

    public static readonly CreateTemplateDocumentFieldPreferencesParamsFont Helvetica = new(
        Values.Helvetica
    );

    public static readonly CreateTemplateDocumentFieldPreferencesParamsFont Courier = new(
        Values.Courier
    );

    public CreateTemplateDocumentFieldPreferencesParamsFont(string value)
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
    public static CreateTemplateDocumentFieldPreferencesParamsFont FromCustom(string value)
    {
        return new CreateTemplateDocumentFieldPreferencesParamsFont(value);
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
        CreateTemplateDocumentFieldPreferencesParamsFont value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateTemplateDocumentFieldPreferencesParamsFont value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateTemplateDocumentFieldPreferencesParamsFont value
    ) => value.Value;

    public static explicit operator CreateTemplateDocumentFieldPreferencesParamsFont(
        string value
    ) => new(value);

    internal class CreateTemplateDocumentFieldPreferencesParamsFontSerializer
        : JsonConverter<CreateTemplateDocumentFieldPreferencesParamsFont>
    {
        public override CreateTemplateDocumentFieldPreferencesParamsFont Read(
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
            return new CreateTemplateDocumentFieldPreferencesParamsFont(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTemplateDocumentFieldPreferencesParamsFont value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateTemplateDocumentFieldPreferencesParamsFont ReadAsPropertyName(
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
            return new CreateTemplateDocumentFieldPreferencesParamsFont(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTemplateDocumentFieldPreferencesParamsFont value,
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
