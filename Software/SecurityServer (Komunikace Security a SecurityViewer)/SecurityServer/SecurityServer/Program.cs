using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace SecurityServer
{
    class Program
    {
        private static Logger logger = new Logger();
        private static List<Socket> clientSockets = new List<Socket>();
        private static Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static byte[] buffer = new byte[serverSocket.SendBufferSize];

        static void Main(string[] args)
        {
            try
            {
                // Settings
                Console.Title = "Server";
                logger.WriteLine("Setting up server...");
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, 6666));

                // Starting server
                logger.WriteLine("Starting server...");
                serverSocket.Listen(0);
                serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
                logger.WriteLine("The server is running at " + serverSocket.LocalEndPoint);
                logger.WriteLine("Waiting for a connection...");
                
                Console.ReadLine();
            }
            catch (Exception exception)
            {
                logger.WriteLine(exception.Message);
            }
        }
       
        /// <summary>
        /// Accept connection
        /// </summary>
        /// <param name="AR"></param>
        private static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket = serverSocket.EndAccept(AR);
            clientSockets.Add(socket);
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), socket);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            logger.WriteLine("Client [" + socket.RemoteEndPoint + "] connected", ConsoleColor.Green);
        }

        /// <summary>
        /// Receive data
        /// </summary>
        /// <param name="AR"></param>
        private static void ReceiveCallBack(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;

            try
            {
                int received = socket.EndReceive(AR);
                byte[] dataBuffer = new byte[received];
                Buffer.BlockCopy(buffer, 0, dataBuffer, 0, received);
                string message = Encoding.ASCII.GetString(dataBuffer);
                logger.WriteLine("[" + socket.RemoteEndPoint + "]: " + message);
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), socket);
            }

            // Connection lost
            catch (SocketException)
            {
                //socket.Close();
                clientSockets.Remove(socket);
                logger.WriteLine("Client [" + socket.RemoteEndPoint + "] disconnected", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Send data
        /// </summary>
        /// <param name="AR"></param>
        private static void SendCallBack(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }

        /// <summary>
        /// Send message to client
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="message"></param>
        private static void SendText(Socket socket, string message)
        {
            byte[] data = Encoding.ASCII.GetBytes(message);
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallBack), socket);
        }
    }
}
