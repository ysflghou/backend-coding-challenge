using backend_coding_challenge.Controllers;
using backend_coding_challenge.GithubClient;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace backend_coding_challenge.Tests.Controllers
{
    internal class TrendingRepositoriesControllerTests
    {
        [Test]
        public async Task GetTrendingRepositories_Returns_NotFound_In_Case_Of_Exception()
        {
            // Arrange
            var trendingRepositoriesClient = new Mock<ITrendingRepositoriesClient>();
            trendingRepositoriesClient.Setup(_ => _.GetTrendingRepositoriesAsync())
                .Throws(new HttpRequestException("Failed to retrieve trending repositories from github api"));
            var trendingRepositoriesController = new TrendingRepositoriesController(trendingRepositoriesClient.Object);

            // Act
            IActionResult trendingRepositories = await trendingRepositoriesController.GetTrendingRepositories();

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(trendingRepositories);
        }
    }
}
