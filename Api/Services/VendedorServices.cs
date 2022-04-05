using Api.Repository;
using Api.Repository.Repository;
using Models;

namespace Api.Services
{
    public class VendedorServices : BaseServices<Vendedor, VendedorRepository>
    {
        public VendedorServices(ApiContext context) : base(context) { }
    }
}
