using System;
using System.Threading.Tasks;
using TelegramBot.Core.Input;

namespace TelegramBot.Core.Commands
{
    public interface IBotCommand
    {
        Guid Id { get; }

        Task Execute(ICommandInput input);
    }
}
