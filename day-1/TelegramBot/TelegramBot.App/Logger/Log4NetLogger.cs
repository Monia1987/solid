using System;
using log4net;
using log4net.Config;
using TelegramBot.Core;

namespace TelegramBot.App.Logger
{
    public class Log4NetLogger : IBotLogger
    {
        private static readonly ILog Log = LogManager.GetLogger("BotLogger");

        public Log4NetLogger()
        {
            InitLogger();
        }

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }

        public void Info(string message, params object[] parameters)
        {
            if(Log.IsInfoEnabled)
                Log.InfoFormat(message,parameters);
        }

        public void Error(string message, params object[] parameters)
        {
            if (Log.IsErrorEnabled)
                Log.ErrorFormat(message, parameters);
        }

        public void Error(Exception exception, string message, params object[] parameters)
        {
            if (Log.IsErrorEnabled)
                Log.Error(string.Format(message, parameters), exception);
        }
    }
}
