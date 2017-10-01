using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace SecurityServer
{
    class Program
    {
        private static Logger logger = new Logger();  // Formating command line
        private static List<Socket> unknownClients = new List<Socket>();  // Not assignet clients yet
        private static List<Socket> mobileApps = new List<Socket>();  // SecurityViewer = Mobile app
        private static List<Socket> controlUnits = new List<Socket>();  // Security = Control unit

        static void Main(string[] args)
        {
            try
            {
                StartServer();
            }
            catch (Exception exception)
            {
                logger.WriteLine(exception.Message);
            }
        }

        #region Data processing
        private static void ProcessReceived(Socket client, string message)
        {
            // Mobile app (SecurityViewer)
            if (mobileApps.Contains(client))
            {
                logger.WriteLine("Mobile app [" + client.RemoteEndPoint + "]: " + message);
            }

            // Control unit (Security)
            else if (controlUnits.Contains(client))
            {
                logger.WriteLine("Control unit [" + client.RemoteEndPoint + "]: " + message);
            }

            // Unknown clients
            else if (unknownClients.Contains(client))
            {
                logger.WriteLine("[" + client.RemoteEndPoint + "]: " + message);
                AssignRole(client, message);
            }
        } 

        /// <summary>
        /// Assign unknown client to one role
        /// </summary>
        /// <param name="client"></param>
        /// <param name="message"></param>
        private static void AssignRole(Socket client, string message)
        {
            // If control unit
            if (message.ToLower().Equals("Security".ToLower()))
            {
                controlUnits.Add(client);  // Assign
                unknownClients.Remove(client);  // Remove from old list
                logger.WriteLine("Client [" + client.RemoteEndPoint + "] identified as control unit (Security)", ConsoleColor.Yellow);
            }

            // If mobile app
            else if (message.ToLower().Equals("SecurityViewer".ToLower()))
            {
                mobileApps.Add(client);  // Assign
                unknownClients.Remove(client);  // Remove from old list
                logger.WriteLine("Client [" + client.RemoteEndPoint + "] identified as mobile app (SecurityViewer)", ConsoleColor.Yellow);
            }
        }
        #endregion Data processing

        #region Server part

        private static Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static byte[] buffer = new byte[server.SendBufferSize];

        /// <summary>
        /// Start the server
        /// </summary>
        private static void StartServer()
        {
            // Settings
            Console.Title = "Server";
            logger.WriteLine("Setting up server...");
            server.Bind(new IPEndPoint(IPAddress.Any, 6666));

            // Starting server
            logger.WriteLine("Starting server...");
            server.Listen(0);
            server.BeginAccept(new AsyncCallback(AcceptCallback), null);
            logger.WriteLine("The server is running at " + server.LocalEndPoint);
            logger.WriteLine("Waiting for a connection...");

            Console.ReadLine();
        }

        /// <summary>
        /// Accept connection
        /// </summary>
        /// <param name="AR"></param>
        private static void AcceptCallback(IAsyncResult AR)
        {
            // Accept new connection
            Socket client = server.EndAccept(AR);  // End request
            unknownClients.Add(client);  // Add to unknown clients
            client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), client);  // Start listening for communication
            logger.WriteLine("Client [" + client.RemoteEndPoint + "] connected", ConsoleColor.Green);

            // Start accepting another connections
            server.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        /// <summary>
        /// Receive data
        /// </summary>
        /// <param name="AR"></param>
        private static void ReceiveCallBack(IAsyncResult AR)
        {
            Socket client = (Socket)AR.AsyncState;

            try
            {
                // Stop listening
                int received = client.EndReceive(AR);

                // Read incoming data
                byte[] dataBuffer = new byte[received];
                Buffer.BlockCopy(buffer, 0, dataBuffer, 0, received);
                string message = Encoding.UTF8.GetString(dataBuffer).Trim();

                // Process received data
                ProcessReceived(client, message);

                // Start listening again
                client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), client);
            }

            // Connection lost
            catch (SocketException)
            {
                // Remove user from socket lists
                if (unknownClients.Contains(client)) unknownClients.Remove(client);
                if (mobileApps.Contains(client)) mobileApps.Remove(client);
                if (controlUnits.Contains(client)) controlUnits.Remove(client);

                // Notificate
                logger.WriteLine("Client [" + client.RemoteEndPoint + "] disconnected", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Send message to client
        /// </summary>
        /// <param name="client">To who we are sending</param>
        /// <param name="message">Data to send</param>
        private static void SendMessage(Socket client, string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message.Trim());
            client.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallBack), client);
        }

        /// <summary>
        /// Finish sending after data receive confirmed
        /// </summary>
        /// <param name="AR"></param>
        private static void SendCallBack(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }

        #endregion Server part
    }
}
