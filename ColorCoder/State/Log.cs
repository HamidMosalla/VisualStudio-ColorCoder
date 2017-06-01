using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualStudio_ColorCoder.State
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