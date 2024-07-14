namespace Financer.Api.Endpoints;

public static class HealthEndpoints
{
    public static void MapHealthEndpoints(this RouteGroupBuilder endpointsBuilder)
    {
        endpointsBuilder.MapGet("/healthz", () => Results.Ok("Healthy"));
    }
}
