using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace testConsole
{
    class 序列化
    {
        //static void Main()
        //{
        //    var masters = new List<KungFuMaster>(){
        //        new KungFuMaster(){id =1 , name = "谢晓峰", age =18, kungfu="三少爷的剑"},
        //        new KungFuMaster(){id =2 , name = "洪七公", age =18, kungfu="打狗棒法"},
        //        new KungFuMaster(){id =3 , name = "郭靖", age =18, kungfu="降龙十八掌"},
        //        new KungFuMaster(){id =4 , name = "令狐冲", age =18, kungfu="独孤九剑"},
        //        new KungFuMaster(){id =5 , name = "李寻欢", age =18, kungfu="小李飞刀"}
        //    };

        //    using( FileStream fs = new FileStream (@"E:\Ed\master.obj",FileMode.Append))
        //    {
        //        var myBytes = Serializer.SerializeBytes(masters);
        //        fs.Write(myBytes, 0, myBytes.Length);
        //        fs.Close();
        //    };

        //    using (FileStream fsRead = new FileStream(@"E:\Ed\master.obj",FileMode.Open) )
        //    {
        //        int fsLen = (int)fsRead.Length;
        //        byte[] heBytes = new byte[fsLen];
        //        int r = fsRead.Read(heBytes, 0, heBytes.Length);
        //        var myObj = Serializer.DeserializeBytes(heBytes) as List<KungFuMaster>;
        //        myObj.ForEach(m =>
        //            Console.WriteLine(m.id + "——" + m.name + "——" + m.kungfu));
        //    }
        //}
        static void Main()
        {
            var master = new List<KungFuMaster>(){ 
                            new KungFuMaster(){ Id = 1, Name = "黄蓉",    Age = 18, Menpai = "丐帮", Kungfu = "打狗棒法",  Level = 9  },
                            new KungFuMaster(){ Id = 2, Name = "洪七公",  Age = 70, Menpai = "丐帮", Kungfu = "打狗棒法",  Level = 10 },
                            new KungFuMaster(){ Id = 3, Name = "郭靖",    Age = 22, Menpai = "丐帮", Kungfu = "降龙十八掌",Level = 10 },
                            new KungFuMaster(){ Id = 4, Name = "任我行",  Age = 50, Menpai = "明教", Kungfu = "葵花宝典",  Level = 1  },
                            new KungFuMaster(){ Id = 5, Name = "东方不败",Age = 35, Menpai = "明教", Kungfu = "葵花宝典",  Level = 10 },
                            new KungFuMaster(){ Id = 6, Name = "林平之",  Age = 23, Menpai = "华山", Kungfu = "葵花宝典",  Level = 7  },
                            new KungFuMaster(){ Id = 7, Name = "岳不群",  Age = 50, Menpai = "华山", Kungfu = "葵花宝典",  Level = 8  }         
                        };
            //初始化武学
            var kongfu = new List<Kongfu>(){
                            new Kongfu(){KongfuId=1, KongfuName="打狗棒法", Lethality=90},
                            new Kongfu(){KongfuId=2, KongfuName="降龙十八掌", Lethality=95},
                            new Kongfu(){KongfuId=3, KongfuName="葵花宝典", Lethality=100}
                        };


            var masterKongfuMethod = master
                                    .SelectMany(k => kongfu, (c, k) => new { mt = c, kf = k })
                                    .Where(x => x.kf.Lethality > 90 && x.mt.Kungfu == x.kf.KongfuName)
                                    .Select(m => m.mt.Id + "   " + m.mt.Name + "   " + m.mt.Menpai + "   " + m.mt.Kungfu + "   ");
            string masterKongfuMethodResult = "过滤所学”武功” “伤杀力” 大于90 的大侠(扩展方法 写法):\n";
            masterKongfuMethodResult += "编号(Id) 姓名(Name) 年龄(Age) 门派(Mengpai) 武学(Kungfu) 级别(Level)\n";
            foreach (var m in masterKongfuMethod)
                masterKongfuMethodResult += m.ToString() + "  " + "\n";
            Console.WriteLine(masterKongfuMethodResult);

        }
    }

    [Serializable]
    public class KungFuMaster
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 门派
        /// </summary>
        public string Menpai { get; set; }
        /// <summary>
        /// 武学
        /// </summary>
        public string Kungfu { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        public int Level { get; set; }
    }

    class Kongfu
    {
        public int KongfuId { get; set; }
        public string KongfuName { get; set; }
        public int Lethality { get; set; }
    }

    /// <summary>
    /// 二进制序列化和反序列化类
    /// </summary>
    public class Serializer
    {
        /// <summary>
        /// 使用二进制序列化对象
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] SerializeBytes(object value)
        {
            if (value == null)
            {
                return null;
            }
            var stream = new MemoryStream();
            new BinaryFormatter().Serialize(stream, value);
            var bytes = stream.ToArray();
            return bytes;
        }

        /// <summary>
        /// 使用二进制反序列化
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static object DeserializeBytes(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }
            var stream = new MemoryStream(bytes);
            var result = new BinaryFormatter().Deserialize(stream);
            return result;
        }

    }
}
