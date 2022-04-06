using Api.Data.Context;
using Models;

namespace Infrastructure.Data.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>
    {
        public ClienteRepository(ApiContext context) : base(context) { }
    }
}
