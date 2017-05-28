using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityControl.Arduino
{
    static class BoardPins
    {
        /// <summary>
        /// Get board pins, based on board name
        /// </summary>
        /// <param name="boardName">Arduino board name</param>
        /// <returns>Array of pins</returns>
        public static string[] GetPins(string boardName)
        {
            switch (boardName)
            {
                case "Arduino Uno": return ArduinoDefault();
                case "Arduino Mega": return ArduinoMega();

                default: return ArduinoDefault();
            }
        }


        /// <summary>
        /// Arduino Mega
        /// </summary>
        /// <returns></returns>
        private static string[] ArduinoMega()
        {
            return new string[] {
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "11",
                "12",
                "13",
                "22",
                "23",
                "24",
                "25",
                "26",
                "27",
                "28",
                "29",
                "30",
                "31",
                "32",
                "33",
                "34",
                "35",
                "36",
                "37",
                "38",
                "39",
                "40",
                "41",
                "42",
                "43",
                "44",
                "45",
                "46",
                "47",
                "48",
                "49"
            };
        }

        /// <summary>
        /// Arduino Uno
        /// Arduino Duemilanove
        /// Arduino Diecimila 
        /// Arduino Nano
        /// Arduino NG
        /// Arduino Mini
        /// Arduino Extreme
        /// Arduino USB
        /// Arduino Bluetooth
        /// Arduino Serial
        /// Severino
        /// </summary>
        /// <returns></returns>
        private static string[] ArduinoDefault()
        {
            return new string[] {
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9",
                "10",
                "11",
                "12",
                "13"
            };
        }
    }
}
