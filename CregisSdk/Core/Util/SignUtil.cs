using CregisSdk.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cregis.Core.Util
{
    /// <summary>
    /// 签名工具类
    /// author scottcheng
    /// version 1.0.0
    /// date 2023/11/17
    /// </summary>
    public class SignUtil
    {

        /**
         * 加签
         *
         * @param map 参数map
         * @return 加签之后的值
         */
        public static string DoSign(Dictionary<string, object> map, string apiKey)
        {
            string paramStr = ParamsAsciiAsc(map);
            string paramStr2 = apiKey + paramStr;
            string sign = Md5Util.GetMd5(paramStr2, Encoding.UTF8).ToLower();
            return sign;
        }

        /**
         * 验签
         *
         * @param map     参数map
         * @param signStr 接收方生成的sign
         * @return boolean
         */
        public static bool verifySign(Dictionary<string, object> map, string apiKey, string signStr)
        {
            return DoSign(map, apiKey) == signStr;
        }

        /**
         * 对所传入的参数 进行ASCII码升序排列 最终生成字符串
         *
         * @param paramMap 参数mao
         * @return 字符串
         */
        public static string ParamsAsciiAsc(Dictionary<string, object> paramMap)
        {
            StringBuilder strB = new StringBuilder();
            // 排除sign和空值参数
            foreach (var param in paramMap.OrderBy(p => p.Key))
            {
                if (param.Key != "sign")
                {
                    if (param.Value != null && param.Value.ToString() != null)
                    {

                        strB.Append(param.Key).Append(param.Value);
                    }
                }
            }
            return strB.ToString();
        }
    }
}

