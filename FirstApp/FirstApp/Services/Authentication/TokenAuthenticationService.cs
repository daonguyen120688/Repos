using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FirstApp.Models;
using FirstApp.Services.UserManagement;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FirstApp.Services.Authentication
{
    public class TokenAuthenticationService : IAuthenticateService
    {
        private readonly IUserManagementService _userManagementService;
        private readonly TokenManagement _tokenManagement;

        public TokenAuthenticationService(IUserManagementService userManagementService, IOptions<TokenManagement> tokenManagement)
        {
            _userManagementService = userManagementService;
            _tokenManagement = tokenManagement.Value;
        }

        public bool IsAuthenticated(TokenRequest request, out string token)
        {
            token = string.Empty;
            if (!_userManagementService.IsValidUser(request.Username, request.Password)) return false;

            var claim = new[]
            {
                new Claim(ClaimTypes.Name, request.Username),
                new Claim(ClaimTypes.DateOfBirth,"06/12/1988")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                _tokenManagement.Issuer,
                _tokenManagement.Audience,
                claim,
                expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration),
                signingCredentials: credentials
            );
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return true;
        }
    }
}
