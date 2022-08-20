using Models;

namespace Api.Infra.Repository
{
    public class VendedorRepository : BaseRepository<Seller>
    {
        public VendedorRepository(ApiDbContext context) : base(context) { }
    }
}
