using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(TemplateFieldType.TemplateFieldTypeSerializer))]
[Serializable]
public readonly record struct TemplateFieldType : IStringEnum
{
    public static readonly TemplateFieldType Heading = new(Values.Heading);

    public static readonly TemplateFieldType Text = new(Values.Text);

    public static readonly TemplateFieldType Signature = new(Values.Signature);

    public static readonly TemplateFieldType Initials = new(Values.Initials);

    public static readonly TemplateFieldType Date = new(Values.Date);

    public static readonly TemplateFieldType Number = new(Values.Number);

    public static readonly TemplateFieldType Image = new(Values.Image);

    public static readonly TemplateFieldType Checkbox = new(Values.Checkbox);

    public static readonly TemplateFieldType Multiple = new(Values.Multiple);

    public static readonly TemplateFieldType File = new(Values.File);

    public static readonly TemplateFieldType Radio = new(Values.Radio);

    public static readonly TemplateFieldType Select = new(Values.Select);

    public static readonly TemplateFieldType Cells = new(Values.Cells);

    public static readonly TemplateFieldType Stamp = new(Values.Stamp);

    public static readonly TemplateFieldType Payment = new(Values.Payment);

    public static readonly TemplateFieldType Phone = new(Values.Phone);

    public static readonly TemplateFieldType Verification = new(Values.Verification);

    public static readonly TemplateFieldType Kba = new(Values.Kba);

    public static readonly TemplateFieldType Strikethrough = new(Values.Strikethrough);

    public TemplateFieldType(string value)
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
    public static TemplateFieldType FromCustom(string value)
    {
        return new TemplateFieldType(value);
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

    public static bool operator ==(TemplateFieldType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TemplateFieldType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TemplateFieldType value) => value.Value;

    public static explicit operator TemplateFieldType(string value) => new(value);

    internal class TemplateFieldTypeSerializer : JsonConverter<TemplateFieldType>
    {
        public override TemplateFieldType Read(
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
            return new TemplateFieldType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            TemplateFieldType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override TemplateFieldType ReadAsPropertyName(
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
            return new TemplateFieldType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            TemplateFieldType value,
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
