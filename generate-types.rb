#!/usr/bin/env ruby
# frozen_string_literal: true

# Regenerates src/Docuseal from the DocuSeal OpenAPI spec using Fern
# (runs the generator locally in Docker).
# Usage: ./generate-types.rb [path-or-url-to-openapi-json]

require 'fileutils'

Dir.chdir(__dir__)

# A local file argument must be an SDK-mode dump: ApiSpec.call(sdk: true).
spec = ARGV[0] || 'https://console.docuseal.com/openapi.yml?format=json&sdk=true'

if spec.start_with?('http')
  system('curl', '-sf', spec, '-o', 'openapi.tmp.json', exception: true)
else
  FileUtils.cp(spec, 'openapi.tmp.json')
end

FileUtils.rm_rf('.fern-out')
system({ 'CI' => 'true' }, 'npx', '-y', 'fern-api@5.67.1', 'generate', '--local', exception: true)

FileUtils.rm_rf('src')
FileUtils.mkdir_p('src')
FileUtils.cp_r('.fern-out/src/Docuseal', 'src/Docuseal')

# DELETE /<resource>/{id}?permanently=true has no own OpenAPI operation.

RESOURCES = [
  {
    entity: 'Template',
    path: 'templates',
    result: 'TemplateArchiveResult',
    id_description: 'The unique identifier of the document template.',
    description: 'The API endpoint allows you to permanently delete a document template and all of its submissions.'
  },
  {
    entity: 'Submission',
    path: 'submissions',
    result: 'SubmissionArchiveResult',
    id_description: 'The unique identifier of the submission.',
    description: 'The API endpoint allows you to permanently delete a submission and all of its submitters and documents.'
  }
].freeze

def append_methods(filename, methods)
  path = File.join('src/Docuseal', filename)
  content = File.read(path)
  raise "#{filename}: permanently delete methods already present" if content.include?('PermanentlyDelete')

  File.write(path, content.sub(/\}\s*\z/) { "\n#{methods}}\n" })
end

append_methods('IDocusealClient.cs', RESOURCES.map do |res|
  <<~CS.gsub(/^(?!$)/, '    ')
    /// <summary>
    /// #{res[:description]}
    /// </summary>
    WithRawResponseTask<#{res[:result]}> PermanentlyDelete#{res[:entity]}Async(
        PermanentlyDelete#{res[:entity]}Params request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
  CS
end.join("\n"))

append_methods('DocusealClient.cs', RESOURCES.map do |res|
  <<~CS.gsub(/^(?!$)/, '    ')
    /// <summary>
    /// #{res[:description]}
    /// </summary>
    /// <example><code>
    /// await client.PermanentlyDelete#{res[:entity]}Async(new PermanentlyDelete#{res[:entity]}Params { Id = 1 });
    /// </code></example>
    public WithRawResponseTask<#{res[:result]}> PermanentlyDelete#{res[:entity]}Async(
        PermanentlyDelete#{res[:entity]}Params request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<#{res[:result]}>(
            PermanentlyDelete#{res[:entity]}AsyncCore(request, options, cancellationToken)
        );
    }

    private async Task<WithRawResponse<#{res[:result]}>> PermanentlyDelete#{res[:entity]}AsyncCore(
        PermanentlyDelete#{res[:entity]}Params request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new Docuseal.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("permanently", "true")
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
                        "#{res[:path]}/{0}",
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
                var responseData = JsonUtils.Deserialize<#{res[:result]}>(responseBody)!;
                return new WithRawResponse<#{res[:result]}>()
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
  CS
end.join("\n"))

RESOURCES.each do |res|
  File.write(File.join('src/Docuseal/Requests', "PermanentlyDelete#{res[:entity]}Params.cs"), <<~CS)
    using Docuseal.Core;
    using global::System.Text.Json.Serialization;

    namespace Docuseal;

    [Serializable]
    public record PermanentlyDelete#{res[:entity]}Params
    {
        /// <summary>
        /// #{res[:id_description]}
        /// </summary>
        [JsonIgnore]
        public required int Id { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return JsonUtils.Serialize(this);
        }
    }
  CS
end

FileUtils.rm_rf('.fern-out')
FileUtils.rm_f('openapi.tmp.json')
