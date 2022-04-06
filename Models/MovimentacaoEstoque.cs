using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class MovimentacaoEstoque : BaseModel
    {
        [Required(ErrorMessage = "Informe a quantidade.")]
        [JsonProperty(PropertyName = "quantidade")]
        public int quantidade { get; set; }

        [Required]
        [JsonProperty(PropertyName = "tipo_movimento")]
        public string tipo_movimento { get; set; }

        [Required(ErrorMessage = "Informe o motivo da movimentação no estoque.")]
        [JsonProperty(PropertyName = "motivo_movimento")]
        public string motivo_movimento { get; set; }

        [Required(ErrorMessage = "Informe o produto.")]
        [JsonProperty(PropertyName = "produto_id")]
        public long produto_id { get; set; }
        public Produto produto { get; set; }
    }
}
