using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleNotification
{
    class LogData
    {
        /// <summary>
        /// Contains the path to generate the log
        /// </summary>
        
        /// <summary>
        /// This methods writes the logMessage in the specific text file
        /// mentioned in the log path 
        /// </summary>
        /// <param name="logMessage"></param>
        public void WriteToLog(string logMessage)
        {
            if (!Directory.Exists(Constants.LogPath))
            {
                Directory.CreateDirectory(Constants.LogPath);
            }
            using (StreamWriter streamWriter = new StreamWriter(Constants.LogPath + Constants.LogFileName, true))
            {
                streamWriter.Write("\r\n" + logMessage);
                streamWriter.Close();
            }
        }

        /// <summary>
        /// This method is used to log the error, warning, information in Eventlog
        /// </summary>
        /// <param name="message"></param>
        /// <param name="fileName"></param>
        /// <param name="eventLogEntryType"></param>
        public void WriteToEventLog(string message, string fileName, EventLogEntryType eventLogEntryType)
        {
            EventLog eventLog = new EventLog();
            if (!EventLog.SourceExists(Constants.EventSource))
            {
                EventLog.CreateEventSource(Constants.EventSource, "Application");
            }
            eventLog.Source = Constants.EventSource;

            if (!String.IsNullOrEmpty(fileName))
                eventLog.WriteEntry("" + message + "\n File Name: " + fileName, eventLogEntryType);
            else
                eventLog.WriteEntry("" + message, eventLogEntryType);
        }
    }
}
