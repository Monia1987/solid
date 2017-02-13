using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using TelegramBot.Core.Conditions;
using TelegramBot.Core.Input;

namespace TelegramBot.App.Conditions
{
    public class RateCondition : ICommandCondition
    {
        public Task<bool> Check(ICommandInput input)
        {
            if (input.MessageType != MessageType.TextMessage)
                return Task.FromResult(false);

            if(string.IsNullOrEmpty(input.Text))
                return Task.FromResult(false);

            return Task.FromResult(input.Text.ToLowerInvariant().StartsWith("/rate"));

        }
    }
}
