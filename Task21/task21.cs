namespace OOAP_Course2
{
    // наследуем реализацию
    public abstract class BaseFileStorage
    {
        protected string FilePath { get; }

        protected BaseFileStorage(string filePath)
        {
            FilePath = filePath;
        }

        protected void WriteData(string data)
        {
            File.WriteAllText(FilePath, data);
        }

        protected string ReadData()
        {
            return File.Exists(FilePath) ? File.ReadAllText(FilePath) : string.Empty;
        }
    }

    public class UserSettingsStorage : BaseFileStorage
    {
        public UserSettingsStorage(string configPath) : base(configPath) { }

        public void SaveTheme(string themeName)
        {
            WriteData($"Theme={themeName}"); 
            Console.WriteLine($"Настройки сохранены, тема: {themeName}");
        }

        public string LoadTheme()
        {
            string data = ReadData();
            return string.IsNullOrEmpty(data) ? "Default" : data.Split('=')[1];
        }
    }

    // пример на льготное наследование
    public class InvalidConfigurationException : Exception
    {
        public string ConfigKey { get; }

        public InvalidConfigurationException(string configKey, string message) 
            : base(message)
        {
            ConfigKey = configKey;
        }
    }
}