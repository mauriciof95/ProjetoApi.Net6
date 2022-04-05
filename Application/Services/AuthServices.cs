using Models.Request;
using Models.ViewModel;

namespace Application.Services
{
    public class AuthServices : BaseServices<UserAuthRequest>
    {
        public AuthServices(string token) : base(token)
        {
            URL += "/Usuario";
        }

        public async Task<TokenVM> Login(UserAuthRequest userAuth) 
            => await PostAsync<TokenVM>($"{URL}/login", userAuth);

        public async Task Logout()
            => await GetAsync($"{URL}/revoke");
        

    }
}
