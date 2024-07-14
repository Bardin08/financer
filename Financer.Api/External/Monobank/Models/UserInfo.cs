namespace Financer.Api.External.Monobank.Models;

public record UserInfo
{
    public required string ClientId { get; init; }
    public required string Name { get; init; }
    public string? WebHookUrl { get; init; }
    public string? Permissions { get; init; }
    public List<Jar>? Jars { get; init; }
    public required List<Account> Accounts { get; init; }
}