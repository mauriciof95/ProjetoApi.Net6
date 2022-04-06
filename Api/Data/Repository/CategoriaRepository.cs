using Api.Data.Context;
using Models;

namespace Infrastructure.Data.Repository
{
    public class CategoriaRepository : BaseRepository<Categoria>
    {
        public CategoriaRepository(ApiContext context) : base(context) { }        
    }
}
