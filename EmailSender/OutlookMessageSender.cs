using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using EmailSender._365;
namespace EmailSender
{
    public partial class OutlookMessageSender : ServiceBase
    {
        public OutlookMessageSender()
        {
            InitializeComponent();
            //ConnectIntoOutlook();
            
        }

        protected override void OnStart(string[] args)
        {
            
           OutlookHandler handler = new OutlookHandler();
           handler.InitOutlookConnection();


        }

        protected override void OnStop()
        {
        }
    }
}
