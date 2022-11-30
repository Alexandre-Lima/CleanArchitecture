using Newtonsoft.Json;
using System.Net.Mime;
using System.Text;

namespace CleanArchitecture.Repositories
{
    public abstract class ApiRepository
    {
        private HttpClient _httpClient;

        protected ApiRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected void SetHeadToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", token);
        }

        protected async Task<T> PostAsync<T>(string url, object request)
        {
            var uri = new Uri(url, UriKind.Relative);
            using var content = GetContent(request);
            using var response = await _httpClient.PostAsync(uri, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException($"Erro ao salvar.");
            }

            return JsonConvert.DeserializeObject<T>(responseContent);
        }

        protected async Task<T> GetAsync<T>(string url)
        {
            var uri = new Uri(url, UriKind.Relative);
            using var response = await _httpClient.GetAsync(uri);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException($"Erro ao consultar.");
            }

            return JsonConvert.DeserializeObject<T>(responseContent);
        }

        private static StringContent GetContent(object request)
        {
            var json = JsonConvert.SerializeObject(request);
            return new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
        }
    }
}
