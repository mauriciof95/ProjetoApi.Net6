using Models;

namespace Api.Repository.Repository
{
    public class ProdutoRepository : BaseRepository<Produto>
    {
        public ProdutoRepository(ApiContext context) : base(context) { }
    }
}
