using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace 序列化操作
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    //[XmlRoot(Namespace = "")]
    public class MyClass
    {

        public string MyString { get; set; }

        public int MyInt { get; set; }

        public MyEnum MyEnum { get; set; }

        [XmlElement("MyClass1", typeof(MyClass1))]
        [XmlElement("MyClass2", typeof(MyClass2))]
        public object MyObj { get; set; }
    }

    [Serializable]
    [XmlType(AnonymousType = true)]
    public enum MyEnum
    {
        //[XmlEnum("Value1")]
        Value5,
        //[XmlEnum("Value2")]
        Value2
    }

    public class MyClass1
    {
        public string MyString2 { get; set; }
    }

    public class MyClass2
    {
        public int MyInt2 { get; set; }
    }
}