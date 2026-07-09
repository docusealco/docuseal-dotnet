using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateSubmissionFromPdfRequestDocumentFieldType.CreateSubmissionFromPdfRequestDocumentFieldTypeSerializer)
)]
[Serializable]
public readonly record struct CreateSubmissionFromPdfRequestDocumentFieldType : IStringEnum
{
    public static readonly CreateSubmissionFromPdfRequestDocumentFieldType Heading = new(
        Values.Heading
    );

    public static readonly CreateSubmissionFromPdfRequestDocumentFieldType Text = new(Values.Text);

    public static readonly CreateSubmissionFromPdfRequestDocumentFieldType Signature = new(
        Values.Signature
    );

    public static readonly CreateSubmissionFromPdfRequestDocumentFieldType Initials = new(
        Values.Initials
    );

    public static readonly CreateSubmissionFromPdfRequestDocumentFieldType Date = new(Values.Date);

    public static readonly CreateSubmissionFromPdfRequestDocumentFieldType Number = new(
        Values.Number
    );

    public static readonly CreateSubmissionFromPdfRequestDocumentFieldType Image = new(
        Values.Image
    );

    public static readonly CreateSubmissionFromPdfRequestDocumentFieldType Checkbox = new(
        Values.Checkbox
    );

    public static readonly CreateSubmissionFromPdfRequestDocumentFieldType Multiple = new(
        Values.Multiple
    );

    public static readonly CreateSubmissionFromPdfRequestDocumentFieldType File = new(Values.File);

    public static readonly CreateSubmissionFromPdfRequestDocumentFieldType Radio = new(
        Values.Radio
    );

    public static readonly CreateSubmissionFromPdfRequestDocumentFieldType Select = new(
        Values.Select
    );

    public static readonly CreateSubmissionFromPdfRequestDocumentFieldType Cells = new(
        Values.Cells
    );

    public static readonly CreateSubmissionFromPdfRequestDocumentFieldType Stamp = new(
        Values.Stamp
    );

    public static readonly CreateSubmissionFromPdfRequestDocumentFieldType Payment = new(
        Values.Payment
    );

    public static readonly CreateSubmissionFromPdfRequestDocumentFieldType Phone = new(
        Values.Phone
    );

    public static readonly CreateSubmissionFromPdfRequestDocumentFieldType Verification = new(
        Values.Verification
    );

    public static readonly CreateSubmissionFromPdfRequestDocumentFieldType Kba = new(Values.Kba);

    public static readonly CreateSubmissionFromPdfRequestDocumentFieldType Strikethrough = new(
        Values.Strikethrough
    );

    public CreateSubmissionFromPdfRequestDocumentFieldType(string value)
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
    public static CreateSubmissionFromPdfRequestDocumentFieldType FromCustom(string value)
    {
        return new CreateSubmissionFromPdfRequestDocumentFieldType(value);
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
        CreateSubmissionFromPdfRequestDocumentFieldType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateSubmissionFromPdfRequestDocumentFieldType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateSubmissionFromPdfRequestDocumentFieldType value) =>
        value.Value;

    public static explicit operator CreateSubmissionFromPdfRequestDocumentFieldType(string value) =>
        new(value);

    internal class CreateSubmissionFromPdfRequestDocumentFieldTypeSerializer
        : JsonConverter<CreateSubmissionFromPdfRequestDocumentFieldType>
    {
        public override CreateSubmissionFromPdfRequestDocumentFieldType Read(
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
            return new CreateSubmissionFromPdfRequestDocumentFieldType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateSubmissionFromPdfRequestDocumentFieldType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateSubmissionFromPdfRequestDocumentFieldType ReadAsPropertyName(
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
            return new CreateSubmissionFromPdfRequestDocumentFieldType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateSubmissionFromPdfRequestDocumentFieldType value,
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
        public const string Heading = "heading";

        public const string Text = "text";

        public const string Signature = "signature";

        public const string Initials = "initials";

        public const string Date = "date";

        public const string Number = "number";

        public const string Image = "image";

        public const string Checkbox = "checkbox";

        public const string Multiple = "multiple";

        public const string File = "file";

        public const string Radio = "radio";

        public const string Select = "select";

        public const string Cells = "cells";

        public const string Stamp = "stamp";

        public const string Payment = "payment";

        public const string Phone = "phone";

        public const string Verification = "verification";

        public const string Kba = "kba";

        public const string Strikethrough = "strikethrough";
    }
}
