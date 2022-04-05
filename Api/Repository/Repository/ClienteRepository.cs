using Models;

namespace Api.Repository.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>
    {
        public ClienteRepository(ApiContext context) : base(context) { }
    }
}
