using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Core.Commands;
using TelegramBot.Core.Context;
using TelegramBot.Core.Input;

namespace TelegramBot.Core
{
    public class Bot
    {
        private TelegramBotClient _botClient;
        private User _botUser;

        public BotInfo BotInfo { get; internal set; }

        internal IList<BaseCommand> Commands { get; set; }

        internal Bot()
        {
            Commands = new List<BaseCommand>();
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
                        foreach (var botCommand in Commands)
                        {
                            if (botCommand.Context == null)
                                botCommand.Context = context;

                            if (botCommand.IsApplicable(commandInput))
                                await botCommand.Execute(_botClient, commandInput);
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
