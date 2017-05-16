using System.IO.Ports;

namespace SecurityControl.Arduino
{
    public class Connection
    {
        private SerialPort mySerial = new SerialPort();

        #region Connection
        /// <summary>
        /// Create new serial connection without parametres
        /// </summary>
        public Connection()
        {
            ;
        }

        /// <summary>
        /// Create new serial connection
        /// </summary>
        /// <param name="port">Port name</param>
        /// <param name="baudRate">Connection speed</param>
        public Connection(string port, int baudRate)
        {
            mySerial.PortName = port;
            mySerial.BaudRate = baudRate;
            mySerial.Open();
        }

        /// <summary>
        /// Return SerialPort connection
        /// </summary>
        /// <returns>SerialPort connection</returns>
        public SerialPort GetConnection()
        {
            return mySerial;
        }

        /// <summary>
        /// Return communication port
        /// </summary>
        /// <returns>Port</returns>
        public string GetPort()
        {
            return mySerial.PortName;
        }

        /// <summary>
        /// Return communication speed
        /// </summary>
        /// <returns>BaudRate</returns>
        public int GetBaudRate()
        {
            return mySerial.BaudRate;
        }

        /// <summary>
        /// Set connection parametres
        /// </summary>
        /// <param name="port">Port to connect</param>
        /// <param name="baudRate">Speed to connect with</param>
        public void SetConnection(string port, int baudRate)
        {
            mySerial.PortName = port;
            mySerial.BaudRate = baudRate;
        }

        /// <summary>
        /// Open serial connection
        /// </summary>
        public void Open()
        {
            mySerial.Open();
        }

        /// <summary>
        /// Close serial connection
        /// </summary>
        public void Close()
        {
            if (IsOpen())
            {
                mySerial.Close();
            }
        }

        /// <summary>
        /// Get connection status
        /// </summary>
        /// <returns>True if connected</returns>
        public bool IsOpen()
        {
            return mySerial.IsOpen;
        }

        /// <summary>
        /// Set what method is called, when data recieved
        /// </summary>
        /// <param name="handler"></param>
        public void SetDataReciever(SerialDataReceivedEventHandler handler)
        {
            mySerial.DataReceived += new SerialDataReceivedEventHandler(handler);
        }
        #endregion Connection

        #region Operations
        /// <summary>
        /// Send command into serial
        /// </summary>
        /// <param name="command">Command string</param>
        public void Send(string command)
        {
            mySerial.WriteLine(command);
        }

        /// <summary>
        /// Recieve one line from serial
        /// </summary>
        /// <returns>Answer for command</returns>
        public string ReadLine()
        {
            return mySerial.ReadLine();
        }
        #endregion Operations
    }
}
