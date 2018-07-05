using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace 序列化操作
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass obj = new MyClass { MyInt = 12, MyString = "abc", MyEnum = MyEnum.Value5, MyObj = new MyClass1 { MyString2 = "in" } };
            Console.WriteLine(Serialize<MyClass>(obj));

            MyClass obj2 = new MyClass { MyInt = 12, MyString = "abc", MyEnum = MyEnum.Value5, MyObj = new MyClass2 { MyInt2 = 23 } };
            Console.WriteLine(Serialize<MyClass>(obj2));
            Console.ReadKey();

        }

        public static string Serialize<T>(T o)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Serialize(ms, o);
                byte[] bytes = ms.ToArray();
                return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
            }
            

        }
    }
}
