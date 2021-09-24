using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SCAPE.Application.DTOs;
using SCAPE.Application.Interfaces;
using SCAPE.Application.Utils;
using SCAPE.Domain.Entities;
using SCAPE.Domain.Exceptions;
using SCAPE.Domain.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SCAPE.Application.Services
{
    public class TokenService : ITokenService
    {

        

        public TokenService()
        {

        }

        /// <summary>
        /// Create a JSON Web Token for a new user session
        /// </summary>
        /// <param name="user">User logged in</param>
        /// <param name="secretKey">Key to encrypt the JSON Web token</param>
        /// <returns></returns>
        public TokenModelDTO getToken(User user,string secretKey)
        {
            var key = Encoding.ASCII.GetBytes(secretKey);
            double expires_in = 5000;

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            claims.AddClaim(new Claim(ClaimTypes.Role, user.Role));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(expires_in),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            string bearer_token = tokenHandler.WriteToken(createdToken);

            return new TokenModelDTO(bearer_token,"bearer",expires_in,user.Role);
        }
    }
}
