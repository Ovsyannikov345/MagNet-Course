namespace Common
{
    public interface IDataManager
    {
        public void SaveUsers<T>(T data);

        public T LoadUsers<T>();

        public int LoadConfig();
    }
}
