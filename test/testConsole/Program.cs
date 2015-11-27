using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobileStargeDLL;


namespace testConsole
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    #region test 
        //    //Stack<string> number = new Stack<string>() ;  
        //    //number.Push("1");
        //    //number.Push("2");
        //    //number.Push("3");
        //    //string s = number.Pop();
        //    //byte i = 255;
        //    //int[] a = new int[8];
        //    //a[0] = 1;
        //    //a[1] = 2;
        //    //Console.WriteLine(s);
        //    //try
        //    //{               
        //    //    checked
        //    //    {
        //    //        i += 1;
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    Console.WriteLine("出错了"+ex);
        //    //}
        //    //Console.WriteLine(i);
        //    //Console.ReadKey();
        //    #endregion 

        //    #region pratics
        //    //Person[] people = new Person[5];
        //    //Chinese cn1 = new Chinese();
        //    //Chinese cn2 = new Chinese();
        //    //British uk1 = new British();
        //    //British uk2 = new British();
        //    //Japanese jp1 = new Japanese();
        //    //people[0] = cn1;
        //    //people[1] = cn2;
        //    //people[2] = uk1;
        //    //people[3] = uk2;
        //    //people[4] = jp1;

        //    //foreach (Person p in people)
        //    //{
        //    //    p.sayhi();
        //    //}

        //    //Japanese.say();

        //    //Manager.checkIn();

            //Computer com = new Computer();
            //com.Device = new MP3();
            //com.Device = com.Device as MP3;
            //if (com.Device != null)
            //{
            //    MP3 mp =(MP3) com.Device;
            //    mp.Play();

            //}
        //    #endregion 


        //} 
    }

    abstract class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public virtual void Show()
        {
            Console.WriteLine("show---------------");
        }

        public abstract void sayhi();
 
    }

    class Chinese : Person
    {
        public override void Show()
        {
            Console.WriteLine("我是中国人");
        }

        public override void sayhi()
        {
            Console.WriteLine("say hi in Chinese");
        }
    }

    class British : Person
    {
        public override void Show()
        {
            Console.WriteLine("我是英国人");
        }

        public override void sayhi()
        {
            Console.WriteLine("say hi in British");
        }
    }

    class Japanese : Person
    {
        public static void say()
        {
            Console.WriteLine("ho hai yi you ");
        }

        public override void Show()
        {
            Console.WriteLine("我是日本人");
        }

        public override void sayhi()
        {
            Console.WriteLine("say hi in Japanese");
        }
 
    }

    public static class Manager
    {
        static Manager()
        {
            Console.WriteLine("i am managerment ");
        }

        public static void checkIn()
        {
            Console.WriteLine("manager checked in  ");
 
        }
    }

    public class Computer
    {
        public StorageDevice Device;

        public void ReadData()
        {
            if (Device != null)
            {
                Device.Read();
            }
            
        }

        public void WriteData()
        {
            if (Device != null)
            {
                Device.Write();
            }
            
        }
    }

}

