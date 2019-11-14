using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Company.Application.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Company.API.Extensions
{
    public static class TokenService
    {
        public static string GenerateToken(UserViewModel user, IConfiguration iconfiguration)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var connStr = iconfiguration.GetConnectionString("Secret_Chave_Privada_Token");
            var key = Encoding.ASCII.GetBytes(connStr);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Role, user.RolesDescription)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}