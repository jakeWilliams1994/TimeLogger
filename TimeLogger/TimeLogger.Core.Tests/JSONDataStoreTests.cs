using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TimeLogger.Core.Tests
{
    public class JSONDataStoreTests
    {
        [Test]
        public void Store_WithTaskList_SavesToFileStore()
        {
            var taskList = new List<Task>();
            taskList.Add(new Task
            {
                Name = "task",
                StartTime = new DateTime(2019, 10, 16, 12, 15, 0),
                EndTime = new DateTime(2019, 10, 16, 12, 45, 0),
            });
            var fileStore = Substitute.For<IFileStore>();
            var jsonDataStore = new JSONDataStore(fileStore);
            jsonDataStore.Store(taskList);
            var json = @"[{""Name"":""task"",""StartTime"":""2019-10-16T12:15:00"",""EndTime"":""2019-10-16T12:45:00""}]";
            fileStore.Received().Store("file", json);
        }

        [Test]
        public void Load_WithFileName_ReturnsTaskList()
        {
            var fileStore = Substitute.For<IFileStore>();
            fileStore.Load("file").Returns(@"[{""Name"":""task"",""StartTime"":""2019-10-16T12:15:00"",""EndTime"":""2019-10-16T12:45:00""}]");
            var jsonDataStore = new JSONDataStore(fileStore);
            var expected = new Task[] {
                new Task {
                    Name = "task",
                    StartTime = new DateTime(2019, 10, 16, 12, 15, 0),
                    EndTime = new DateTime(2019, 10, 16, 12, 45, 0),
                }
            };
            jsonDataStore.Load("file").Should().BeEquivalentTo(expected);
        }
    }
}
