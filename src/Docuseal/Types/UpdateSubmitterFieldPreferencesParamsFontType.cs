using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(UpdateSubmitterFieldPreferencesParamsFontType.UpdateSubmitterFieldPreferencesParamsFontTypeSerializer)
)]
[Serializable]
public readonly record struct UpdateSubmitterFieldPreferencesParamsFontType : IStringEnum
{
    public static readonly UpdateSubmitterFieldPreferencesParamsFontType Bold = new(Values.Bold);

    public static readonly UpdateSubmitterFieldPreferencesParamsFontType Italic = new(
        Values.Italic
    );

    public static readonly UpdateSubmitterFieldPreferencesParamsFontType BoldItalic = new(
        Values.BoldItalic
    );

    public UpdateSubmitterFieldPreferencesParamsFontType(string value)
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
    public static UpdateSubmitterFieldPreferencesParamsFontType FromCustom(string value)
    {
        return new UpdateSubmitterFieldPreferencesParamsFontType(value);
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
        UpdateSubmitterFieldPreferencesParamsFontType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdateSubmitterFieldPreferencesParamsFontType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(UpdateSubmitterFieldPreferencesParamsFontType value) =>
        value.Value;

    public static explicit operator UpdateSubmitterFieldPreferencesParamsFontType(string value) =>
        new(value);

    internal class UpdateSubmitterFieldPreferencesParamsFontTypeSerializer
        : JsonConverter<UpdateSubmitterFieldPreferencesParamsFontType>
    {
        public override UpdateSubmitterFieldPreferencesParamsFontType Read(
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
            return new UpdateSubmitterFieldPreferencesParamsFontType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateSubmitterFieldPreferencesParamsFontType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateSubmitterFieldPreferencesParamsFontType ReadAsPropertyName(
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
            return new UpdateSubmitterFieldPreferencesParamsFontType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateSubmitterFieldPreferencesParamsFontType value,
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
