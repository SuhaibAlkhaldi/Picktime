using Microsoft.IdentityModel.Tokens;
using Picktime.DTOs.JWT;
using Picktime.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Picktime.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;

        public TokenService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            int minutesExpiration =  _jwtSettings.Portal_AccessTokenExpirationInMinutes;
            SymmetricSecurityKey secretKey = new(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            SigningCredentials signinCredentials = new(secretKey, SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityToken tokeOptions = new(
            claims: claims,
            expires: DateTime.Now.AddMinutes(minutesExpiration),
            signingCredentials: signinCredentials
        );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            TokenValidationParameters tokenValidationParameters = new()
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };
            JwtSecurityTokenHandler tokenHandler = new();
            SecurityToken securityToken;
            ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }



    }
}
