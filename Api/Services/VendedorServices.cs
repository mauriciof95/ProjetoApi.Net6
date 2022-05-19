using Infrastructure.Data.Repository;
using Models;

namespace Api.Services
{
    public class VendedorServices : BaseServices<Vendedor>
    {
        public VendedorServices(VendedorRepository repository) : base(repository) { }
    }
}
