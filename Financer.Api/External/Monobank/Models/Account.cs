namespace Financer.Api.External.Monobank.Models;

public record Account
{
    public required string Id { get; init; }
    public required string Iban { get; init; }
    public required string SendId { get; init; }
    public required string Type { get; init; }
    public int CurrencyCode { get; init; }
    public int Balance { get; init; }
    public int CreditLimit { get; init; }
    public string? CashbackType { get; init; }
    public List<string>? MaskedPan { get; init; }
}