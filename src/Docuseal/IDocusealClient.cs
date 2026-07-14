namespace Docuseal;

public partial interface IDocusealClient
{
    /// <summary>
    /// The API endpoint provides the ability to retrieve a list of available document templates.
    /// </summary>
    WithRawResponseTask<TemplateList> GetTemplatesAsync(
        GetTemplatesParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The API endpoint provides the functionality to retrieve information about a document template.
    /// </summary>
    WithRawResponseTask<Template> GetTemplateAsync(
        GetTemplateParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The API endpoint provides the functionality to move a document template to a different folder and update the name of the template.
    /// </summary>
    WithRawResponseTask<TemplateUpdateResult> UpdateTemplateAsync(
        UpdateTemplateParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The API endpoint allows you to archive a document template.
    /// </summary>
    WithRawResponseTask<TemplateArchiveResult> ArchiveTemplateAsync(
        ArchiveTemplateParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The API endpoint provides the ability to retrieve a list of available submissions.
    /// </summary>
    WithRawResponseTask<SubmissionList> GetSubmissionsAsync(
        GetSubmissionsParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The API endpoint provides the functionality to retrieve information about a submission.
    /// </summary>
    WithRawResponseTask<Submission> GetSubmissionAsync(
        GetSubmissionParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The API endpoint allows you to update a submission: change its name, expiration date, and archive or unarchive it.
    /// </summary>
    WithRawResponseTask<SubmissionUpdateResult> UpdateSubmissionAsync(
        UpdateSubmissionParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The API endpoint allows you to archive a submission.
    /// </summary>
    WithRawResponseTask<SubmissionArchiveResult> ArchiveSubmissionAsync(
        ArchiveSubmissionParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint returns a list of partially filled documents for a submission. If the submission has been completed, the final signed documents are returned.
    /// </summary>
    WithRawResponseTask<SubmissionDocuments> GetSubmissionDocumentsAsync(
        GetSubmissionDocumentsParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The API endpoint provides the functionality to create one-off submission request from a PDF. Use <c>{{Field Name;role=Signer1;type=date}}</c> text tags to define fillable fields in the document. See <see href="https://www.docuseal.com/examples/fieldtags.pdf">https://www.docuseal.com/examples/fieldtags.pdf</see> for more text tag formats. Or specify the exact pixel coordinates of the document fields using `fields` param.<br/><b>Related Guides</b><br/><see href="https://www.docuseal.com/guides/use-embedded-text-field-tags-in-the-pdf-to-create-a-fillable-form">Use embedded text field tags to create a fillable form</see>
    /// </summary>
    WithRawResponseTask<SubmissionCreateResult> CreateSubmissionFromPdfAsync(
        CreateSubmissionFromPdfParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The API endpoint provides functionality to create a one-off submission request from a DOCX file with dynamic content variables. Use <c>[[variable_name]]</c> text tags to define dynamic content variables in the document. See <see href="https://www.docuseal.com/examples/demo_template.docx">https://www.docuseal.com/examples/demo_template.docx</see> for the specific text variable syntax, including dynamic content tables and lists. You can also use the <c>{{signature}}</c> field syntax to define fillable fields, as in a PDF.<br/><b>Related Guides</b><br/><see href="https://www.docuseal.com/guides/use-dynamic-content-variables-in-docx-to-create-personalized-documents">Use dynamic content variables in DOCX to create personalized documents</see>
    /// </summary>
    WithRawResponseTask<SubmissionCreateResult> CreateSubmissionFromDocxAsync(
        CreateSubmissionFromDocxParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API endpoint allows you to create a one-off submission request document using the provided HTML content, with special field tags rendered as a fillable and signable form.<br/><b>Related Guides</b><br/><see href="https://www.docuseal.com/guides/create-pdf-document-fillable-form-with-html-api">Create PDF document fillable form with HTML</see>
    /// </summary>
    WithRawResponseTask<SubmissionCreateResult> CreateSubmissionFromHtmlAsync(
        CreateSubmissionFromHtmlParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The API endpoint provides functionality to retrieve information about a submitter, along with the submitter documents and field values.
    /// </summary>
    WithRawResponseTask<Submitter> GetSubmitterAsync(
        GetSubmitterParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The API endpoint allows you to update submitter details, pre-fill or update field values and re-send emails.<br/><b>Related Guides</b><br/><see href="https://www.docuseal.com/guides/pre-fill-pdf-document-form-fields-with-api#automatically_sign_documents_via_api">Automatically sign documents via API</see>
    /// </summary>
    WithRawResponseTask<SubmitterUpdateResult> UpdateSubmitterAsync(
        UpdateSubmitterParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The API endpoint provides the ability to retrieve a list of submitters.
    /// </summary>
    WithRawResponseTask<SubmitterList> GetSubmittersAsync(
        GetSubmittersParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The API endpoint allows you to add, remove or replace documents in the template with provided PDF/DOCX file or HTML content.
    /// </summary>
    WithRawResponseTask<Template> UpdateTemplateDocumentsAsync(
        UpdateTemplateDocumentsParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The API endpoint allows you to clone an existing template into a new template.
    /// </summary>
    WithRawResponseTask<Template> CloneTemplateAsync(
        CloneTemplateParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The API endpoint provides the functionality to seamlessly generate a PDF document template by utilizing the provided HTML content while incorporating pre-defined fields.<br/><b>Related Guides</b><br/><see href="https://www.docuseal.com/guides/create-pdf-document-fillable-form-with-html-api">Create PDF document fillable form with HTML</see>
    /// </summary>
    WithRawResponseTask<Template> CreateTemplateFromHtmlAsync(
        CreateTemplateFromHtmlParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The API endpoint provides the functionality to create a fillable document template for an existing Microsoft Word document. Use <c>{{Field Name;role=Signer1;type=date}}</c> text tags to define fillable fields in the document. See <see href="https://www.docuseal.com/examples/fieldtags.docx">https://www.docuseal.com/examples/fieldtags.docx</see> for more text tag formats. Or specify the exact pixel coordinates of the document fields using `fields` param.<br/><b>Related Guides</b><br/><see href="https://www.docuseal.com/guides/use-embedded-text-field-tags-in-the-pdf-to-create-a-fillable-form">Use embedded text field tags to create a fillable form</see>
    /// </summary>
    WithRawResponseTask<Template> CreateTemplateFromDocxAsync(
        CreateTemplateFromDocxParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The API endpoint provides the functionality to create a fillable document template for a PDF file. Use <c>{{Field Name;role=Signer1;type=date}}</c> text tags to define fillable fields in the document. See <see href="https://www.docuseal.com/examples/fieldtags.pdf">https://www.docuseal.com/examples/fieldtags.pdf</see> for more text tag formats. Or specify the exact pixel coordinates of the document fields using `fields` param.<br/><b>Related Guides</b><br/><see href="https://www.docuseal.com/guides/use-embedded-text-field-tags-in-the-pdf-to-create-a-fillable-form">Use embedded text field tags to create a fillable form</see>
    /// </summary>
    WithRawResponseTask<Template> CreateTemplateFromPdfAsync(
        CreateTemplateFromPdfParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The API endpoint allows you to merge multiple templates with documents and fields into a new combined template.
    /// </summary>
    WithRawResponseTask<Template> MergeTemplateAsync(
        MergeTemplateParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This API endpoint allows you to create signature requests (submissions) for a document template and send them to the specified submitters (signers).<br/><b>Related Guides</b><br/><see href="https://www.docuseal.com/guides/send-documents-for-signature-via-api">Send documents for signature via API</see><br/><see href="https://www.docuseal.com/guides/pre-fill-pdf-document-form-fields-with-api">Pre-fill PDF document form fields with API</see>
    /// </summary>
    WithRawResponseTask<SubmissionInitResult> CreateSubmissionAsync(
        CreateSubmissionParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
