using Newtonsoft.Json;
using WebServices.Http.Util;

namespace Application.Services
{
    public class BaseServices<T>
    {
        protected HttpServices _http;
        protected string URL;
        protected const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";

        public BaseServices(string token){
            _http = new HttpServices();
            _http.AddHeader("Authorization", $"Bearer {token}");
            URL = "http://localhost:8900";
        }

        protected async Task<ICollection<T>> GetAllAsync()
            => await _http.GET<ICollection<T>>($"{URL}");

        protected async Task<ICollection<TAnother>> GetAllAsync<TAnother>(string resource)
            => await _http.GET<ICollection<TAnother>> ($"{resource}");

        protected async Task<T> GetAsync(string resource)
            => await _http.GET<T>(resource);

        protected async Task<TAnother> GetAsync<TAnother>(string resource)
            => await _http.GET<TAnother>(resource);

        protected async Task<T> PostAsync(string resource, T model)
            => await _http.POST<T>(resource, JsonConvert.SerializeObject(model));

        protected async Task<TAnother> PostAsync<TAnother>(string resource, T model)
            => await _http.POST<TAnother>(resource, JsonConvert.SerializeObject(model));

        protected async Task<T> PutAsync<T>(string resource, T model)
            => await _http.POST<T>(resource, JsonConvert.SerializeObject(model));

        protected async Task DeleteAsync<T>(string resource)
            => await _http.DELETE<T>(resource);

        protected string UrlDate(DateTime date) => date.ToString("dd-MM-yyyy hh:mm:ss");
    }
}
