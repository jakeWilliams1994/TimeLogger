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

            logger.GetCurrentTask().Name.Should().BeEquivalentTo("current-task");
            logger.GetCurrentTask().StartTime.Should().BeCloseTo(DateTime.Now);
            logger.GetCurrentTask().EndTime.Should().Be(DateTime.MinValue);
        }

        [Test]
        public void SetCurrentTask_WithTaskName_EndsLastTask()
        {
            var logger = new Logger();
            logger.SetCurrentTask("old-task");
            var oldTaskStartTime = DateTime.Now;
            logger.SetCurrentTask("new-task");
            var newTaskStartTime = DateTime.Now;

            logger.Tasks.First().Name.Should().BeEquivalentTo("old-task");
            logger.Tasks.First().StartTime.Should().BeCloseTo(oldTaskStartTime);
            logger.Tasks.First().EndTime.Should().BeCloseTo(newTaskStartTime);
            logger.GetCurrentTask().Name.Should().BeEquivalentTo("new-task");
            logger.GetCurrentTask().StartTime.Should().BeCloseTo(newTaskStartTime);
            logger.GetCurrentTask().EndTime.Should().Be(DateTime.MinValue);
        }
    }
}
