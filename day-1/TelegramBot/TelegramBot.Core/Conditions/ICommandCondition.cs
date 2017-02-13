using System.Threading.Tasks;
using TelegramBot.Core.Input;

namespace TelegramBot.Core.Conditions
{
    public interface ICommandCondition
    {
        Task<bool> Check(ICommandInput input);
    }
}