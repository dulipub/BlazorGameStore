using BlazorGameStore.API.Apis;
using BlazorGameStore.API.Infrastructure;
using BlazorGameStore.API.Models;
using BlazorGameStore.API.Repositories;
using BlazorGameStore.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<GameStoreContext>( options => options.UseInMemoryDatabase("gamestore"));

builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { 
            Title = "",
            Description = "",
            Version = "v1",
        });
    }
);

builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IRepository<Game>, BaseRepository<Game>>();
builder.Services.AddScoped<IRepository<Genre>, BaseRepository<Genre>>();

// Configure Mapster
MapsterConfig.Configure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GamesStore");
    });
}

app.UseHttpsRedirection();

//Map API endpoints
app.MapGamesApi();
app.MapGenresApi();

//seed data
Initialize.Configure(app);

app.Run();
