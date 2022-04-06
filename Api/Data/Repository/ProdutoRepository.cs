using Api.Data.Context;
using Models;

namespace Infrastructure.Data.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>
    {
        public ProdutoRepository(ApiContext context) : base(context) { }
    }
}
