using Financer.Api.Endpoints;

namespace Financer.Api.DependencyInjection;

public static class EndpointsExtensions
{
    public static void UseEndpoints(this WebApplication app)
    {
        var apiEndpoints = app.MapGroup("/api");

        apiEndpoints.MapHealthEndpoints();
    }
}
