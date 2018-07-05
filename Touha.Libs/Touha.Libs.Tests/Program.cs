using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Touha.Libs.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SystemInfo.UserName);
            //Console.WriteLine(SystemInfo.GetString("Win32_BIOS", "SerialNumber"));
            Console.WriteLine(SystemInfo.GetUserName());
            Console.WriteLine(SystemInfo.MacAddress);
            Console.WriteLine(SystemInfo.OperationSystem);
            Console.WriteLine(SystemInfo.BIOSSerialNumber);
            //Console.WriteLine(SystemInfo.GetBIOSSerialNumber());
            Console.WriteLine(ConvertHelper.ObjectToJson(new { A = 1 }));
            var obj = ConvertHelper.JsonToObject("{\"A\":1}");

            int port = 9993;
            string ip = "127.0.0.1";
            TcpHelper helper = new TcpHelper(ip, port);
            Thread t = new Thread(StartListen);
            t.Start(helper);
            
            TcpClient client = new TcpClient();
            client.Connect(ip, port);
            NetworkStream ns = client.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes("Hello World");
            ns.Write(buffer, 0, buffer.Length);
            
            Console.Read();
        }

        private static void StartListen(object obj)
        {
            TcpHelper helper = obj as TcpHelper;
            helper.StartListen();
        }
    }
}
