using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("pedido", Schema = "public")]
    public class Pedido : BaseModel
    {
        [Column(Order = 1)]
        [Required(ErrorMessage = "Informe a data do pedido.")]
        [JsonProperty(PropertyName = "data_pedido")]
        public DateTime data_pedido { get; set; }

        [Column(Order = 2)]
        [Required(ErrorMessage = "Informe o status do pedido.")]
        [JsonProperty(PropertyName = "status_pedido")]
        public string status_pedido { get; set; }

        [Column(Order = 3)]
        [Required(ErrorMessage = "Selecione o cliente.")]
        [JsonProperty(PropertyName = "cliente_id")]
        public long cliente_id { get; set; }

        [Column(Order = 4)]
        [Required(ErrorMessage = "Selecione o vendedor.")]
        [JsonProperty(PropertyName = "vendedor_id")]
        public long vendedor_id { get; set; }




        [ForeignKey("cliente_id")]
        public Cliente cliente { get; set; }

        [ForeignKey("cliente_id")]
        public Vendedor vendedor { get; set; }

        public ICollection<PedidoItem> pedido_itens { get; set; }
    }
}
