using FluentAssertions;
using NUnit.Framework;

namespace TimeLogger.Core.Tests
{
    public class LoggerTests
    {
        [Test]
        public void SetCurrentTask_WithDateTime_SetsCurrentTask()
        {
            var logger = new Logger();
            logger.SetCurrentTask("current-task");
            logger.CurrentTask.Should().BeEquivalentTo("current-task");
        }
    }
}
