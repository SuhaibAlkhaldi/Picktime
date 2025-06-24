using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Picktime.Context;
using Picktime.Controllers;
using Picktime.DTOs;
using Picktime.DTOs.Auth;
using Picktime.DTOs.JWT;
using Picktime.Heplers.Swagger;
using Picktime.Interfaces;
using Picktime.Middleware;
using Picktime.Services;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PickTimeDbContext>(options => options.UseSqlServer("Data Source=DESKTOP-V1IJ63L\\SQLEXPRESS;Initial Catalog=PickTimeDB;Integrated Security=True;TrustServerCertificate=True"));
builder.Services.AddScoped<IAuth, AuthService>(); //configure for my service 
builder.Services.AddScoped<ICategory, CategoryService>();
builder.Services.AddScoped<IProvider, ProviderService>();
builder.Services.AddScoped<IProviderServiceService, ProviderServiceService>();
builder.Services.AddScoped<IUserReview, UserReviewService>();
builder.Services.AddScoped<ILockUpItem, LockUpItemService>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddScoped<BaseDTO>();
builder.Services.AddScoped<SessionProvider>();

JwtSettings jwtSettings = new();
configuration.Bind(nameof(jwtSettings), jwtSettings);
builder.Services.AddSingleton(jwtSettings);

builder.Services.Configure<UserConfiguration>(builder.Configuration.GetSection("UserConfiguration"));
builder.Services.AddSingleton<UserConfiguration>(provider =>
{
    var config = provider.GetRequiredService<IOptions<UserConfiguration>>();
    return config.Value;
});
builder.Services.AddHttpContextAccessor();
builder.Services.InitializeSwagger();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pick Time API", Version = "v1" });
    c.CustomSchemaIds(type => type.ToString());
    //c.EnableAnnotations();
    c.UseInlineDefinitionsForEnums(); // hide completely
                                      // c.DefaultModelsExpandDepth(0); // collapse

    c.MapType(typeof(TimeSpan), () => new OpenApiSchema
    {
        Type = "string",
        Example = new OpenApiString("00:00:00")
    });

});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false, // or true with proper Issuer
            ValidateAudience = false, // or true with expected Audience
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)) // should match the one used to sign the token
        };
    });

builder.Services.AddAuthorization();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<MacAddressMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<SessionMiddleware>();
app.MapControllers();

app.Run();
