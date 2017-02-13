using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Core.Commands;
using TelegramBot.Core.Conditions;
using TelegramBot.Core.Context;
using TelegramBot.Core.Factory;
using TelegramBot.Core.Info;
using TelegramBot.Core.Input;

namespace TelegramBot.Core
{
    public class Bot
    {
        private TelegramBotClient _botClient;
        private User _botUser;

        public BotInfo BotInfo { get; internal set; }
        internal IDictionary<ICommandCondition, IList<CommandInfo>> Commands { get; set; }
        protected ICommandFactory CommandFactory { get; set; }

        public Bot(ICommandFactory commandFactory)
        {
            Commands = new Dictionary<ICommandCondition, IList<CommandInfo>>();
            CommandFactory = commandFactory;
        }
        
        public async Task Awake()
        {
            _botClient = new TelegramBotClient(BotInfo.ApiToken);
            _botUser = await _botClient.GetMeAsync();
        }

        public async Task Run()
        {
            using (var context = new CommandContext())
            {
                while (true)
                {
                    var updates = await _botClient.GetUpdatesAsync(context.Offset);
                    foreach (var update in updates)
                    {
                        context.ChatId = update.Message.Chat.Id;
                        var commandInput = new TelegramBotCommandInput(update);

                        foreach (var command in Commands)
                        {
                            if (!await command.Key.Check(commandInput))
                                continue;

                            foreach (var commandInfo in command.Value)
                            {
                                var commandInstance = CommandFactory.Create(commandInfo, context, _botClient);
                                await commandInstance.Execute(commandInput);
                            }
                        }

                        context.Offset = update.Id + 1;
                        context.LastCommandId = null;
                    }

                    await Task.Delay(1000);
                }
            }
        }
    }
}
