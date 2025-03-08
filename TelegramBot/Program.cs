using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot;

//TODO: Add a normal logic? don`t use AI
public static class Program
{
    public static void Main()
    {
        var telegramBot = new TelegramBotClient(Helper.GetToken());

        telegramBot.StartReceiving(HandleUpdateAsync, HandleErrorAsync);
        Console.WriteLine("Bot is running");

        Console.ReadLine();
    }

    public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Type == UpdateType.Message)
        {
            var message = update.Message;
        }
    }

    public static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        // TODO: Add logging
        return Task.CompletedTask;
    }

    
}
