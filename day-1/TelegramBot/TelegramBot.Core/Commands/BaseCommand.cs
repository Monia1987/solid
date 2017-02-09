using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot.Core.Context;
using TelegramBot.Core.Input;

namespace TelegramBot.Core.Commands
{
    public abstract class BaseCommand
    {
        public abstract Guid Id { get; }

        public ICommandContext Context { get; set; }
        protected ICollection<string> CommandKeys { get; }

        protected BaseCommand()
        {
            CommandKeys = new List<string>();
        }

        public async Task Execute(ITelegramBotClient client, ICommandInput input)
        {
            await OnExecute(client, input);

            Context.LastCommandId = Id;
        }

        public abstract Task OnExecute(ITelegramBotClient client, ICommandInput input);

        public virtual bool IsApplicable(ICommandInput input)
        {
            return input != null 
                && CommandKeys.Any(commandKey => input.Text.ToLowerInvariant().StartsWith(commandKey));
        }

        public void RegisterCommandKey(string key)
        {
            CommandKeys.Add($"/{key.TrimStart('/').ToLowerInvariant()}");
        }
    }
}
