using System;

namespace TimeLogger.Core
{
    public class Logger
    {
        public Task CurrentTask { get; set; }

        public void SetCurrentTask(string task)
        {
            CurrentTask = new Task
            {
                Name = task,
                StartTime = DateTime.Now
            };
        }
    }
}
