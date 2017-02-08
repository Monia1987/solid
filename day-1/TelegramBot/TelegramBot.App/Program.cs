using System.Configuration;
using TelegramBot.Core;

namespace TelegramBot.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var botInfo = new BotInfo(ConfigurationManager.AppSettings["BotToken"]);
            var bot = new Bot(botInfo);
            bot.Awake().Wait();
            bot.Run().Wait();
        }
    }
}
