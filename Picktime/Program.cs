using Microsoft.EntityFrameworkCore;
using Picktime.Context;
using Picktime.Controllers;
using Picktime.DTOs;
using Picktime.Interfaces;
using Picktime.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<PickTimeDbContext>(options => options.UseSqlServer("Data Source=DESKTOP-V1IJ63L\\SQLEXPRESS;Initial Catalog=PickTimeDB;Integrated Security=True;TrustServerCertificate=True"));
builder.Services.AddDbContext<PickTimeDbContext>(options => options.UseSqlServer("Data Source=DESKTOP-NBIV360;Initial Catalog=PickTimeDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));
builder.Services.AddScoped<IAuth, AuthService>(); //configure for my service 
builder.Services.AddScoped<ICategory, CategoryService>();
builder.Services.AddScoped<IBooking, BookingService>();
builder.Services.AddScoped<IProviderService, ProviderService>();
builder.Services.AddScoped<BaseDTO>();
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<MacAddressMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
