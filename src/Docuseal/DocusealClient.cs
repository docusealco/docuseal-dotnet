using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Docuseal
{
    public partial class DocusealClient
    {
        public const string GlobalUrl = "https://api.docuseal.com";
        public const string EuUrl = "https://api.docuseal.eu";

        private const string Version = "1.0.0";

        private string _apiKey;

        public DocusealClient(string apiKey) : this(apiKey, GlobalUrl)
        {
        }

        public DocusealClient(string apiKey, string baseUrl) : this(apiKey, baseUrl, new HttpClient { Timeout = TimeSpan.FromSeconds(60) })
        {
        }

        public DocusealClient(string apiKey, string baseUrl, HttpClient httpClient) : this(httpClient)
        {
            _apiKey = apiKey;
            BaseUrl = baseUrl;
        }

        partial void PrepareRequest(HttpClient client, HttpRequestMessage request, StringBuilder urlBuilder)
        {
            request.Headers.Add("X-Auth-Token", _apiKey);
            request.Headers.Add("User-Agent", $"docuseal-dotnet/{Version}");
        }

        // POST /submissions/init is not in the public OpenAPI spec yet,
        // so this method and its response type are written by hand.
        public virtual async Task<CreateSubmissionResponse> CreateSubmissionAsync(CreateSubmissionRequest body, CancellationToken cancellationToken = default)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, BaseUrl.TrimEnd('/') + "/submissions/init");
            PrepareRequest(_httpClient, request, new StringBuilder());
            request.Content = new StringContent(JsonSerializer.Serialize(body, JsonSerializerSettings), Encoding.UTF8, "application/json");

            using var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            var data = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

            if ((int)response.StatusCode >= 400)
            {
                throw new DocusealException($"The HTTP status code of the response was not expected ({(int)response.StatusCode}).",
                    (int)response.StatusCode, data, new Dictionary<string, IEnumerable<string>>(), null);
            }

            return JsonSerializer.Deserialize<CreateSubmissionResponse>(data, JsonSerializerSettings);
        }
    }

    public partial class CreateSubmissionResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("submitters")]
        public ICollection<CreateSubmissionsFromEmailsResponseItem> Submitters { get; set; }

        [JsonPropertyName("expired_at")]
        public string ExpiredAt { get; set; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }
    }
}
