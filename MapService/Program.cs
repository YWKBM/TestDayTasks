using MapLib;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMapLib("localhost:6379");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();