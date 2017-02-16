using System.Threading.Tasks;
using TelegramBot.Core.Input;

namespace TelegramBot.Core.Conditions
{
    public class DefaultCommandCondition : ICommandCondition
    {
        public Task<bool> Check(ICommandInput input)
        {
            return Task.FromResult(input.Processed != true);
        }
    }
}
