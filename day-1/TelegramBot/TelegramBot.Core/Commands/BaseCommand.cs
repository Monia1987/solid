using System;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot.Core.Context;
using TelegramBot.Core.Input;

namespace TelegramBot.Core.Commands
{
    public abstract class BaseCommand : IBotCommand
    {
        public abstract Guid Id { get; }

        protected ICommandContext Context { get; set; }
        protected ITelegramBotClient Client { get; set; }

        protected BaseCommand(ICommandContext context, ITelegramBotClient botClient)
        {
            Client = botClient;
            Context = context;
        }

        public async Task Execute(ICommandInput input)
        {
            await OnExecute(input);

            Context.LastCommandId = Id;
        }

        public abstract Task OnExecute(ICommandInput input);
    }
}
