using FluentAssertions;
using NUnit.Framework;

namespace TimeLogger.Core.Tests
{
    public class LoggerTests
    {
        [Test]
        public void Log_WithDateTime_SetsCurrentTask()
        {
            var logger = new Logger();
            logger.Log("current-task");
            logger.CurrentTask.Should().BeEquivalentTo("current-task");
        }
    }
}
