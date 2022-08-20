using Models;

namespace Api.Infra.Repository
{
    public class ClienteRepository : BaseRepository<Client>
    {
        public ClienteRepository(ApiDbContext context) : base(context) { }
    }
}
