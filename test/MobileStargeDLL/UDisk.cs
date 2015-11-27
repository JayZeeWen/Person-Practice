using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileStargeDLL
{
    public class UDisk : StorageDevice
    {
        public override void Read()
        {
            Console.WriteLine("U盘读数据");
        }

        public override void Write()
        {
            Console.WriteLine("U盘写数据");
        }
    }
}
