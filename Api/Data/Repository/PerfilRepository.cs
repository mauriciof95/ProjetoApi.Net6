using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Infrastructure.Data.Repository
{
    public class PerfilRepository : BaseRepository<Perfil>
    {
        public PerfilRepository (ApiContext context) : base(context){ }

        public async Task<ICollection<PerfilPermissao>> RetornarPermissoesPorPerfil(long perfil_id)
            => await _context.PerfilPermissoes.AsNoTracking().Where(x => x.perfil_id == perfil_id).ToListAsync();

        public bool RoleHasPermission(string perfil, string permission)
            => _context.PerfilPermissoes.Include(p => p.perfil).Any(x => x.perfil.descricao == perfil && x.permissao == permission);
    }
}
