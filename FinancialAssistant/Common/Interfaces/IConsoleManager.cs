namespace Common
{
    public interface IConsoleManager
    {
        public void PrintInfo(string info);

        public int GetUserInt(string userMessage, int? minValue = null, int? maxValue = null);

        public double GetUserDouble(string userMessage, double? minValue = null, double? maxValue = null);

        public string GetUserString(string userMessage);

        public void Clear();
    }
}
