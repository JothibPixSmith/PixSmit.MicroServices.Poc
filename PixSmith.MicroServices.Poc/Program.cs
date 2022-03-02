using Microsoft.EntityFrameworkCore;
using PixSmith.MicroServices.Infrastructure.Database;
using PixSmith.MicroServices.Infrastructure.Repositories;
using PixSmith.MicroServices.Infrastructure.Repositories.Interfaces;
using PixSmith.MicroServices.Poc.Infrastructure.JsonContexts.Domain;
using PixSmith.MicroServices.Services;
using PixSmith.MicroServices.Services.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlite<PocContext>($"Data Source=.\\testDb.db");

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        opts.JsonSerializerOptions.AddContext<ArtistContext>();        
    });

builder.Services.AddTransient<IArtistRepository, ArtistRepository>();
builder.Services.AddTransient<IArtistService, ArtistService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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


