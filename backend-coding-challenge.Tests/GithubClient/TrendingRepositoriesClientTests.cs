using backend_coding_challenge.GithubClient;
using backend_coding_challenge.Models;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace backend_coding_challenge.Tests.GithubClient
{
    internal class TrendingRepositoriesClientTests
    {
        [Test]
        public async Task GetTrendingRepositoriesAsync_Sets_RequestHeaders()
        {
            // Arrange
            Mock<HttpMessageHandler> httpMessageHandlerMock = CreateMinimalHttpMessageHandlerMock(new HttpResponseMessage());

            var httpClient = new HttpClient(httpMessageHandlerMock.Object);
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            httpClientFactoryMock.Setup(_ => _.CreateClient(string.Empty))
                    .Returns(httpClient);
            var trendingRepositoriesClient = new TrendingRepositoriesClient(httpClientFactoryMock.Object);

            // Act
            await trendingRepositoriesClient.GetTrendingRepositoriesAsync();

            // Assert
            Assert.That(httpClient.DefaultRequestHeaders.Contains("Accept"));
            Assert.That(httpClient.DefaultRequestHeaders.UserAgent.Contains(new ProductInfoHeaderValue("backend_coding_challenge", "v1")));
        }

        [Test]
        public async Task GetTrendingRepositoriesAsync_Calls_HttpClientsSendAsync()
        {
            // Arrange
            Mock<HttpMessageHandler> httpMessageHandlerMock = CreateMinimalHttpMessageHandlerMock(new HttpResponseMessage());

            var httpClient = new HttpClient(httpMessageHandlerMock.Object);
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            httpClientFactoryMock.Setup(_ => _.CreateClient(string.Empty))
                    .Returns(httpClient);
            var trendingRepositoriesClient = new TrendingRepositoriesClient(httpClientFactoryMock.Object);

            // Act
            await trendingRepositoriesClient.GetTrendingRepositoriesAsync();

            // Assert
            httpMessageHandlerMock.Protected().Verify(
                methodName: "SendAsync",
                times: Times.Once(),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>());
        }

        [Test]
        public async Task GetTrendingRepositoriesAsync_Gets_TrendingRepositories()
        {
            // Arrange
            var response = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(GetExpectedRequestJsonContent()),
            };
            Mock<HttpMessageHandler> httpMessageHandlerMock = CreateMinimalHttpMessageHandlerMock(response);

            var httpClient = new HttpClient(httpMessageHandlerMock.Object);
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            httpClientFactoryMock.Setup(_ => _.CreateClient(string.Empty))
                    .Returns(httpClient);
            var trendingRepositoriesClient = new TrendingRepositoriesClient(httpClientFactoryMock.Object);
            var expectedTrendingRepositories = GetExpectedTrendingRepositories();

            // Act
            GithubRepositories trendingRepositories = await trendingRepositoriesClient.GetTrendingRepositoriesAsync();

            // Assert
            Assert.AreEqual(expectedTrendingRepositories.TotalCount, trendingRepositories.TotalCount);
            Assert.AreEqual(expectedTrendingRepositories.IncompleteResults, trendingRepositories.IncompleteResults);
            Assert.AreEqual(expectedTrendingRepositories.Repositories[0].Id, trendingRepositories.Repositories[0].Id);
            Assert.AreEqual(expectedTrendingRepositories.Repositories[1].Name, trendingRepositories.Repositories[1].Name);
            Assert.AreEqual(expectedTrendingRepositories.Repositories[2].StarsNumber, trendingRepositories.Repositories[2].StarsNumber);
            Assert.AreEqual(expectedTrendingRepositories.Repositories[0].Url, trendingRepositories.Repositories[0].Url);
            Assert.AreEqual(expectedTrendingRepositories.Repositories[1].Description, trendingRepositories.Repositories[1].Description);
            Assert.AreEqual(expectedTrendingRepositories.Repositories[2].Language, trendingRepositories.Repositories[2].Language);
        }

        private static Mock<HttpMessageHandler> CreateMinimalHttpMessageHandlerMock(HttpResponseMessage httpResponseMessage)
        {
            Mock<HttpMessageHandler> httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            httpMessageHandlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               .ReturnsAsync(httpResponseMessage)
               .Verifiable();
            return httpMessageHandlerMock;
        }

        private static string GetExpectedRequestJsonContent()
        {
            const string content = @"{
                ""total_count"": 20000,
                ""incomplete_results"": false,
                ""items"": [
                        {
                            ""id"": 368525749,
                            ""name"": ""secguide"",
                            ""stargazers_count"": 5014,
                            ""html_url"": ""https://github.com/Tencent/secguide"",
                            ""description"": ""secguide description"",
                            ""language"": null
                        },
                        {
                            ""id"": 372536760,
                            ""name"": ""oceanbase"",
                            ""stargazers_count"": 2625,
                            ""html_url"": ""https://github.com/oceanbase/oceanbase"",
                            ""description"": ""OceanBase is an enterprise distributed relational database"",
                            ""language"": ""C++""
                        },
                        {
                            ""id"": 367284699,
                            ""name"": ""lima"",
                            ""stargazers_count"": 2521,
                            ""html_url"": ""https://github.com/AkihiroSuda/lima"",
                            ""description"": ""Linux virtual machines"",
                            ""language"": ""Go""
                        }
                    ]
                }";
            return content;
        }
        private static GithubRepositories GetExpectedTrendingRepositories()
        {
            var expectedTrendingRepositories = new GithubRepositories
            {
                TotalCount = 20000,
                IncompleteResults = false,
                Repositories = new List<GithubRepository>
                {
                    new GithubRepository
                    {
                        Id = 368525749,
                        Name = "secguide",
                        StarsNumber = 5014,
                        Url = "https://github.com/Tencent/secguide",
                        Description = "secguide description",
                        Language = null
                    },
                    new GithubRepository
                    {
                        Id = 372536760,
                        Name = "oceanbase",
                        StarsNumber = 2625,
                        Url = "https://github.com/oceanbase/oceanbase",
                        Description = "OceanBase is an enterprise distributed relational database",
                        Language = "C++"
                    },
                    new GithubRepository
                    {
                        Id = 367284699,
                        Name = "lima",
                        StarsNumber = 2521,
                        Url = "https://github.com/AkihiroSuda/lima",
                        Description = "Linux virtual machines",
                        Language = "Go"
                    }
                }
            };
            return expectedTrendingRepositories;
        }
    }
}
