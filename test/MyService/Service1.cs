using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace MyService
{
    public partial class Service1 : ServiceBase
    {
        System.Timers.Timer t = null;  

        public Service1()
        {
            InitializeComponent();
            base.CanPauseAndContinue = true;
            t = new System.Timers.Timer(5000);
            t.AutoReset = true;

            //是否执行System.Timers.Timer.Elapsed事件； 
            t.Enabled = true;
            t.Elapsed += new System.Timers.ElapsedEventHandler(theout);
        }

        protected override void OnStart(string[] args)
        {
            string state = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "启动";
            WriteLog(state);
        }

        protected override void OnStop()
        {
            string state = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "停止";
            WriteLog(state);
            t.Stop();
        }

        //恢复服务执行 
        protected override void OnContinue()
        {
            string state = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "继续";
            WriteLog(state);
            t.Start();
        }

        //暂停服务执行  
        protected override void OnPause()
        {
            string state = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "暂停";
            WriteLog(state);

            t.Stop();
        }  

        public void WriteLog(string str)
        {
            using (StreamWriter sw = File.AppendText(@"d:\serviceTest.txt"))
            {
                sw.WriteLine(str);
                sw.Flush();
            }
        }

        public void theout(object source, System.Timers.ElapsedEventArgs e)
        {

            WriteLog("For Test:" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
        } 
    }
}
