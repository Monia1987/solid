using System;

namespace TelegramBot.Core.Context
{
    public class CommandContext: ICommandContext
    {
        private bool _isDisposed = false;

        public CommandContext()
        {
            Offset = 0;
        }

        public int Offset { get; set; }
        public long ChatId { get; set; }

        public Guid? LastCommandId { get; set; }

        public void Dispose()
        {
            _isDisposed = true;
        }
    }
}
