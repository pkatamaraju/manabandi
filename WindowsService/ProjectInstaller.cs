using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace WindowsService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        private System.ServiceProcess.ServiceProcessInstaller ServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller ServiceInstaller;
       // private System.ComponentModel.IContainer components = null;
        public ProjectInstaller()
        {
            InitializeComponent();
        }
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
        //private void InitializeComponent()
        //{
        //    components = new System.ComponentModel.Container();
        //    this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
        //    this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();

        //    this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
        //    this.serviceProcessInstaller1.Username = null;
        //    this.serviceProcessInstaller1.Password = null;

        //    this.serviceInstaller1.DisplayName = "RRWindowsService";
        //    this.serviceInstaller1.ServiceName = "RRWindowsService";
        //}
    }
}
