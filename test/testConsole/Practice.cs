using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testConsole
{
    class Practice
    {
        delegate string MyDelegete(string val);

        //static void Main(string[] args)
        //{
        //    //WaterObserver ob = new WaterObserver();
        //    //StatusObserver satatusOb = new StatusObserver();
        //    //Water water = new Water();
        //    //water.AddObserver(ob);
        //    //water.RemoveObserver(ob);
        //    //water.AddObserver(satatusOb);
        //    //water.SetTemp(20);
        //    //Console.WriteLine("————————————");
        //    //water.SetTemp(50);
        //    string strq = "匿名方法外部-----------";
        //    MyDelegete my = delegate(string param)
        //    {
        //        string str2 = "匿名方法内部";
        //        return param + strq + str2;
        //    };
        //    Console.WriteLine(my("参数---------"));
        //    Console.ReadKey();
        //} 
    }

    public interface Observer
    {
        void update(Observable observable);
    }

    public abstract class Observable
    {
        protected bool isChanaged; 
        protected List<Observer> Observers = new List<Observer>();

        public Observable()
        {
            isChanaged = false;
        }

        public void AddObserver(Observer ob)
        {
            this.Observers.Add(ob);
        }

        public void RemoveObserver(Observer ob)
        {
            this.Observers.Remove(ob);
        }

        public void RemoveAllObservers()
        {
            this.Observers.Clear();
        }

        public void NotifyObserver(Observable observable)
        {
            foreach (Observer ob in this.Observers)
            {
                ob.update(observable);
            }
        }
    }

    public class WaterObserver : Observer
    {
        public void  update(Observable observable)
        {
            Water water = (Water)observable;
            Console.WriteLine("当前水的温度是：" + water.GetTemp());
        }
    }

    public class StatusObserver : Observer
    {
        public void update(Observable observable)
        {
            Water water = (Water)observable;
            if (water.GetTemp() >= 40)
            {
                Console.WriteLine("当前水的状态：温水");
            }
            else if(water.GetTemp() < 40)
            {
                Console.WriteLine("当前水的状态：凉白开");
            }
        }
    }

    public class Water : Observable
    {
        public double Temp;
        public string Status;

        public void SetTemp(double temp)
        {
            this.Temp = temp;
            NotifyObserver(this);
        }
        public double GetTemp()
        {
            return this.Temp;
        }
    }
}
