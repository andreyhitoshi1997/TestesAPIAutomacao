using System.Threading.Tasks;

namespace TestesAPIAutomacao.Pages
{
    public class PublicResourcePage
    {
        private readonly ApiClient _apiClient;
        private readonly AuthClient _authClient;

        public PublicResourcePage(string baseUrl)
        {
            _apiClient = new ApiClient(baseUrl);
            _authClient = new AuthClient(baseUrl);
        }

        public async Task<string> GetPublicResourceAsync()
        {
            string token = await _authClient.GetTokenAsync();
            var response = await _apiClient.GetAsync(Endpoints.PUBLIC_RESOURCE, token);
            
            if (!response.IsSuccessful)
                throw new System.Exception("Falha ao acessar recurso público protegido");

            return response.Content;
        }
    }
}
