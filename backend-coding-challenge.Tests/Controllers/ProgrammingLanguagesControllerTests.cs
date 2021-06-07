using backend_coding_challenge.Controllers;
using backend_coding_challenge.GithubClient;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace backend_coding_challenge.Tests.Controllers
{
    internal class ProgrammingLanguagesControllerTests
    {
        [Test]
        public async Task GetProgrammingLanguagesInTrendingRepositories_Returns_NotFound_In_Case_Of_Exception()
        {
            // Arrange
            var trendingRepositoriesClient = new Mock<ITrendingRepositoriesClient>();
            trendingRepositoriesClient.Setup(_ => _.GetTrendingRepositoriesAsync())
                .Throws(new HttpRequestException("Failed to retrieve trending repositories from github api"));
            var programmingLanguagesController = new ProgrammingLanguagesController(trendingRepositoriesClient.Object);

            // Act
            IActionResult programmingLanguages = await programmingLanguagesController.GetProgrammingLanguagesInTrendingRepositories();

            // Assert
            Assert.IsInstanceOf<NotFoundObjectResult>(programmingLanguages);
        }
    }
}
