using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touha.Libs
{
    public class EncryptUtil
    {
        /// <summary>
        /// MD5
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string MD5(byte[] buffer)
        {
            System.Security.Cryptography.MD5 calculator = System.Security.Cryptography.MD5.Create();
            buffer = calculator.ComputeHash(buffer);
            calculator.Clear();
            //将字节数组转换成十六进制的字符串形式
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < buffer.Length; i++)
            {
                stringBuilder.Append(buffer[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}
