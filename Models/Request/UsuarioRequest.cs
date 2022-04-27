using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Models.Request
{
    public class UsuarioRequest
    {
        [JsonProperty(PropertyName = "nome")]
        [Required(ErrorMessage = "Informe o nome.")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no max 100 caracteres.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no min 3 caracteres.")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "senha")]
        [Required(ErrorMessage = "Informe a senha.")]
        [MaxLength(15, ErrorMessage = "O nome deve ter no max 15 caracteres.")]
        [MinLength(6, ErrorMessage = "A senha deve ter no min 6 caracteres.")]
        public string Senha { get; set; }

        [JsonProperty(PropertyName = "email")]
        [Required(ErrorMessage = "Informe o e-mail.")]
        [EmailAddress(ErrorMessage = "Formato invalido de e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Selecione o perfil.")]
        [JsonProperty(PropertyName = "perfil_id")]
        public long Perfil_id { get; set; }

        [JsonProperty(PropertyName = "ativo")]
        public bool Ativo { get; set; }
    }
}
