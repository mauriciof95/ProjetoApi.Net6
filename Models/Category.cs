using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public  class Category : BaseEntity
    {
        [Required(ErrorMessage = "Informe uma descrição.")]
        [MaxLength(50, ErrorMessage = "A descrição deve ter no max 50 caracteres.")]
        public string description { get; set; }

        public ICollection<Product> products { get; set; }
    }
}
