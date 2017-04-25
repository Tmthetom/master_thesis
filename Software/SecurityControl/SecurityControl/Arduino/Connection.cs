using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityControl.Arduino
{
    class Connection
    {
        private SerialPort mySerial = new SerialPort();

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
    }
}
