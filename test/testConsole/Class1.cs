using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testConsole
{
     public class Class1
    {
         public static int m_Int = 1;
         static Class1()
         {
             m_Int = 2;
         }
         public  Class1()
         {
             Console.WriteLine("构造方法被调用");
         }
         //static void Main(string[] args)
         //{
         //    Console.WriteLine("Main访法");
         //    Console.Read();
         //}
    }

     public class PerCCtor
     {
         //static void Main(string[] args)
         //{
         //    long number = 1000000000;
         //    Test(number);
         //    Console.Read();
         //}
         private static void Test(long number)
         {
             long StartBeforeFieldInit = DateTime.Now.Ticks;
             for (long i = 0; i < number; i++)
             {
                 BeforeFileInit.i = 1;
             }
             long endBeforeFieldInit = DateTime.Now.Ticks;
             long startNotBeforeFieldInit = DateTime.Now.Ticks;
             for (long i = 0; i < number; i++)
             {
                 NotBeforeFieldInit.i = 1;
             }
             long endNotBeforeFeildInit = DateTime.Now.Ticks;
             Console.WriteLine("BeforeFieldInit" + (endBeforeFieldInit - StartBeforeFieldInit));
             Console.WriteLine("BeforeFieldInit" + (endNotBeforeFeildInit - startNotBeforeFieldInit));
         }
     }
     public class BeforeFileInit
     {
         public static int i = 1;
     }
     public class NotBeforeFieldInit
     {
         public static int i;
         static NotBeforeFieldInit()
         {
             i = 1;
         }
     }
}
