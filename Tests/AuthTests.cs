using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using RestSharp;
using TestesAPIAutomacao.Pages; // Adicione essa linha para importar ApiClient
using TestesAPIAutomacao; // Adicione essa linha para importar Endpoints

namespace TestesAPIAutomacao.Tests
{
    public class AuthTests
    {
        private readonly ApiClient _apiClient;

        public AuthTests()
        {
            _apiClient = new ApiClient(Endpoints.BASE_URL);
        }

        [Fact]
        public async Task GetUsers_ShouldReturnSuccess()
        {
            var response = await _apiClient.GetAsync(Endpoints.USERS);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Content.Should().Contain("data");
        }

        [Fact]
        public async Task Login_ShouldReturnUnauthorized_WhenInvalidCredentials()
        {
            var response = await _apiClient.PostAsync(Endpoints.LOGIN, new { email = "invalid@example.com", password = "123456" });
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }
    }
}
