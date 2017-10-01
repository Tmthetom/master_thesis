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
        private static IPAddress ip = IPAddress.Parse("81.200.57.24");
        private static int port = 6666;

        private static Logger logger = new Logger();
        private static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static byte[] buffer = new byte[clientSocket.SendBufferSize];

        static void Main(string[] args)
        {
            try
            {
                SelectClientRole();  // Select unknown client, mobile app or control station
                StartConnection();  // Establish connection with server
                StartCommunication();  // Start user communication
            }
            catch (Exception exception)
            {
                logger.WriteLine(exception.Message);
            }
        }

        private static void StartCommunication()
        {
            string message;
            while (true)
            {
                logger.Write("Send message: ");
                message = Console.ReadLine();
                SendMessage(message);
            }
        }

        private static void SendMessage(string message)
        {
            buffer = Encoding.UTF8.GetBytes(message.Trim());
            clientSocket.Send(buffer);
        }

        private static void StartConnection()
        {
            int attempts = 0;

            while (!clientSocket.Connected)
            {
                try
                {
                    attempts++;
                    //clientSocket.Connect(IPAddress.Loopback, port);  // Internal network
                    clientSocket.Connect(ip, port);  // Internet connection
                    logger.WriteLine("Successfully connected to [" + clientSocket.RemoteEndPoint + "] as unknown client", ConsoleColor.Green);
                    SendClientRole();
                }
                catch (Exception)
                {
                    Console.Clear();
                    logger.WriteLine("Connection attempts: " + attempts);
                }
            }
        }

        private static void SelectClientRole()
        {
            string role = "-1";
            while (role.Equals("-1"))
            {
                Console.WriteLine("Please select client role: ");
                Console.WriteLine("\t 1 - for mobile app (SecurityViewer)");
                Console.WriteLine("\t 2 - for control unit (Security)");
                Console.WriteLine("\t 0 - for unknown client");
                Console.Write("Selected role: ");
                role = Console.ReadLine();

                // Mobile app (SecurityViewer)
                if (role.Equals("1"))
                {
                    Console.Title = "Mobile app (SecurityViewer)";
                }

                // Control unit (Security)
                else if (role.Equals("2"))
                {
                    Console.Title = "Control unit (Security)";
                }

                // Unknown client
                else if (role.Equals("0"))
                {
                    Console.Title = "Client";
                }

                // Not selected
                else
                {
                    role = "-1";
                }

                Console.Clear();
            }
        }

        private static void SendClientRole()
        {
            // Mobile app (SecurityViewer)
            if (Console.Title.Equals("Mobile app (SecurityViewer)"))
            {
                SendMessage("SecurityViewer");
                logger.WriteLine("Client identified as mobile app (SecurityViewer)", ConsoleColor.Yellow);
            }

            // Control unit (Security)
            else if (Console.Title.Equals("Control unit (Security)"))
            {
                SendMessage("Security");
                logger.WriteLine("Client identified as control unit (Security)", ConsoleColor.Yellow);
            }
        }
    }
}
