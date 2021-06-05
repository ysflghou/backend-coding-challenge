using backend_coding_challenge.GithubClient;
using NUnit.Framework;
using System;

namespace backend_coding_challenge.Tests.GithubClient
{
    internal class RequestUriBuilderTests
    {
        [Test]
        public void BuildRequestUri_Returns_CorrectGithubTrendingRepositoriesUri()
        {
            var todaysDate = DateTime.Today;
            var monthBeforeToday = todaysDate.Subtract(TimeSpan.FromDays(30)).ToString("yyyy-MM-dd");
            var expectedUri = new Uri($"https://api.github.com/search/repositories?q=created:>{monthBeforeToday}&sort=stars&order=desc&per_page=100");
            var actualUri = RequestUriBuilder.BuildRequestUri();
            Assert.AreEqual(expectedUri, actualUri);
        }
    }
}
