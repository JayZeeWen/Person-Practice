using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            RealDuck rd = new RealDuck();
            IShoutable shou = rd;
            shou.Shut();
            rd.Swim();
        }
    }

    public abstract class Duck
    {
        public abstract void Swim();
    }

    public interface IShoutable
    {
        void Shut();
    }

    public class RealDuck:Duck,IShoutable
    {   
        public void Shut()
        {
            Console.WriteLine(" gagagagagaga ");
        }

        public override void Swim()
        {
            Console.WriteLine("Real Duck Swimming......");
        }
    }

    public class WoodDuck : Duck
    {
        public override void Swim()
        {
            Console.WriteLine("Wood Duck Swimming......");
        }
    }

    public class RubberDuck : Duck, IShoutable
    {
        public void Shut()
        {
            Console.WriteLine(" jijijijijijijiji ");
        }

        public override void Swim()
        {
            Console.WriteLine("Rubber Duck Swimming......");
        }
    }

}
