using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("produto", Schema = "public")]
    public class Produto : BaseModel
    {
        [Column(Order = 1)]
        [Required(ErrorMessage = "Informe uma descrição.")]
        [MaxLength(50, ErrorMessage = "A descrição deve ter no max 50 caracteres.")]
        [JsonProperty(PropertyName = "descricao")]
        public string descricao { get; set; }

        [Column(Order = 2)]
        [Required(ErrorMessage = "Informe o valor.")]
        [JsonProperty(PropertyName = "valor")]
        public decimal valor { get; set; }

        [Column(Order = 3)]
        [Required(ErrorMessage = "Selecione a categoria.")]
        [JsonProperty(PropertyName = "categoria_id")]
        public long categoria_id { get; set; }


        [ForeignKey("categoria_id")]
        public Categoria categoria { get; set; }
    }
}
