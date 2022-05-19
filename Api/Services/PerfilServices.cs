using Infrastructure.Data.Repository;
using Models;

namespace Api.Services
{
    public class PerfilServices : BaseServices<Perfil>
    {
        private readonly PerfilRepository _repository;

        public PerfilServices(PerfilRepository repository) : base(repository) => _repository = repository;
        

        public async Task<ICollection<PerfilPermissao>> RetornarPermissoesPorPerfil(long perfil_id)
            => await _repository.RetornarPermissoesPorPerfil(perfil_id);

        public bool RoleHasPermission(string perfil, string permission)
            => _repository.RoleHasPermission(perfil, permission);
    }
}
