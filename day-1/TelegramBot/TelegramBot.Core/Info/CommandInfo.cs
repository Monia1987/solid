using System;

namespace TelegramBot.Core.Info
{
    public class CommandInfo
    {
        public Type CommandType { get; set; }
        public string CommandName { get; set; }

        public override string ToString()
        {
            return CommandName;
        }
    }
}
