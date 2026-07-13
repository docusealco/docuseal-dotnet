using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(UpdateSubmitterFieldPreferencesParamsBackground.UpdateSubmitterFieldPreferencesParamsBackgroundSerializer)
)]
[Serializable]
public readonly record struct UpdateSubmitterFieldPreferencesParamsBackground : IStringEnum
{
    public static readonly UpdateSubmitterFieldPreferencesParamsBackground Black = new(
        Values.Black
    );

    public static readonly UpdateSubmitterFieldPreferencesParamsBackground White = new(
        Values.White
    );

    public static readonly UpdateSubmitterFieldPreferencesParamsBackground Blue = new(Values.Blue);

    public UpdateSubmitterFieldPreferencesParamsBackground(string value)
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
    public static UpdateSubmitterFieldPreferencesParamsBackground FromCustom(string value)
    {
        return new UpdateSubmitterFieldPreferencesParamsBackground(value);
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
        UpdateSubmitterFieldPreferencesParamsBackground value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdateSubmitterFieldPreferencesParamsBackground value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(UpdateSubmitterFieldPreferencesParamsBackground value) =>
        value.Value;

    public static explicit operator UpdateSubmitterFieldPreferencesParamsBackground(string value) =>
        new(value);

    internal class UpdateSubmitterFieldPreferencesParamsBackgroundSerializer
        : JsonConverter<UpdateSubmitterFieldPreferencesParamsBackground>
    {
        public override UpdateSubmitterFieldPreferencesParamsBackground Read(
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
            return new UpdateSubmitterFieldPreferencesParamsBackground(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateSubmitterFieldPreferencesParamsBackground value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateSubmitterFieldPreferencesParamsBackground ReadAsPropertyName(
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
            return new UpdateSubmitterFieldPreferencesParamsBackground(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateSubmitterFieldPreferencesParamsBackground value,
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
