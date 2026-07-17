using Docuseal.Core;
using global::System.IO;
using global::System.Text.Json;
using global::System.Threading;
using global::System.Threading.Tasks;

namespace Docuseal;

/// <summary>
/// Reads webhook events delivered to your own HTTP endpoint, such as
/// <see cref="FormCompletedEvent"/>.
/// <para>
/// Event types cannot be deserialized by a host framework's model binding: they rely on
/// converters that <see cref="DocusealClient"/> registers on its own
/// <see cref="JsonSerializerOptions"/>, and a framework binds request bodies with its own.
/// Parse the request body with these methods instead of binding it.
/// </para>
/// <example>
/// <code>
/// [HttpPost]
/// public async Task&lt;IActionResult&gt; Post()
/// {
///     var payload = await WebhookEvent.ParseAsync&lt;FormCompletedEvent&gt;(Request.Body);
///     ...
/// }
/// </code>
/// </example>
/// </summary>
public static class WebhookEvent
{
    /// <summary>
    /// Reads a webhook event from a JSON string.
    /// <para>
    /// Absent properties deserialize to null or the default value rather than throwing, as
    /// they do everywhere else in this client, so that a payload carrying fields this version
    /// does not know about is still delivered to your handler.
    /// </para>
    /// </summary>
    /// <exception cref="JsonException">The payload is not valid JSON for a <typeparamref name="T"/>.</exception>
    public static T? Parse<T>(string json) =>
        JsonSerializer.Deserialize<T>(json, JsonOptions.JsonSerializerOptions);

    /// <summary>
    /// Reads a webhook event from a JSON stream, such as an unbuffered request body.
    /// <para>
    /// Absent properties deserialize to null or the default value rather than throwing, as
    /// they do everywhere else in this client, so that a payload carrying fields this version
    /// does not know about is still delivered to your handler.
    /// </para>
    /// </summary>
    /// <exception cref="JsonException">The payload is not valid JSON for a <typeparamref name="T"/>.</exception>
    public static ValueTask<T?> ParseAsync<T>(
        Stream json,
        CancellationToken cancellationToken = default
    ) => JsonSerializer.DeserializeAsync<T>(json, JsonOptions.JsonSerializerOptions, cancellationToken);
}
