using System;

namespace LoggerLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new XmlFileLogger();
            logger.LogInfo("Info");
            logger.LogWarning("Warning");
            logger.LogError("Error");
            Console.ResetColor();


            Console.ReadKey();
        }
    }
}
