using System.Diagnostics;

namespace ColorCoder.ColorCoderCore
{
    internal static class Log
    {
        internal static void LogError(string message)
        {
            try
            {
                EventLog.WriteEntry("Microsoft Visual Studio", "ColorCoder: " + (message ?? "null"), EventLogEntryType.Error);
            }
            catch
            {
                // Don't kill extension for logging errors
            }
        }
    }
}