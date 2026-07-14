using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(PageSize.PageSizeSerializer))]
[Serializable]
public readonly record struct PageSize : IStringEnum
{
    public static readonly PageSize Letter = new(Values.Letter);

    public static readonly PageSize Legal = new(Values.Legal);

    public static readonly PageSize Tabloid = new(Values.Tabloid);

    public static readonly PageSize Ledger = new(Values.Ledger);

    public static readonly PageSize A0 = new(Values.A0);

    public static readonly PageSize A1 = new(Values.A1);

    public static readonly PageSize A2 = new(Values.A2);

    public static readonly PageSize A3 = new(Values.A3);

    public static readonly PageSize A4 = new(Values.A4);

    public static readonly PageSize A5 = new(Values.A5);

    public static readonly PageSize A6 = new(Values.A6);

    public PageSize(string value)
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
    public static PageSize FromCustom(string value)
    {
        return new PageSize(value);
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

    public static bool operator ==(PageSize value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(PageSize value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(PageSize value) => value.Value;

    public static explicit operator PageSize(string value) => new(value);

    internal class PageSizeSerializer : JsonConverter<PageSize>
    {
        public override PageSize Read(
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
            return new PageSize(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PageSize value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PageSize ReadAsPropertyName(
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
            return new PageSize(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PageSize value,
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
