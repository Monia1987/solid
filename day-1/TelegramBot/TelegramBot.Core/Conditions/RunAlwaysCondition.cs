using System.Threading.Tasks;
using TelegramBot.Core.Input;

namespace TelegramBot.Core.Conditions
{
    public class RunAlwaysCondition : ICommandCondition
    {
        public Task<bool> Check(ICommandInput input)
        {
            return Task.FromResult(true);
        }
    }
}
