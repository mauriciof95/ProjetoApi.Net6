using Infrastructure.Data.Repository;
using Models;

namespace Api.Services
{
    public class ProdutoServices : BaseServices<Produto>
    {
        public ProdutoServices(ProdutoRepository repository) : base(repository) { }
    }
}
