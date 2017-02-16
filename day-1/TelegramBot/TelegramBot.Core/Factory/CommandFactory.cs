using Microsoft.Practices.Unity;
using Telegram.Bot;
using TelegramBot.Core.Commands;
using TelegramBot.Core.Info;

namespace TelegramBot.Core.Factory
{
    public class CommandFactory: ICommandFactory
    {
        private readonly IUnityContainer _container;

        public CommandFactory(IUnityContainer container)
        {
            _container = container;
        }

        public IBotCommand Create(CommandInfo commandInfo, ITelegramBotClient botClient, BotLogger logger)
        {
            var overrides = new ParameterOverrides
                {
                        {"botClient", botClient},
                        {"logger", logger }
                };

            return _container.Resolve(commandInfo.CommandType, overrides) as IBotCommand;
        }
    }
}
