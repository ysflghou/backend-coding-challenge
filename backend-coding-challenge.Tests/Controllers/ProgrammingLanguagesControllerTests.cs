using backend_coding_challenge.Controllers;
using backend_coding_challenge.GithubClient;
using backend_coding_challenge.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
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

        [Test]
        public async Task GetProgrammingLanguagesInTrendingRepositories_Returns_ProgrammingLanguages()
        {
            // Arrange
            var expectedProgrammingLanguages = new ProgrammingLanguages
            {
                TotalCount = 1,
                Languages = new List<ProgrammingLanguage>
                {
                    new ProgrammingLanguage
                    {
                        Name = "C++",
                        GithubRepositoriesCount = 1,
                        GithubRepositories = new List<GithubRepository>
                        {
                            new GithubRepository
                            {
                                Id = 372536760,
                                Name = "oceanbase",
                                StarsNumber = 2625,
                                Url = "https://github.com/oceanbase/oceanbase",
                                Description = "OceanBase is an enterprise distributed relational database",
                                Language = "C++"
                            }
                        }
                    }
                }
            };
            var githubRepositories = new GithubRepositories
            {
                TotalCount = 20000,
                IncompleteResults = false,
                Repositories = new List<GithubRepository>
                {
                    new GithubRepository
                    {
                        Id = 372536760,
                        Name = "oceanbase",
                        StarsNumber = 2625,
                        Url = "https://github.com/oceanbase/oceanbase",
                        Description = "OceanBase is an enterprise distributed relational database",
                        Language = "C++"
                    }
                }
            };
            var trendingRepositoriesClient = new Mock<ITrendingRepositoriesClient>();
            trendingRepositoriesClient.Setup(_ => _.GetTrendingRepositoriesAsync())
                .ReturnsAsync(githubRepositories);
            var programmingLanguagesController = new ProgrammingLanguagesController(trendingRepositoriesClient.Object);

            // Act
            IActionResult apiResult = await programmingLanguagesController.GetProgrammingLanguagesInTrendingRepositories();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(apiResult);
            OkObjectResult OkApiResult = apiResult as OkObjectResult;
            Assert.IsNotNull(OkApiResult.Value);
            var programmingLanguages = OkApiResult.Value;
            programmingLanguages.Should().BeEquivalentTo(expectedProgrammingLanguages);
        }
    }
}
