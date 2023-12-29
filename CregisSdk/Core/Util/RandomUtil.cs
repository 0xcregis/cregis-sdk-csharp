using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CregisSdk.Core.Util
{
    public class RandomUtil
    {
        static Random random = new Random(10);
        /// <summary>
        /// 获取纯数字随机数
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetNonce(int length)
        {
            string tmp = "";
            for (int i = 0; i < length; i++)
            {
                int seed = random.Next(0, 10);
                tmp += seed.ToString();
            }
            return tmp;
        }

        /// <summary>
        /// 获取纯数字随机数
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static long GetLong(int length)
        {
            string tmp = "";
            for (int i = 0; i < length; i++)
            {
                int seed = random.Next(0, 10);
                if (seed == 0 && tmp == "")
                    continue;
                tmp += seed.ToString();
            }
            if(tmp == "")
                tmp = "1";
            return Convert.ToInt64(tmp);
        }
    }
}
