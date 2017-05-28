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
                case "Arduino Mega 2560": return ArduinoMega();

                case "Genuino Mega": return ArduinoMega();
                case "Genuino Mega 2560": return ArduinoMega();

                default: return ArduinoDefault();
            }
        }


        /// <summary>
        /// Arduino/Genuino Mega
        /// Arduino/Genuino Mega 2560
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
        /// Arduino/Genuino Uno
        /// Arduino/Genuino Duemilanove
        /// Arduino/Genuino Diecimila 
        /// Arduino/Genuino Nano
        /// Arduino/Genuino NG
        /// Arduino/Genuino Mini
        /// Arduino/Genuino Extreme
        /// Arduino/Genuino USB
        /// Arduino/Genuino Bluetooth
        /// Arduino/Genuino Serial
        /// Arduino/Genuino 101
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
