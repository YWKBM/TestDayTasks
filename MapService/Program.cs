using MapLib;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMapLib("localhost:6379");
builder.Services.AddMagicOnion();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();