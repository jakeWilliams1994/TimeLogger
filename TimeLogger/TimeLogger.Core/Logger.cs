using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeLogger.Core
{
    public class Logger
    {
        private Task CurrentTask { get; set; }
        public List<Task> Tasks { get; set; }

        public Logger()
        {
            Tasks = new List<Task>();
        }

        public void SetCurrentTask(string task)
        {
            var currentTask = new Task
            {
                Name = task,
                StartTime = DateTime.Now
            };
            Tasks.Add(currentTask);
        }

        public Task GetCurrentTask() => CurrentTask ?? Tasks.Last();
    }
}
