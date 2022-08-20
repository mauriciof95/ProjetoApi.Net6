using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Product : BaseEntity
    {
        [Required(ErrorMessage = "Informe uma descrição.")]
        [MaxLength(50, ErrorMessage = "A descrição deve ter no max 50 caracteres.")]
        public string description { get; set; }

        [Required(ErrorMessage = "Informe o valor.")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "Selecione a categoria.")]
        public long category_id { get; set; }

        public Category category { get; set; }

        public ICollection<StockMoviment> moviments { get; set; }
    }
}
