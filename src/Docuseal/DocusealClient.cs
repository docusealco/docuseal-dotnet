using Docuseal.Core;
using global::System.Text.Json;

namespace Docuseal;

public partial class DocusealClient : IDocusealClient
{
    private readonly RawClient _client;

    public DocusealClient(string? apiKey = null, ClientOptions? clientOptions = null)
    {
        clientOptions ??= new ClientOptions();
        var platformHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "Docuseal" },
                { "X-Fern-SDK-Version", Version.Current },
            }
        );
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

    private async Task<WithRawResponse<GetTemplatesResponse>> GetTemplatesAsyncCore(
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
                var responseData = JsonUtils.Deserialize<GetTemplatesResponse>(responseBody)!;
                return new WithRawResponse<GetTemplatesResponse>()
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

    private async Task<WithRawResponse<GetTemplateResponse>> GetTemplateAsyncCore(
        GetTemplateParams request,
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
                    Path = string.Format(
                        "templates/{0}",
                        ValueConvert.ToPathParameterString(request.Id)
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
                var responseData = JsonUtils.Deserialize<GetTemplateResponse>(responseBody)!;
                return new WithRawResponse<GetTemplateResponse>()
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

    private async Task<WithRawResponse<UpdateTemplateResponse>> UpdateTemplateAsyncCore(
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
                    Path = string.Format(
                        "templates/{0}",
                        ValueConvert.ToPathParameterString(request.Id)
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
                var responseData = JsonUtils.Deserialize<UpdateTemplateResponse>(responseBody)!;
                return new WithRawResponse<UpdateTemplateResponse>()
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

    private async Task<WithRawResponse<ArchiveTemplateResponse>> ArchiveTemplateAsyncCore(
        ArchiveTemplateParams request,
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
                        "templates/{0}",
                        ValueConvert.ToPathParameterString(request.Id)
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
                var responseData = JsonUtils.Deserialize<ArchiveTemplateResponse>(responseBody)!;
                return new WithRawResponse<ArchiveTemplateResponse>()
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

    private async Task<WithRawResponse<GetSubmissionsResponse>> GetSubmissionsAsyncCore(
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
                var responseData = JsonUtils.Deserialize<GetSubmissionsResponse>(responseBody)!;
                return new WithRawResponse<GetSubmissionsResponse>()
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

    private async Task<WithRawResponse<GetSubmissionResponse>> GetSubmissionAsyncCore(
        GetSubmissionParams request,
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
                    Path = string.Format(
                        "submissions/{0}",
                        ValueConvert.ToPathParameterString(request.Id)
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
                var responseData = JsonUtils.Deserialize<GetSubmissionResponse>(responseBody)!;
                return new WithRawResponse<GetSubmissionResponse>()
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

    private async Task<WithRawResponse<ArchiveSubmissionResponse>> ArchiveSubmissionAsyncCore(
        ArchiveSubmissionParams request,
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
                        "submissions/{0}",
                        ValueConvert.ToPathParameterString(request.Id)
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
                var responseData = JsonUtils.Deserialize<ArchiveSubmissionResponse>(responseBody)!;
                return new WithRawResponse<ArchiveSubmissionResponse>()
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
        WithRawResponse<GetSubmissionDocumentsResponse>
    > GetSubmissionDocumentsAsyncCore(
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
                        ValueConvert.ToPathParameterString(request.Id)
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
                var responseData = JsonUtils.Deserialize<GetSubmissionDocumentsResponse>(
                    responseBody
                )!;
                return new WithRawResponse<GetSubmissionDocumentsResponse>()
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
        WithRawResponse<IEnumerable<CreateSubmissionsFromEmailsResponseItem>>
    > CreateSubmissionsFromEmailsAsyncCore(
        CreateSubmissionsFromEmailsParams request,
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
                    Path = "submissions/emails",
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
                var responseData = JsonUtils.Deserialize<
                    IEnumerable<CreateSubmissionsFromEmailsResponseItem>
                >(responseBody)!;
                return new WithRawResponse<IEnumerable<CreateSubmissionsFromEmailsResponseItem>>()
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
        WithRawResponse<CreateSubmissionFromPdfResponse>
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
                var responseData = JsonUtils.Deserialize<CreateSubmissionFromPdfResponse>(
                    responseBody
                )!;
                return new WithRawResponse<CreateSubmissionFromPdfResponse>()
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
        WithRawResponse<CreateSubmissionFromPdfResponse>
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
                var responseData = JsonUtils.Deserialize<CreateSubmissionFromPdfResponse>(
                    responseBody
                )!;
                return new WithRawResponse<CreateSubmissionFromPdfResponse>()
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
        WithRawResponse<CreateSubmissionFromPdfResponse>
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
                var responseData = JsonUtils.Deserialize<CreateSubmissionFromPdfResponse>(
                    responseBody
                )!;
                return new WithRawResponse<CreateSubmissionFromPdfResponse>()
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

    private async Task<WithRawResponse<GetSubmitterResponse>> GetSubmitterAsyncCore(
        GetSubmitterParams request,
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
                    Path = string.Format(
                        "submitters/{0}",
                        ValueConvert.ToPathParameterString(request.Id)
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
                var responseData = JsonUtils.Deserialize<GetSubmitterResponse>(responseBody)!;
                return new WithRawResponse<GetSubmitterResponse>()
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

    private async Task<WithRawResponse<UpdateSubmitterResponse>> UpdateSubmitterAsyncCore(
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
                    Path = string.Format(
                        "submitters/{0}",
                        ValueConvert.ToPathParameterString(request.Id)
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
                var responseData = JsonUtils.Deserialize<UpdateSubmitterResponse>(responseBody)!;
                return new WithRawResponse<UpdateSubmitterResponse>()
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

    private async Task<WithRawResponse<GetSubmittersResponse>> GetSubmittersAsyncCore(
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
                var responseData = JsonUtils.Deserialize<GetSubmittersResponse>(responseBody)!;
                return new WithRawResponse<GetSubmittersResponse>()
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

    private async Task<WithRawResponse<GetTemplateResponse>> AddDocumentToTemplateAsyncCore(
        AddDocumentToTemplateParams request,
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
                        ValueConvert.ToPathParameterString(request.Id)
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
                var responseData = JsonUtils.Deserialize<GetTemplateResponse>(responseBody)!;
                return new WithRawResponse<GetTemplateResponse>()
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

    private async Task<WithRawResponse<GetTemplateResponse>> CloneTemplateAsyncCore(
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
                        ValueConvert.ToPathParameterString(request.Id)
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
                var responseData = JsonUtils.Deserialize<GetTemplateResponse>(responseBody)!;
                return new WithRawResponse<GetTemplateResponse>()
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

    private async Task<WithRawResponse<GetTemplateResponse>> CreateTemplateFromHtmlAsyncCore(
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
                var responseData = JsonUtils.Deserialize<GetTemplateResponse>(responseBody)!;
                return new WithRawResponse<GetTemplateResponse>()
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

    private async Task<WithRawResponse<GetTemplateResponse>> CreateTemplateFromDocxAsyncCore(
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
                var responseData = JsonUtils.Deserialize<GetTemplateResponse>(responseBody)!;
                return new WithRawResponse<GetTemplateResponse>()
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

    private async Task<WithRawResponse<GetTemplateResponse>> CreateTemplateFromPdfAsyncCore(
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
                var responseData = JsonUtils.Deserialize<GetTemplateResponse>(responseBody)!;
                return new WithRawResponse<GetTemplateResponse>()
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

    private async Task<WithRawResponse<GetTemplateResponse>> MergeTemplateAsyncCore(
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
                var responseData = JsonUtils.Deserialize<GetTemplateResponse>(responseBody)!;
                return new WithRawResponse<GetTemplateResponse>()
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

    private async Task<WithRawResponse<CreateSubmissionResponse>> CreateSubmissionAsyncCore(
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
                var responseData = JsonUtils.Deserialize<CreateSubmissionResponse>(responseBody)!;
                return new WithRawResponse<CreateSubmissionResponse>()
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
    public WithRawResponseTask<GetTemplatesResponse> GetTemplatesAsync(
        GetTemplatesParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetTemplatesResponse>(
            GetTemplatesAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint provides the functionality to retrieve information about a document template.
    /// </summary>
    /// <example><code>
    /// await client.GetTemplateAsync(new GetTemplateParams { Id = 1 });
    /// </code></example>
    public WithRawResponseTask<GetTemplateResponse> GetTemplateAsync(
        GetTemplateParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetTemplateResponse>(
            GetTemplateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint provides the functionality to move a document template to a different folder and update the name of the template.
    /// </summary>
    /// <example><code>
    /// await client.UpdateTemplateAsync(new UpdateTemplateParams { Id = 1 });
    /// </code></example>
    public WithRawResponseTask<UpdateTemplateResponse> UpdateTemplateAsync(
        UpdateTemplateParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<UpdateTemplateResponse>(
            UpdateTemplateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint allows you to archive a document template.
    /// </summary>
    /// <example><code>
    /// await client.ArchiveTemplateAsync(new ArchiveTemplateParams { Id = 1 });
    /// </code></example>
    public WithRawResponseTask<ArchiveTemplateResponse> ArchiveTemplateAsync(
        ArchiveTemplateParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ArchiveTemplateResponse>(
            ArchiveTemplateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint provides the ability to retrieve a list of available submissions.
    /// </summary>
    /// <example><code>
    /// await client.GetSubmissionsAsync(new GetSubmissionsParams { Slug = "NtLDQM7eJX2ZMd" });
    /// </code></example>
    public WithRawResponseTask<GetSubmissionsResponse> GetSubmissionsAsync(
        GetSubmissionsParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetSubmissionsResponse>(
            GetSubmissionsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint provides the functionality to retrieve information about a submission.
    /// </summary>
    /// <example><code>
    /// await client.GetSubmissionAsync(new GetSubmissionParams { Id = 1 });
    /// </code></example>
    public WithRawResponseTask<GetSubmissionResponse> GetSubmissionAsync(
        GetSubmissionParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetSubmissionResponse>(
            GetSubmissionAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint allows you to archive a submission.
    /// </summary>
    /// <example><code>
    /// await client.ArchiveSubmissionAsync(new ArchiveSubmissionParams { Id = 1 });
    /// </code></example>
    public WithRawResponseTask<ArchiveSubmissionResponse> ArchiveSubmissionAsync(
        ArchiveSubmissionParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<ArchiveSubmissionResponse>(
            ArchiveSubmissionAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This endpoint returns a list of partially filled documents for a submission. If the submission has been completed, the final signed documents are returned.
    /// </summary>
    /// <example><code>
    /// await client.GetSubmissionDocumentsAsync(new GetSubmissionDocumentsParams { Id = 1 });
    /// </code></example>
    public WithRawResponseTask<GetSubmissionDocumentsResponse> GetSubmissionDocumentsAsync(
        GetSubmissionDocumentsParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetSubmissionDocumentsResponse>(
            GetSubmissionDocumentsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// This API endpoint allows you to create submissions for a document template and send them to the specified email addresses. This is a simplified version of the POST /submissions API to be used with Zapier or other automation tools.
    /// </summary>
    /// <example><code>
    /// await client.CreateSubmissionsFromEmailsAsync(
    ///     new CreateSubmissionsFromEmailsParams { TemplateId = 1000001, Emails = "{{emails}}" }
    /// );
    /// </code></example>
    public WithRawResponseTask<
        IEnumerable<CreateSubmissionsFromEmailsResponseItem>
    > CreateSubmissionsFromEmailsAsync(
        CreateSubmissionsFromEmailsParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<IEnumerable<CreateSubmissionsFromEmailsResponseItem>>(
            CreateSubmissionsFromEmailsAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint provides the functionality to create one-off submission request from a PDF. Use <c>{{Field Name;role=Signer1;type=date}}</c> text tags to define fillable fields in the document. See <see href="https://www.docuseal.com/examples/fieldtags.pdf">https://www.docuseal.com/examples/fieldtags.pdf</see> for more text tag formats. Or specify the exact pixel coordinates of the document fields using `fields` param.<br/><b>Related Guides</b><br/><see href="https://www.docuseal.com/guides/use-embedded-text-field-tags-in-the-pdf-to-create-a-fillable-form">Use embedded text field tags to create a fillable form</see>
    /// </summary>
    /// <example><code>
    /// await client.CreateSubmissionFromPdfAsync(
    ///     new CreateSubmissionFromPdfParams
    ///     {
    ///         Documents = new List&lt;CreateSubmissionFromPdfRequestDocument&gt;()
    ///         {
    ///             new CreateSubmissionFromPdfRequestDocument { Name = "name", File = "base64" },
    ///         },
    ///         Submitters = new List&lt;CreateSubmissionFromPdfRequestSubmitter&gt;()
    ///         {
    ///             new CreateSubmissionFromPdfRequestSubmitter(),
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CreateSubmissionFromPdfResponse> CreateSubmissionFromPdfAsync(
        CreateSubmissionFromPdfParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateSubmissionFromPdfResponse>(
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
    ///         Documents = new List&lt;CreateSubmissionFromDocxRequestDocument&gt;()
    ///         {
    ///             new CreateSubmissionFromDocxRequestDocument { Name = "name", File = "base64" },
    ///         },
    ///         Submitters = new List&lt;CreateSubmissionFromPdfRequestSubmitter&gt;()
    ///         {
    ///             new CreateSubmissionFromPdfRequestSubmitter(),
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CreateSubmissionFromPdfResponse> CreateSubmissionFromDocxAsync(
        CreateSubmissionFromDocxParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateSubmissionFromPdfResponse>(
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
    ///         Documents = new List&lt;CreateSubmissionFromHtmlRequestDocument&gt;()
    ///         {
    ///             new CreateSubmissionFromHtmlRequestDocument
    ///             {
    ///                 Html =
    ///                     "<para>Lorem Ipsum is simply dummy text of the\n&lt;text-field\n  name=\"Industry\"\n  role=\"First Party\"\n  required=\"false\"\n  style=\"width: 80px; height: 16px; display: inline-block; margin-bottom: -4px\"&gt;\n&lt;/text-field&gt;\nand typesetting industry</para>\n",
    ///             },
    ///         },
    ///         Submitters = new List&lt;CreateSubmissionFromPdfRequestSubmitter&gt;()
    ///         {
    ///             new CreateSubmissionFromPdfRequestSubmitter(),
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CreateSubmissionFromPdfResponse> CreateSubmissionFromHtmlAsync(
        CreateSubmissionFromHtmlParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateSubmissionFromPdfResponse>(
            CreateSubmissionFromHtmlAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint provides functionality to retrieve information about a submitter, along with the submitter documents and field values.
    /// </summary>
    /// <example><code>
    /// await client.GetSubmitterAsync(new GetSubmitterParams { Id = 1 });
    /// </code></example>
    public WithRawResponseTask<GetSubmitterResponse> GetSubmitterAsync(
        GetSubmitterParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetSubmitterResponse>(
            GetSubmitterAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint allows you to update submitter details, pre-fill or update field values and re-send emails.<br/><b>Related Guides</b><br/><see href="https://www.docuseal.com/guides/pre-fill-pdf-document-form-fields-with-api#automatically_sign_documents_via_api">Automatically sign documents via API</see>
    /// </summary>
    /// <example><code>
    /// await client.UpdateSubmitterAsync(new UpdateSubmitterParams { Id = 1 });
    /// </code></example>
    public WithRawResponseTask<UpdateSubmitterResponse> UpdateSubmitterAsync(
        UpdateSubmitterParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<UpdateSubmitterResponse>(
            UpdateSubmitterAsyncCore(request, options, cancellationToken)
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
    public WithRawResponseTask<GetSubmittersResponse> GetSubmittersAsync(
        GetSubmittersParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetSubmittersResponse>(
            GetSubmittersAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint allows you to add, remove or replace documents in the template with provided PDF/DOCX file or HTML content.
    /// </summary>
    /// <example><code>
    /// await client.AddDocumentToTemplateAsync(new AddDocumentToTemplateParams { Id = 1 });
    /// </code></example>
    public WithRawResponseTask<GetTemplateResponse> AddDocumentToTemplateAsync(
        AddDocumentToTemplateParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetTemplateResponse>(
            AddDocumentToTemplateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint allows you to clone an existing template into a new template.
    /// </summary>
    /// <example><code>
    /// await client.CloneTemplateAsync(new CloneTemplateParams { Id = 1 });
    /// </code></example>
    public WithRawResponseTask<GetTemplateResponse> CloneTemplateAsync(
        CloneTemplateParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetTemplateResponse>(
            CloneTemplateAsyncCore(request, options, cancellationToken)
        );
    }

    /// <summary>
    /// The API endpoint provides the functionality to seamlessly generate a PDF document template by utilizing the provided HTML content while incorporating pre-defined fields.<br/><b>Related Guides</b><br/><see href="https://www.docuseal.com/guides/create-pdf-document-fillable-form-with-html-api">Create PDF document fillable form with HTML</see>
    /// </summary>
    /// <example><code>
    /// await client.CreateTemplateFromHtmlAsync(
    ///     new CreateTemplateFromHtmlParams
    ///     {
    ///         Html =
    ///             "<para>Lorem Ipsum is simply dummy text of the\n&lt;text-field\n  name=\"Industry\"\n  role=\"First Party\"\n  required=\"false\"\n  style=\"width: 80px; height: 16px; display: inline-block; margin-bottom: -4px\"&gt;\n&lt;/text-field&gt;\nand typesetting industry</para>\n",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<GetTemplateResponse> CreateTemplateFromHtmlAsync(
        CreateTemplateFromHtmlParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetTemplateResponse>(
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
    ///         Documents = new List&lt;CreateTemplateFromDocxRequestDocument&gt;()
    ///         {
    ///             new CreateTemplateFromDocxRequestDocument { Name = "name", File = "base64" },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<GetTemplateResponse> CreateTemplateFromDocxAsync(
        CreateTemplateFromDocxParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetTemplateResponse>(
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
    ///         Documents = new List&lt;CreateTemplateFromPdfRequestDocument&gt;()
    ///         {
    ///             new CreateTemplateFromPdfRequestDocument { Name = "name", File = "base64" },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<GetTemplateResponse> CreateTemplateFromPdfAsync(
        CreateTemplateFromPdfParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetTemplateResponse>(
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
    public WithRawResponseTask<GetTemplateResponse> MergeTemplateAsync(
        MergeTemplateParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetTemplateResponse>(
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
    ///         Submitters = new List&lt;CreateSubmissionRequestSubmitter&gt;()
    ///         {
    ///             new CreateSubmissionRequestSubmitter(),
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<CreateSubmissionResponse> CreateSubmissionAsync(
        CreateSubmissionParams request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<CreateSubmissionResponse>(
            CreateSubmissionAsyncCore(request, options, cancellationToken)
        );
    }
}
