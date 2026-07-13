using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateTemplateDocumentFieldParamsType.CreateTemplateDocumentFieldParamsTypeSerializer)
)]
[Serializable]
public readonly record struct CreateTemplateDocumentFieldParamsType : IStringEnum
{
    public static readonly CreateTemplateDocumentFieldParamsType Heading = new(Values.Heading);

    public static readonly CreateTemplateDocumentFieldParamsType Text = new(Values.Text);

    public static readonly CreateTemplateDocumentFieldParamsType Signature = new(Values.Signature);

    public static readonly CreateTemplateDocumentFieldParamsType Initials = new(Values.Initials);

    public static readonly CreateTemplateDocumentFieldParamsType Date = new(Values.Date);

    public static readonly CreateTemplateDocumentFieldParamsType Number = new(Values.Number);

    public static readonly CreateTemplateDocumentFieldParamsType Image = new(Values.Image);

    public static readonly CreateTemplateDocumentFieldParamsType Checkbox = new(Values.Checkbox);

    public static readonly CreateTemplateDocumentFieldParamsType Multiple = new(Values.Multiple);

    public static readonly CreateTemplateDocumentFieldParamsType File = new(Values.File);

    public static readonly CreateTemplateDocumentFieldParamsType Radio = new(Values.Radio);

    public static readonly CreateTemplateDocumentFieldParamsType Select = new(Values.Select);

    public static readonly CreateTemplateDocumentFieldParamsType Cells = new(Values.Cells);

    public static readonly CreateTemplateDocumentFieldParamsType Stamp = new(Values.Stamp);

    public static readonly CreateTemplateDocumentFieldParamsType Payment = new(Values.Payment);

    public static readonly CreateTemplateDocumentFieldParamsType Phone = new(Values.Phone);

    public static readonly CreateTemplateDocumentFieldParamsType Verification = new(
        Values.Verification
    );

    public static readonly CreateTemplateDocumentFieldParamsType Kba = new(Values.Kba);

    public static readonly CreateTemplateDocumentFieldParamsType Strikethrough = new(
        Values.Strikethrough
    );

    public CreateTemplateDocumentFieldParamsType(string value)
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
    public static CreateTemplateDocumentFieldParamsType FromCustom(string value)
    {
        return new CreateTemplateDocumentFieldParamsType(value);
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

    public static bool operator ==(CreateTemplateDocumentFieldParamsType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateTemplateDocumentFieldParamsType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateTemplateDocumentFieldParamsType value) =>
        value.Value;

    public static explicit operator CreateTemplateDocumentFieldParamsType(string value) =>
        new(value);

    internal class CreateTemplateDocumentFieldParamsTypeSerializer
        : JsonConverter<CreateTemplateDocumentFieldParamsType>
    {
        public override CreateTemplateDocumentFieldParamsType Read(
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
            return new CreateTemplateDocumentFieldParamsType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateTemplateDocumentFieldParamsType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateTemplateDocumentFieldParamsType ReadAsPropertyName(
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
            return new CreateTemplateDocumentFieldParamsType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateTemplateDocumentFieldParamsType value,
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
