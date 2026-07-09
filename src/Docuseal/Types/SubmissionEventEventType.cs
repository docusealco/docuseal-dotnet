using Docuseal.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Docuseal;

[JsonConverter(typeof(SubmissionEventEventType.SubmissionEventEventTypeSerializer))]
[Serializable]
public readonly record struct SubmissionEventEventType : IStringEnum
{
    public static readonly SubmissionEventEventType SendEmail = new(Values.SendEmail);

    public static readonly SubmissionEventEventType BounceEmail = new(Values.BounceEmail);

    public static readonly SubmissionEventEventType ComplaintEmail = new(Values.ComplaintEmail);

    public static readonly SubmissionEventEventType SendReminderEmail = new(
        Values.SendReminderEmail
    );

    public static readonly SubmissionEventEventType SendSms = new(Values.SendSms);

    public static readonly SubmissionEventEventType Send2FaSms = new(Values.Send2FaSms);

    public static readonly SubmissionEventEventType OpenEmail = new(Values.OpenEmail);

    public static readonly SubmissionEventEventType ClickEmail = new(Values.ClickEmail);

    public static readonly SubmissionEventEventType ClickSms = new(Values.ClickSms);

    public static readonly SubmissionEventEventType PhoneVerified = new(Values.PhoneVerified);

    public static readonly SubmissionEventEventType StartForm = new(Values.StartForm);

    public static readonly SubmissionEventEventType StartVerification = new(
        Values.StartVerification
    );

    public static readonly SubmissionEventEventType CompleteVerification = new(
        Values.CompleteVerification
    );

    public static readonly SubmissionEventEventType ViewForm = new(Values.ViewForm);

    public static readonly SubmissionEventEventType InviteParty = new(Values.InviteParty);

    public static readonly SubmissionEventEventType CompleteForm = new(Values.CompleteForm);

    public static readonly SubmissionEventEventType DeclineForm = new(Values.DeclineForm);

    public static readonly SubmissionEventEventType ApiCompleteForm = new(Values.ApiCompleteForm);

    public SubmissionEventEventType(string value)
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
    public static SubmissionEventEventType FromCustom(string value)
    {
        return new SubmissionEventEventType(value);
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

    public static bool operator ==(SubmissionEventEventType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubmissionEventEventType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubmissionEventEventType value) => value.Value;

    public static explicit operator SubmissionEventEventType(string value) => new(value);

    internal class SubmissionEventEventTypeSerializer : JsonConverter<SubmissionEventEventType>
    {
        public override SubmissionEventEventType Read(
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
            return new SubmissionEventEventType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubmissionEventEventType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubmissionEventEventType ReadAsPropertyName(
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
            return new SubmissionEventEventType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubmissionEventEventType value,
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
