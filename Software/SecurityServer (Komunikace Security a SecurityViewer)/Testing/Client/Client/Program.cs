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
        //private static IPAddress ip = IPAddress.Parse("81.200.57.24");
        private static IPAddress ip = IPAddress.Loopback;  // Internal network
        private static int port = 6666;

        private static Logger logger = new Logger();
        private static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static byte[] buffer = new byte[clientSocket.SendBufferSize];
        private static int receivedInt;
        private static byte[] receivedData;

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
                // Writing
                if (!Console.Title.Contains("READ ONLY"))
                {
                    logger.Write("Send message: ");
                    message = Console.ReadLine();
                    SendMessage(message);
                }

                // Reading
                if (!Console.Title.Contains("WRITE ONLY"))
                {
                    ReceiveMessage();
                }
            }
        }

        private static void SendMessage(string message)
        {
            buffer = Encoding.UTF8.GetBytes(message.Trim());
            clientSocket.Send(buffer);
        }

        private static void ReceiveMessage()
        {
            receivedInt = clientSocket.Receive(buffer);
            receivedData = new byte[receivedInt];
            Buffer.BlockCopy(buffer, 0, receivedData, 0, receivedInt);
            logger.WriteLine("Received: " + Encoding.UTF8.GetString(receivedData).Trim());
        }

        private static void StartConnection()
        {
            int attempts = 0;

            while (!clientSocket.Connected)
            {
                try
                {
                    attempts++;
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
                // Write menu
                Console.WriteLine("Please select client role:");
                Console.WriteLine();
                Console.WriteLine("\t 1 - mobile app (SecurityViewer)");
                Console.WriteLine("\t 2 - control unit (Security)");
                Console.WriteLine();
                Console.WriteLine("\t 3 - mobile app (SecurityViewer) \t [READ ONLY]");
                Console.WriteLine("\t 4 - control unit (Security) \t\t [READ ONLY]");
                Console.WriteLine();
                Console.WriteLine("\t 5 - mobile app (SecurityViewer) \t [WRITE ONLY]");
                Console.WriteLine("\t 6 - control unit (Security) \t\t [WRITE ONLY]");
                Console.WriteLine();
                Console.WriteLine("\t 0 - unknown client");
                Console.WriteLine();
                Console.Write("Selected role: ");

                // Read answer
                role = Console.ReadLine();

                // Recognize answer
                switch (role)
                {
                    case "1":       // Mobile app (SecurityViewer)
                        Console.Title = "Mobile app (SecurityViewer)";
                        break;
                    case "2":       // Control unit (Security)
                        Console.Title = "Control unit (Security)";
                        break;

                    case "3":       // Mobile app (SecurityViewer) [WRITE ONLY]
                        Console.Title = "Mobile app (SecurityViewer) [WRITE ONLY]";
                        break;
                    case "4":       // Control unit (Security) [WRITE ONLY]
                        Console.Title = "Control unit (Security) [WRITE ONLY]";
                        break;

                    case "5":       // Mobile app (SecurityViewer) [READ ONLY]
                        Console.Title = "Mobile app (SecurityViewer) [READ ONLY]";
                        break;
                    case "6":       // Control unit (Security) [READ ONLY]
                        Console.Title = "Control unit (Security) [READ ONLY]";
                        break;

                    default:        // Role not selected
                        role = "-1";
                        break;
                }

                // Clear menu
                Console.Clear();
            }
        }

        private static void SendClientRole()
        {
            // Mobile app (SecurityViewer)
            if (Console.Title.Contains("Mobile app (SecurityViewer)"))
            {
                SendMessage("SecurityViewer");
                logger.WriteLine("Client identified as mobile app (SecurityViewer)", ConsoleColor.Yellow);
            }

            // Control unit (Security)
            else if (Console.Title.Contains("Control unit (Security)"))
            {
                SendMessage("Security");
                logger.WriteLine("Client identified as control unit (Security)", ConsoleColor.Yellow);
            }
        }
    }
}
