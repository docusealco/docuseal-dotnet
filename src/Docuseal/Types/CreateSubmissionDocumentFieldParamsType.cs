using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(
    typeof(CreateSubmissionDocumentFieldParamsType.CreateSubmissionDocumentFieldParamsTypeSerializer)
)]
[Serializable]
public readonly record struct CreateSubmissionDocumentFieldParamsType : IStringEnum
{
    public static readonly CreateSubmissionDocumentFieldParamsType Heading = new(Values.Heading);

    public static readonly CreateSubmissionDocumentFieldParamsType Text = new(Values.Text);

    public static readonly CreateSubmissionDocumentFieldParamsType Signature = new(
        Values.Signature
    );

    public static readonly CreateSubmissionDocumentFieldParamsType Initials = new(Values.Initials);

    public static readonly CreateSubmissionDocumentFieldParamsType Date = new(Values.Date);

    public static readonly CreateSubmissionDocumentFieldParamsType Number = new(Values.Number);

    public static readonly CreateSubmissionDocumentFieldParamsType Image = new(Values.Image);

    public static readonly CreateSubmissionDocumentFieldParamsType Checkbox = new(Values.Checkbox);

    public static readonly CreateSubmissionDocumentFieldParamsType Multiple = new(Values.Multiple);

    public static readonly CreateSubmissionDocumentFieldParamsType File = new(Values.File);

    public static readonly CreateSubmissionDocumentFieldParamsType Radio = new(Values.Radio);

    public static readonly CreateSubmissionDocumentFieldParamsType Select = new(Values.Select);

    public static readonly CreateSubmissionDocumentFieldParamsType Cells = new(Values.Cells);

    public static readonly CreateSubmissionDocumentFieldParamsType Stamp = new(Values.Stamp);

    public static readonly CreateSubmissionDocumentFieldParamsType Payment = new(Values.Payment);

    public static readonly CreateSubmissionDocumentFieldParamsType Phone = new(Values.Phone);

    public static readonly CreateSubmissionDocumentFieldParamsType Verification = new(
        Values.Verification
    );

    public static readonly CreateSubmissionDocumentFieldParamsType Kba = new(Values.Kba);

    public static readonly CreateSubmissionDocumentFieldParamsType Strikethrough = new(
        Values.Strikethrough
    );

    public CreateSubmissionDocumentFieldParamsType(string value)
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
    public static CreateSubmissionDocumentFieldParamsType FromCustom(string value)
    {
        return new CreateSubmissionDocumentFieldParamsType(value);
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

    public static bool operator ==(CreateSubmissionDocumentFieldParamsType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreateSubmissionDocumentFieldParamsType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreateSubmissionDocumentFieldParamsType value) =>
        value.Value;

    public static explicit operator CreateSubmissionDocumentFieldParamsType(string value) =>
        new(value);

    internal class CreateSubmissionDocumentFieldParamsTypeSerializer
        : JsonConverter<CreateSubmissionDocumentFieldParamsType>
    {
        public override CreateSubmissionDocumentFieldParamsType Read(
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
            return new CreateSubmissionDocumentFieldParamsType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateSubmissionDocumentFieldParamsType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateSubmissionDocumentFieldParamsType ReadAsPropertyName(
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
            return new CreateSubmissionDocumentFieldParamsType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateSubmissionDocumentFieldParamsType value,
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
