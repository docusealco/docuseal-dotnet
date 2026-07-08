# DocuSeal .NET

.NET client for the [DocuSeal API](https://www.docuseal.com/docs/api). DocuSeal is an open source platform to create, fill and sign digital documents.

## Installation

```sh
dotnet add package Docuseal
```

Requires .NET 8.0+. No external dependencies.

## Configuration

Get your API key at [console.docuseal.com/api](https://console.docuseal.com/api).

### Global cloud (docuseal.com)

```csharp
var client = new DocusealClient(Environment.GetEnvironmentVariable("DOCUSEAL_API_KEY"));
```

### EU cloud (docuseal.eu)

```csharp
var client = new DocusealClient(Environment.GetEnvironmentVariable("DOCUSEAL_API_KEY"), DocusealClient.EuUrl);
```

### On-premises

```csharp
var client = new DocusealClient(Environment.GetEnvironmentVariable("DOCUSEAL_API_KEY"), "https://yourdocuseal.com/api");
```

## Usage

### List templates

```csharp
var templates = await client.GetTemplatesAsync(limit: 20);

foreach (var template in templates.Data)
{
    Console.WriteLine($"{template.Id} {template.Name}");
}
```

### Create a signature request

```csharp
var submission = await client.CreateSubmissionAsync(new CreateSubmissionRequest
{
    TemplateId = 1000001,
    Submitters = new List<CreateSubmissionRequestSubmitter>
    {
        new() { Role = "First Party", Email = "signer@example.com" }
    }
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
catch (DocusealException e)
{
    Console.WriteLine($"{e.StatusCode} {e.Message}");
}
```

All methods accept an optional `CancellationToken` as the last argument.

## Regenerating the client

`src/Docuseal/DocusealClient.g.cs` is generated from the DocuSeal OpenAPI
specification and is never edited by hand:

```sh
./generate-types.sh
```

Requires Node.js (`npx`), .NET and `ruby`.

## Documentation

Full API documentation: [docuseal.com/docs/api](https://www.docuseal.com/docs/api)

## License

MIT
