using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("vendedor", Schema = "public")]
    [Index(nameof(documento), IsUnique = true)]
    public class Vendedor : BaseModel
    {
        [Required(ErrorMessage = "Informe o nome do Vendedor.")]
        [JsonProperty(PropertyName = "nome")]
        [MaxLength(50, ErrorMessage = "O nome deve ter no max 50 caracteres.")]
        [Column(Order = 1)]
        public string nome { get; set; }

        [Required(ErrorMessage = "Informe o Documento.")]
        [JsonProperty(PropertyName = "documento")]
        [MaxLength(15, ErrorMessage = "O Documento deve ter no max 15 caracteres.")]
        [Column(Order = 2)]
        public string documento { get; set; }
    }
}
