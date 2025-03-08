using Microsoft.Extensions.Configuration;
using System;
using System.Text.Json;

namespace TelegramBot
{
    public static class Helper
    {
        public static string GetToken()
        {
            //TODO: Add validation for the token
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration["BotConfig:Token"];
        }
    }
}
