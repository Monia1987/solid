using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Core.Conditions;
using TelegramBot.Core.Factory;
using TelegramBot.Core.Info;
using TelegramBot.Core.Input;

namespace TelegramBot.Core
{
    public class Bot
    {
        protected TelegramBotClient _botClient;
        protected User _botUser;
        public BotInfo BotInfo { get; internal set; }

        protected ICommandFactory CommandFactory { get; set; }
        internal IDictionary<ICommandCondition, IList<CommandInfo>> Commands { get; set; }
        internal BotLogger Logger { get; set; }

        public Bot(ICommandFactory commandFactory)
        {
            Commands = new Dictionary<ICommandCondition, IList<CommandInfo>>();
            CommandFactory = commandFactory;
        }

        public async Task Awake()
        {
            _botClient = new TelegramBotClient(BotInfo.ApiToken);
            _botUser = await _botClient.GetMeAsync();

            Logger.Info($"I'm {_botUser.Username} and I'm awake.");
        }

        public async Task Run()
        {
            var offset = 0;
            Logger.Info($"Are you really want me to do some job? Ok...");
            while (true)
            {
                var updates = await _botClient.GetUpdatesAsync(offset);
                foreach (var update in updates)
                {
                    var commandInput = new TelegramBotCommandInput(update);

                    Logger.Info($"So.. ChatId is {commandInput.ChatId}, message \"{commandInput.Text}\" bla-bla-bla...");

                    foreach (var command in Commands)
                    {
                        if (!await command.Key.Check(commandInput))
                            continue;

                        foreach (var commandInfo in command.Value)
                        {
                            var commandInstance = CommandFactory.Create(commandInfo, _botClient, Logger);
                            if (await commandInstance.Execute(commandInput))
                                commandInput.Processed = true;
                        }
                    }

                    offset = update.Id + 1;
                }

                await Task.Delay(1000);
            }

        }
    }
}
