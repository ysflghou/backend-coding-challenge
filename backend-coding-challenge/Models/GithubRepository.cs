using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace backend_coding_challenge.Models
{
    [DataContract]
    public class GithubRepository
    {
        [DataMember]
        [JsonProperty("id")]
        public int Id { get; set; }

        [DataMember]
        [JsonProperty("name")]
        public string Name { get; set; }

        [DataMember]
        [JsonProperty("stargazers_count")]
        public int StarsNumber { get; set; }

        [DataMember]
        [JsonProperty("html_url")]
        public string Url { get; set; }

        [DataMember]
        [JsonProperty("description")]
        public string Description { get; set; }

        [DataMember]
        [JsonProperty("language")]
        public string Language { get; set; }
    }
}
