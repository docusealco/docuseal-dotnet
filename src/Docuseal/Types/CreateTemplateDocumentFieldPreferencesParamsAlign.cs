using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateTemplateDocumentFieldPreferencesParamsAlign.CreateTemplateDocumentFieldPreferencesParamsAlignSerializer)
)]
[Serializable]
public readonly record struct CreateTemplateDocumentFieldPreferencesParamsAlign : IStringEnum
{
    public static readonly CreateTemplateDocumentFieldPreferencesParamsAlign Left = new(
        Values.Left
    );

    public static readonly CreateTemplateDocumentFieldPreferencesParamsAlign Center = new(
        Values.Center
    );

    public static readonly CreateTemplateDocumentFieldPreferencesParamsAlign Right = new(
        Values.Right
    );

    public CreateTemplateDocumentFieldPreferencesParamsAlign(string value)
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
    public static CreateTemplateDocumentFieldPreferencesParamsAlign FromCustom(string value)
    {
        return new CreateTemplateDocumentFieldPreferencesParamsAlign(value);
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
        CreateTemplateDocumentFieldPreferencesParamsAlign value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateTemplateDocumentFieldPreferencesParamsAlign value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateTemplateDocumentFieldPreferencesParamsAlign value
    ) => value.Value;

    public static explicit operator CreateTemplateDocumentFieldPreferencesParamsAlign(
        string value
    ) => new(value);

    internal class CreateTemplateDocumentFieldPreferencesParamsAlignSerializer
        : JsonConverter<CreateTemplateDocumentFieldPreferencesParamsAlign>
    {
        public override CreateTemplateDocumentFieldPreferencesParamsAlign Read(
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
            return new CreateTemplateDocumentFieldPreferencesParamsAlign(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTemplateDocumentFieldPreferencesParamsAlign value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateTemplateDocumentFieldPreferencesParamsAlign ReadAsPropertyName(
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
            return new CreateTemplateDocumentFieldPreferencesParamsAlign(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTemplateDocumentFieldPreferencesParamsAlign value,
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
        public const string Left = "left";

        public const string Center = "center";

        public const string Right = "right";
    }
}
