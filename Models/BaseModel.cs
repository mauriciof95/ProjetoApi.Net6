using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class BaseModel
    {
        [Key]
        [JsonProperty("id")]
        [Column(Order = 0)]
        public long id { get; set; }

        [Column(Order = 100)]
        [JsonProperty("data_criacao")]
        public DateTime data_criacao { get; set; }

        [Column(Order = 101)]
        [JsonProperty("data_edicao")]
        public DateTime? data_edicao { get; set; }
    }
}
