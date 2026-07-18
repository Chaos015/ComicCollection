using ComicCollection.Application.Contract;
using ComicCollection.Application.Services;
using ComicCollection.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using ComicCollection.Infrastructure.Interfaces;
using ComicCollection.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<ComicCollectionContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddSingleton<IComicRepository, ComicRepository>();
builder.Services.AddScoped<IComicService, ComicService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
