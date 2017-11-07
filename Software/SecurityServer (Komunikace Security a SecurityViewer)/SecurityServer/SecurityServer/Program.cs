using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SecurityServer
{
    class Program
    {
        #region Initialization

        private static Logger log = new Logger();  // Formating command line
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
                log.WriteLine(exception.Message);
            }
        }

        #endregion Initialization

        #region Data processing

        /// <summary>
        /// Process received message from client
        /// </summary>
        /// <param name="client">Client who send message</param>
        /// <param name="message">Message from client to process</param>
        private static void ProcessReceivedMessage(Socket client, string message)
        {
            // Check if client is connected
            if (!IsConnected(client)) return;

            // Mobile app (SecurityViewer)
            if (mobileApps.Contains(client))
            {
                log.WriteLine("Mobile app [" + client.RemoteEndPoint + "]: " + message);
                SendMessageToGroup(controlUnits, message);
            }

            // Control unit (Security)
            else if (controlUnits.Contains(client))
            {
                log.WriteLine("Control unit [" + client.RemoteEndPoint + "]: " + message);
                SendMessageToGroup(mobileApps, message);
            }

            // Unknown clients
            else if (unknownClients.Contains(client))
            {
                AssignRole(client, message);
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
            SetConsoleCtrlHandler(new HandlerRoutine(ConsoleCtrlCheck), true);
            Console.Title = "Server";
            log.WriteLine("Setting up server...");
            server.Bind(new IPEndPoint(IPAddress.Any, 6666));

            // Starting server
            log.WriteLine("Starting server...");
            server.Listen(0);
            server.BeginAccept(new AsyncCallback(AcceptCallback), null);
            log.WriteLine("The server is running at " + server.LocalEndPoint);
            log.WriteLine("Waiting for a connection...");

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
            log.WriteLine("Client [" + client.RemoteEndPoint + "] connected", ConsoleColor.Green);

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
                ProcessReceivedMessage(client, message);

                // Start listening again
                client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), client);
            }

            // Connection lost
            catch (SocketException)
            {
                ClientDisconnected(client);
            }
        }

        /// <summary>
        /// Assign unknown client to one role
        /// </summary>
        /// <param name="client">Client checked for assign</param>
        /// <param name="message">Message with role name</param>
        private static void AssignRole(Socket client, string message)
        {
            // If control unit
            if (message.ToLower().Equals("Security".ToLower()))
            {
                controlUnits.Add(client);  // Assign
                unknownClients.Remove(client);  // Remove from old list
                log.WriteLine("Client [" + client.RemoteEndPoint + "] identified as control unit (Security)", ConsoleColor.Yellow);
            }

            // If mobile app
            else if (message.ToLower().Equals("SecurityViewer".ToLower()))
            {
                mobileApps.Add(client);  // Assign
                unknownClients.Remove(client);  // Remove from old list
                log.WriteLine("Client [" + client.RemoteEndPoint + "] identified as mobile app (SecurityViewer)", ConsoleColor.Yellow);
            }

            else
            {
                log.WriteLine("Client [" + client.RemoteEndPoint + "]: " + message);
            }
        }
        
        /// <summary>
        /// Check if client is connected
        /// </summary>
        /// <returns>True when connected, false when disconnected</returns>
        public static bool IsConnected(Socket client)
        {
            try
            {
                //return !(client.Poll(1, SelectMode.SelectRead) && client.Available == 0);
                if ((client.Poll(1, SelectMode.SelectRead) && client.Available == 0))
                {
                    ClientDisconnected(client);
                    return false;
                }
                return true;
            }
            catch (SocketException)
            {
                ClientDisconnected(client);
                return false;
            }
        }

        /// <summary>
        /// When client disconnected
        /// </summary>
        private static void ClientDisconnected(Socket client)
        {
            // Unknown client
            if (unknownClients.Contains(client))
            {
                unknownClients.Remove(client);
                log.WriteLine("Client [" + client.RemoteEndPoint + "] disconnected", ConsoleColor.Red);
            }

            // Mobile app
            else if (mobileApps.Contains(client))
            {
                mobileApps.Remove(client);
                log.WriteLine("Mobile app [" + client.RemoteEndPoint + "] disconnected", ConsoleColor.Red);
            }

            // Control unit
            else if (controlUnits.Contains(client))
            {
                controlUnits.Remove(client);
                log.WriteLine("Control unit [" + client.RemoteEndPoint + "] disconnected", ConsoleColor.Red);
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
        /// Send message to certain group of clients
        /// </summary>
        /// <param name="client">To who we are sending</param>
        /// <param name="message">Data to send</param>
        private static void SendMessageToGroup(List<Socket> clients, string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message.Trim());
            foreach (Socket client in clients)
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

        /// <summary>
        /// Close all current connections
        /// </summary>
        private static void CloseAllConnections()
        {
            foreach (Socket user in unknownClients)
            {
                user.Shutdown(SocketShutdown.Both);
                user.Close();
            }

            foreach (Socket user in mobileApps)
            {
                user.Shutdown(SocketShutdown.Both);
                user.Close();
            }

            foreach (Socket user in controlUnits)
            {
                user.Shutdown(SocketShutdown.Both);
                user.Close();
            }
        }

        #endregion Server part

        #region Form closing event

        // http://geekswithblogs.net/mrnat/archive/2004/09/23/11594.aspx

        // Declare the SetConsoleCtrlHandler function
        // as external and receiving a delegate.
        [DllImport("Kernel32")]
        public static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);

        // A delegate type to be used as the handler routine 
        // for SetConsoleCtrlHandler.
        public delegate bool HandlerRoutine(CtrlTypes CtrlType);

        // An enumerated type for the control messages
        // sent to the handler routine.
        public enum CtrlTypes
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT,
            CTRL_CLOSE_EVENT,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT
        }

        private static bool ConsoleCtrlCheck(CtrlTypes ctrlType)
        {
            CloseAllConnections();
            return true;
        }

        #endregion Form closing event
    }
}
