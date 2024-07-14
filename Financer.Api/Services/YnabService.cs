using YnabNet;
using YnabNet.Models.Requests;

namespace Financer.Api.Services;

public interface IYnabService
{
    public Task CreateTransaction(TransactionCreateRequest<TransactionPayload> transaction);
}

public class YnabService(
    Guid budgetId,
    IYnabClient ynabClient,
    ILogger<YnabService> logger) : IYnabService
{
    private readonly Guid _budgetId = budgetId;
    private readonly IYnabClient _ynabClient = ynabClient;
    private readonly ILogger<YnabService> _logger = logger;

    public async Task CreateTransaction(TransactionCreateRequest<TransactionPayload> transaction)
    {
        try
        {
            var response = await _ynabClient.Transactions.Create(_budgetId, transaction);

            if (response?.Transaction == null)
            {
                _logger.LogError("Error while creating transaction. {PayeeName}: {Amount}",
                    transaction.Transaction.PayeeName, transaction.Transaction.Amount);
            }
        }
        catch (Exception e)
        {
            // in the future I'd like to add some retry logic
            _logger.LogError(e, "Error while creating transaction. {PayeeName}: {Amount}",
                transaction.Transaction.PayeeName, transaction.Transaction.Amount);
        }
    }
}
