using Models;

namespace Api.Repository.Repository
{
    public class VendedorRepository : BaseRepository<Vendedor>
    {
        public VendedorRepository(ApiContext context) : base(context) { }
    }
}
