using Infrastructure.Data.Repository;
using Api.Data.Context;
using Models;

namespace Api.Services
{
    public class ClienteServices : BaseServices<Cliente, ClienteRepository>
    {
        public ClienteServices(ApiContext context) : base(context) { }
    
    }
}
