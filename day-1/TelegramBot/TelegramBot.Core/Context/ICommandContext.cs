using System;

namespace TelegramBot.Core.Context
{
    public interface ICommandContext: IDisposable
    {
        int Offset { get; }
        long ChatId { get; }
        Guid? LastCommandId { get; set; }
    }
}
