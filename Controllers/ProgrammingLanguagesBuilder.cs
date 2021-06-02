using backend_coding_challenge.Models;
using System.Collections.Generic;
using System.Linq;

namespace backend_coding_challenge.Controllers
{
    public static class ProgrammingLanguagesBuilder
    {
        public static ProgrammingLanguages BuildProgrammingLanguagesInTrendingRepositories(GithubRepositories trendingRepositories)
        {
            IEnumerable<GithubRepository> repositories = trendingRepositories.Repositories
                .Where(repository => repository.Language != null);
            string[] languages = repositories
                .Select(repository => repository.Language)
                .Distinct().ToArray();
            var programmingLanguagesDictionary = new Dictionary<string, List<GithubRepository>>();
            foreach (var repository in repositories)
            {
                string language = repository.Language;
                if (programmingLanguagesDictionary.ContainsKey(language))
                {
                    programmingLanguagesDictionary[language].Add(repository);
                }
                else
                {
                    programmingLanguagesDictionary.Add(language, new List<GithubRepository> { repository });
                }
            }
            var programmingLanguages = new List<ProgrammingLanguage>();
            foreach (var dictionaryEntry in programmingLanguagesDictionary)
            {
                string languageName = dictionaryEntry.Key;
                List<GithubRepository> languageRepositories = dictionaryEntry.Value;
                var programmingLanguage = new ProgrammingLanguage
                {
                    Name = languageName,
                    GithubRepositoriesCount = languageRepositories.Count,
                    GithubRepositories = languageRepositories
                };
                programmingLanguages.Add(programmingLanguage);
            }
            return new ProgrammingLanguages
            {
                Languages = programmingLanguages,
                TotalCount = programmingLanguages.Count
            };
        }
    }
}
