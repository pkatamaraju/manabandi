using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using RaiteRaju.ServiceLayer;

namespace WindowsService
{
    public partial class RRWindowsService : ServiceBase
    {
        ServiceHost Host;
        public RRWindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Host = new ServiceHost(typeof(RaiteRaju.ServiceLayer.InformationService));
            Host.Open();
        }

        protected override void OnStop()
        {
            Host.Close();
        }
    }
}
