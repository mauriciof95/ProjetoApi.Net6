using System.ComponentModel.DataAnnotations;

namespace Models.Request
{
    public class UserAuthRequest
    {
        [Required(ErrorMessage = "Informe o nome de usuario.")]
        public string username { get; set; }

        [Required(ErrorMessage = "Informe a senha.")]
        public string password { get; set; }
    }
}
