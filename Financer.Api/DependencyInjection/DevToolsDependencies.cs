namespace Financer.Api.DependencyInjection;

public static class DevToolsDependencies
{
    public static void AddDevTools(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public static void UseDevTools(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Financer API V1");
            c.RoutePrefix = string.Empty;
        });
    }
}
