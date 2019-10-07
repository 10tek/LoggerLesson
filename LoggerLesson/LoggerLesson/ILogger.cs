using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerLesson
{
    interface ILogger
    {
        void LogInfo(string message);
        void LogError(string message);
        void LogWarning(string message);

    }
}
