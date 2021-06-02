using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace backend_coding_challenge.Models
{
    [DataContract]
    public class GithubRepositories
    {
        [DataMember]
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [DataMember]
        [JsonProperty("incomplete_results")]
        public bool IncompleteResults { get; set; }

        [DataMember]
        [JsonProperty("items")]
        public IReadOnlyList<GithubRepository> Repositories { get; set; }
    }
}
