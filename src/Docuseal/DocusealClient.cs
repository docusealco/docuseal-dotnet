using Docuseal.Core;
using global::System.Text.Json;

namespace Docuseal;

public partial class DocusealClient : IDocusealClient
{
    private readonly RawClient _client;

    /// <summary>
    /// Initializes a new client using the given base URL (e.g. <see cref="DocusealClientEnvironment.EU"/>).
    /// </summary>
    /// <example><code>
    /// var client = new DocusealClient(apiKey, DocusealClientEnvironment.EU);
    /// </code></example>
    public DocusealClient(string? apiKey, string baseUrl)
        : this(apiKey, new ClientOptions { BaseUrl = baseUrl }) { }

    /// <summary>
    /// Initializes a new client using the given base URL together with additional client options.
    /// The explicit <paramref name="baseUrl"/> takes precedence over <see cref="ClientOptions.BaseUrl"/>.
    /// </summary>
    /// <example><code>
    /// var client = new DocusealClient(apiKey, DocusealClientEnvironment.EU, new ClientOptions { Timeout = TimeSpan.FromSeconds(30) });
    /// </code></example>
    public DocusealClient(string? apiKey, string baseUrl, ClientOptions clientOptions)
        : this(
            apiKey,
            new ClientOptions
            {
                BaseUrl = baseUrl,
                HttpClient = clientOptions.HttpClient,
                MaxRetries = clientOptions.MaxRetries,
                Timeout = clientOptions.Timeout,
                Headers = new Headers(new Dictionary<string, HeaderValue>(clientOptions.Headers)),
                AdditionalHeaders = clientOptions.AdditionalHeaders,
            }
        ) { }

    public DocusealClient(string? apiKey = null, ClientOptions? clientOptions = null)
    {
        clientOptions ??= new ClientOptions();
        var platformHeaders = new Headers(new Dictionary<string, string>() { { "User-Agent", "DocuSeal C# v1.0.2" } });
        foreach (var header in platformHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        var clientOptionsWithAuth = clientOptions.Clone();
        var authHeaders = new Headers(
            new Dictionary<string, string>() { { "X-Auth-Token", apiKey ?? "" } }
        );
        foreach (var header in authHeaders)
        {
            clientOptionsWithAuth.Headers[header.Key] = header.Value;
        }
        _client = new RawClient(clientOptionsWithAuth);
    }

    private async Task<WithRawResponse<TemplateList>> GetTemplatesAsyncCore(
        GetTemplatesParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 9)
            .Add("q", request.Q)
            .Add("slug", request.Slug)
            .Add("external_id", request.ExternalId)
            .Add("folder", request.Folder)
            .Add("archived", request.Archived)
            .Add("shared", request.Shared)
            .Add("limit", request.Limit)
            .Add("after", request.After)
            .Add("before", request.Before)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "templates",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<TemplateList>(responseBody)!;
                return new WithRawResponse<TemplateList>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<WithRawResponse<Template>> GetTemplateAsyncCore(
        int id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = string.Format("templates/{0}", ValueConvert.ToPathParameterString(id)),
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<Template>(responseBody)!;
                return new WithRawResponse<Template>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<WithRawResponse<TemplateUpdateResult>> UpdateTemplateAsyncCore(
        int id,
        UpdateTemplateParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Put,
                    Path = string.Format("templates/{0}", ValueConvert.ToPathParameterString(id)),
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<TemplateUpdateResult>(responseBody)!;
                return new WithRawResponse<TemplateUpdateResult>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<WithRawResponse<TemplateArchiveResult>> ArchiveTemplateAsyncCore(
        int id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Delete,
                    Path = string.Format("templates/{0}", ValueConvert.ToPathParameterString(id)),
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<TemplateArchiveResult>(responseBody)!;
                return new WithRawResponse<TemplateArchiveResult>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<WithRawResponse<SubmissionList>> GetSubmissionsAsyncCore(
        GetSubmissionsParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 9)
            .Add("template_id", request.TemplateId)
            .Add("status", request.Status)
            .Add("q", request.Q)
            .Add("slug", request.Slug)
            .Add("template_folder", request.TemplateFolder)
            .Add("archived", request.Archived)
            .Add("limit", request.Limit)
            .Add("after", request.After)
            .Add("before", request.Before)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "submissions",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<SubmissionList>(responseBody)!;
                return new WithRawResponse<SubmissionList>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<WithRawResponse<Submission>> GetSubmissionAsyncCore(
        int id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = string.Format("submissions/{0}", ValueConvert.ToPathParameterString(id)),
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<Submission>(responseBody)!;
                return new WithRawResponse<Submission>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<WithRawResponse<SubmissionUpdateResult>> UpdateSubmissionAsyncCore(
        int id,
        UpdateSubmissionParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Put,
                    Path = string.Format("submissions/{0}", ValueConvert.ToPathParameterString(id)),
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<SubmissionUpdateResult>(responseBody)!;
                return new WithRawResponse<SubmissionUpdateResult>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<WithRawResponse<SubmissionArchiveResult>> ArchiveSubmissionAsyncCore(
        int id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Delete,
                    Path = string.Format("submissions/{0}", ValueConvert.ToPathParameterString(id)),
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<SubmissionArchiveResult>(responseBody)!;
                return new WithRawResponse<SubmissionArchiveResult>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<WithRawResponse<SubmissionDocuments>> GetSubmissionDocumentsAsyncCore(
        int id,
        GetSubmissionDocumentsParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("merge", request.Merge)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "submissions/{0}/documents",
                        ValueConvert.ToPathParameterString(id)
                    ),
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<SubmissionDocuments>(responseBody)!;
                return new WithRawResponse<SubmissionDocuments>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<
        WithRawResponse<SubmissionCreateOneoffResult>
    > CreateSubmissionFromPdfAsyncCore(
        CreateSubmissionFromPdfParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "submissions/pdf",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<SubmissionCreateOneoffResult>(
                    responseBody
                )!;
                return new WithRawResponse<SubmissionCreateOneoffResult>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<
        WithRawResponse<SubmissionCreateOneoffResult>
    > CreateSubmissionFromDocxAsyncCore(
        CreateSubmissionFromDocxParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "submissions/docx",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<SubmissionCreateOneoffResult>(
                    responseBody
                )!;
                return new WithRawResponse<SubmissionCreateOneoffResult>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<
        WithRawResponse<SubmissionCreateOneoffResult>
    > CreateSubmissionFromHtmlAsyncCore(
        CreateSubmissionFromHtmlParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "submissions/html",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<SubmissionCreateOneoffResult>(
                    responseBody
                )!;
                return new WithRawResponse<SubmissionCreateOneoffResult>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<WithRawResponse<Submitter>> GetSubmitterAsyncCore(
        int id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = string.Format("submitters/{0}", ValueConvert.ToPathParameterString(id)),
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<Submitter>(responseBody)!;
                return new WithRawResponse<Submitter>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<WithRawResponse<SubmitterUpdateResult>> UpdateSubmitterAsyncCore(
        int id,
        UpdateSubmitterParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Put,
                    Path = string.Format("submitters/{0}", ValueConvert.ToPathParameterString(id)),
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<SubmitterUpdateResult>(responseBody)!;
                return new WithRawResponse<SubmitterUpdateResult>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<WithRawResponse<SubmitterList>> GetSubmittersAsyncCore(
        GetSubmittersParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 9)
            .Add("submission_id", request.SubmissionId)
            .Add("q", request.Q)
            .Add("slug", request.Slug)
            .Add("completed_after", request.CompletedAfter)
            .Add("completed_before", request.CompletedBefore)
            .Add("external_id", request.ExternalId)
            .Add("limit", request.Limit)
            .Add("after", request.After)
            .Add("before", request.Before)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Get,
                    Path = "submitters",
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<SubmitterList>(responseBody)!;
                return new WithRawResponse<SubmitterList>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<WithRawResponse<Template>> UpdateTemplateDocumentsAsyncCore(
        int id,
        UpdateTemplateDocumentsParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "templates/{0}/documents",
                        ValueConvert.ToPathParameterString(id)
                    ),
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<Template>(responseBody)!;
                return new WithRawResponse<Template>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<WithRawResponse<Template>> CloneTemplateAsyncCore(
        int id,
        CloneTemplateParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "templates/{0}/clone",
                        ValueConvert.ToPathParameterString(id)
                    ),
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<Template>(responseBody)!;
                return new WithRawResponse<Template>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<WithRawResponse<Template>> CreateTemplateFromHtmlAsyncCore(
        CreateTemplateFromHtmlParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "templates/html",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<Template>(responseBody)!;
                return new WithRawResponse<Template>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<WithRawResponse<Template>> CreateTemplateFromDocxAsyncCore(
        CreateTemplateFromDocxParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "templates/docx",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<Template>(responseBody)!;
                return new WithRawResponse<Template>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<WithRawResponse<Template>> CreateTemplateFromPdfAsyncCore(
        CreateTemplateFromPdfParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "templates/pdf",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<Template>(responseBody)!;
                return new WithRawResponse<Template>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<WithRawResponse<Template>> MergeTemplateAsyncCore(
        MergeTemplateParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "templates/merge",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<Template>(responseBody)!;
                return new WithRawResponse<Template>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<WithRawResponse<SubmissionCreateResult>> CreateSubmissionAsyncCore(
        CreateSubmissionParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Post,
                    Path = "submissions/init",
                    Body = request,
                    QueryString = _queryString,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<SubmissionCreateResult>(responseBody)!;
                return new WithRawResponse<SubmissionCreateResult>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<
        WithRawResponse<TemplatePermanentlyDeleteResult>
    > PermanentlyDeleteTemplateAsyncCore(
        int id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "templates/{0}?permanently=true",
                        ValueConvert.ToPathParameterString(id)
                    ),
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<TemplatePermanentlyDeleteResult>(
                    responseBody
                )!;
                return new WithRawResponse<TemplatePermanentlyDeleteResult>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    private async Task<
        WithRawResponse<SubmissionPermanentlyDeleteResult>
    > PermanentlyDeleteSubmissionAsyncCore(
        int id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 0)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new Docuseal.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "submissions/{0}?permanently=true",
                        ValueConvert.ToPathParameterString(id)
                    ),
                    QueryString = _queryString,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<SubmissionPermanentlyDeleteResult>(
                    responseBody
                )!;
                return new WithRawResponse<SubmissionPermanentlyDeleteResult>()
                {
                    Data = responseData,
                    RawResponse = new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new DocusealClientApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e,
                    rawResponse: new Docuseal.RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    }
                );
            }
        }
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            throw new DocusealClientApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody,
                rawResponse: new Docuseal.RawResponse()
                {
                    StatusCode = response.Raw.StatusCode,
                    Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                    Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                }
            );
        }
    }

    /// <summary>
    /// The API endpoint provides the ability to retrieve a list of available document templates.
    /// </summary>
    /// <example><code>
    /// await client.GetTemplatesAsync(new GetTemplatesParams { Slug = "opaKWh8WWTAcVG" });
    /// </code></example>
    public WithRawResponseTask<TemplateList> GetTemplatesAsync(
        GetTemplatesParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<TemplateList>(
            GetTemplatesAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint provides the functionality to retrieve information about a document template.
    /// </summary>
    /// <example><code>
    /// await client.GetTemplateAsync(1);
    /// </code></example>
    public WithRawResponseTask<Template> GetTemplateAsync(
        int id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Template>(
            GetTemplateAsyncCore(id, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint provides the functionality to move a document template to a different folder and update the name of the template.
    /// </summary>
    /// <example><code>
    /// await client.UpdateTemplateAsync(1, new UpdateTemplateParams());
    /// </code></example>
    public WithRawResponseTask<TemplateUpdateResult> UpdateTemplateAsync(
        int id,
        UpdateTemplateParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<TemplateUpdateResult>(
            UpdateTemplateAsyncCore(id, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint allows you to archive a document template.
    /// </summary>
    /// <example><code>
    /// await client.ArchiveTemplateAsync(1);
    /// </code></example>
    public WithRawResponseTask<TemplateArchiveResult> ArchiveTemplateAsync(
        int id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<TemplateArchiveResult>(
            ArchiveTemplateAsyncCore(id, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint provides the ability to retrieve a list of available submissions.
    /// </summary>
    /// <example><code>
    /// await client.GetSubmissionsAsync(new GetSubmissionsParams { Slug = "NtLDQM7eJX2ZMd" });
    /// </code></example>
    public WithRawResponseTask<SubmissionList> GetSubmissionsAsync(
        GetSubmissionsParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SubmissionList>(
            GetSubmissionsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint provides the functionality to retrieve information about a submission.
    /// </summary>
    /// <example><code>
    /// await client.GetSubmissionAsync(1);
    /// </code></example>
    public WithRawResponseTask<Submission> GetSubmissionAsync(
        int id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Submission>(
            GetSubmissionAsyncCore(id, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint allows you to update a submission: change its name, expiration date, and archive or unarchive it.
    /// </summary>
    /// <example><code>
    /// await client.UpdateSubmissionAsync(1, new UpdateSubmissionParams());
    /// </code></example>
    public WithRawResponseTask<SubmissionUpdateResult> UpdateSubmissionAsync(
        int id,
        UpdateSubmissionParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SubmissionUpdateResult>(
            UpdateSubmissionAsyncCore(id, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint allows you to archive a submission.
    /// </summary>
    /// <example><code>
    /// await client.ArchiveSubmissionAsync(1);
    /// </code></example>
    public WithRawResponseTask<SubmissionArchiveResult> ArchiveSubmissionAsync(
        int id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SubmissionArchiveResult>(
            ArchiveSubmissionAsyncCore(id, options, cancellationToken)
        );
    }

    /// <summary>
    /// This endpoint returns a list of partially filled documents for a submission. If the submission has been completed, the final signed documents are returned.
    /// </summary>
    /// <example><code>
    /// await client.GetSubmissionDocumentsAsync(1, new GetSubmissionDocumentsParams());
    /// </code></example>
    public WithRawResponseTask<SubmissionDocuments> GetSubmissionDocumentsAsync(
        int id,
        GetSubmissionDocumentsParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SubmissionDocuments>(
            GetSubmissionDocumentsAsyncCore(id, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint provides the functionality to create one-off submission request from a PDF. Use <c>{{Field Name;role=Signer1;type=date}}</c> text tags to define fillable fields in the document. See <see href="https://www.docuseal.com/examples/fieldtags.pdf">https://www.docuseal.com/examples/fieldtags.pdf</see> for more text tag formats. Or specify the exact pixel coordinates of the document fields using `fields` param.<br/><b>Related Guides</b><br/><see href="https://www.docuseal.com/guides/use-embedded-text-field-tags-in-the-pdf-to-create-a-fillable-form">Use embedded text field tags to create a fillable form</see>
    /// </summary>
    /// <example><code>
    /// await client.CreateSubmissionFromPdfAsync(
    ///     new CreateSubmissionFromPdfParams
    ///     {
    ///         Documents = new List&lt;CreateSubmissionFromPdfDocumentParams&gt;()
    ///         {
    ///             new CreateSubmissionFromPdfDocumentParams { Name = "name", File = "base64" },
    ///         },
    ///         Submitters = new List&lt;CreateSubmissionSubmitterParams&gt;()
    ///         {
    ///             new CreateSubmissionSubmitterParams(),
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<SubmissionCreateOneoffResult> CreateSubmissionFromPdfAsync(
        CreateSubmissionFromPdfParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SubmissionCreateOneoffResult>(
            CreateSubmissionFromPdfAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint provides functionality to create a one-off submission request from a DOCX file with dynamic content variables. Use <c>[[variable_name]]</c> text tags to define dynamic content variables in the document. See <see href="https://www.docuseal.com/examples/demo_template.docx">https://www.docuseal.com/examples/demo_template.docx</see> for the specific text variable syntax, including dynamic content tables and lists. You can also use the <c>{{signature}}</c> field syntax to define fillable fields, as in a PDF.<br/><b>Related Guides</b><br/><see href="https://www.docuseal.com/guides/use-dynamic-content-variables-in-docx-to-create-personalized-documents">Use dynamic content variables in DOCX to create personalized documents</see>
    /// </summary>
    /// <example><code>
    /// await client.CreateSubmissionFromDocxAsync(
    ///     new CreateSubmissionFromDocxParams
    ///     {
    ///         Documents = new List&lt;CreateSubmissionFromDocxDocumentParams&gt;()
    ///         {
    ///             new CreateSubmissionFromDocxDocumentParams { Name = "name", File = "base64" },
    ///         },
    ///         Submitters = new List&lt;CreateSubmissionSubmitterParams&gt;()
    ///         {
    ///             new CreateSubmissionSubmitterParams(),
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<SubmissionCreateOneoffResult> CreateSubmissionFromDocxAsync(
        CreateSubmissionFromDocxParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SubmissionCreateOneoffResult>(
            CreateSubmissionFromDocxAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API endpoint allows you to create a one-off submission request document using the provided HTML content, with special field tags rendered as a fillable and signable form.<br/><b>Related Guides</b><br/><see href="https://www.docuseal.com/guides/create-pdf-document-fillable-form-with-html-api">Create PDF document fillable form with HTML</see>
    /// </summary>
    /// <example><code>
    /// await client.CreateSubmissionFromHtmlAsync(
    ///     new CreateSubmissionFromHtmlParams
    ///     {
    ///         Documents = new List&lt;CreateSubmissionFromHtmlDocumentParams&gt;()
    ///         {
    ///             new CreateSubmissionFromHtmlDocumentParams
    ///             {
    ///                 Html =
    ///                     "<para>Lorem Ipsum is simply dummy text of the\n&lt;text-field\n  name=\"Industry\"\n  role=\"First Party\"\n  required=\"false\"\n  style=\"width: 80px; height: 16px; display: inline-block; margin-bottom: -4px\"&gt;\n&lt;/text-field&gt;\nand typesetting industry</para>\n",
    ///             },
    ///         },
    ///         Submitters = new List&lt;CreateSubmissionSubmitterParams&gt;()
    ///         {
    ///             new CreateSubmissionSubmitterParams(),
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<SubmissionCreateOneoffResult> CreateSubmissionFromHtmlAsync(
        CreateSubmissionFromHtmlParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SubmissionCreateOneoffResult>(
            CreateSubmissionFromHtmlAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint provides functionality to retrieve information about a submitter, along with the submitter documents and field values.
    /// </summary>
    /// <example><code>
    /// await client.GetSubmitterAsync(1);
    /// </code></example>
    public WithRawResponseTask<Submitter> GetSubmitterAsync(
        int id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Submitter>(
            GetSubmitterAsyncCore(id, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint allows you to update submitter details, pre-fill or update field values and re-send emails.<br/><b>Related Guides</b><br/><see href="https://www.docuseal.com/guides/pre-fill-pdf-document-form-fields-with-api#automatically_sign_documents_via_api">Automatically sign documents via API</see>
    /// </summary>
    /// <example><code>
    /// await client.UpdateSubmitterAsync(1, new UpdateSubmitterParams());
    /// </code></example>
    public WithRawResponseTask<SubmitterUpdateResult> UpdateSubmitterAsync(
        int id,
        UpdateSubmitterParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SubmitterUpdateResult>(
            UpdateSubmitterAsyncCore(id, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint provides the ability to retrieve a list of submitters.
    /// </summary>
    /// <example><code>
    /// await client.GetSubmittersAsync(
    ///     new GetSubmittersParams
    ///     {
    ///         Slug = "zAyL9fH36Havvm",
    ///         CompletedAfter = new DateTime(2024, 03, 05, 09, 32, 20, 000),
    ///         CompletedBefore = new DateTime(2024, 03, 06, 19, 32, 20, 000),
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<SubmitterList> GetSubmittersAsync(
        GetSubmittersParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SubmitterList>(
            GetSubmittersAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint allows you to add, remove or replace documents in the template with provided PDF/DOCX file or HTML content.
    /// </summary>
    /// <example><code>
    /// await client.UpdateTemplateDocumentsAsync(1, new UpdateTemplateDocumentsParams());
    /// </code></example>
    public WithRawResponseTask<Template> UpdateTemplateDocumentsAsync(
        int id,
        UpdateTemplateDocumentsParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Template>(
            UpdateTemplateDocumentsAsyncCore(id, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint allows you to clone an existing template into a new template.
    /// </summary>
    /// <example><code>
    /// await client.CloneTemplateAsync(1, new CloneTemplateParams());
    /// </code></example>
    public WithRawResponseTask<Template> CloneTemplateAsync(
        int id,
        CloneTemplateParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Template>(
            CloneTemplateAsyncCore(id, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint provides the functionality to seamlessly generate a PDF document template by utilizing the provided HTML content while incorporating pre-defined fields.<br/><b>Related Guides</b><br/><see href="https://www.docuseal.com/guides/create-pdf-document-fillable-form-with-html-api">Create PDF document fillable form with HTML</see>
    /// </summary>
    /// <example><code>
    /// await client.CreateTemplateFromHtmlAsync(new CreateTemplateFromHtmlParams());
    /// </code></example>
    public WithRawResponseTask<Template> CreateTemplateFromHtmlAsync(
        CreateTemplateFromHtmlParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Template>(
            CreateTemplateFromHtmlAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint provides the functionality to create a fillable document template for an existing Microsoft Word document. Use <c>{{Field Name;role=Signer1;type=date}}</c> text tags to define fillable fields in the document. See <see href="https://www.docuseal.com/examples/fieldtags.docx">https://www.docuseal.com/examples/fieldtags.docx</see> for more text tag formats. Or specify the exact pixel coordinates of the document fields using `fields` param.<br/><b>Related Guides</b><br/><see href="https://www.docuseal.com/guides/use-embedded-text-field-tags-in-the-pdf-to-create-a-fillable-form">Use embedded text field tags to create a fillable form</see>
    /// </summary>
    /// <example><code>
    /// await client.CreateTemplateFromDocxAsync(
    ///     new CreateTemplateFromDocxParams
    ///     {
    ///         Documents = new List&lt;CreateTemplateFromDocxDocumentParams&gt;()
    ///         {
    ///             new CreateTemplateFromDocxDocumentParams { Name = "name", File = "base64" },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<Template> CreateTemplateFromDocxAsync(
        CreateTemplateFromDocxParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Template>(
            CreateTemplateFromDocxAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint provides the functionality to create a fillable document template for a PDF file. Use <c>{{Field Name;role=Signer1;type=date}}</c> text tags to define fillable fields in the document. See <see href="https://www.docuseal.com/examples/fieldtags.pdf">https://www.docuseal.com/examples/fieldtags.pdf</see> for more text tag formats. Or specify the exact pixel coordinates of the document fields using `fields` param.<br/><b>Related Guides</b><br/><see href="https://www.docuseal.com/guides/use-embedded-text-field-tags-in-the-pdf-to-create-a-fillable-form">Use embedded text field tags to create a fillable form</see>
    /// </summary>
    /// <example><code>
    /// await client.CreateTemplateFromPdfAsync(
    ///     new CreateTemplateFromPdfParams
    ///     {
    ///         Documents = new List&lt;CreateTemplateFromPdfDocumentParams&gt;()
    ///         {
    ///             new CreateTemplateFromPdfDocumentParams { Name = "name", File = "base64" },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<Template> CreateTemplateFromPdfAsync(
        CreateTemplateFromPdfParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Template>(
            CreateTemplateFromPdfAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint allows you to merge multiple templates with documents and fields into a new combined template.
    /// </summary>
    /// <example><code>
    /// await client.MergeTemplateAsync(
    ///     new MergeTemplateParams
    ///     {
    ///         TemplateIds = new List&lt;int&gt;() { 321, 432 },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<Template> MergeTemplateAsync(
        MergeTemplateParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<Template>(
            MergeTemplateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API endpoint allows you to create signature requests (submissions) for a document template and send them to the specified submitters (signers).<br/><b>Related Guides</b><br/><see href="https://www.docuseal.com/guides/send-documents-for-signature-via-api">Send documents for signature via API</see><br/><see href="https://www.docuseal.com/guides/pre-fill-pdf-document-form-fields-with-api">Pre-fill PDF document form fields with API</see>
    /// </summary>
    /// <example><code>
    /// await client.CreateSubmissionAsync(
    ///     new CreateSubmissionParams
    ///     {
    ///         TemplateId = 1000001,
    ///         Submitters = new List&lt;CreateSubmissionSubmitterParams&gt;()
    ///         {
    ///             new CreateSubmissionSubmitterParams(),
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<SubmissionCreateResult> CreateSubmissionAsync(
        CreateSubmissionParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SubmissionCreateResult>(
            CreateSubmissionAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint allows you to permanently delete a document template and all of its submissions.
    /// </summary>
    /// <example><code>
    /// await client.PermanentlyDeleteTemplateAsync(1);
    /// </code></example>
    public WithRawResponseTask<TemplatePermanentlyDeleteResult> PermanentlyDeleteTemplateAsync(
        int id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<TemplatePermanentlyDeleteResult>(
            PermanentlyDeleteTemplateAsyncCore(id, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint allows you to permanently delete a submission and all of its submitters and documents.
    /// </summary>
    /// <example><code>
    /// await client.PermanentlyDeleteSubmissionAsync(1);
    /// </code></example>
    public WithRawResponseTask<SubmissionPermanentlyDeleteResult> PermanentlyDeleteSubmissionAsync(
        int id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<SubmissionPermanentlyDeleteResult>(
            PermanentlyDeleteSubmissionAsyncCore(id, options, cancellationToken)
        );
    }
}
