namespace Docuseal;

public partial class DocusealClient
{
    /// <summary>
    /// The API endpoint provides the ability to retrieve a list of available document templates.
    /// </summary>
    /// <example><code>
    /// await client.GetTemplatesAsync();
    /// </code></example>
    public WithRawResponseTask<TemplateList> GetTemplatesAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) => GetTemplatesAsync(new GetTemplatesParams(), options, cancellationToken);

    /// <summary>
    /// The API endpoint provides the ability to retrieve a list of available submissions.
    /// </summary>
    /// <example><code>
    /// await client.GetSubmissionsAsync();
    /// </code></example>
    public WithRawResponseTask<SubmissionList> GetSubmissionsAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) => GetSubmissionsAsync(new GetSubmissionsParams(), options, cancellationToken);

    /// <summary>
    /// The API endpoint provides the ability to retrieve a list of submitters.
    /// </summary>
    /// <example><code>
    /// await client.GetSubmittersAsync();
    /// </code></example>
    public WithRawResponseTask<SubmitterList> GetSubmittersAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) => GetSubmittersAsync(new GetSubmittersParams(), options, cancellationToken);

    /// <summary>
    /// This endpoint returns a list of partially filled documents for a submission. If the submission has been completed, the final signed documents are returned.
    /// </summary>
    /// <example><code>
    /// await client.GetSubmissionDocumentsAsync(1);
    /// </code></example>
    public WithRawResponseTask<SubmissionDocuments> GetSubmissionDocumentsAsync(
        int id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) => GetSubmissionDocumentsAsync(id, new GetSubmissionDocumentsParams(), options, cancellationToken);

    /// <summary>
    /// The API endpoint allows you to clone an existing template into a new template.
    /// </summary>
    /// <example><code>
    /// await client.CloneTemplateAsync(1);
    /// </code></example>
    public WithRawResponseTask<Template> CloneTemplateAsync(
        int id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    ) => CloneTemplateAsync(id, new CloneTemplateParams(), options, cancellationToken);
}

public partial interface IDocusealClient
{
    /// <summary>
    /// The API endpoint provides the ability to retrieve a list of available document templates.
    /// </summary>
    WithRawResponseTask<TemplateList> GetTemplatesAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The API endpoint provides the ability to retrieve a list of available submissions.
    /// </summary>
    WithRawResponseTask<SubmissionList> GetSubmissionsAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The API endpoint provides the ability to retrieve a list of submitters.
    /// </summary>
    WithRawResponseTask<SubmitterList> GetSubmittersAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint returns a list of partially filled documents for a submission. If the submission has been completed, the final signed documents are returned.
    /// </summary>
    WithRawResponseTask<SubmissionDocuments> GetSubmissionDocumentsAsync(
        int id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The API endpoint allows you to clone an existing template into a new template.
    /// </summary>
    WithRawResponseTask<Template> CloneTemplateAsync(
        int id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
