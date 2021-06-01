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
        public async Task<GithubRepositories> GetTrendingReposAsync()
        {
            Uri requestUri = RequestUriBuilder.BuildRequestUri();
            using (var httpClient = new HttpClient())
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri);
                httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("backend_coding_challenge", "v1"));
                HttpResponseMessage response = await httpClient.SendAsync(requestMessage);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot retrieve tasks");
                }
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<GithubRepositories>(content);
            }
        }
    }
}
