using Api.Repository;
using Api.Repository.Repository;
using Models;

namespace Api.Services
{
    public class ClienteServices : BaseServices<Cliente, ClienteRepository>
    {
        public ClienteServices(ApiContext context) : base(context) { }
    
    }
}
