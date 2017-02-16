using Telegram.Bot.Types.Enums;

namespace TelegramBot.Core.Input
{
    public interface ICommandInput
    {
        string Text { get; }
        int UpdateId { get; }
        long ChatId { get; }

        bool Processed { get; }
        MessageType MessageType { get; set; }
    }
}
