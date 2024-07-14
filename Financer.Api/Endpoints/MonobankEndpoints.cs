using Financer.Api.External.Monobank;
using Financer.Api.External.Monobank.Models;
using Microsoft.AspNetCore.Mvc;

namespace Financer.Api.Endpoints;

public static class MonobankEndpoints
{
    public static void MapMonobankEndpoints(this IEndpointRouteBuilder app)
    {
        // This endpoint is used by Monobank to verify the webhook
        app.MapGet("/monobank/webhook", () => Results.Ok());

        app.MapPost("/monobank/webhook", async (
            [FromBody] WebhookPayload payload,
            [FromServices] IMonobankService monobankService,
            [FromServices] ILogger logger) =>
        {
            if (payload.Type != "StatementItem")
            {
                logger.LogWarning("Unknown payload type: {Type}, Full payload: {@Payload}", payload.Type, payload);
                return Results.Ok();
            }

            await monobankService.AddTransactionToYnab(
                payload.Data.Account,
                payload.Data.StatementItem);

            return Results.Ok();
        });
    }
}
