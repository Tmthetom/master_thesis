using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static byte[] data;  // 1
        static Socket socket; // 1
        static void Main(string[] args)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // 2
            socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6666)); // 3

            while (true)
            {
                socket.Listen(1); // 4
                Socket accepteddata = socket.Accept(); // 5
                data = new byte[accepteddata.SendBufferSize]; // 6
                int j = accepteddata.Receive(data); // 7
                byte[] adata = new byte[j];         // 7
                for (int i = 0; i < j; i++)         // 7
                    adata[i] = data[i];             // 7
                string dat = Encoding.Default.GetString(adata); // 8
                Console.WriteLine(dat);                         // 8
            }
        }
    }
}
