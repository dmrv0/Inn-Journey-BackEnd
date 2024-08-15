using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SednaReservationAPI.Application.Abstractions.Token;
using SednaReservationAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.RateLimiting;
using System.Threading.Tasks;

namespace SednaReservationAPI.Infrastructure.Services
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Application.DTOs.Token CreateAccessToken(int minute)
        {
            Application.DTOs.Token token = new();

            // Symmetry of SecurityKey
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            
            // Encryption of SymmetricSecurityKey
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);
            var isAdmin = true;


            // Custom claim for isAdmin
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, "Admin"), // Add role claim if needed
                new Claim("isAdmin", "true") // Add custom claim
            };
            
         

            // Settings for Create Token
            token.Expiration = DateTime.UtcNow.AddMinutes(minute);
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials,
                 claims: claims 
                );

            // Token Creater
            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);

            // Refreash Token Creater
            token.RefreshToken = CreateRefreshtoken();
            return token;
            
        }

        public string CreateRefreshtoken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}
