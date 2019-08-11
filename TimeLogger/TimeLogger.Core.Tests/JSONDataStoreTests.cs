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
            var json = @"[{""Name"":""task"",""StartTime"":""2019-10-16T12:15:00"",""EndTime"":""2019-10-16T12:45:00""}]";
            fileStore.Received().Store("file", json);
        }
    }
}
