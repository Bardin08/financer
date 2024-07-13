namespace Financer.Api.Endpoints;

public static class HealthEndpoints
{
    public static void MapHealthEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var groupBuilder = endpoints.MapGroup("/api");

        groupBuilder.MapGet("/healthz", () => Results.Ok("Healthy"));
    }
}
