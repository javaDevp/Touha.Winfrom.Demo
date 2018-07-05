using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace cn.touha.tools.lib.xml
{
    public class XmlHelper
    {
        public static string Serialize<T>(T obj) where T : class
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (MemoryStream ms = new MemoryStream())
                {
                    serializer.Serialize(ms, obj);
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }catch(Exception ex)
            {
                return null;
            }
        }

        public static T Deserialize<T>(string xml) where T : class
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using(StringReader reader = new StringReader(xml))
                {
                    return (T)serializer.Deserialize(reader);
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
