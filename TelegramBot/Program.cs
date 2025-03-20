using LoyaltyCalc;
using System.Collections.Concurrent;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot;

//TODO: Add a normal logic? don`t use AI
public static class Program
{
    private static readonly ConcurrentDictionary<long, string> UserMessages = new ConcurrentDictionary<long, string>();

    public static void Main()
    {
        var telegramBot = new TelegramBotClient(Helper.GetToken());

        telegramBot.StartReceiving(HandleUpdateAsync, HandleErrorAsync);
        Console.WriteLine("Bot is running");

        Console.ReadLine();
    }

    public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Type == UpdateType.Message && update.Message.Type == MessageType.Text)
        {
            // Save the user's message
            UserMessages[update.Message.Chat.Id] = update.Message.Text;

            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("Calculate", "CalculateButton"),
                }
            });

            await botClient.SendTextMessageAsync(update.Message.Chat.Id, "Push the button", replyMarkup: inlineKeyboard, cancellationToken: cancellationToken);
        }
        else if (update.Type == UpdateType.CallbackQuery && update.CallbackQuery.Data == "CalculateButton")
        {
            // Retrieve the user's message
            if (UserMessages.TryGetValue(update.CallbackQuery.Message.Chat.Id, out var userMessage))
            {
                //TODO: Add validation data 
                var data = userMessage;
                var result = LoyaltyCalculator.LoyaltyCalculate(DataParser.StringParse(data));

                await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, result.ToString(), cancellationToken: cancellationToken);


            }
        }
    }

    public static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        // TODO: Add logging
        return Task.CompletedTask;
    }
}
