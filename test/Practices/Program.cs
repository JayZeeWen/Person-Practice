using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practices
{
    class Program
    {
        //static void Main(string[] args)
        //{

        //    //string str = Console.ReadLine();
        //    //string[] strs = str.Split(' ');
        //    //double n = Convert.ToInt32(strs[0]);
        //    //int m = Convert.ToInt32(strs[1]);
        //    //double[] series = new double[m] ;
        //    float x;
        //    x = Convert.ToSingle("123.213");
        //    //series[0] = n;
        //    //for (int i = 1; i < m; i++)
        //    //{
        //    //    series[i] = Math.Sqrt(series[i - 1]);
        //    //}
        //    //foreach (double num in series)
        //    //{
        //    //    Console.WriteLine(num);
        //    //}
        //    Console.WriteLine(" SUM : " + x);

        //    Console.ReadKey();
        //}

        static void Main()
        {
            //Computer comp = new Computer();
            //ProtableDevice device = new FlashDevice();
            //comp.Device = device;
        }

        public static double Sum(double[] numbers)
        {
            double s = 0; 
            foreach (double d in numbers)
            {
                s += d;
            }
            return s;
        }
    }
}
