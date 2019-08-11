using System;

namespace TimeLogger.Core
{
    public class Logger
    {
        public string CurrentTask { get; set; }

        public void Log(string task)
        {
            CurrentTask = task;
        }
    }
}
