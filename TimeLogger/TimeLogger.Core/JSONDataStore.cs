using System;

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
            _fileStore.Store("a", "b");
        }
    }
}
