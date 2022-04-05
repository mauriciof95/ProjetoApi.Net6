using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace WebServices.Http.Util
{
    public class HttpServices
    {
        private HttpClient _httpClient;

        public HttpServices()
        {
            _httpClient = new HttpClient();
        }

        public void AddHeader(string name, string value)
            => _httpClient.DefaultRequestHeaders.Add(name, value);

        public void AddBasicAuth(string client, string secret)
        {
            var hash = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(client + ":" + secret));
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", hash);
        }

        public async Task<T> GET<T>(string url)
        {
            HttpResponseMessage response = await SendRequest(_httpClient, new HttpRequestOption(){ 
                Method = "GET",
                Url = url
            });
            return await PrepareResponse<T>(response, response.StatusCode);
        }

        public async Task<List<T>> GetAll<T>(string url)
        {
            HttpResponseMessage response = await SendRequest(_httpClient, new HttpRequestOption()
            {
                Method = "GET",
                Url = url
            });
            return await PrepareResponse<List<T>>(response, response.StatusCode);
        }

        public async Task<List<T>> GetAll_JetOil<T>(string url, HttpContent content)
        {
            HttpResponseMessage response = await SendRequest(_httpClient, new HttpRequestOption()
            {
                Method = "GET",
                HttpContent = content,
                Url = url
            });
            return await PrepareResponse<List<T>>(response, response.StatusCode);
        }

        public async Task<T> POST<T>(string url, HttpContent content)
        {
            HttpResponseMessage response = await SendRequest(_httpClient, new HttpRequestOption()
            {
                Method = "POST",
                Url = url,
                HttpContent = content
            });
            return await PrepareResponse<T>(response, response.StatusCode);
        }

        public async Task<T> POST<T>(string url, string content)
            => await POST<T>(url, JsonToHttpContent(content));

        public async Task<T> PUT<T>(string url, HttpContent content)
        {
            HttpResponseMessage response = await SendRequest(_httpClient, new HttpRequestOption()
            {
                Method = "PUT",
                Url = url,
                HttpContent = content
            });
            return await PrepareResponse<T>(response, response.StatusCode);
        }

        public async Task<T> PUT<T>(string url, string content)
            => await PUT<T>(url, JsonToHttpContent(content));
        

        public async Task DELETE<T>(string url)
        {
            HttpResponseMessage response = await SendRequest(_httpClient, new HttpRequestOption()
            {
                Method = "DELETE",
                Url = url
            });
            await PrepareResponse<T>(response, response.StatusCode);
        }

        public StringContent JsonToHttpContent(string jsonData)
        {
            return new StringContent(jsonData, Encoding.UTF8, "application/json");
        }

        public async Task<HttpResponseMessage> SendRequest(HttpClient http, HttpRequestOption options)
        {
            try
            {
                switch (options.Method)
                {
                    case "GET":
                        return await http.GetAsync(options.Url);
                    case "POST":
                        return await http.PostAsync(options.Url, options.HttpContent);
                    case "PUT":
                        return await http.PutAsync(options.Url, options.HttpContent);
                    case "DELETE":
                        return await http.DeleteAsync(options.Url);
                    default:
                        return null;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<T> PrepareResponse<T>(HttpResponseMessage response, HttpStatusCode statusCode)
        {
            if ((int) statusCode >= 200 && (int)statusCode < 300)
            {
                var json = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(json)) return default(T);

                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                switch (statusCode)
                {
                    case HttpStatusCode.NotFound:
                        return default(T);
                    case HttpStatusCode.Unauthorized:
                        throw new Exception("Acesso não autorizado");
                    case HttpStatusCode.ServiceUnavailable:
                        throw new Exception("Serviço indisponível! Tente mais tarde!");
                    case HttpStatusCode.UnprocessableEntity:
                        throw new Exception(response.RequestMessage.ToString());
                    case HttpStatusCode.InternalServerError:
                        throw new Exception("Erro interno do servidor.");
                    default:
                        throw new Exception("Houve problemas ao realizar sua requisição.");
                }
            }
        }
    }

    public class HttpRequestOption
    {
        public string Method { get; set; }
        public string Url { get; set; }
        public HttpContent HttpContent { get; set; }
    }
}
