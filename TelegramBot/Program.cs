using LoyaltyCalc;
using Microsoft.Extensions.Configuration;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using System.Configuration;

//TODO: Add a normal logic? don`t use AI


public class Program
{   
    private static IConfiguration _configuration;
    private static ITelegramBotClient _botClient;
    private static ReceiverOptions _receiverOptions;

    private static readonly string _token = "7792348424:AAECbLaoJxjlA20wnFAzVTThvZmHV75TKW4";

    public static void Main()
    {
        var telegramBot = new TelegramBotClient(_token);

        
    }

    
}