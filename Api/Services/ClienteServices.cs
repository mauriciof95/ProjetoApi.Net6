using Infrastructure.Data.Repository;
using Models;

namespace Api.Services
{
    public class ClienteServices : BaseServices<Cliente>
    {
        public ClienteServices(ClienteRepository repository) : base(repository) { }
    
    }
}
