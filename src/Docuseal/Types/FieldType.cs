using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(FieldType.FieldTypeSerializer))]
[Serializable]
public readonly record struct FieldType : IStringEnum
{
    public static readonly FieldType Heading = new(Values.Heading);

    public static readonly FieldType Text = new(Values.Text);

    public static readonly FieldType Signature = new(Values.Signature);

    public static readonly FieldType Initials = new(Values.Initials);

    public static readonly FieldType Date = new(Values.Date);

    public static readonly FieldType Number = new(Values.Number);

    public static readonly FieldType Image = new(Values.Image);

    public static readonly FieldType Checkbox = new(Values.Checkbox);

    public static readonly FieldType Multiple = new(Values.Multiple);

    public static readonly FieldType File = new(Values.File);

    public static readonly FieldType Radio = new(Values.Radio);

    public static readonly FieldType Select = new(Values.Select);

    public static readonly FieldType Cells = new(Values.Cells);

    public static readonly FieldType Stamp = new(Values.Stamp);

    public static readonly FieldType Payment = new(Values.Payment);

    public static readonly FieldType Phone = new(Values.Phone);

    public static readonly FieldType Verification = new(Values.Verification);

    public static readonly FieldType Kba = new(Values.Kba);

    public static readonly FieldType Strikethrough = new(Values.Strikethrough);

    public FieldType(string value)
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
    public static FieldType FromCustom(string value)
    {
        return new FieldType(value);
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

    public static bool operator ==(FieldType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(FieldType value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(FieldType value) => value.Value;

    public static explicit operator FieldType(string value) => new(value);

    internal class FieldTypeSerializer : JsonConverter<FieldType>
    {
        public override FieldType Read(
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
            return new FieldType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FieldType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FieldType ReadAsPropertyName(
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
            return new FieldType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FieldType value,
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
