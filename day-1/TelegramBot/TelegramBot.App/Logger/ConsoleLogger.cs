using System;
using TelegramBot.Core;

namespace TelegramBot.App.Logger
{
    public class ConsoleLogger : IBotLogger
    {
        public void Info(string message, params object[] parameters)
        {
            Console.WriteLine(message, parameters);
        }

        public void Error(string message, params object[] parameters)
        {
            Console.WriteLine($"ERROR!: {string.Format(message, parameters)}");
        }

        public void Error(Exception exception, string message, params object[] parameters)
        {
            Console.WriteLine($"ERROR!: {string.Format(message, parameters)}");
            Console.WriteLine(exception);
        }
    }
}
