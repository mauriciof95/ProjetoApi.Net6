using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("categoria", Schema = "public")]
    public  class Categoria : BaseModel
    {
        [Required(ErrorMessage = "Informe uma descrição.")]
        [JsonProperty(PropertyName = "descricao")]
        [MaxLength(50, ErrorMessage = "A descrição deve ter no max 50 caracteres.")]
        [Column(Order = 1)]
        public string descricao { get; set; }
    }
}
