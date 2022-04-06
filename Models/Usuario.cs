using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Usuario : BaseModel
    {
        [JsonProperty(PropertyName = "nome")]
        [Required(ErrorMessage = "Informe o nome.")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no max 100 caracteres.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no min 3 caracteres.")]
        public string nome { get; set; }

        [JsonProperty(PropertyName = "senha")]
        [Required(ErrorMessage = "Informe a senha.")]
        [MaxLength(16, ErrorMessage = "O nome deve ter no max 16 caracteres.")]
        [MinLength(8, ErrorMessage = "A senha deve ter no min 8 caracteres.")]
        public string senha { get; set; }

        [JsonProperty(PropertyName = "email")]
        [Required(ErrorMessage = "Informe o e-mail.")]
        [EmailAddress(ErrorMessage = "Formato invalido de e-mail")]
        public string email { get; set; }

        [Required(ErrorMessage = "Selecione o perfil.")]
        [JsonProperty(PropertyName = "perfil_id")]
        public long perfil_id { get; set; }

        [JsonProperty(PropertyName = "ativo")]
        public bool ativo { get; set; }

        [JsonProperty(PropertyName = "refresh_token")]
        public string? refresh_token { get; set; }

        [JsonProperty(PropertyName = "refresh_token_expiry_time")]
        public DateTime? refresh_token_expiry_time { get; set; }

        public Perfil perfil { get; set; }
    }
}
