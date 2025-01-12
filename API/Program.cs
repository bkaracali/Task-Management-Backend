using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS servisini ekleyin
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder
            .WithOrigins("http://localhost:3000")  // Frontend'in çalýþtýðý adresi burada belirtin
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// DbContext'i ekleyin
builder.Services.AddDbContext<admin123Context>(options =>
                   options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Diðer servisleri ekleyin
ServiceDI.Init(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS politikasýný uygulayýn
app.UseCors("AllowLocalhost");

app.UseAuthorization();

app.MapControllers();

app.Run();