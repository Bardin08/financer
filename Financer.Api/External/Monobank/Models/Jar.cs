namespace Financer.Api.External.Monobank.Models;

public record Jar
{
    public required string Id { get; init; }
    public required string SendId { get; init; }
    public required string Title { get; init; }
    public string? Description { get; init; }
    public int CurrencyCode { get; init; }
    public int Balance { get; init; }
    public int? Goal { get; init; }
}