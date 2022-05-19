using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Perfil : BaseModel
    {
        [Required(ErrorMessage = "Informe uma descrição.")]
        [JsonProperty(PropertyName = "descricao")]
        [MaxLength(50, ErrorMessage = "A descrição deve ter no max 50 caracteres.")]
        public string descricao { get; set; }

        [JsonProperty(PropertyName = "ativo")]
        public bool ativo { get; set; }

        public ICollection<PerfilPermissao> permissoes { get; set; }
        public ICollection<Usuario> usuarios { get; set; }
    }
}
