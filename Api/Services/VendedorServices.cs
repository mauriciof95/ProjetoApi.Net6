using Infrastructure.Data.Repository;
using Api.Data.Context;
using Models;

namespace Api.Services
{
    public class VendedorServices : BaseServices<Vendedor, VendedorRepository>
    {
        public VendedorServices(ApiContext context) : base(context) { }
    }
}
