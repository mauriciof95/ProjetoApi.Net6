using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("perfil", Schema = "public")]
    public class Perfil : BaseModel
    {
        [Column(Order = 1)]
        [Required(ErrorMessage = "Informe uma descrição.")]
        [JsonProperty(PropertyName = "descricao")]
        [MaxLength(50, ErrorMessage = "A descrição deve ter no max 50 caracteres.")]
        public string descricao { get; set; }

        [Column(Order = 2)]
        [JsonProperty(PropertyName = "ativo")]
        public bool ativo { get; set; }
    }
}
