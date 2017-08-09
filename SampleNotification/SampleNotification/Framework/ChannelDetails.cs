using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleNotification
{
    public class ChannelDetails
    {
        private string channelName;
        private string status;

        public string ChannelName
        {
            get { return channelName; }
            set { channelName = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
       
    }
}
