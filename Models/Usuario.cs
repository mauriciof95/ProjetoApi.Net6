using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("usuario", Schema = "public")]
    public class Usuario : BaseModel
    {
        [Column(Order = 1)]
        [JsonProperty(PropertyName = "nome")]
        [Required(ErrorMessage = "Informe o nome.")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no max 100 caracteres.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no min 3 caracteres.")]
        public string nome { get; set; }

        [Column(Order = 2)]
        [JsonProperty(PropertyName = "senha")]
        [Required(ErrorMessage = "Informe a senha.")]
        [MaxLength(16, ErrorMessage = "O nome deve ter no max 16 caracteres.")]
        [MinLength(8, ErrorMessage = "A senha deve ter no min 8 caracteres.")]
        public string senha { get; set; }

        [Column(Order = 3)]
        [JsonProperty(PropertyName = "email")]
        [Required(ErrorMessage = "Informe o e-mail.")]
        [EmailAddress(ErrorMessage = "Formato invalido de e-mail")]
        public string email { get; set; }

        [Required(ErrorMessage = "Selecione o perfil.")]
        [Column(Order = 4)]
        [JsonProperty(PropertyName = "perfil_id")]
        public long perfil_id { get; set; }

        [Column(Order = 5)]
        [JsonProperty(PropertyName = "ativo")]
        public bool ativo { get; set; }

        [Column(Order = 6)]
        [JsonProperty(PropertyName = "refresh_token")]
        public string? refresh_token { get; set; }

        [Column(Order = 7)]
        [JsonProperty(PropertyName = "refresh_token_expiry_time")]
        public DateTime? refresh_token_expiry_time { get; set; }

        [ForeignKey("perfil_id")]
        public Perfil perfil { get; set; }
    }
}
