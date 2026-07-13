using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateSubmissionSubmitterFieldPreferencesParamsAlign.CreateSubmissionSubmitterFieldPreferencesParamsAlignSerializer)
)]
[Serializable]
public readonly record struct CreateSubmissionSubmitterFieldPreferencesParamsAlign : IStringEnum
{
    public static readonly CreateSubmissionSubmitterFieldPreferencesParamsAlign Left = new(
        Values.Left
    );

    public static readonly CreateSubmissionSubmitterFieldPreferencesParamsAlign Center = new(
        Values.Center
    );

    public static readonly CreateSubmissionSubmitterFieldPreferencesParamsAlign Right = new(
        Values.Right
    );

    public CreateSubmissionSubmitterFieldPreferencesParamsAlign(string value)
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
    public static CreateSubmissionSubmitterFieldPreferencesParamsAlign FromCustom(string value)
    {
        return new CreateSubmissionSubmitterFieldPreferencesParamsAlign(value);
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
        CreateSubmissionSubmitterFieldPreferencesParamsAlign value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateSubmissionSubmitterFieldPreferencesParamsAlign value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateSubmissionSubmitterFieldPreferencesParamsAlign value
    ) => value.Value;

    public static explicit operator CreateSubmissionSubmitterFieldPreferencesParamsAlign(
        string value
    ) => new(value);

    internal class CreateSubmissionSubmitterFieldPreferencesParamsAlignSerializer
        : JsonConverter<CreateSubmissionSubmitterFieldPreferencesParamsAlign>
    {
        public override CreateSubmissionSubmitterFieldPreferencesParamsAlign Read(
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
            return new CreateSubmissionSubmitterFieldPreferencesParamsAlign(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateSubmissionSubmitterFieldPreferencesParamsAlign value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateSubmissionSubmitterFieldPreferencesParamsAlign ReadAsPropertyName(
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
            return new CreateSubmissionSubmitterFieldPreferencesParamsAlign(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateSubmissionSubmitterFieldPreferencesParamsAlign value,
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
