using ecommerce_biu.Models;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace ecommerce_biu.Utils
{
    internal sealed class JwtUtils
    {
        public static string Generate(User user)
        {
            string secretLKey = "your-secret-key-123";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretLKey));
            var credentias = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([

                    new("username", user.UserName),
                    new("role", user.Rol.Name)
                ]
                ),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = credentias,
                Issuer = "Issuer",
                Audience = "Audience"
            };
            var handler = new JsonWebTokenHandler();
            return handler.CreateToken(tokenDescriptor);
        }


    }
}
