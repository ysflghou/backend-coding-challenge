using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace backend_coding_challenge.Models
{
    [DataContract]
    public class ProgrammingLanguages
    {
        [DataMember]
        [JsonPropertyName("total_count")]
        public int TotalCount { get; set; }

        [DataMember]
        [JsonPropertyName("languages")]
        public IReadOnlyList<ProgrammingLanguage> Languages { get; set; }
    }
}
