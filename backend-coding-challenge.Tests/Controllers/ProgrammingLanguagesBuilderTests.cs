using backend_coding_challenge.Controllers;
using backend_coding_challenge.Models;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace backend_coding_challenge.Tests.Controllers
{
    internal class ProgrammingLanguagesBuilderTests
    {
        [TestCaseSource(nameof(GetGithubRepositoriesAndExpectedProgrammingLanguages))]
        public void BuildProgrammingLanguagesInTrendingRepositories_Builds_Languages_Correctely(
            GithubRepositories githubRepositories,
            ProgrammingLanguages expectedProgrammingLanguages)
        {
            // Act
            ProgrammingLanguages programmingLanguages = ProgrammingLanguagesBuilder
                .BuildProgrammingLanguagesInTrendingRepositories(githubRepositories);

            // Assert
            programmingLanguages.Should().BeEquivalentTo(expectedProgrammingLanguages);
        }

        private static IEnumerable<TestCaseData> GetGithubRepositoriesAndExpectedProgrammingLanguages()
        {
            yield return new TestCaseData(
                new GithubRepositories
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
                            Language = "Go"
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
                },
                new ProgrammingLanguages
                {
                    TotalCount = 2,
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
                        },
                        new ProgrammingLanguage
                        {
                            Name = "Go",
                            GithubRepositoriesCount = 2,
                            GithubRepositories = new List<GithubRepository>
                            {
                                new GithubRepository
                                {
                                    Id = 368525749,
                                    Name = "secguide",
                                    StarsNumber = 5014,
                                    Url = "https://github.com/Tencent/secguide",
                                    Description = "secguide description",
                                    Language = "Go"
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
                        }
                    }
                }
            );

            yield return new TestCaseData(
                new GithubRepositories
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
                            Language = null // Test with null language
                        },
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
                },
                new ProgrammingLanguages
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
                }
            );
        }
    }
}
