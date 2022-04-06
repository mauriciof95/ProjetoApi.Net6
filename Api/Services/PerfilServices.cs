using Api.Data.Context;
using Infrastructure.Data.Repository;
using Models;

namespace Api.Services
{
    public class PerfilServices : BaseServices<Perfil, PerfilRepository>
    {
        public PerfilServices(ApiContext context) : base(context){ }

        public async Task<ICollection<PerfilPermissao>> RetornarPermissoesPorPerfil(long perfil_id)
            => await _repository.RetornarPermissoesPorPerfil(perfil_id);

        public bool RoleHasPermission(string perfil, string permission)
            => _repository.RoleHasPermission(perfil, permission);
    }
}
