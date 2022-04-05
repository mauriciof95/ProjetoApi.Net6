using Blazored.LocalStorage;

namespace Application.Util
{
    public static class Auth
    {
        public static async Task<bool> CheckToken(ILocalStorageService ls)
        {
            string token = await ls.GetToken();
            return !string.IsNullOrEmpty(token);
        }
    }
}
