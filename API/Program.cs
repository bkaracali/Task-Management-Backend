using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<admin123Context>(options =>
                   options.UseNpgsql("Persist Security Info=True;Password=kadircanborasemih;Username=admin123;Database=admin123;Host=localhost"));
ServiceDI.Init(builder.Services);

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
