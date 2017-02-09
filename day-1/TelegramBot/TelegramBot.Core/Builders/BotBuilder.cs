using TelegramBot.Core.Commands;

namespace TelegramBot.Core.Builders
{
    public class BotBuilder
    {
        private readonly Bot _bot;

        public BotBuilder()
        {
            _bot = new Bot();
        }

        public BotBuilder RegisterCommand<TCommand>(TCommand command, params string[] keys) where TCommand : BaseCommand
        {
            foreach (var key in keys)
                command.RegisterCommandKey(key);

            _bot.Commands.Add(command);
            return this;
        }

        public BotBuilder SetInfo(BotInfo info)
        {
            _bot.BotInfo = info;
            return this;
        }

        public Bot Build()
        {
            return _bot;
        }
    }
}
