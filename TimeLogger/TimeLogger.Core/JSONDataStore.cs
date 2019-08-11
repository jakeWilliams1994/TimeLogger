using System;
using Newtonsoft.Json;

namespace TimeLogger.Core
{
    public class JSONDataStore
    {
        private IFileStore _fileStore;

        public JSONDataStore(IFileStore fileStore)
        {
            _fileStore = fileStore;
        }

        public void Store(Task[] taskList)
        {
            var json = JsonConvert.SerializeObject(taskList);
            _fileStore.Store("file", json);
        }
    }
}
