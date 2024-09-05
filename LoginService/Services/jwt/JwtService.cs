using LoginService.Core.Configuraciones;
using LoginService.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoginService.Services.jwt
{
    public class JwtService(IConfigurations _configurations) : IJwtService
    {
        public string GenerationToken(UserModel infoUser)
        {
            var key = _configurations.getSetting("JwtSettings:Key");

            var keyBytes = Encoding.ASCII.GetBytes(key);

            var claims = new ClaimsIdentity();

            claims.AddClaim(
                new Claim(ClaimTypes.NameIdentifier, infoUser.UserName)
                );

            var credentialsToken = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature
                );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = credentialsToken
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);


            string token = tokenHandler.WriteToken(tokenConfig);
            return token;
        }
    }
}
