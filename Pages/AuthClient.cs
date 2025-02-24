using RestSharp;
using System.Threading.Tasks;

namespace TestesAPIAutomacao.Pages
{
    public class AuthClient
    {
        private readonly ApiClient _apiClient;
        private string? _token;

        public AuthClient(string baseUrl)
        {
            _apiClient = new ApiClient(baseUrl);
        }

        public async Task<string> GetTokenAsync()
        {
            if (_token != null)
                return _token; // Reutiliza o token se já existir

            var requestBody = new
            {
                email = "eve.holt@reqres.in",
                password = "cityslicka"
            };

            var response = await _apiClient.PostAsync(Endpoints.LOGIN, requestBody);

            if (response.IsSuccessful)
            {
                _token = response.Content.Split("\"token\":\"")[1].Split("\"")[0]; // Captura o token do JSON
                return _token;
            }

            throw new System.Exception("Falha ao obter token");
        }
    }
}
