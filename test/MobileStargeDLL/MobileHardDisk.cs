using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileStargeDLL
{
    public class MobileHardDisk : StorageDevice
    {
        public override void Read()
        {
            Console.WriteLine("移动硬盘读数据");
        }

        public override void Write()
        {
            Console.WriteLine("移动硬盘写数据");
        }
    }
}
