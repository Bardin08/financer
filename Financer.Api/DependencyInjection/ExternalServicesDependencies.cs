using Financer.Api.External.Monobank;
using Financer.Api.Services;
using YnabNet;

namespace Financer.Api.DependencyInjection;

public static class ExternalServicesDependencies
{
    public static void AddExternalServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddYnabClient(configuration);
        services.AddScoped<IYnabService, YnabService>(sp =>
        {
            var ynabClient = sp.GetRequiredService<IYnabClient>();
            var logger = sp.GetRequiredService<ILogger<YnabService>>();
            var budgetId = Guid.Parse(configuration["YNAB:BudgetId"]!);
            return new YnabService(budgetId, ynabClient, logger);
        });

        services.AddScoped<IMonobankService, MonobankService>();
        services.AddHttpClient<IMonobankApiClient, MonobankApiClient>(c =>
        {
            c.BaseAddress = new Uri("https://api.monobank.ua/");
            c.DefaultRequestHeaders.Add("X-Token", configuration["Monobank:Token"]);
        });
    }
}
