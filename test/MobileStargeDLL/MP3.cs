using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileStargeDLL
{
    public class MP3:StorageDevice
    {
        public override void Read()
        {
            Console.WriteLine("MP3读数据");
        }

        public override void Write()
        {
            Console.WriteLine("MP3写数据");
        }

        public void Play()
        {
            Console.WriteLine("播放");
        }
    }
}
