using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Touha.Libs
{
    public class TcpHelper
    {
        private TcpListener listener;

        public TcpHelper(string ip, int port)
        {
            var localaddr = IPAddress.Parse(ip);
            listener = new TcpListener(localaddr, port);
        }

        public void StartListen()
        {
            // Buffer for reading data
            Byte[] bytes = new Byte[256];
            listener.Start();
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                NetworkStream ns = client.GetStream();
                int i;

                // Loop to receive all the data sent by the client.
                while ((i = ns.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    string data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Received: {0}", data);
                }

                // Shutdown and end connection
                client.Close();
            }
        }
    }
}
