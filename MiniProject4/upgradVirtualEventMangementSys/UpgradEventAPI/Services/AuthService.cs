using DAL.DataAccess;
using DAL.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UpgradEventAPI.Models;

namespace UpgradEventAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserInfoService _userService;
        private readonly IConfiguration _config;

        public AuthService(UserInfoService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        public async Task<string> Login(string email, string password)
        {
            var user = _userService.Login(email, password);

            if (user == null)
                return null;

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.EmailId),
            new Claim(ClaimTypes.Role, user.Role)
        };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}