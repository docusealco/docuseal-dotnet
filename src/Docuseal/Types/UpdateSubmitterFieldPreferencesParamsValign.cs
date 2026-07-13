using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(UpdateSubmitterFieldPreferencesParamsValign.UpdateSubmitterFieldPreferencesParamsValignSerializer)
)]
[Serializable]
public readonly record struct UpdateSubmitterFieldPreferencesParamsValign : IStringEnum
{
    public static readonly UpdateSubmitterFieldPreferencesParamsValign Top = new(Values.Top);

    public static readonly UpdateSubmitterFieldPreferencesParamsValign Center = new(Values.Center);

    public static readonly UpdateSubmitterFieldPreferencesParamsValign Bottom = new(Values.Bottom);

    public UpdateSubmitterFieldPreferencesParamsValign(string value)
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
    public static UpdateSubmitterFieldPreferencesParamsValign FromCustom(string value)
    {
        return new UpdateSubmitterFieldPreferencesParamsValign(value);
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
        UpdateSubmitterFieldPreferencesParamsValign value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdateSubmitterFieldPreferencesParamsValign value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(UpdateSubmitterFieldPreferencesParamsValign value) =>
        value.Value;

    public static explicit operator UpdateSubmitterFieldPreferencesParamsValign(string value) =>
        new(value);

    internal class UpdateSubmitterFieldPreferencesParamsValignSerializer
        : JsonConverter<UpdateSubmitterFieldPreferencesParamsValign>
    {
        public override UpdateSubmitterFieldPreferencesParamsValign Read(
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
            return new UpdateSubmitterFieldPreferencesParamsValign(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateSubmitterFieldPreferencesParamsValign value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateSubmitterFieldPreferencesParamsValign ReadAsPropertyName(
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
            return new UpdateSubmitterFieldPreferencesParamsValign(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateSubmitterFieldPreferencesParamsValign value,
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
        public const string Top = "top";

        public const string Center = "center";

        public const string Bottom = "bottom";
    }
}
