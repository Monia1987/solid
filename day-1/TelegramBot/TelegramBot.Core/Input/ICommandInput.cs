using Telegram.Bot.Types.Enums;

namespace TelegramBot.Core.Input
{
    public interface ICommandInput
    {
        string Text { get; }
        int UpdateId { get; }

        MessageType MessageType { get; set; }
    }
}
