using Models;

namespace Application.Services
{
    public class UsuarioServices : BaseServices<Usuario>
    {
        public UsuarioServices(string token) : base(token) => URL += "/usuario";

        public async Task<ICollection<Usuario>> GetAll() => await GetAllAsync();
    }
}
