using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_tap_Advance.Properties.Utils
{
    public static class Logger
    {
        private static readonly string LogFilePath = "log.txt";

        public static void Log(string message)
        {
            File.AppendAllText(LogFilePath, $"{DateTime.Now}: {message}\n");
        }
    }
}