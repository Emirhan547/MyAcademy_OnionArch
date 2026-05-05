using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnionApp.Application.Features.Results.AppUserResults;
using OnionApp.Application.Features.Results.TokenResults;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Tools
{
    public class JwtTokenGenerator
    {
        public static GetTokenResponse GenerateToken(GetCheckAppUserQueryResult result, IConfiguration configuration)
        {
            var jwtSection = configuration.GetSection(JwtTokenDefaults.ConfigSectionName);
            var issuer = jwtSection["Issuer"] ?? throw new InvalidOperationException("Jwt:Issuer is required.");
            var audience = jwtSection["Audience"] ?? throw new InvalidOperationException("Jwt:Audience is required.");
            var keyText = jwtSection["Key"] ?? throw new InvalidOperationException("Jwt:Key is required.");
            var expireDays = int.TryParse(jwtSection["ExpireDays"], out var days) ? days : 3;

            var claims = new List<Claim>();
            if (!string.IsNullOrEmpty(result.Role))
                claims.Add(new Claim(ClaimTypes.Role, result.Role));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()));
           
            if (!string.IsNullOrEmpty(result.UserName))
                claims.Add(new Claim("Username", result.UserName));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyText));
            var signInCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.UtcNow.AddDays(expireDays);
            var token = new JwtSecurityToken(issuer: issuer, audience: audience, claims: claims, notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials: signInCredential);

            var handler = new JwtSecurityTokenHandler();
            return new GetTokenResponse(handler.WriteToken(token), expireDate);
        }
    }
}