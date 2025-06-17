using Microsoft.EntityFrameworkCore;
using Picktime.Context;
using Picktime.Interfaces;
using Picktime.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PickTimeDbContext>(options => options.UseSqlServer("Data Source=DESKTOP-V1IJ63L\\SQLEXPRESS;Initial Catalog=PickTimeDB;Integrated Security=True;TrustServerCertificate=True"));
builder.Services.AddScoped<IAuth, AuthService>(); //configure for my service 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
