using System;
using FirstApp.Models;

namespace FirstApp.Services.Authentication
{
    public class TokenAuthenticationService : IAuthenticateService
    {
        public bool IsAuthenticated(TokenRequest request, out string token)
        {
            throw new NotImplementedException();
        }
    }
}
