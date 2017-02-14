using System;

namespace TelegramBot.Core
{
    public interface IBotLogger
    {
        void Info(string message,params object[] parameters);

        void Error(string message, params object[] parameters);

        void Error(Exception exception, string message, params object[] parameters);
    }
}