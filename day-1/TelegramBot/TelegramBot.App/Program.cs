using System.Configuration;
using TelegramBot.App.Commands;
using TelegramBot.App.Services;
using TelegramBot.Core;
using TelegramBot.Core.Builders;

namespace TelegramBot.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var botInfo = new BotInfo(ConfigurationManager.AppSettings["BotToken"]);
            var bot = new BotBuilder()
                .SetInfo(botInfo)
                .RegisterCommand(new WeatherCommand(new WeatherService()), "/weather", "/погода")
                .RegisterCommand(new DefaultCommand())
                .Build();

            bot.Awake().Wait();
            bot.Run().Wait();
        }
    }
}
