using System.ComponentModel.DataAnnotations;

namespace Models.Request
{
    public class UserAuthRequest
    {
        [Required(ErrorMessage = "Informe o nome de usuario.")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Informe a senha.")]
        public string senha { get; set; }
    }
}
