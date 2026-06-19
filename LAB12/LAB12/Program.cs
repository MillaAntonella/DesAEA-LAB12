using LAB12.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Jueves18Context>(options =>
    options.UseSqlServer(
        "Server=LAB1508-18\\SQLEXPRESS;" +
        "Database=JUEVES18;" +
        "Trusted_Connection=True;" +
        "TrustServerCertificate=True"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();