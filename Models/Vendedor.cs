using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    [Index(nameof(documento), IsUnique = true)]
    public class Vendedor : BaseModel
    {
        [Required(ErrorMessage = "Informe o nome do Vendedor.")]
        [JsonProperty(PropertyName = "nome")]
        [MaxLength(50, ErrorMessage = "O nome deve ter no max 50 caracteres.")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Informe o Documento.")]
        [JsonProperty(PropertyName = "documento")]
        [MaxLength(15, ErrorMessage = "O Documento deve ter no max 15 caracteres.")]
        public string documento { get; set; }

        public ICollection<Pedido> pedidos { get; set; }
    }
}
