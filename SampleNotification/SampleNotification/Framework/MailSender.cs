using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace SampleNotification
{
    class MailSender
    {
        
        MailMessage message;
        SmtpClient smtp;

        /// <summary>
        /// This methods is used to accept all the channels, format them and send mail.
        /// </summary>
        /// <param name="channelDetails"></param>
        public void SendMail(List<ChannelDetails> channelDetails)
        {
            //Mail Body
            string mailBody = FormatMailBody(channelDetails);
            Send(mailBody);
        }


        /// <summary>
        /// This methods is used to format the Mail Body
        /// </summary>
        /// <param name="channelDetails"></param>
        private string FormatMailBody(List<ChannelDetails> channelDetails)
        {
            StringBuilder failedChannel = new StringBuilder();
            StringBuilder stoppedChannel = new StringBuilder();
            foreach (ChannelDetails channel in channelDetails)
            {
                if (channel.Status == Constants.StatusFailed)
                {
                    if (failedChannel.ToString() == "")
                        failedChannel.Append(channel.ChannelName);
                    else
                    {
                        failedChannel.Append(channel.ChannelName);
                        failedChannel.Append(",");
                    }
                }
                else
                {
                    if (stoppedChannel.ToString() == "")
                        stoppedChannel.Append(channel.ChannelName);
                    else
                    {
                        stoppedChannel.Append(channel.ChannelName);
                        stoppedChannel.Append(",");
                    }
                }
            }
            return string.Format(Constants.MailBody, failedChannel.ToString(), stoppedChannel.ToString());
        }

        /// <summary>
        /// This methods is used to send Mail
        /// </summary>
        /// <param name="mailBody"></param>
        private void Send(string mailBody)
        {
            try
            {
                message = new MailMessage();
                message.From = new MailAddress(Constants.FromMailID);
                message.To.Add(Constants.ToMailID);
                message.Subject = Constants.Subject;                
                message.Body = mailBody;

                //set smtp details
                smtp = new SmtpClient();
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(Constants.FromMailID, "********");
                
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                LogData errorLog = new LogData();
                errorLog.WriteToLog("\r\nError Description : " + ex.ToString());
                errorLog.WriteToEventLog(ex.ToString(), "MailSender", System.Diagnostics.EventLogEntryType.Error);
            }
        }
    }
}
