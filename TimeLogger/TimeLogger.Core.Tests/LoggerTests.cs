using FluentAssertions;
using NUnit.Framework;
using System;

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
    }
}
