using Financer.Api.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();
builder.AddLogging();

builder.Services.AddDevTools();

var app = builder.Build();
if (app.Environment.IsDevelopment())
    app.UseDevTools();

app.UseEndpoints();

app.Run();
