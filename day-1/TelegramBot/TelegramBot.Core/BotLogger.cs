using System;

namespace TelegramBot.Core
{
    public class BotLogger
    {
        private readonly IBotLogger _logger;

        public BotLogger(IBotLogger logger)
        {
            _logger = logger;
        }

        public void Info(string message, params object[] parameters)
        {
            if(IsLoggerReady() == false)
                return;

            _logger.Info(message, parameters);
        }

        public void Error(string message, params object[] parameters)
        {
            if (IsLoggerReady() == false)
                return;

            _logger.Error(message, parameters);
        }

        public void Error(Exception exception, string message, params object[] parameters)
        {
            if (IsLoggerReady() == false)
                return;

            _logger.Error(exception, message, parameters);
        }

        private bool IsLoggerReady()
        {
            return _logger != null;
        }
    }
}
