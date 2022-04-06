using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Pedido : BaseModel
    {
        [Required(ErrorMessage = "Informe a data do pedido.")]
        [JsonProperty(PropertyName = "data_pedido")]
        public DateTime data_pedido { get; set; }

        [Required(ErrorMessage = "Informe o status do pedido.")]
        [JsonProperty(PropertyName = "status_pedido")]
        public string status_pedido { get; set; }

        [Required(ErrorMessage = "Selecione o cliente.")]
        [JsonProperty(PropertyName = "cliente_id")]
        public long cliente_id { get; set; }

        [Required(ErrorMessage = "Selecione o vendedor.")]
        [JsonProperty(PropertyName = "vendedor_id")]
        public long vendedor_id { get; set; }



        public Cliente cliente { get; set; }

        public Vendedor vendedor { get; set; }

        public ICollection<PedidoItem> pedido_itens { get; set; }
    }
}
