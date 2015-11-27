//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace testConsole
//{
//    class ObserverPattern
//    {
//        //static void Main(string[] args)
//        //{
//        //    TemperatureObserver tempOb = new TemperatureObserver();
//        //    BoildObserver boildOb1 = new BoildObserver("关闭电源");
//        //    BoildObserver boildOb2 = new BoildObserver("保温");
//        //    IsColdObserber cold = new IsColdObserber();
//        //    Water water1 = new Water();
//        //    water1.AddObserver(tempOb);
//        //    water1.AddObserver(boildOb2);
//        //    water1.AddObserver(cold);
//        //    water1.Change(-1);
//        //    Console.WriteLine("------------");
//        //    water1.Change(100);
            
            


//        //}
//    }

//    public interface Observer
//    {
//        void update(Observable observable);
//    }

//    public abstract class Observable
//    {
//        protected bool isChanaged;
//        protected List<Observer> observers = new List<Observer>();

//        public Observable()
//        {
//            isChanaged = false;
//        }

//        public void AddObserver(Observer observer)
//        {
//            this.observers.Add(observer);
//        }

//        public void RemoverObserver(Observer observer)
//        {
//            this.observers.Remove(observer);
//        }

//        public void RemoveAllObservers()
//        {
//            this.observers.Clear();
//        }

//        public void NotifyObservers()
//        {
//            if (isChanaged)
//            {
//                foreach (Observer ob in observers)
//                {
//                    ob.update(this);
//                }
//                isChanaged = false;
//            }
//        }            
//    }

//    //温度观察者
//    public class TemperatureObserver : Observer
//    {
//        public void update(Observable observable)
//        {
//            Water water = (Water)observable;
//            Console.WriteLine("温度：" + water.GetTemp() + "       状态：" + water.GetStatus());
//            Console.WriteLine("温度监测中···");
//        }
//    }

//    //沸水观察者
//    public class BoildObserver : Observer
//    {
//        string doSomething;
//        public BoildObserver(string doSomething)
//        {
//            this.doSomething = doSomething;
//        }

//        public void  update(Observable observable)
//        {
//            Water water = (Water)observable;
//            if (water.GetTemp() >= 100)
//            {
//                Console.WriteLine("状态：" + water.GetStatus());
//                Console.WriteLine("BoildObserver：" + doSomething);

//            }
//        }
//    }

//    public class IsColdObserber : Observer
//    {
//        public void update(Observable observable)
//        {
//            Water water = (Water)observable;
//            if (water.GetTemp() <= 0)
//            {
//                Console.WriteLine("冰水");
//            }
//            else
//            {
//                Console.WriteLine("非冰水");
//            }
//        }
//    }

//    //水——被观察者
//    public class Water : Observable
//    {
//        private double temperature;
//        private string status;

//        public Water()
//        {            
//            this.temperature = 0;
//            this.status = "冷水";
//        }

//        public Water(Observer ob)
//        {
//            //this.Observable();
//            observers.Add(ob);
//        }

//        public double GetTemp()
//        {
//            return temperature;
//        }

//        public string GetStatus()
//        {
//            return status;
//        }

//        public void Change(double temp)
//        {
//            this.temperature = temp;
//            if (temp < 40)
//            {
//                status = "冷水";
//            }
//            else if (temperature >= 40 && temperature < 60)
//            {
//                status = "温水";
//            }
//            else if (temperature >= 60 && temperature < 100)
//            {
//                status = "热水";
//            }
//            else
//            {
//                status = "开水";
//            }
//            this.isChanaged = true;
//            NotifyObservers();
//        }


//    }

//}
