using Models.Enum;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("perfil_permissao", Schema = "public")]
    public class PerfilPermissao : BaseModel
    {
        [Column(Order = 1)]
        [JsonProperty(PropertyName = "perfil_id")]
        public long perfil_id { get; set; }

        [Column(Order = 2)]
        [ForeignKey("perfil_id")]
        public Perfil perfil { get; set; }

        [Column(Order = 3)]
        [JsonProperty(PropertyName = "permissao")]
        public string permissao { get; set; }
    }
}
