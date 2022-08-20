using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Role : BaseEntity
    {
        [Required(ErrorMessage = "Informe uma descrição.")]
        [MaxLength(50, ErrorMessage = "A descrição deve ter no max 50 caracteres.")]
        public string name { get; set; }

        public bool active { get; set; }

        public ICollection<Permission> permissions { get; set; }
        public ICollection<User> users { get; set; }
    }
}
