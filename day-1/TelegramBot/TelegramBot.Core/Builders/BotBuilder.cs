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
        private readonly BotLogger _logger;


        public BotBuilder(IUnityContainer container)
        {
            _logger = ResolveLogger(container);

            _bot = container.Resolve<Bot>();
            _bot.Logger = _logger;

            _logger.Info("Bot resolved");
            
        }

        public IPrepearedBotBuilder RegisterCommand<TCommand,TCondition>()
            where TCommand: IBotCommand
            where TCondition: ICommandCondition, new()
        {
            var commandInfo = CreateCommandInfo<TCommand>();
            var condition = CreateCommandCondition<TCondition>();
            RegisterCommand(condition, commandInfo);

            _logger.Info($"Command {commandInfo} registered.");

            return this;
        }

        public IPrepearedBotBuilder SetInfo(BotInfo info)
        {
            _bot.BotInfo = info;
            _logger.Info($"Api key set.");
            return this;
        }

        public Bot Build()
        {
            return _bot;
        }

        #region protected

        private BotLogger ResolveLogger(IUnityContainer container)
        {
            IBotLogger innerLogger = null;
            try
            {
                innerLogger = container.Resolve<IBotLogger>();
            }
            catch
            {
                // ignored
            }

            return new BotLogger(innerLogger);
        }

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
