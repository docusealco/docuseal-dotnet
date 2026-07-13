using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateTemplateDocumentFieldPreferencesParamsCurrency.CreateTemplateDocumentFieldPreferencesParamsCurrencySerializer)
)]
[Serializable]
public readonly record struct CreateTemplateDocumentFieldPreferencesParamsCurrency : IStringEnum
{
    public static readonly CreateTemplateDocumentFieldPreferencesParamsCurrency Usd = new(
        Values.Usd
    );

    public static readonly CreateTemplateDocumentFieldPreferencesParamsCurrency Eur = new(
        Values.Eur
    );

    public static readonly CreateTemplateDocumentFieldPreferencesParamsCurrency Gbp = new(
        Values.Gbp
    );

    public static readonly CreateTemplateDocumentFieldPreferencesParamsCurrency Cad = new(
        Values.Cad
    );

    public static readonly CreateTemplateDocumentFieldPreferencesParamsCurrency Aud = new(
        Values.Aud
    );

    public CreateTemplateDocumentFieldPreferencesParamsCurrency(string value)
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
    public static CreateTemplateDocumentFieldPreferencesParamsCurrency FromCustom(string value)
    {
        return new CreateTemplateDocumentFieldPreferencesParamsCurrency(value);
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
        CreateTemplateDocumentFieldPreferencesParamsCurrency value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateTemplateDocumentFieldPreferencesParamsCurrency value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateTemplateDocumentFieldPreferencesParamsCurrency value
    ) => value.Value;

    public static explicit operator CreateTemplateDocumentFieldPreferencesParamsCurrency(
        string value
    ) => new(value);

    internal class CreateTemplateDocumentFieldPreferencesParamsCurrencySerializer
        : JsonConverter<CreateTemplateDocumentFieldPreferencesParamsCurrency>
    {
        public override CreateTemplateDocumentFieldPreferencesParamsCurrency Read(
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
            return new CreateTemplateDocumentFieldPreferencesParamsCurrency(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTemplateDocumentFieldPreferencesParamsCurrency value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateTemplateDocumentFieldPreferencesParamsCurrency ReadAsPropertyName(
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
            return new CreateTemplateDocumentFieldPreferencesParamsCurrency(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTemplateDocumentFieldPreferencesParamsCurrency value,
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
        public const string Usd = "USD";

        public const string Eur = "EUR";

        public const string Gbp = "GBP";

        public const string Cad = "CAD";

        public const string Aud = "AUD";
    }
}
