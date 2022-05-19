using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Request
{
    public class DadosPedidoRequest
    {
        [Required(ErrorMessage = "Selecione o cliente.")]
        public long cliente_id { get; set; }

        [Required(ErrorMessage = "Selecione o vendedor.")]
        public long vendedor_id { get; set; }

        [Required(ErrorMessage = "Selecione os itens do pedido")]
        [MinLength(1, ErrorMessage = "Selecione pelo menos 1 item")]
        public List<ItemPedidoRequest> itens { get; set; }
    }
}
