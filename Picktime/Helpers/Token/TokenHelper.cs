using Microsoft.IdentityModel.Tokens;
using Picktime.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Picktime.Helpers.Token
{
    public class TokenHelper
    {
        public static string GenerateJWTToken(User users,string role)
        {
          
            var jwtToken = new JwtSecurityTokenHandler();

            // Define the secret key 
            var secret = "longPrimarySecretForPichTimeProjectWithAspNetCoreFinalProject";
            var tokenByteKey = Encoding.UTF8.GetBytes(secret);

            // Define token descriptor with claims, expiry, and signing credentials
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim("UserId", users.Id.ToString()),
                new Claim("Role", role.ToString()),
                new Claim("SelectedLanguage",users.SelectedLanguage.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenByteKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtToken.CreateToken(descriptor);
            return jwtToken.WriteToken(token);
        }
        public static string IsVlaidToken(string token)
        {

            try
            {
                var jwtToken = new JwtSecurityTokenHandler();
                var secret = "longPrimarySecretForPichTimeProjectWithAspNetCoreFinalProject";
                var tokenByteKey = Encoding.UTF8.GetBytes(secret);
                var tokenValidtorParams = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(tokenByteKey),
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ClockSkew = TimeSpan.Zero
                };
                var tokenBase = jwtToken.ValidateToken(token, tokenValidtorParams, out SecurityToken valid);
                return "valid";

            }
            catch (Exception ex)
            {
                return $"InValid {ex.Message}";
            }


        }
    }
}
