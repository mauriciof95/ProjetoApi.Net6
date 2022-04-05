using Api.Repository;
using Api.Repository.Repository;
using Models;

namespace Api.Services
{
    public class ProdutoServices : BaseServices<Produto, ProdutoRepository>
    {
        public ProdutoServices(ApiContext context) : base(context) { }
    }
}
