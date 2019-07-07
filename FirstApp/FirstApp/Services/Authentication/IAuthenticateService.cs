using FirstApp.Models;

namespace FirstApp.Services.Authentication
{
    public interface IAuthenticateService
    {
        bool IsAuthenticated(TokenRequest request, out string token);
    }
}
