using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("movimentacao_estoque", Schema = "public")]
    public class MovimentacaoEstoque : BaseModel
    {
        [Column(Order = 1)]
        [Required(ErrorMessage = "Informe a quantidade.")]
        [JsonProperty(PropertyName = "quantidade")]
        public int quantidade { get; set; }

        [Column(Order = 2)]
        [Required]
        [JsonProperty(PropertyName = "tipo_movimento")]
        public string tipo_movimento { get; set; }

        [Column(Order = 3)]
        [Required(ErrorMessage = "Informe o motivo da movimentação no estoque.")]
        [JsonProperty(PropertyName = "motivo_movimento")]
        public string motivo_movimento { get; set; }

        [Column(Order = 4)]
        [Required(ErrorMessage = "Informe o produto.")]
        [JsonProperty(PropertyName = "produto_id")]
        public long produto_id { get; set; }


        [ForeignKey("produto_id")]
        public Produto produto { get; set; }
    }
}
