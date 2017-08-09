using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleNotification
{
    public static class Constants
    {
        public readonly static int Interval = Convert.ToInt32(ConfigurationManager.AppSettings["Interval"]);
        public readonly static string StatusFailed = "Failed";
        public readonly static string StatusStopped = "Stopped";
        public readonly static string Subject = "Failed/Stopped channel Status";
        public readonly static string MailBody = "The channels {0} are Failed!" + Environment.NewLine + "The channels {1} are Stopped!";
        public readonly static string FromMailID = ConfigurationManager.AppSettings["FromMailID"].ToString();
        public readonly static string ToMailID = ConfigurationManager.AppSettings["ToMailID"].ToString();
        public readonly static string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        public readonly static string LogPath = ConfigurationManager.AppSettings["LogPath"];
        public readonly static string EventSource = "NotificationMail";
        public readonly static string LogFileName = "MailLog.txt";
    }
}
