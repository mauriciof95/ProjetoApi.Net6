using System.ComponentModel.DataAnnotations;

namespace Models.Request
{
    public class ItemPedidoRequest
    {
        [Required(ErrorMessage = "Selecione o item.")]
        [Range(1, long.MaxValue, ErrorMessage = "Codigo de produto invalido.")]
        public long produto_id { get; set; }

        [Required(ErrorMessage = "Informe a quantidade.")]
        [Range(1, 99999, ErrorMessage = "A Quantidade deve ser no minimo 1.")]
        public int quantidade { get; set; }
    }
}
