using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practices
{
    class Computer
    {
        public ProtableDevice Device
        {
            get;
            set;
        }

        public void Wirte()
        {
            Console.WriteLine("computer writing ");
        }

        public void Read()
        {
            Console.WriteLine("computer readding ");
        }
    }
}
