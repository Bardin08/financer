using Serilog;
using Serilog.Events;
using X.Serilog.Sinks.Telegram.Extensions;

namespace Financer.Api.DependencyInjection;

public static class LoggingDependencies
{
    public static void AddLogging(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.TelegramCore(
                builder.Configuration["Logging:Telegram:Token"]!,
                builder.Configuration["Logging:Telegram:ChatId"]!,
                LogEventLevel.Warning)
            .CreateLogger();

        builder.Logging.AddSerilog();
    }
}
