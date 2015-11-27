using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Web.Services;
using System.Collections;
using System.Diagnostics;
using System.ServiceProcess;



namespace test
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ServiceController controller = new ServiceController("MyService");

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Person> personlist = new List<Person>();
            personlist.Add(new Person { Name = "zwj", Age = 22 });
            personlist.Add(new Person { Name = "zfc", Age = 23 });

            //JavaScriptSerializer jss = new JavaScriptSerializer();
            string json = SetJsonFromObj(personlist);
            List<Person> list2 = GetPersonListFromJson<Person>(json);
            //lblJson.Text = json;
            //List<Person> list2 = (List<Person>)JsonConvert.DeserializeObject(json);
            //lblJson.Text = list2[0].Name;

            
        }

        /// <summary>
        /// 将list转换为json字符串
        /// </summary>
        /// <param name="list"></param>
        public string SetJsonFromObj<T>(List<T> list)
        {
            //JavaScriptSerializer jss = new JavaScriptSerializer();
            string json = JsonConvert.SerializeObject(list);
            return json;
        }


        /// <summary>
        /// 将json字符串转化为List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public List<T> GetPersonListFromJson<T>(string json)
        {
            //JavaScriptSerializer jss = new JavaScriptSerializer();
            
            List<T> list = JsonConvert.DeserializeObject<List<T>>(json);
            return list;
        }

        [WebMethod()]
        public static ArrayList GetSubList(string sBuyID)
        {
            ArrayList subList = new ArrayList();

            if (sBuyID == "500166")
            {
                subList.Add(new ListItem("文艺", "1"));
                subList.Add(new ListItem("少儿", "2"));
                subList.Add(new ListItem("人文社科", "3"));
                subList.Add(new ListItem("科技", "4"));
            }
            else if (sBuyID == "500168")
            {
                subList.Add(new ListItem("手机通讯", "1"));
                subList.Add(new ListItem("手机配件", "2"));
                subList.Add(new ListItem("摄影摄像", "3"));
                subList.Add(new ListItem("数码配件", "4"));
            }

            return subList;
        }

        protected void btnServceStart_Click(object sender, EventArgs e)
        {
            string current = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            System.Environment.CurrentDirectory = current + "\\bin\\Services";
            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.FileName = "Install.bat";
            process.StartInfo.CreateNoWindow = true;
            process.Start();

        }

        protected void btnServicesStop_Click(object sender, EventArgs e)
        {
            string current = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            System.Environment.CurrentDirectory = current + "\\bin\\Services";
            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.FileName = "Unstall.bat";
            process.StartInfo.CreateNoWindow = true;
            process.Start();
        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            controller.Start();
        }

        protected void btnStop_Click(object sender, EventArgs e)
        {
            if (controller.CanStop)
            {
                controller.Stop();
            }
        }

        protected void btnPause_Click(object sender, EventArgs e)
        {
            if (controller.CanPauseAndContinue)
            {
                if (controller.Status == ServiceControllerStatus.Running)
                {
                    controller.Pause();
                    btnPause.Text = "Continue";
                }
                else if (controller.Status == ServiceControllerStatus.Paused)
                {
                    controller.Continue();
                    btnPause.Text = "Pause";
                }
            }
        }
    }

    public class Person
    {
        public int Age;
        public string Name;
    }


    


}