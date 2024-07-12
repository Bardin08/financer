using Financer.Api.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDevTools();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDevTools();

app.MapGet("/ping", () => Results.Ok("pong"))
    .WithName("ping")
    .WithOpenApi();

app.Run();
