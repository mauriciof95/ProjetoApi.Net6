using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    [Index(nameof(document), IsUnique = true)]
    public class Seller : BaseEntity
    {
        [Required(ErrorMessage = "Informe o nome do Vendedor.")]
        [MaxLength(50, ErrorMessage = "O nome deve ter no max 50 caracteres.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Informe o Documento.")]
        [MaxLength(15, ErrorMessage = "O Documento deve ter no max 15 caracteres.")]
        public string document { get; set; }

        public ICollection<Order> orders { get; set; }
    }
}
