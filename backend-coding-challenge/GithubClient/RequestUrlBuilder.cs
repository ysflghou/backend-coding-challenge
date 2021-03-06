using System;

namespace backend_coding_challenge.GithubClient
{
    public static class RequestUriBuilder
    {
        const string githubRepositoriesUrl = "https://api.github.com/search/repositories";
        internal static Uri BuildRequestUri()
        {
            var requestqueryParameters = BuildRequestQueryParameters();
            var uriString = $"{githubRepositoriesUrl}?{requestqueryParameters}";
            return new Uri(uriString);
        }
        private static string BuildRequestQueryParameters()
        {
            var todaysDate = DateTime.Today;
            var monthBeforeToday = todaysDate.Subtract(TimeSpan.FromDays(30)).ToString("yyyy-MM-dd");
            var queryParameters = $"q=created:>{monthBeforeToday}&sort=stars&order=desc&per_page=100";
            return queryParameters;
        }
    }
}
