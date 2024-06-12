namespace Infrastructure.Settings;

public class TelegramSettings
{
    public const string Key = "CronExpression";
    public string? BotToken { get; init; }
    public string? ChatId { get; init; }
}