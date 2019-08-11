using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace TimeLogger.Core.Tests
{
    public class LoggerTests
    {
        [Test]
        public void SetCurrentTask_WithTaskName_SetsCurrentTask()
        {
            var logger = new Logger();
            logger.SetCurrentTask("current-task");
            var expected = new Task
            {
                Name = "current-task",
                StartTime = DateTime.Now
            };
            logger.CurrentTask.Name.Should().BeEquivalentTo(expected.Name);
            logger.CurrentTask.StartTime.Should().BeCloseTo(expected.StartTime);
        }

        [Test]
        public void SetCurrentTask_WithTaskName_AddsTaskToTaskList()
        {
            var logger = new Logger();
            logger.SetCurrentTask("current-task");
            var expected = new Task
            {
                Name = "current-task",
                StartTime = DateTime.Now
            };
            logger.Tasks.First().Name.Should().BeEquivalentTo(expected.Name);
            logger.Tasks.First().StartTime.Should().BeCloseTo(expected.StartTime);
        }
    }
}
