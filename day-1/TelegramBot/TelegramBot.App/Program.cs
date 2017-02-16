using System.Configuration;
using Microsoft.Practices.Unity;
using TelegramBot.App.Commands;
using TelegramBot.App.Conditions;
using TelegramBot.App.Logger;
using TelegramBot.App.Parsers;
using TelegramBot.App.Services;
using TelegramBot.Core;
using TelegramBot.Core.Builders;
using TelegramBot.Core.Conditions;
using TelegramBot.Core.Factory;

namespace TelegramBot.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var unityContainer = RegisterUnityContainer();

            var botInfo = new BotInfo(ConfigurationManager.AppSettings["BotToken"]);
            var botBuilder = unityContainer.Resolve<IBotBuilder>();

            var bot = botBuilder.SetInfo(botInfo)
                .RegisterCommand<WeatherCommand, WeatherCondition>()
                .RegisterCommand<RateCommand, RateCondition>()
                .RegisterCommand<DefaultCommand, DefaultCommandCondition>()
                .Build();

            bot.Awake().Wait();
            bot.Run().Wait();
        }

        private static IUnityContainer RegisterUnityContainer()
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<IBotBuilder, BotBuilder>();
            unityContainer.RegisterType<ICommandFactory, CommandFactory>();
            unityContainer.RegisterType<Bot, Bot>();

            unityContainer.RegisterType<IBotLogger, Log4NetLogger>();

            unityContainer.RegisterType<DummyMessagesService, DummyMessagesService>();
            unityContainer.RegisterType<WeatherService, WeatherService>();
            unityContainer.RegisterType<RateService, RateService>();
            unityContainer.RegisterType<HttpService, HttpService>();

            unityContainer.RegisterType<JsonParser, JsonParser>();

            unityContainer.RegisterType<DefaultCommand, DefaultCommand>();
            unityContainer.RegisterType<WeatherCommand, WeatherCommand>();
            unityContainer.RegisterType<RateCommand, RateCommand>();

            return unityContainer;
        }
    }
}
