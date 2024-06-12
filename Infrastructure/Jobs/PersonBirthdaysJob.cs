using Application.Persons.Queries.GetPersonsWhoseBirthday;
using Infrastructure.Services;
using Infrastructure.Settings;
using MediatR;
using Microsoft.Extensions.Options;
using Quartz;
using Telegram.Bot;

namespace Infrastructure.Jobs;

public class PersonBirthdaysJob : IJob
{
    private readonly ISender _sender;
    private readonly TelegramBotClient _client;
    private readonly TelegramSettings _telegramSettings;
    private readonly NotificationTextService _textService;

    public PersonBirthdaysJob(IOptions<TelegramSettings> telegramSettings, ISender sender,
        NotificationTextService textService)
    {
        _sender = sender;
        _textService = textService;
        _telegramSettings = telegramSettings.Value;

        _client = new TelegramBotClient(_telegramSettings.BotToken);
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var query = new GetPersonsWhoseBirthdayQuery(DateTime.UtcNow);

        var persons = await _sender.Send(query);

        if (persons.Count == 0)
        {
            return;
        }

        foreach (var person in persons)
        {
            var text = _textService.GetText(person);
            await SendMessageAsync(text);
        }
    }

    private async Task SendMessageAsync(string message)
    {
        try
        {
            await _client.SendTextMessageAsync(_telegramSettings.ChatId, message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending message: {ex.Message}");
        }
    }
}