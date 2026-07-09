# DocuSeal .NET

.NET client for the [DocuSeal API](https://www.docuseal.com/docs/api). DocuSeal is an open source platform to create, fill and sign digital documents.

## Installation

```sh
dotnet add package Docuseal
```

Supports .NET Framework 4.6.2+, .NET Standard 2.0 and .NET 8/9.

## Configuration

Get your API key at [console.docuseal.com/api](https://console.docuseal.com/api).

### Global cloud (docuseal.com)

```csharp
var client = new DocusealClient(Environment.GetEnvironmentVariable("DOCUSEAL_API_KEY"));
```

### EU cloud (docuseal.eu)

```csharp
var client = new DocusealClient(
    Environment.GetEnvironmentVariable("DOCUSEAL_API_KEY"),
    new ClientOptions { BaseUrl = "https://api.docuseal.eu" });
```

### On-premises

```csharp
var client = new DocusealClient(
    Environment.GetEnvironmentVariable("DOCUSEAL_API_KEY"),
    new ClientOptions { BaseUrl = "https://yourdocuseal.com/api" });
```

`ClientOptions` also exposes `Timeout` and `MaxRetries`.

## Usage

### List templates

```csharp
var templates = await client.GetTemplatesAsync(new GetTemplatesParams { Limit = 20 });

foreach (var template in templates.Data)
{
    Console.WriteLine($"{template.Id} {template.Name}");
}
```

### Create a signature request

Models use `required` properties: forgetting a required field is a
compile-time error.

```csharp
var submission = await client.CreateSubmissionAsync(new CreateSubmissionParams
{
    TemplateId = 1000001,
    Submitters =
    [
        new CreateSubmissionRequestSubmitter { Role = "First Party", Email = "signer@example.com" },
    ],
});

Console.WriteLine(submission.Submitters.First().EmbedSrc);
```

### Track a submission

```csharp
var submission = await client.GetSubmissionAsync(1001);

Console.WriteLine(submission.Status);

foreach (var document in submission.Documents)
{
    Console.WriteLine($"{document.Name} {document.Url}");
}
```

### Handle errors

```csharp
try
{
    await client.GetTemplateAsync(42);
}
catch (DocusealClientApiException e)
{
    Console.WriteLine($"{e.StatusCode} {e.Message}");
}
```

## Regenerating the SDK

`src/Docuseal` is generated from the DocuSeal OpenAPI specification by
[Fern](https://buildwithfern.com) and is never edited by hand:

```sh
./generate-types.sh
```

Requires Node.js (`npx`), Docker and `ruby`.

## Documentation

Full API documentation: [docuseal.com/docs/api](https://www.docuseal.com/docs/api)

## License

MIT
