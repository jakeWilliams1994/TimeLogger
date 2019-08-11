using System;
using System.Collections.Generic;

namespace TimeLogger.Core
{
    public class Logger
    {
        public Logger()
        {
            Tasks = new List<Task>();
        }

        public Task CurrentTask { get; set; }
        public List<Task> Tasks { get; set; }

        public void SetCurrentTask(string task)
        {
            CurrentTask = new Task
            {
                Name = task,
                StartTime = DateTime.Now
            };
            Tasks.Add(CurrentTask);
        }
    }
}
