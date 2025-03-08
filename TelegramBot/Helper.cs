using Microsoft.Extensions.Configuration;
using System;
using System.Text.Json;

namespace TelegramBot
{
    public static class Helper
    {
        public static string Token { get; private set; }

        public static void SetToken(string token)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();
        }

        public static string GetToken(string token)
        {
            return Token;
        }
    }
}
