using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SampleNotification
{
    class Program
    {
        static void Main(string[] args)
        {
            //MailService obj = new MailService();
            //obj.GetChannelStatusAndMail();
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new MailService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
