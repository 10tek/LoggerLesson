using System;

namespace LoggerLesson
{
    public class ConsoleLogger : ILogger
    {
        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            PrintMessage(message);
        }

        public void LogInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            PrintMessage(message);
        }

        public void LogWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintMessage(message);
        }

        private void PrintMessage(string message)
        {
            Console.WriteLine($"{DateTime.Now.ToShortDateString()} - {message} ");
        }
    }
}
