using Microsoft.EntityFrameworkCore;
using Models;

namespace Api.Infra.Repository
{
    public class PerfilRepository : BaseRepository<Role>
    {
        public PerfilRepository (ApiDbContext context) : base(context){ }

        public async Task<ICollection<Permission>> RetornarPermissoesPorPerfil(long perfil_id)
            => await _context.PerfilPermissoes.AsNoTracking().Where(x => x.role_id == perfil_id).ToListAsync();

        public bool RoleHasPermission(string perfil, string permission)
            => _context.PerfilPermissoes.Include(p => p.perfil).Any(x => x.perfil.name == perfil && x.permission == permission);
    }
}
