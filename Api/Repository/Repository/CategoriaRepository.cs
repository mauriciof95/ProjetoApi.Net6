using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq;

namespace Api.Repository.Repository
{
    public class CategoriaRepository : BaseRepository<Categoria>
    {
        public CategoriaRepository(ApiContext context) : base(context) { }        
    }
}
