using CleanArchitechture.Application.Dtos.User;
using CleanArchitechture.Application.Services.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitechture.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private TokenConfig tokenConfig;
        public TokenService(IOptions<TokenConfig> options)
        {
            tokenConfig = options.Value;
        }
        public string GenerateToken(GetUserDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenConfig.Key);
            List<Claim> claims = new List<Claim>() 
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name)
            };
            var securityToken = new JwtSecurityToken(
                issuer: tokenConfig.Issuer,
                audience: tokenConfig.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

                );
            var token = tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
