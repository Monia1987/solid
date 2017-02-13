using System.Collections.Generic;
using Microsoft.Practices.Unity;
using TelegramBot.Core.Commands;
using TelegramBot.Core.Conditions;
using TelegramBot.Core.Info;

namespace TelegramBot.Core.Builders
{
    public class BotBuilder: IBotBuilder, IPrepearedBotBuilder
    {
        private readonly Bot _bot;

        public BotBuilder(IUnityContainer container)
        {
            _bot = container.Resolve<Bot>();
        }

        public IPrepearedBotBuilder RegisterCommand<TCommand,TCondition>()
            where TCommand: IBotCommand
            where TCondition: ICommandCondition, new()
        {
            var commandInfo = CreateCommandInfo<TCommand>();
            var condition = CreateCommandCondition<TCondition>();
            RegisterCommand(condition, commandInfo);

            return this;
        }

        public IPrepearedBotBuilder SetInfo(BotInfo info)
        {
            _bot.BotInfo = info;
            return this;
        }

        public Bot Build()
        {
            return _bot;
        }

        #region protected

        protected virtual CommandInfo CreateCommandInfo<TCommand>()
             where TCommand : IBotCommand
        {
            return new CommandInfo
                {
                    CommandType = typeof(TCommand),
                    CommandName = typeof(TCommand).ToString()
                };
        }

        protected virtual ICommandCondition CreateCommandCondition<TCondition>()
            where TCondition : ICommandCondition, new()
        {
            return new TCondition();
        }

        protected virtual void RegisterCommand(ICommandCondition condition, CommandInfo commandInfo)
        {
            if (!_bot.Commands.ContainsKey(condition))
                _bot.Commands.Add(condition, new List<CommandInfo>());

            _bot.Commands[condition].Add(commandInfo);
        }

        #endregion
    }
}
