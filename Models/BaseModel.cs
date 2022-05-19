using Newtonsoft.Json;
using System;

namespace Models
{
    public class BaseModel
    {
        public long id { get; set; }

        [JsonProperty("data_criacao")]
        public DateTime data_criacao { get; set; }

        [JsonProperty("data_edicao")]
        public DateTime? data_edicao { get; set; }
    }
}
