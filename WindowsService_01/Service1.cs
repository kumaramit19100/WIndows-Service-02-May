using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsService_01
{
    public partial class Service1 : ServiceBase
    {
        Timer timer = new Timer();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer.Elapsed += new ElapsedEventHandler(Timer_Elap);
            timer.Enabled = true;
            timer.Interval = 100;
            msg("Hello");
        }

        private void msg(string v)
        {
            string path = @"E:\WindowsService\WindowsRegistryService_01_May.txt";

            if (File.Exists(path))
            {
                using (StreamWriter writer = File.CreateText(path))
                {
                    writer.WriteLine(v);
                }
            }
            else
            {
                using(StreamWriter writer = File.AppendText(path))
                {
                    writer.WriteLine(v);
                }
            }
        }

        private void Timer_Elap(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void OnStop()
        {
        }
    }
}
