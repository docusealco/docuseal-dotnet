using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateTemplateFromPdfRequestDocumentFieldType.CreateTemplateFromPdfRequestDocumentFieldTypeSerializer)
)]
[Serializable]
public readonly record struct CreateTemplateFromPdfRequestDocumentFieldType : IStringEnum
{
    public static readonly CreateTemplateFromPdfRequestDocumentFieldType Heading = new(
        Values.Heading
    );

    public static readonly CreateTemplateFromPdfRequestDocumentFieldType Text = new(Values.Text);

    public static readonly CreateTemplateFromPdfRequestDocumentFieldType Signature = new(
        Values.Signature
    );

    public static readonly CreateTemplateFromPdfRequestDocumentFieldType Initials = new(
        Values.Initials
    );

    public static readonly CreateTemplateFromPdfRequestDocumentFieldType Date = new(Values.Date);

    public static readonly CreateTemplateFromPdfRequestDocumentFieldType Number = new(
        Values.Number
    );

    public static readonly CreateTemplateFromPdfRequestDocumentFieldType Image = new(Values.Image);

    public static readonly CreateTemplateFromPdfRequestDocumentFieldType Checkbox = new(
        Values.Checkbox
    );

    public static readonly CreateTemplateFromPdfRequestDocumentFieldType Multiple = new(
        Values.Multiple
    );

    public static readonly CreateTemplateFromPdfRequestDocumentFieldType File = new(Values.File);

    public static readonly CreateTemplateFromPdfRequestDocumentFieldType Radio = new(Values.Radio);

    public static readonly CreateTemplateFromPdfRequestDocumentFieldType Select = new(
        Values.Select
    );

    public static readonly CreateTemplateFromPdfRequestDocumentFieldType Cells = new(Values.Cells);

    public static readonly CreateTemplateFromPdfRequestDocumentFieldType Stamp = new(Values.Stamp);

    public static readonly CreateTemplateFromPdfRequestDocumentFieldType Payment = new(
        Values.Payment
    );

    public static readonly CreateTemplateFromPdfRequestDocumentFieldType Phone = new(Values.Phone);

    public static readonly CreateTemplateFromPdfRequestDocumentFieldType Verification = new(
        Values.Verification
    );

    public static readonly CreateTemplateFromPdfRequestDocumentFieldType Kba = new(Values.Kba);

    public static readonly CreateTemplateFromPdfRequestDocumentFieldType Strikethrough = new(
        Values.Strikethrough
    );

    public CreateTemplateFromPdfRequestDocumentFieldType(string value)
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
    public static CreateTemplateFromPdfRequestDocumentFieldType FromCustom(string value)
    {
        return new CreateTemplateFromPdfRequestDocumentFieldType(value);
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
        CreateTemplateFromPdfRequestDocumentFieldType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateTemplateFromPdfRequestDocumentFieldType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateTemplateFromPdfRequestDocumentFieldType value) =>
        value.Value;

    public static explicit operator CreateTemplateFromPdfRequestDocumentFieldType(string value) =>
        new(value);

    internal class CreateTemplateFromPdfRequestDocumentFieldTypeSerializer
        : JsonConverter<CreateTemplateFromPdfRequestDocumentFieldType>
    {
        public override CreateTemplateFromPdfRequestDocumentFieldType Read(
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
            return new CreateTemplateFromPdfRequestDocumentFieldType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTemplateFromPdfRequestDocumentFieldType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateTemplateFromPdfRequestDocumentFieldType ReadAsPropertyName(
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
            return new CreateTemplateFromPdfRequestDocumentFieldType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTemplateFromPdfRequestDocumentFieldType value,
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
