using Blazored.LocalStorage;

namespace Application.Util
{
    public static class LocalStorageFunctions
    {
        private const string TokenKey = "token";

        public async static Task<string> GetToken(this ILocalStorageService ls)
            => await ls.GetItemAsStringAsync(TokenKey);
        
        public static async Task SetToken(this ILocalStorageService ls, string token)
            => await ls.SetItemAsStringAsync(TokenKey, token);

        public static async Task Clear(this ILocalStorageService ls)
            => await ls.ClearAsync();

        public static async Task<bool> IsLogged(this ILocalStorageService ls)
        {
            string token = await ls.GetToken();
            return !string.IsNullOrEmpty(token);
        }
    }
}
