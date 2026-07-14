# DocuSeal .NET

The DocuSeal .NET library provides seamless integration with the DocuSeal API, allowing developers to interact with DocuSeal's electronic signature and document management features directly within .NET applications. This library is designed to simplify API interactions and provide tools for efficient implementation.

## Documentation

Detailed documentation is available at [DocuSeal API Docs](https://www.docuseal.com/docs/api?lang=csharp).

## Installation

To install the library, run:

```sh
dotnet add package Docuseal
```

Supports .NET Framework 4.6.2+, .NET Standard 2.0 and .NET 8/9.

## Usage

### Configuration

Set up the library with your DocuSeal API key based on your deployment. Retrieve your API key from the appropriate location:

#### Global Cloud

API keys for the global cloud can be obtained from your [Global DocuSeal Console](https://console.docuseal.com/api).

```csharp
var client = new DocusealClient(Environment.GetEnvironmentVariable("DOCUSEAL_API_KEY"));
```

#### EU Cloud

API keys for the EU cloud can be obtained from your [EU DocuSeal Console](https://console.docuseal.eu/api).

```csharp
var client = new DocusealClient(
    Environment.GetEnvironmentVariable("DOCUSEAL_API_KEY"),
    new ClientOptions { BaseUrl = "https://api.docuseal.eu" });
```

#### On-Premises

For on-premises installations, API keys can be retrieved from the API settings page of your deployed application, e.g., https://yourdocusealapp.com/settings/api.

```csharp
var client = new DocusealClient(
    Environment.GetEnvironmentVariable("DOCUSEAL_API_KEY"),
    new ClientOptions { BaseUrl = "https://yourdocuseal.com/api" });
```

## API Methods

### GetSubmissionsAsync(params)

[Documentation](https://www.docuseal.com/docs/api?lang=csharp#list-all-submissions)

Provides the ability to retrieve a list of available submissions.


```csharp
var submissions = await client.GetSubmissionsAsync(new GetSubmissionsParams { Limit = 10 });
```

### GetSubmissionAsync(id)

[Documentation](https://www.docuseal.com/docs/api?lang=csharp#get-a-submission)

Provides the functionality to retrieve information about a submission.


```csharp
var submission = await client.GetSubmissionAsync(new GetSubmissionParams { Id = 1001 });
```

### GetSubmissionDocumentsAsync(id)

[Documentation](https://www.docuseal.com/docs/api?lang=csharp#get-submission-documents)

This endpoint returns a list of partially filled documents for a submission. If the submission has been completed, the final signed documents are returned.


```csharp
var submission = await client.GetSubmissionDocumentsAsync(new GetSubmissionDocumentsParams { Id = 1001 });
```

### CreateSubmissionAsync(data)

[Documentation](https://www.docuseal.com/docs/api?lang=csharp#create-a-submission)

This API endpoint allows you to create signature requests (submissions) for a document template and send them to the specified submitters (signers).

**Related Guides:**<br>
[Send documents for signature via API](https://www.docuseal.com/guides/send-documents-for-signature-via-api)
[Pre-fill PDF document form fields with API](https://www.docuseal.com/guides/pre-fill-pdf-document-form-fields-with-api)


```csharp
var submission = await client.CreateSubmissionAsync(new CreateSubmissionParams
{
    TemplateId = 1000001,
    SendEmail = true,
    Submitters = [
        new CreateSubmissionSubmitterParams
        {
            Role = "First Party",
            Email = "john.doe@example.com"
        },
    ]
});
```

### CreateSubmissionFromPdfAsync(data)

[Documentation](https://www.docuseal.com/docs/api?lang=csharp#create-a-submission-from-pdf)

Provides the functionality to create one-off submission request from a PDF. Use `{{Field Name;role=Signer1;type=date}}` text tags to define fillable fields in the document. See [https://www.docuseal.com/examples/fieldtags.pdf](https://www.docuseal.com/examples/fieldtags.pdf) for more text tag formats. Or specify the exact pixel coordinates of the document fields using `fields` param.

**Related Guides:**<br>
[Use embedded text field tags to create a fillable form](https://www.docuseal.com/guides/use-embedded-text-field-tags-in-the-pdf-to-create-a-fillable-form)


```csharp
var submission = await client.CreateSubmissionFromPdfAsync(new CreateSubmissionFromPdfParams
{
    Name = "Test Submission Document",
    Documents = [
        new CreateSubmissionFromPdfDocumentParams
        {
            Name = "string",
            File = "base64",
            Fields = [
                new CreateSubmissionDocumentFieldParams
                {
                    Name = "string",
                    Areas = [
                        new CreateSubmissionDocumentFieldAreaParams
                        {
                            X = 0,
                            Y = 0,
                            W = 0,
                            H = 0,
                            Page = 1
                        },
                    ]
                },
            ]
        },
    ],
    Submitters = [
        new CreateSubmissionSubmitterParams
        {
            Role = "First Party",
            Email = "john.doe@example.com"
        },
    ]
});
```

### CreateSubmissionFromDocxAsync(data)

[Documentation](https://www.docuseal.com/docs/api?lang=csharp#create-a-submission-from-docx)

Provides functionality to create a one-off submission request from a DOCX file with dynamic content variables. Use `[[variable_name]]` text tags to define dynamic content variables in the document. See [https://www.docuseal.com/examples/demo\_template.docx](https://www.docuseal.com/examples/demo_template.docx) for the specific text variable syntax, including dynamic content tables and lists. You can also use the `{{signature}}` field syntax to define fillable fields, as in a PDF.

**Related Guides:**<br>
[Use dynamic content variables in DOCX to create personalized documents](https://www.docuseal.com/guides/use-dynamic-content-variables-in-docx-to-create-personalized-documents)


```csharp
var submission = await client.CreateSubmissionFromDocxAsync(new CreateSubmissionFromDocxParams
{
    Name = "Test Submission Document",
    Variables = new Dictionary<string, object?> { ["variable_name"] = "value" },
    Documents = [
        new CreateSubmissionFromDocxDocumentParams
        {
            Name = "string",
            File = "base64"
        },
    ],
    Submitters = [
        new CreateSubmissionSubmitterParams
        {
            Role = "First Party",
            Email = "john.doe@example.com"
        },
    ]
});
```

### CreateSubmissionFromHtmlAsync(data)

[Documentation](https://www.docuseal.com/docs/api?lang=csharp#create-a-submission-from-html)

This API endpoint allows you to create a one-off submission request document using the provided HTML content, with special field tags rendered as a fillable and signable form.

**Related Guides:**<br>
[Create PDF document fillable form with HTML](https://www.docuseal.com/guides/create-pdf-document-fillable-form-with-html-api)


```csharp
var submission = await client.CreateSubmissionFromHtmlAsync(new CreateSubmissionFromHtmlParams
{
    Name = "Test Submission Document",
    Documents = [
        new CreateSubmissionFromHtmlDocumentParams
        {
            Name = "Test Document",
            Html = """
<p>Lorem Ipsum is simply dummy text of the
<text-field
  name="Industry"
  role="First Party"
  required="false"
  style="width: 80px; height: 16px; display: inline-block; margin-bottom: -4px">
</text-field>
and typesetting industry</p>
"""
        },
    ],
    Submitters = [
        new CreateSubmissionSubmitterParams
        {
            Role = "First Party",
            Email = "john.doe@example.com"
        },
    ]
});
```

### UpdateSubmissionAsync(id, data)

[Documentation](https://www.docuseal.com/docs/api?lang=csharp#update-a-submission)

Allows you to update a submission: change its name, expiration date, and archive or unarchive it.


```csharp
var submission = await client.UpdateSubmissionAsync(new UpdateSubmissionParams
{
    Id = 1001,
    Name = "New Submission Name",
    ExpireAt = "2024-09-01 12:00:00 UTC",
    Archived = true
});
```

### ArchiveSubmissionAsync(id)

[Documentation](https://www.docuseal.com/docs/api?lang=csharp#archive-a-submission)

Allows you to archive a submission.


```csharp
await client.ArchiveSubmissionAsync(new ArchiveSubmissionParams { Id = 1001 });
```

### GetSubmittersAsync(params)

[Documentation](https://www.docuseal.com/docs/api?lang=csharp#list-all-submitters)

Provides the ability to retrieve a list of submitters.


```csharp
var submitters = await client.GetSubmittersAsync(new GetSubmittersParams { Limit = 10 });
```

### GetSubmitterAsync(id)

[Documentation](https://www.docuseal.com/docs/api?lang=csharp#get-a-submitter)

Provides functionality to retrieve information about a submitter, along with the submitter documents and field values.


```csharp
var submitter = await client.GetSubmitterAsync(new GetSubmitterParams { Id = 500001 });
```

### UpdateSubmitterAsync(id, data)

[Documentation](https://www.docuseal.com/docs/api?lang=csharp#update-a-submitter)

Allows you to update submitter details, pre-fill or update field values and re-send emails.

**Related Guides:**<br>
[Automatically sign documents via API](https://www.docuseal.com/guides/pre-fill-pdf-document-form-fields-with-api#automatically_sign_documents_via_api)


```csharp
var submitter = await client.UpdateSubmitterAsync(new UpdateSubmitterParams
{
    Id = 500001,
    Email = "john.doe@example.com",
    Fields = [
        new UpdateSubmitterFieldParams
        {
            Name = "First Name",
            DefaultValue = "Acme"
        },
    ]
});
```

### GetTemplatesAsync(params)

[Documentation](https://www.docuseal.com/docs/api?lang=csharp#list-all-templates)

Provides the ability to retrieve a list of available document templates.


```csharp
var templates = await client.GetTemplatesAsync(new GetTemplatesParams { Limit = 10 });
```

### GetTemplateAsync(id)

[Documentation](https://www.docuseal.com/docs/api?lang=csharp#get-a-template)

Provides the functionality to retrieve information about a document template.


```csharp
var template = await client.GetTemplateAsync(new GetTemplateParams { Id = 1000001 });
```

### CreateTemplateFromPdfAsync(data)

[Documentation](https://www.docuseal.com/docs/api?lang=csharp#create-a-template-from-pdf)

Provides the functionality to create a fillable document template for a PDF file. Use `{{Field Name;role=Signer1;type=date}}` text tags to define fillable fields in the document. See [https://www.docuseal.com/examples/fieldtags.pdf](https://www.docuseal.com/examples/fieldtags.pdf) for more text tag formats. Or specify the exact pixel coordinates of the document fields using `fields` param.

**Related Guides:**<br>
[Use embedded text field tags to create a fillable form](https://www.docuseal.com/guides/use-embedded-text-field-tags-in-the-pdf-to-create-a-fillable-form)


```csharp
var template = await client.CreateTemplateFromPdfAsync(new CreateTemplateFromPdfParams
{
    Name = "Test PDF",
    Documents = [
        new CreateTemplateFromPdfDocumentParams
        {
            Name = "string",
            File = "base64",
            Fields = [
                new CreateTemplateDocumentFieldParams
                {
                    Name = "string",
                    Areas = [
                        new CreateTemplateDocumentFieldAreaParams
                        {
                            X = 0,
                            Y = 0,
                            W = 0,
                            H = 0,
                            Page = 1
                        },
                    ]
                },
            ]
        },
    ]
});
```

### CreateTemplateFromDocxAsync(data)

[Documentation](https://www.docuseal.com/docs/api?lang=csharp#create-a-template-from-word-docx)

Provides the functionality to create a fillable document template for an existing Microsoft Word document. Use `{{Field Name;role=Signer1;type=date}}` text tags to define fillable fields in the document. See [https://www.docuseal.com/examples/fieldtags.docx](https://www.docuseal.com/examples/fieldtags.docx) for more text tag formats. Or specify the exact pixel coordinates of the document fields using `fields` param.

**Related Guides:**<br>
[Use embedded text field tags to create a fillable form](https://www.docuseal.com/guides/use-embedded-text-field-tags-in-the-pdf-to-create-a-fillable-form)


```csharp
var template = await client.CreateTemplateFromDocxAsync(new CreateTemplateFromDocxParams
{
    Name = "Test DOCX",
    Documents = [
        new CreateTemplateFromDocxDocumentParams
        {
            Name = "string",
            File = "base64"
        },
    ]
});
```

### CreateTemplateFromHtmlAsync(data)

[Documentation](https://www.docuseal.com/docs/api?lang=csharp#create-a-template-from-html)

Provides the functionality to seamlessly generate a PDF document template by utilizing the provided HTML content while incorporating pre-defined fields.

**Related Guides:**<br>
[Create PDF document fillable form with HTML](https://www.docuseal.com/guides/create-pdf-document-fillable-form-with-html-api)


```csharp
var template = await client.CreateTemplateFromHtmlAsync(new CreateTemplateFromHtmlParams
{
    Html = """
<p>Lorem Ipsum is simply dummy text of the
<text-field
  name="Industry"
  role="First Party"
  required="false"
  style="width: 80px; height: 16px; display: inline-block; margin-bottom: -4px">
</text-field>
and typesetting industry</p>
""",
    Name = "Test Template"
});
```

### CloneTemplateAsync(id, data)

[Documentation](https://www.docuseal.com/docs/api?lang=csharp#clone-a-template)

Allows you to clone an existing template into a new template.


```csharp
var template = await client.CloneTemplateAsync(new CloneTemplateParams
{
    Id = 1000001,
    Name = "Cloned Template"
});
```

### MergeTemplateAsync(data)

[Documentation](https://www.docuseal.com/docs/api?lang=csharp#merge-templates)

Allows you to merge multiple templates with documents and fields into a new combined template.


```csharp
var template = await client.MergeTemplateAsync(new MergeTemplateParams
{
    TemplateIds = [321, 432],
    Name = "Merged Template"
});
```

### UpdateTemplateAsync(id, data)

[Documentation](https://www.docuseal.com/docs/api?lang=csharp#update-a-template)


Provides the functionality to move a document template to a different folder and update the name of the template.


```csharp
var template = await client.UpdateTemplateAsync(new UpdateTemplateParams
{
    Id = 1000001,
    Name = "New Document Name",
    FolderName = "New Folder"
});
```

### UpdateTemplateDocumentsAsync(id, data)

[Documentation](https://www.docuseal.com/docs/api?lang=csharp#update-template-documents)

Allows you to add, remove or replace documents in the template with provided PDF/DOCX file or HTML content.


```csharp
var template = await client.UpdateTemplateDocumentsAsync(new UpdateTemplateDocumentsParams
{
    Id = 1000001,
    Documents = [
        new UpdateTemplateDocumentsDocumentParams
        {
            File = "string"
        },
    ]
});
```

### ArchiveTemplateAsync(id)

[Documentation](https://www.docuseal.com/docs/api?lang=csharp#archive-a-template)

Allows you to archive a document template.


```csharp
await client.ArchiveTemplateAsync(new ArchiveTemplateParams { Id = 1000001 });
```

## Support

For feature requests or bug reports, visit our [GitHub Issues page](https://github.com/docusealco/docuseal-dotnet/issues).


## License

The gem is available as open source under the terms of the [MIT License](https://opensource.org/licenses/MIT).
