using Infrastructure.Data.Repository;
using Models;

namespace Api.Services
{
    public class CategoriaServices : BaseServices<Categoria>
    {
        private readonly CategoriaRepository _repository;

        public CategoriaServices(CategoriaRepository repository) : base(repository) => _repository = repository;

        public async Task<Categoria> FirstSearchBy_Descricao(string descricao)
            => await _repository.FirstSearchBy(x => x.descricao == descricao);
    }
}
