using RestSharp;
using System.Threading.Tasks;

namespace TestesAPIAutomacao.Pages
{
    public class ApiClient
    {
        private readonly RestClient _client;

        public ApiClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public async Task<RestResponse> GetAsync(string endpoint, string token = null)
        {
            var request = new RestRequest(endpoint, Method.Get);
            if (token != null)
                request.AddHeader("Authorization", $"Bearer {token}");

            return await _client.ExecuteAsync(request);
        }

        public async Task<RestResponse> PostAsync(string endpoint, object body, string token = null)
        {
            var request = new RestRequest(endpoint, Method.Post);
            request.AddJsonBody(body);
            if (token != null)
                request.AddHeader("Authorization", $"Bearer {token}");

            return await _client.ExecuteAsync(request);
        }
    }
}
