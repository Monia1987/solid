using Telegram.Bot;
using TelegramBot.Core.Commands;
using TelegramBot.Core.Info;

namespace TelegramBot.Core.Factory
{
    public interface ICommandFactory
    {
        IBotCommand Create(CommandInfo commandInfo, ITelegramBotClient botClient, BotLogger logger);
    }
}
