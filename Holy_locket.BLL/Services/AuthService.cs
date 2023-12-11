using Holy_locket.BLL.DTO;
using Holy_locket.BLL.Services.Abstraction;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.Services
{
    public class AuthService
    {
        public async static Task<string> GenerateJSONWebToken(IConfiguration config, int id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var claims = new List<Claim> { new Claim(ClaimValueTypes.DnsName, id.ToString()) };
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(config["Jwt:Issuer"],
              config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async static Task<bool> CheckToken(IConfiguration config, TokenInfoDTO loginInfo)
        {
            var handler = new JwtSecurityTokenHandler();
            var validationParametrs = await GetValidationParameters(config).ConfigureAwait(false);
            var result = await handler.ValidateTokenAsync(loginInfo.token, validationParametrs);
            string key = "http://schemas.xmlsoap.org/claims/dns";
            if (result.IsValid)
            {
                if (result.Claims.ContainsKey(key) && result.Claims[key].ToString() == loginInfo.id.ToString())
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        private async static Task<TokenValidationParameters> GetValidationParameters(IConfiguration config)
        {

            return new TokenValidationParameters()
            {
                ValidateLifetime = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidIssuer = config["Jwt:Issuer"],
                ValidAudience = config["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
            };
        }
    }
}
