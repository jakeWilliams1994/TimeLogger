using NSubstitute;
using NUnit.Framework;
using System;

namespace TimeLogger.Core.Tests
{
    public class JSONDataStoreTests
    {
        [Test]
        public void Store_WithTaskList_SavesToFileStore()
        {
            var taskList = new Task[] {
                new Task {
                    Name = "task",
                    StartTime = new DateTime(2019, 10, 16, 12, 15, 0),
                    EndTime = new DateTime(2019, 10, 16, 12, 45, 0),
                }
            };
            var fileStore = Substitute.For<IFileStore>();
            var jsonDataStore = new JSONDataStore(fileStore);
            jsonDataStore.Store(taskList);
            fileStore.Received().Store("a", "b");
        }
    }
}
