using Microsoft.Extensions.Configuration;
using System.Text.Json;
using TelegramBot;


//TODO: Add a normal logic? don`t use AI
public static class Program
{
    public static void Main()
    {
       var telegramBot = new TelegramBotClient(Helper.Token);
    }
}
