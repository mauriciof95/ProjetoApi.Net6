using Microsoft.EntityFrameworkCore;
using Models;

namespace Api.Infra.Repository
{
    public class UsuarioRepository : BaseRepository<User>
    {
        public UsuarioRepository(ApiDbContext context) : base(context){ }

        public async Task<User> RetornarUsuarioPorNomeSenha(string username, string password)
            => await _context.Usuarios.FirstOrDefaultAsync(x => x.name == username && x.password == password);

        public async Task<User> RetornarUsuarioPorNome(string username)
            => await _context.Usuarios.FirstOrDefaultAsync(x => x.name == username);
    }
}
