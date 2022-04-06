using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Infrastructure.Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>
    {
        public UsuarioRepository(ApiContext context) : base(context){ }

        public async Task<Usuario> RetornarUsuarioPorNomeSenha(string username, string password)
            => await _context.Usuarios.FirstOrDefaultAsync(x => x.nome == username && x.senha == password);

        public async Task<Usuario> RetornarUsuarioPorNome(string username)
            => await _context.Usuarios.FirstOrDefaultAsync(x => x.nome == username);
    }
}
