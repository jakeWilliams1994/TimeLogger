namespace TimeLogger.Core
{
    public interface IFileStore
    {
        void Store(string v1, string v2);
        string Load(string fileName);
    }
}