using System;
using System.IO;

namespace Infrastructure
{
    public sealed class Logger
    {
        private static readonly Logger _instance = new Logger();
        private readonly string _logFilePath;

        private Logger()
        {
            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
            _logFilePath = Path.Combine(logDirectory, "app.log");
        }

        public static Logger Instance => _instance;

        public void LogInfo(string message) => Log("INFO", message);
        public void LogWarning(string message) => Log("WARNING", message);
        public void LogError(string message) => Log("ERROR", message);

        private void Log(string level, string message)
        {
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
            File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
        }
    }
}
