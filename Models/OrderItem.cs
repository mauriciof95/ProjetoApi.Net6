using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class OrderItem : BaseEntity
    {
        [Required(ErrorMessage = "Informe o valor pago.")]
        public decimal unit_value_paid { get; set; }

        [Required(ErrorMessage = "Informe a quantidade.")]
        public decimal amount { get; set; }

        [Required]
        public long order_id { get; set; }

        [Required]
        public long product_id { get; set; }


        public Order order { get; set; }
        public Product product { get; set; }
    }
}
