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
using System.Security.Claims;

namespace Holy_locket.BLL.Services
{
    public class AuthService
    {
        public static async Task<string> GenerateJSONWebToken(IConfiguration config, int id, int role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var claims = new List<Claim>
            {
                new Claim("id", id.ToString()),
                new Claim("role", role.ToString()),
            };

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static async Task<bool> CheckToken(IConfiguration config, string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var validationParameters = await GetValidationParameters(config).ConfigureAwait(false);

            try
            {
                var result = await handler.ValidateTokenAsync(token, validationParameters);

                return result.IsValid;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Token validation failed: {ex.Message}");
                return false;
            }
        }
        public static async Task<UserRoleDTO> GetFromToken(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var result = handler.ReadToken(token) as JwtSecurityToken;

                if (result != null)
                {
                    var userIdClaim = result.Claims.FirstOrDefault(c => c.Type == "id");
                    var roleClaim = result.Claims.FirstOrDefault(c => c.Type == "role");

                    if (userIdClaim?.Value != null && int.TryParse(userIdClaim.Value, out int userId) && int.TryParse(roleClaim.Value, out int role))
                    {
                        return new UserRoleDTO(userId, role);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to get from token: {ex.Message}");
            }
            return null;
        }
        private static async Task<TokenValidationParameters> GetValidationParameters(IConfiguration config)
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
