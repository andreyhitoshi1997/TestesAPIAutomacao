using System.Threading.Tasks;
using TestesAPIAutomacao.Pages;
using Xunit;
using FluentAssertions;

namespace TestesAPIAutomacao.Tests
{
    public class ProtectedResourceTests
    {
        private readonly PublicResourcePage _publicResourcePage;

        public ProtectedResourceTests()
        {
            _publicResourcePage = new PublicResourcePage(Endpoints.BASE_URL);
        }

        [Fact]
        public async Task AccessPublicResource_ShouldReturnSuccess_WhenAuthenticated()
        {
            string responseContent = await _publicResourcePage.GetPublicResourceAsync();
            responseContent.Should().Contain("data"); // Verifica se a resposta tem dados
        }
    }
}
