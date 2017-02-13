using TelegramBot.Core.Commands;
using TelegramBot.Core.Conditions;

namespace TelegramBot.Core.Builders
{
    public interface IBotBuilder
    {
        IPrepearedBotBuilder SetInfo(BotInfo info);
    }

    public interface IPrepearedBotBuilder
    {
        Bot Build();

        IPrepearedBotBuilder RegisterCommand<TCommand, TCondition>()
            where TCommand : IBotCommand
            where TCondition : ICommandCondition, new();
    }
}