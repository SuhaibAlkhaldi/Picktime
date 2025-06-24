using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Picktime.DTOs.JWT;
using System.Text;

namespace Picktime.Heplers.JWT
{
    public static class JwtStartup
    {
        public static void InitializeJwt(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSettings jwtSettings = new();
            configuration.Bind(nameof(jwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);
            // services.ConfigureCORS(configuration);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.Zero
                };
                x.IncludeErrorDetails = true;
            });
        }
    }
}
