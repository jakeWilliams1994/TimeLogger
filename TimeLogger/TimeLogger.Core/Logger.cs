﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeLogger.Core
{
    public class Logger
    {
        public List<Task> Tasks { get; set; }

        public Logger()
        {
            Tasks = new List<Task>();
        }

        public void SetCurrentTask(string task)
        {
            var currentTime = DateTime.Now;
            EndCurrentTask(currentTime);
            var currentTask = new Task
            {
                Name = task,
                StartTime = currentTime
            };
            Tasks.Add(currentTask);
        }

        public Task GetCurrentTask() => Tasks.Last();

        public void EndCurrentTask()
        {
            var currentTask = GetCurrentTask();
            if (currentTask.EndTime == DateTime.MinValue)
                Tasks.Last().EndTime = DateTime.Now;
        }

        private void EndCurrentTask(DateTime endTime)
        {
            if (Tasks.Count > 0)
                Tasks.Last().EndTime = endTime;
        }
    }
}
