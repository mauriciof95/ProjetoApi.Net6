using Api.Repository;
using Api.Repository.Repository;
using Models;

namespace Api.Services
{
    public class CategoriaServices : BaseServices<Categoria, CategoriaRepository>
    {
        public CategoriaServices(ApiContext context) : base(context) { }

        public async Task<Categoria> FirstSearchBy_Descricao(string descricao)
            => await _repository.FirstSearchBy(x => x.descricao == descricao);
    }
}
