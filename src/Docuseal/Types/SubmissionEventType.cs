using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(SubmissionEventType.SubmissionEventTypeSerializer))]
[Serializable]
public readonly record struct SubmissionEventType : IStringEnum
{
    public static readonly SubmissionEventType SendEmail = new(Values.SendEmail);

    public static readonly SubmissionEventType BounceEmail = new(Values.BounceEmail);

    public static readonly SubmissionEventType ComplaintEmail = new(Values.ComplaintEmail);

    public static readonly SubmissionEventType SendReminderEmail = new(Values.SendReminderEmail);

    public static readonly SubmissionEventType SendSms = new(Values.SendSms);

    public static readonly SubmissionEventType Send2FaSms = new(Values.Send2FaSms);

    public static readonly SubmissionEventType OpenEmail = new(Values.OpenEmail);

    public static readonly SubmissionEventType ClickEmail = new(Values.ClickEmail);

    public static readonly SubmissionEventType ClickSms = new(Values.ClickSms);

    public static readonly SubmissionEventType PhoneVerified = new(Values.PhoneVerified);

    public static readonly SubmissionEventType StartForm = new(Values.StartForm);

    public static readonly SubmissionEventType StartVerification = new(Values.StartVerification);

    public static readonly SubmissionEventType CompleteVerification = new(
        Values.CompleteVerification
    );

    public static readonly SubmissionEventType ViewForm = new(Values.ViewForm);

    public static readonly SubmissionEventType InviteParty = new(Values.InviteParty);

    public static readonly SubmissionEventType CompleteForm = new(Values.CompleteForm);

    public static readonly SubmissionEventType DeclineForm = new(Values.DeclineForm);

    public static readonly SubmissionEventType ApiCompleteForm = new(Values.ApiCompleteForm);

    public SubmissionEventType(string value)
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
    public static SubmissionEventType FromCustom(string value)
    {
        return new SubmissionEventType(value);
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

    public static bool operator ==(SubmissionEventType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubmissionEventType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubmissionEventType value) => value.Value;

    public static explicit operator SubmissionEventType(string value) => new(value);

    internal class SubmissionEventTypeSerializer : JsonConverter<SubmissionEventType>
    {
        public override SubmissionEventType Read(
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
            return new SubmissionEventType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubmissionEventType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubmissionEventType ReadAsPropertyName(
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
            return new SubmissionEventType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubmissionEventType value,
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
        public const string SendEmail = "send_email";

        public const string BounceEmail = "bounce_email";

        public const string ComplaintEmail = "complaint_email";

        public const string SendReminderEmail = "send_reminder_email";

        public const string SendSms = "send_sms";

        public const string Send2FaSms = "send_2fa_sms";

        public const string OpenEmail = "open_email";

        public const string ClickEmail = "click_email";

        public const string ClickSms = "click_sms";

        public const string PhoneVerified = "phone_verified";

        public const string StartForm = "start_form";

        public const string StartVerification = "start_verification";

        public const string CompleteVerification = "complete_verification";

        public const string ViewForm = "view_form";

        public const string InviteParty = "invite_party";

        public const string CompleteForm = "complete_form";

        public const string DeclineForm = "decline_form";

        public const string ApiCompleteForm = "api_complete_form";
    }
}
