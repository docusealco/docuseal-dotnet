using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateTemplateFromDocxRequestDocumentFieldType.CreateTemplateFromDocxRequestDocumentFieldTypeSerializer)
)]
[Serializable]
public readonly record struct CreateTemplateFromDocxRequestDocumentFieldType : IStringEnum
{
    public static readonly CreateTemplateFromDocxRequestDocumentFieldType Heading = new(
        Values.Heading
    );

    public static readonly CreateTemplateFromDocxRequestDocumentFieldType Text = new(Values.Text);

    public static readonly CreateTemplateFromDocxRequestDocumentFieldType Signature = new(
        Values.Signature
    );

    public static readonly CreateTemplateFromDocxRequestDocumentFieldType Initials = new(
        Values.Initials
    );

    public static readonly CreateTemplateFromDocxRequestDocumentFieldType Date = new(Values.Date);

    public static readonly CreateTemplateFromDocxRequestDocumentFieldType Number = new(
        Values.Number
    );

    public static readonly CreateTemplateFromDocxRequestDocumentFieldType Image = new(Values.Image);

    public static readonly CreateTemplateFromDocxRequestDocumentFieldType Checkbox = new(
        Values.Checkbox
    );

    public static readonly CreateTemplateFromDocxRequestDocumentFieldType Multiple = new(
        Values.Multiple
    );

    public static readonly CreateTemplateFromDocxRequestDocumentFieldType File = new(Values.File);

    public static readonly CreateTemplateFromDocxRequestDocumentFieldType Radio = new(Values.Radio);

    public static readonly CreateTemplateFromDocxRequestDocumentFieldType Select = new(
        Values.Select
    );

    public static readonly CreateTemplateFromDocxRequestDocumentFieldType Cells = new(Values.Cells);

    public static readonly CreateTemplateFromDocxRequestDocumentFieldType Stamp = new(Values.Stamp);

    public static readonly CreateTemplateFromDocxRequestDocumentFieldType Payment = new(
        Values.Payment
    );

    public static readonly CreateTemplateFromDocxRequestDocumentFieldType Phone = new(Values.Phone);

    public static readonly CreateTemplateFromDocxRequestDocumentFieldType Verification = new(
        Values.Verification
    );

    public static readonly CreateTemplateFromDocxRequestDocumentFieldType Kba = new(Values.Kba);

    public static readonly CreateTemplateFromDocxRequestDocumentFieldType Strikethrough = new(
        Values.Strikethrough
    );

    public CreateTemplateFromDocxRequestDocumentFieldType(string value)
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
    public static CreateTemplateFromDocxRequestDocumentFieldType FromCustom(string value)
    {
        return new CreateTemplateFromDocxRequestDocumentFieldType(value);
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
        CreateTemplateFromDocxRequestDocumentFieldType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateTemplateFromDocxRequestDocumentFieldType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateTemplateFromDocxRequestDocumentFieldType value) =>
        value.Value;

    public static explicit operator CreateTemplateFromDocxRequestDocumentFieldType(string value) =>
        new(value);

    internal class CreateTemplateFromDocxRequestDocumentFieldTypeSerializer
        : JsonConverter<CreateTemplateFromDocxRequestDocumentFieldType>
    {
        public override CreateTemplateFromDocxRequestDocumentFieldType Read(
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
            return new CreateTemplateFromDocxRequestDocumentFieldType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTemplateFromDocxRequestDocumentFieldType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateTemplateFromDocxRequestDocumentFieldType ReadAsPropertyName(
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
            return new CreateTemplateFromDocxRequestDocumentFieldType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTemplateFromDocxRequestDocumentFieldType value,
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
