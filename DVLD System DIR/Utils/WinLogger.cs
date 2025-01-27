using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer.Utils
{
    /// <summary>
    /// Class to write enteries/logs to Windows Event Viewer with a custom source
    /// </summary>
    public class WinLogger
    {
        public readonly string sourceName;

        public WinLogger(string sourceName, string logName = "Application")
        {
            this.sourceName = sourceName;
            if(!EventLog.SourceExists(sourceName))EventLog.CreateEventSource(sourceName, logName);
        }

        #region Satic Methods
        /// <summary>
        /// Writes an entry to Windows event viewer with the type of the method name.
        /// Creates a new source if the given source name does not already exist.
        /// </summary>
        /// <param name="sourceName"></param>
        /// <param name="message"></param>
        /// <param name="logName">Log to create the new source if the given source name does not exist.</param>
        public static void Info(string sourceName, string message, string logName = "Application")
        {
            if (!EventLog.SourceExists(sourceName)) EventLog.CreateEventSource(sourceName, logName);
            EventLog.WriteEntry(sourceName, message, EventLogEntryType.Information);
        }

        /// <summary>
        /// Writes an entry to Windows event viewer with the type of the method name.
        /// Creates a new source if the given source name does not already exist.
        /// </summary>
        /// <param name="sourceName"></param>
        /// <param name="message"></param>
        /// <param name="logName">Log to create the new source if the given source name does not exist.</param>
        public static void Warning(string sourceName, string message, string logName = "Application")
        {
            if (!EventLog.SourceExists(sourceName)) EventLog.CreateEventSource(sourceName, logName);
            EventLog.WriteEntry(sourceName, message, EventLogEntryType.Warning);
        }

        /// <summary>
        /// Writes an entry to Windows event viewer with the type of the method name.
        /// Creates a new source if the given source name does not already exist.
        /// </summary>
        /// <param name="sourceName"></param>
        /// <param name="logName">Log to create the new source if the given source name does not exist.</param>
        public static void Warning(string sourceName, Exception ex, string logName = "Application")
        {
            if (!EventLog.SourceExists(sourceName)) EventLog.CreateEventSource(sourceName, logName);
            EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Warning);
        }

        /// <summary>
        /// Writes an entry to Windows event viewer with the type of the method name.
        /// Creates a new source if the given source name does not already exist.
        /// </summary>
        /// <param name="sourceName"></param>
        /// <param name="message"></param>
        /// <param name="logName">Log to create the new source if the given source name does not exist.</param>
        public static void Error(string sourceName, string message, string logName = "Application")
        {
            if (!EventLog.SourceExists(sourceName)) EventLog.CreateEventSource(sourceName, logName);
            EventLog.WriteEntry(sourceName, message, EventLogEntryType.Error);
        }

        /// <summary>
        /// Writes an entry to Windows event viewer with the type of the method name.
        /// Creates a new source if the given source name does not already exist.
        /// </summary>
        /// <param name="sourceName"></param>
        /// <param name="logName">Log to create the new source if the given source name does not exist.</param>
        public static void Error(string sourceName, Exception ex, string logName = "Application")
        {
            if (!EventLog.SourceExists(sourceName)) EventLog.CreateEventSource(sourceName, logName);
            EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);
        }
        #endregion 

        #region Instance Methods
        /// <summary>
        /// Writes a new log to Windows event viewer.
        /// </summary>
        /// <param name="message">The message displayed in the log.</param>
        public void Info(string message)
        {
            EventLog.WriteEntry(sourceName, message, EventLogEntryType.Information);
        }

        /// <summary>
        /// Writes a new log to Windows event viewer.
        /// </summary>
        /// <param name="message">The message displayed in the log.</param>
        public void Warning(string message)
        {
            EventLog.WriteEntry(sourceName, message, EventLogEntryType.Warning);
        }

        /// <summary>
        /// Writes a new log to Windows event viewer.
        /// </summary>
        /// <param name="ex">The exception displayed in the log.</param>
        public void Warning(Exception ex)
        {
            EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Warning);
        }

        /// <summary>
        /// Writes a new log to Windows event viewer.
        /// </summary>
        /// <param name="message">The message displayed in the log.</param>
        public void Error(string message)
        {
            EventLog.WriteEntry(sourceName, message, EventLogEntryType.Error);
        }

        /// <summary>
        /// Writes a new log to Windows event viewer.
        /// </summary>
        /// <param name="ex">The exception displayed in the log.</param>
        public void Error(Exception ex)
        {
            EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);
        }
        #endregion 
    }
}
