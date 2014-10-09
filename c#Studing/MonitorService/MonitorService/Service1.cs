using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;

namespace MonitorService
{
    public partial class Service1 : ServiceBase
    {
        public const string logPath = "D:\\monitor\\tmp.log";
        private CJMonitor mainMonitor;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            CJMonitor.writeLog("Start", "ServiceStart");
            mainMonitor = new CJMonitor();
            mainMonitor.startAll();
        }

        protected override void OnStop()
        {
            CJMonitor.writeLog("Stop", "ServiceStop");
            mainMonitor.stopAll();
        }
    }
}
