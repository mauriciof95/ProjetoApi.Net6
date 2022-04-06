using Infrastructure.Data.Repository;
using Api.Data.Context;
using Models;

namespace Api.Services
{
    public class ProdutoServices : BaseServices<Produto, ProdutoRepository>
    {
        public ProdutoServices(ApiContext context) : base(context) { }
    }
}
