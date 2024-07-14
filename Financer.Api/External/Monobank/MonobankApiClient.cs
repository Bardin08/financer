using Financer.Api.External.Monobank.Models;

namespace Financer.Api.External.Monobank;

public interface IMonobankApiClient
{
    Task<UserInfo?> GetUserInfoAsync();
    Task<List<Statement>?> GetStatementsAsync(string accountId, DateTime from, DateTime to);
}

public class MonobankApiClient : IMonobankApiClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<MonobankApiClient> _logger;

    public MonobankApiClient(
        string token,
        HttpClient httpClient,
        ILogger<MonobankApiClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
        _httpClient.BaseAddress = new Uri("https://api.monobank.ua/");
        _httpClient.DefaultRequestHeaders.Add("X-Token", token);
    }

    public async Task<UserInfo?> GetUserInfoAsync()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<UserInfo>("personal/client-info");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting user info");
            return null;
        }
    }

    public async Task<List<Statement>?> GetStatementsAsync(string accountId, DateTime from, DateTime to)
    {
        try
        {
            var unixFrom = new DateTimeOffset(from).ToUnixTimeSeconds();
            var unixTo = new DateTimeOffset(to).ToUnixTimeSeconds();

            return await _httpClient.GetFromJsonAsync<List<Statement>>(
                $"personal/statement/{accountId}/{unixFrom}/{unixTo}");
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting statements");
            return new List<Statement>();
        }
    }
}
