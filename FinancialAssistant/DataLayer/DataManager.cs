using Common;
using System.IO;
using System.Text.Json;

namespace DataLayer
{
    public class DataManager : IDataManager
    {
        private const string savedUsersPath = "Users.json";

        private const string configPath = "Config.json";

        private const int defaultSessionTimeout = 120000;

        public void SaveUsers<T>(T data)
        {
            using StreamWriter sw = new StreamWriter(savedUsersPath, false);

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            sw.WriteLine(json);
        }

        public T LoadUsers<T>()
        {
            if (File.Exists(savedUsersPath))
            {
                using StreamReader sr = new StreamReader(savedUsersPath);

                return JsonSerializer.Deserialize<T>(sr.ReadToEnd());
            }
            else
            {
                return default;
            }
        }

        public int LoadConfig()
        {
            if (File.Exists(configPath))
            {
                using StreamReader sr = new StreamReader(configPath);

                return JsonSerializer.Deserialize<int>(sr.ReadToEnd());
            }
            else
            {
                using StreamWriter sw = new StreamWriter(configPath, false);

                sw.WriteLine(defaultSessionTimeout);

                return defaultSessionTimeout;
            }
        }
    }
}
