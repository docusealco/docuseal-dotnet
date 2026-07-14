using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(EventType.EventTypeSerializer))]
[Serializable]
public readonly record struct EventType : IStringEnum
{
    public static readonly EventType FormViewed = new(Values.FormViewed);

    public static readonly EventType FormStarted = new(Values.FormStarted);

    public static readonly EventType FormCompleted = new(Values.FormCompleted);

    public static readonly EventType FormDeclined = new(Values.FormDeclined);

    public static readonly EventType SubmissionCreated = new(Values.SubmissionCreated);

    public static readonly EventType SubmissionCompleted = new(Values.SubmissionCompleted);

    public static readonly EventType SubmissionExpired = new(Values.SubmissionExpired);

    public static readonly EventType SubmissionArchived = new(Values.SubmissionArchived);

    public static readonly EventType TemplateCreated = new(Values.TemplateCreated);

    public static readonly EventType TemplateUpdated = new(Values.TemplateUpdated);

    public static readonly EventType TemplateArchived = new(Values.TemplateArchived);

    public EventType(string value)
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
    public static EventType FromCustom(string value)
    {
        return new EventType(value);
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

    public static bool operator ==(EventType value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(EventType value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(EventType value) => value.Value;

    public static explicit operator EventType(string value) => new(value);

    internal class EventTypeSerializer : JsonConverter<EventType>
    {
        public override EventType Read(
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
            return new EventType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventType ReadAsPropertyName(
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
            return new EventType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventType value,
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
        public const string FormViewed = "form.viewed";

        public const string FormStarted = "form.started";

        public const string FormCompleted = "form.completed";

        public const string FormDeclined = "form.declined";

        public const string SubmissionCreated = "submission.created";

        public const string SubmissionCompleted = "submission.completed";

        public const string SubmissionExpired = "submission.expired";

        public const string SubmissionArchived = "submission.archived";

        public const string TemplateCreated = "template.created";

        public const string TemplateUpdated = "template.updated";

        public const string TemplateArchived = "template.archived";
    }
}
