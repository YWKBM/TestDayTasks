using MapLib;
using MapLib.Core.Interfaces;
using MapLib.Core.Models.ObjectModel;
using MapService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMapLib("localhost:6379");

builder.Services.AddMagicOnion();
builder.Services.AddScoped<MapHubService>();
builder.Services.AddGrpc();

var app = builder.Build();

app.MapMagicOnionService();


app.MapGet("/", () =>
{
});
app.MapMagicOnionService();


app.Run();