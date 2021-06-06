using backend_coding_challenge.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace backend_coding_challenge.GithubClient
{
    public class TrendingRepositoriesClient : ITrendingRepositoriesClient
    {
        private readonly IHttpClientFactory httpClientFactory;

        public TrendingRepositoriesClient(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<GithubRepositories> GetTrendingRepositoriesAsync()
        {
            Uri requestUri = RequestUriBuilder.BuildRequestUri();
            using (HttpClient httpClient = httpClientFactory.CreateClient())
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
                httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("backend_coding_challenge", "v1"));
                httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<GithubRepositories>(content);
            }
        }
    }
}
