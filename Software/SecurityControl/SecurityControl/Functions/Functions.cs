using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SecurityControl.Functions
{
    class Functions
    {
        /* Last updated 08. 05. 2017 */

        #region Notification Ballooon

        /// <summary>
        /// Popup balloon notification (Windows 10 only)
        /// </summary>
        /// <param name="text">Text in notification</param>
        public void Notification_Balloon(string text)
        {
            NotifyIcon balloon = new NotifyIcon();
            balloon.Icon = SystemIcons.Application;
            balloon.Visible = true;
            balloon.ShowBalloonTip(3000, "", text, ToolTipIcon.Info);
            balloon.Dispose();
        }

        /// <summary>
        /// Popup balloon notification (Windows 10 only)
        /// </summary>
        /// <param name="title">Title of notification</param>
        /// <param name="text">Text in notification</param>
        /// <param name="icon">Icon in notification</param>
        public void Notification_Balloon(string text, Icon icon)
        {
            NotifyIcon balloon = new NotifyIcon()
            {
                Icon = icon,
                Visible = true
            };
            balloon.ShowBalloonTip(3000, "", text, ToolTipIcon.None);
            balloon.Dispose();
        }

        /// <summary>
        /// Popup balloon notification (Windows 10 only)
        /// </summary>
        /// <param name="title">Title of notification</param>
        /// <param name="text">Text in notification</param>
        public void Notification_Balloon(string title, string text)
        {
            NotifyIcon balloon = new NotifyIcon()
            {
                Icon = SystemIcons.Application,
                Visible = true
            };
            balloon.ShowBalloonTip(3000, title, text, ToolTipIcon.Info);
            balloon.Dispose();
        }

        /// <summary>
        /// Popup balloon notification (Windows 10 only)
        /// </summary>
        /// <param name="title">Title of notification</param>
        /// <param name="text">Text in notification</param>
        /// <param name="showTime">How long will be notification visible</param>
        public void Notification_Balloon(string title, string text, int showTime)
        {
            NotifyIcon balloon = new NotifyIcon()
            {
                Icon = SystemIcons.Application,
                Visible = true
            };
            balloon.ShowBalloonTip(showTime, title, text, ToolTipIcon.Info);
            balloon.Dispose();
        }

        /// <summary>
        /// Popup balloon notification (Windows 10 only)
        /// </summary>
        /// <param name="title">Title of notification</param>
        /// <param name="text">Text in notification</param>
        /// <param name="icon">Icon in notification</param>
        public void Notification_Balloon(string title, string text, Icon icon)
        {
            NotifyIcon balloon = new NotifyIcon()
            {
                Icon = icon,
                Visible = true
            };
            balloon.ShowBalloonTip(3000, title, text, ToolTipIcon.None);
            balloon.Dispose();
        }

        /// <summary>
        /// Popup balloon notification (Windows 10 only)
        /// </summary>
        /// <param name="title">Title of notification</param>
        /// <param name="text">Text in notification</param>
        /// <param name="showTime">How long will be notification visible</param>
        /// <param name="icon">Icon in notification</param>
        public void Notification_Balloon(string title, string text, int showTime, Icon icon)
        {
            NotifyIcon balloon = new NotifyIcon()
            {
                Icon = icon,
                Visible = true
            };
            balloon.ShowBalloonTip(showTime, title, text, ToolTipIcon.Info);
            balloon.Dispose();
        }

        #endregion

        #region ToString

        /// <summary>
        /// Formated file size with proper extension (KB, MB, GB, ...)
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>String with file size and proper extension</returns>
        public string ToString_FileSize(string path)
        {
            // File size in bits
            long i = new FileInfo(path).Length;
            // Get absolute value
            long absolute_i = (i < 0 ? -i : i);
            // Determine the suffix and readable value
            string suffix;
            double readable;
            if (absolute_i >= 0x1000000000000000) // Exabyte
            {
                suffix = "EB";
                readable = (i >> 50);
            }
            else if (absolute_i >= 0x4000000000000) // Petabyte
            {
                suffix = "PB";
                readable = (i >> 40);
            }
            else if (absolute_i >= 0x10000000000) // Terabyte
            {
                suffix = "TB";
                readable = (i >> 30);
            }
            else if (absolute_i >= 0x40000000) // Gigabyte
            {
                suffix = "GB";
                readable = (i >> 20);
            }
            else if (absolute_i >= 0x100000) // Megabyte
            {
                suffix = "MB";
                readable = (i >> 10);
            }
            else if (absolute_i >= 0x400) // Kilobyte
            {
                suffix = "KB";
                readable = i;
            }
            else
            {
                return i.ToString("0 B"); // Byte
            }
            // Divide by 1024 to get fractional value
            readable = (readable / 1024);
            // Return formatted number with suffix
            return readable.ToString("0.### ") + suffix;
        }

        /// <summary>
        /// Convert timeSpan into formated string
        /// </summary>
        /// <param name="span">Time span with time in ms</param>
        /// <returns>Formated string in Czech language</returns>
        public string ToString_Time_CZ(TimeSpan span)
        {
            string formatted = string.Format("{0}{1}{2}{3}",
                span.Duration().Days > 0 ? string.Format("{0:0} {1}, ", span.Days, span.Days == 1 ? "den" : (span.Seconds <= 4 ? "dny" : "dní")) : string.Empty,
                span.Duration().Hours > 0 ? string.Format("{0:0} {1}, ", span.Hours, span.Hours == 1 ? "hodina" : (span.Hours <= 4 ? "hodiny" : "hodin")) : string.Empty,
                span.Duration().Minutes > 0 ? string.Format("{0:0} {1}, ", span.Minutes, span.Minutes == 1 ? "minuta" : (span.Minutes <= 4 ? "minuty" : "minut")) : string.Empty,
                span.Duration().Seconds > 0 ? string.Format("{0:0} {1}", span.Seconds, span.Seconds == 1 ? "sekunda" : (span.Seconds <= 4 ? "sekundy" : "sekund")) : string.Empty);

            if (formatted.EndsWith(", ")) formatted = formatted.Substring(0, formatted.Length - 2);

            if (string.IsNullOrEmpty(formatted)) formatted = "0 sekund";

            return formatted;
        }

        /// <summary>
        /// Convert timeSpan into formated string
        /// </summary>
        /// <param name="ms">Time in ms</param>
        /// <returns>Formated string in Czech language</returns>
        public string ToString_Time_CZ(long ms)
        {
            TimeSpan span = TimeSpan.FromMilliseconds(ms);

            string formatted = string.Format("{0}{1}{2}{3}",
                span.Duration().Days > 0 ? string.Format("{0:0} {1}, ", span.Days, span.Days == 1 ? "den" : (span.Seconds <= 4 ? "dny" : "dní")) : string.Empty,
                span.Duration().Hours > 0 ? string.Format("{0:0} {1}, ", span.Hours, span.Hours == 1 ? "hodina" : (span.Hours <= 4 ? "hodiny" : "hodin")) : string.Empty,
                span.Duration().Minutes > 0 ? string.Format("{0:0} {1}, ", span.Minutes, span.Minutes == 1 ? "minuta" : (span.Minutes <= 4 ? "minuty" : "minut")) : string.Empty,
                span.Duration().Seconds > 0 ? string.Format("{0:0} {1}", span.Seconds, span.Seconds == 1 ? "sekunda" : (span.Seconds <= 4 ? "sekundy" : "sekund")) : string.Empty);

            if (formatted.EndsWith(", ")) formatted = formatted.Substring(0, formatted.Length - 2);

            if (string.IsNullOrEmpty(formatted)) formatted = "0 sekund";

            return formatted;
        }

        #endregion

        #region File

        /// <summary>
        /// Read all bytes
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>Byte array</returns>
        public byte[] File_ReadAllBytes(string path)
        {
            return File.ReadAllBytes(path);
        }

        /// <summary>
        /// Write all bytes into file
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="data">Data to store in file</param>
        /// <returns>True if success</returns>
        public bool File_WriteAllBytes(string path, byte[] data)
        {
            try
            {
                File.WriteAllBytes(path, data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Get file path without file name
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>File path without file name</returns>
        public string File_Path(string path)
        {
            return Path.GetDirectoryName(path);  // Removes last file from path
        }

        /// <summary>
        /// Get file extension only
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>File extension</returns>
        public string File_Extension(string path)
        {
            return Path.GetExtension(path);  // Get extension
        }

        /// <summary>
        /// Get file name without extension
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>File name without extension</returns>
        public string File_Name(string path)
        {
            return Path.GetFileNameWithoutExtension(path);  // Remove extension
        }

        /// <summary>
        /// Get file name with extension
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>File name with extension</returns>
        public string File_Name_WithExtension(string path)
        {
            return Path.GetFileName(path);
        }

        /// <summary>
        /// Get of operation speed in MB/s
        /// </summary>
        /// <param name="path">Path of file with data before operation</param>
        /// <param name="ms">How long opration takes in ms</param>
        /// <returns>Speed in MB/s</returns>
        public string File_DataFlow(string path, float ms)
        {
            return (File_Size_MB(path) / (ms / 1000)).ToString("N") + " MB/s";  // Data flow
        }

        /// <summary>
        /// Get of operation speed in MB/s
        /// </summary>
        /// <param name="size">Size of file before operation (in bytes)</param>
        /// <param name="ms">How long opration takes in ms</param>
        /// <returns>Speed in MB/s</returns>
        public string File_DataFlow(float size, float ms)
        {
            return (size / (ms / 1000)).ToString("N") + " MB/s";  // Data flow
        }

        /// <summary>
        /// Get file size in B
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>File size in bytes</returns>
        public long File_Size_B(string path)
        {
            return new FileInfo(path).Length;  // File size in B
        }

        /// <summary>
        /// Get file size in MB
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>File size in mega bytes</returns>
        public long File_Size_MB(string path)
        {
            return File_Size_B(path) / (1000 * 1000);  // File size in MB
        }

        #endregion
    }
}
