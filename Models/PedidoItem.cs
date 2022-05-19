using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class PedidoItem : BaseModel
    {
        [Column(Order = 1)]
        [Required(ErrorMessage = "Informe o valor pago.")]
        [JsonProperty(PropertyName = "valor_unitario_pago")]
        public decimal valor_unitario_pago { get; set; }

        [Column(Order = 2)]
        [Required(ErrorMessage = "Informe a quantidade.")]
        [JsonProperty(PropertyName = "quantidade")]
        public decimal quantidade { get; set; }

        [Column(Order = 3)]
        [Required]
        [JsonProperty(PropertyName = "pedido_id")]
        public long pedido_id { get; set; }

        [Column(Order = 4)]
        [Required]
        [JsonProperty(PropertyName = "produto_id")]
        public long produto_id { get; set; }


        public Pedido pedido { get; set; }
        public Produto produto { get; set; }
    }
}
