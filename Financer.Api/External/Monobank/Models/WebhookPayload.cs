namespace Financer.Api.External.Monobank.Models;

public record WebhookPayload
{
    public required string Type { get; init; }
    public required PayloadData Data { get; init; }
}

public record PayloadData
{
    public required string Account { get; init; }
    public required Statement StatementItem { get; init; }
}
