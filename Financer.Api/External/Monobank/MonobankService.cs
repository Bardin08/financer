using Financer.Api.External.Monobank.Models;
using Financer.Api.Services;
using YnabNet.Models.Requests;

namespace Financer.Api.External.Monobank;

public interface IMonobankService
{
    Task AddTransactionToYnab(string account, Statement statement);
}

public class MonobankService(IYnabService ynabService) : IMonobankService
{
    private readonly IYnabService _ynabService = ynabService;

    // get actual mapping of the accounts,
    // get category for the transaction
    public async Task AddTransactionToYnab(string account, Statement statement)
    {
        var transactionDate = DateOnly.FromDateTime(DateTimeOffset.FromUnixTimeSeconds(statement.Time).Date);
        var createTransaction = new TransactionCreateRequest<TransactionPayload>
        {
            Transaction = new TransactionPayload
            {
                AccountId = Guid.Parse("6c0e4bd4-4b40-4ca2-b52c-80daae4a1faa"),
                Amount = ToYnabUnits(statement.Amount),
                Date = transactionDate,
                PayeeName = statement.CounterName,
                Memo = statement.Description,
                Cleared = "cleared",
            }
        };

        await _ynabService.CreateTransaction(createTransaction);
    }

    private long ToYnabUnits(int statementAmount)
    {
        // YNAB uses 1/1000 of the currency unit,
        // so to process the spending amount we need to multiply it by 10
        const float multiplier = 10;
        return (long)(statementAmount * multiplier);
    }
}
