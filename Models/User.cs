using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "Informe o nome.")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no max 100 caracteres.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no min 3 caracteres.")]
        public string name { get; set; }
        [Required(ErrorMessage = "Informe a senha.")]
        [MaxLength(16, ErrorMessage = "O nome deve ter no max 16 caracteres.")]
        [MinLength(8, ErrorMessage = "A senha deve ter no min 8 caracteres.")]
        public string password { get; set; }

        [Required(ErrorMessage = "Informe o e-mail.")]
        [EmailAddress(ErrorMessage = "Formato invalido de e-mail")]
        public string email { get; set; }

        [Required(ErrorMessage = "Selecione o perfil.")]
        [JsonProperty(PropertyName = "perfil_id")]
        public long role_id { get; set; }

        [JsonProperty(PropertyName = "ativo")]
        public bool active { get; set; }

        [JsonProperty(PropertyName = "refresh_token")]
        public string refresh_token { get; set; }

        [JsonProperty(PropertyName = "refresh_token_expiry_time")]
        public DateTime? refresh_token_expiry_time { get; set; }

        public Role role { get; set; }
    }
}
