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

        protected BotLogger Logger { get; set; }

        protected BaseCommand(ICommandContext context, ITelegramBotClient botClient, BotLogger logger)
        {
            Logger = logger;
            Client = botClient;
            Context = context;
        }

        public async Task Execute(ICommandInput input)
        {
            Logger.Info($"I'm trying to execute {GetType()}");
            try
            {
                await OnExecute(input);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Something went wrong");
            }

            Context.LastCommandId = Id;
        }

        public abstract Task OnExecute(ICommandInput input);
    }
}
