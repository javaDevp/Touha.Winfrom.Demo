using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Touha.Libs
{
    public class ConvertHelper
    {
        #region 对象字节数组转换
        /// <summary>
        /// 对象转字节数组
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] ObjectToBytes(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                return ms.GetBuffer();
            }
        }

        /// <summary>
        /// 字节数组转对象
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static object BytesToObject(byte[] buffer)
        {
            using (MemoryStream ms = new MemoryStream(buffer))
            {
                IFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize(ms);
            }
        }
        #endregion

        #region 对象Json转换
        /// <summary>
        /// 对象转json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// json转对象
        /// </summary>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static object JsonToObject(string strJson)
        {
            return JsonConvert.DeserializeObject(strJson);
        }

        /// <summary>
        /// 字符串转对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strJson"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(string strJson)
        {
            return JsonConvert.DeserializeObject<T>(strJson);
        }
        #endregion

        #region 对象xml转换
        /// <summary>
        /// 对象转xml
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToXml(object obj)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(ms, obj);
                using(StreamReader sr = new StreamReader(ms))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// xml转对象
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object XmlToObject(string xml, Type type)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                XmlSerializer serializer = new XmlSerializer(type);
                using (StringReader sr = new StringReader(xml))
                {
                    return serializer.Deserialize(sr);
                }
            }
        }
        #endregion
    }
}