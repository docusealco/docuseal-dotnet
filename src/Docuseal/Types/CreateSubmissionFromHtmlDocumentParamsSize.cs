using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateSubmissionFromHtmlDocumentParamsSize.CreateSubmissionFromHtmlDocumentParamsSizeSerializer)
)]
[Serializable]
public readonly record struct CreateSubmissionFromHtmlDocumentParamsSize : IStringEnum
{
    public static readonly CreateSubmissionFromHtmlDocumentParamsSize Letter = new(Values.Letter);

    public static readonly CreateSubmissionFromHtmlDocumentParamsSize Legal = new(Values.Legal);

    public static readonly CreateSubmissionFromHtmlDocumentParamsSize Tabloid = new(Values.Tabloid);

    public static readonly CreateSubmissionFromHtmlDocumentParamsSize Ledger = new(Values.Ledger);

    public static readonly CreateSubmissionFromHtmlDocumentParamsSize A0 = new(Values.A0);

    public static readonly CreateSubmissionFromHtmlDocumentParamsSize A1 = new(Values.A1);

    public static readonly CreateSubmissionFromHtmlDocumentParamsSize A2 = new(Values.A2);

    public static readonly CreateSubmissionFromHtmlDocumentParamsSize A3 = new(Values.A3);

    public static readonly CreateSubmissionFromHtmlDocumentParamsSize A4 = new(Values.A4);

    public static readonly CreateSubmissionFromHtmlDocumentParamsSize A5 = new(Values.A5);

    public static readonly CreateSubmissionFromHtmlDocumentParamsSize A6 = new(Values.A6);

    public CreateSubmissionFromHtmlDocumentParamsSize(string value)
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
    public static CreateSubmissionFromHtmlDocumentParamsSize FromCustom(string value)
    {
        return new CreateSubmissionFromHtmlDocumentParamsSize(value);
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
        CreateSubmissionFromHtmlDocumentParamsSize value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateSubmissionFromHtmlDocumentParamsSize value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateSubmissionFromHtmlDocumentParamsSize value) =>
        value.Value;

    public static explicit operator CreateSubmissionFromHtmlDocumentParamsSize(string value) =>
        new(value);

    internal class CreateSubmissionFromHtmlDocumentParamsSizeSerializer
        : JsonConverter<CreateSubmissionFromHtmlDocumentParamsSize>
    {
        public override CreateSubmissionFromHtmlDocumentParamsSize Read(
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
            return new CreateSubmissionFromHtmlDocumentParamsSize(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateSubmissionFromHtmlDocumentParamsSize value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateSubmissionFromHtmlDocumentParamsSize ReadAsPropertyName(
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
            return new CreateSubmissionFromHtmlDocumentParamsSize(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateSubmissionFromHtmlDocumentParamsSize value,
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
        public const string Letter = "Letter";

        public const string Legal = "Legal";

        public const string Tabloid = "Tabloid";

        public const string Ledger = "Ledger";

        public const string A0 = "A0";

        public const string A1 = "A1";

        public const string A2 = "A2";

        public const string A3 = "A3";

        public const string A4 = "A4";

        public const string A5 = "A5";

        public const string A6 = "A6";
    }
}
