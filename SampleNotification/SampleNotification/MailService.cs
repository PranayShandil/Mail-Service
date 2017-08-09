using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace SampleNotification
{
    partial class MailService : ServiceBase
    {
        Timer eventLogTimer;
        public MailService()
        {
            InitializeComponent();
            eventLogTimer = new Timer(Constants.Interval);
            eventLogTimer.Elapsed += new ElapsedEventHandler(PerformTask);
        }

        protected override void OnStart(string[] args)
        {

            eventLogTimer.Enabled = true;
        }

        protected override void OnStop()
        {
            eventLogTimer.Enabled = false;
        }

        public void PerformTask(object sender, ElapsedEventArgs e)
        {
            GetChannelStatusAndMail();
        }

        /// <summary>
        /// This methods is used to read database and trigger mail
        /// </summary>
        public void GetChannelStatusAndMail()
        {
            Dal dataAccessLayer = new Dal();
            MailSender objMailSender;
            List<ChannelDetails> channelDetails = dataAccessLayer.GetChannels();
            if (channelDetails != null && channelDetails.Count > 0)
            {
                objMailSender = new MailSender();
                objMailSender.SendMail(channelDetails);
            }
        }
    }
}
