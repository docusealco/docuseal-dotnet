using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(UpdateSubmitterFieldPreferencesParamsFont.UpdateSubmitterFieldPreferencesParamsFontSerializer)
)]
[Serializable]
public readonly record struct UpdateSubmitterFieldPreferencesParamsFont : IStringEnum
{
    public static readonly UpdateSubmitterFieldPreferencesParamsFont Times = new(Values.Times);

    public static readonly UpdateSubmitterFieldPreferencesParamsFont Helvetica = new(
        Values.Helvetica
    );

    public static readonly UpdateSubmitterFieldPreferencesParamsFont Courier = new(Values.Courier);

    public UpdateSubmitterFieldPreferencesParamsFont(string value)
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
    public static UpdateSubmitterFieldPreferencesParamsFont FromCustom(string value)
    {
        return new UpdateSubmitterFieldPreferencesParamsFont(value);
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
        UpdateSubmitterFieldPreferencesParamsFont value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UpdateSubmitterFieldPreferencesParamsFont value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(UpdateSubmitterFieldPreferencesParamsFont value) =>
        value.Value;

    public static explicit operator UpdateSubmitterFieldPreferencesParamsFont(string value) =>
        new(value);

    internal class UpdateSubmitterFieldPreferencesParamsFontSerializer
        : JsonConverter<UpdateSubmitterFieldPreferencesParamsFont>
    {
        public override UpdateSubmitterFieldPreferencesParamsFont Read(
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
            return new UpdateSubmitterFieldPreferencesParamsFont(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateSubmitterFieldPreferencesParamsFont value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UpdateSubmitterFieldPreferencesParamsFont ReadAsPropertyName(
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
            return new UpdateSubmitterFieldPreferencesParamsFont(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateSubmitterFieldPreferencesParamsFont value,
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
