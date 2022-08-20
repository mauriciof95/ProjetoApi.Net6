using Models;

namespace Api.Infra.Repository
{
    public class CategoriaRepository : BaseRepository<Category>
    {
        public CategoriaRepository(ApiDbContext context) : base(context) { }        
    }
}
