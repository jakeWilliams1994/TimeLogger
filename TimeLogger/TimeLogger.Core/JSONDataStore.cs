using System.Collections.Generic;
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

        public void Store(List<Task> taskList)
        {
            var json = JsonConvert.SerializeObject(taskList);
            _fileStore.Store("file", json);
        }

        public List<Task> Load(string fileName)
        {
            var json = _fileStore.Load(fileName);
            return JsonConvert.DeserializeObject<List<Task>>(json);
        }
    }
}
