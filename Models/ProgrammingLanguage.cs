using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_coding_challenge.Models
{
    public class ProgrammingLanguage
    {
        public string Name { get; set; }
        public int NumberOfGithubRepositories { get; set; }
        public IReadOnlyList<GithubRepository> GithubRepositories;
    }
}
