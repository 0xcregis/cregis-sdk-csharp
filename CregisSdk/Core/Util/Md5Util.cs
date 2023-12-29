using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CregisSdk.Core.Util
{
    public class Md5Util
    {
        public static string GetMd5(string content, Encoding encoding)
        {
            byte[] bytes = encoding.GetBytes(content);
            MD5 mD = new MD5CryptoServiceProvider();
            byte[] array = mD.ComputeHash(bytes);
            StringBuilder stringBuilder = new StringBuilder("");
            for (int i = 0; i < array.Length; i++)
            {
                string text = array[i].ToString("x2");
                stringBuilder.Append(text);
            }
            return stringBuilder.ToString();
        }
    }
}
