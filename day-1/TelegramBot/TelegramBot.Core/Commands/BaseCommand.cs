using System;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot.Core.Input;

namespace TelegramBot.Core.Commands
{
    public abstract class BaseCommand : IBotCommand
    {
        public abstract Guid Id { get; }

        protected ITelegramBotClient Client { get; set; }

        protected BotLogger Logger { get; set; }

        protected BaseCommand(ITelegramBotClient botClient, BotLogger logger)
        {
            Logger = logger;
            Client = botClient;
        }

        public async Task<bool> Execute(ICommandInput input)
        {
            Logger.Info($"I'm trying to execute {GetType()}");
            try
            {
                await OnExecute(input);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Something went wrong");
                return false;
            }

            //Context.LastCommandId = Id;
        }

        public abstract Task OnExecute(ICommandInput input);
    }
}
