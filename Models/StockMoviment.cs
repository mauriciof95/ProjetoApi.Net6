using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class StockMoviment : BaseEntity
    {
        [Required(ErrorMessage = "Informe a quantidade.")]
        public int amount { get; set; }

        [Required]
        public string moviment_type { get; set; }

        [Required(ErrorMessage = "Informe o motivo da movimentação no estoque.")]
        public string moviment_reason { get; set; }

        [Required(ErrorMessage = "Informe o produto.")]
        public long product_id { get; set; }
        public Product product { get; set; }
    }
}
