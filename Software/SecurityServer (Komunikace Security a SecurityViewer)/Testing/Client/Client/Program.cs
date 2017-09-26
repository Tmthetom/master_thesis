using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    class Program
    {
        private static Logger logger = new Logger();
        private static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static void Main(string[] args)
        {
            Console.Title = "Client";
            Connection();
            SendMessage();
            Console.ReadLine();
        }

        private static void SendMessage()
        {
            while (true)
            {
                logger.Write("Send message: ");
                string message = Console.ReadLine();
                byte[] buffer = Encoding.ASCII.GetBytes(message);
                clientSocket.Send(buffer);
            }
        }

        private static void Connection()
        {
            int attempts = 0;

            while (!clientSocket.Connected)
            {
                try
                {
                    attempts++;
                    clientSocket.Connect(IPAddress.Loopback, 6666);
                }
                catch (Exception)
                {
                    Console.Clear();
                    logger.WriteLine("Connection attempts: " + attempts);
                }
            }
        }
    }
}
