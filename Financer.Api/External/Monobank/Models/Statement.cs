namespace Financer.Api.External.Monobank.Models;

public record Statement
{
    public required string Id { get; init; }
    public string? Description { get; init; }
    public int Time { get; init; }
    public int Mcc { get; init; }
    public int OriginalMcc { get; init; }
    public bool Hold { get; init; }
    public int Amount { get; init; }
    public int OperationAmount { get; init; }
    public int CurrencyCode { get; init; }
    public int CommissionRate { get; init; }
    public int CashbackAmount { get; init; }
    public int Balance { get; init; }
    public string? Comment { get; init; }
    public string? ReceiptId { get; init; }
    public required string InvoiceId { get; init; }
    public string? CounterEdrpou { get; init; }
    public required string CounterIban { get; init; }
    public required string CounterName { get; init; }
}
