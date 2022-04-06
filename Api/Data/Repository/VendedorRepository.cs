using Api.Data.Context;
using Models;

namespace Infrastructure.Data.Repository
{
    public class VendedorRepository : BaseRepository<Vendedor>
    {
        public VendedorRepository(ApiContext context) : base(context) { }
    }
}
