using System;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot.Core.Input
{
    public class TelegramBotCommandInput: ICommandInput
    {
        public TelegramBotCommandInput(Update update)
        {
            if(update == null)
                throw new ArgumentNullException(nameof(update));

            if (update.Message != null)
            {
                Text = update.Message.Text;
                MessageType = update.Message.Type;
                ChatId = update.Message.Chat.Id;
            }

            UpdateId = update.Id;
        }

        public string Text { get; }

        public int UpdateId { get; }

        public long ChatId { get; }

        public bool Processed { get; set; }

        public MessageType MessageType { get; set; }
    }
}
