using Models;

namespace Api.Infra.Repository
{
    public class ProdutoRepository : BaseRepository<Product>
    {
        public ProdutoRepository(ApiDbContext context) : base(context) { }
    }
}
