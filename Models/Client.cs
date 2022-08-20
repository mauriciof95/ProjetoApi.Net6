using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Index(nameof(document), IsUnique = true)]
    public class Client : BaseEntity
    {
        [Required(ErrorMessage = "Informe o nome do Cliente.")]
        [MaxLength(50, ErrorMessage = "O nome deve ter no max 50 caracteres.")]
        public string name { get; set; }

        [Required(ErrorMessage = "Informe o Documento.")]
        [MaxLength(15, ErrorMessage = "O Documento deve ter no max 15 caracteres.")]
        public string document { get; set; }
        
        public ICollection<Order> orders { get; set; }
    }
}
