using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practices
{
    public abstract class ProtableDevice
    {
        public abstract void Write();

        public abstract void Read();
    }

    public class FlashDevice : ProtableDevice
    {
        public void Write()
        {
            Console.WriteLine("U盘写");
        }

        public void Read()
        {
            Console.WriteLine("U盘读");
        }
    }

    public class MP3Player : ProtableDevice
    {
        public void Write()
        {
            Console.WriteLine("音乐播放器写");
        }
        public void Read()
        {
            Console.WriteLine("MP3读");
        }
        public void PlayMusic(string music)
        {
            Console.WriteLine("palay music : " + music);
        }
    }
}
