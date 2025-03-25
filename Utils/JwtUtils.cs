using ecommerce_biu.Models;
using ecommerce_biu.Responses;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace ecommerce_biu.Utils
{
    public sealed class JwtUtils(IConfiguration configuration)
    {
        public AuthResponse Generate(User user)
        {
            string secretLKey = configuration["Jwt:Secret"]!;
            int expirationTime = configuration.GetValue<int>("Jwt:ExpirationInMinutes");
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(secretLKey));
            var credentias = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([
                    new("idUser", user.Id.ToString()),
                    new("username", user.UserName),
                    new("email", user.Email),
                    //new("role", user.Rol.Name),
                    new(ClaimTypes.Role, user.Rol.Name)
                ]
                ),
                Expires = DateTime.UtcNow.AddMinutes(expirationTime),
                SigningCredentials = credentias,
                Issuer = configuration["Jwt:Issuer"]!,
                Audience = configuration["Jwt:Audience"]!
            };
            var handler = new JsonWebTokenHandler();
            string token = handler.CreateToken(tokenDescriptor);

            AuthResponse response = new()
            {
                IdUser = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Role = user.Rol.Name,
                Jwt = token,
                ExpirationTime = expirationTime
            };

            return response;
        }


    }
}
