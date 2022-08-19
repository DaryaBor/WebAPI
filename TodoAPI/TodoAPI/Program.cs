using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using TodoAPI.Models;
using TodoAPI.Services;
using TodoAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

.

builder.Services.AddControllers();


builder.Services.AddScoped<IFilmRepository>(s => new FilmRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IFilmService, FilmService>();

builder.Services.AddScoped<ISeanceRepository>(s => new SeanceRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<ISeanceService, SeanceService>();

builder.Services.AddScoped<ITicketsRepository>(s => new TicketsRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<ITicketsService, TicketsService>();


var app = builder.Build();




app.MapControllers();

app.Run();
