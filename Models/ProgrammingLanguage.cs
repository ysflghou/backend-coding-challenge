using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace backend_coding_challenge.Models
{
    [DataContract]
    public class ProgrammingLanguage
    {
        [DataMember]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [DataMember]
        [JsonPropertyName("github_repositories_count")]
        public int GithubRepositoriesCount { get; set; }

        [DataMember]
        [JsonPropertyName("github_repositories")]
        public IReadOnlyList<GithubRepository> GithubRepositories { get; set; }
    }
}
