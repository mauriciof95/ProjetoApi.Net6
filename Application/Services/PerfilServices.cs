using Models;

namespace Application.Services
{
    public class PerfilServices : BaseServices<Perfil>
    {
        public PerfilServices(string token) : base(token) => URL += "/perfil";
        
        public async Task<ICollection<Perfil>> GetAll() => await GetAllAsync();
    }
}
