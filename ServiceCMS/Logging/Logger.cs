using Logging.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class Logger : ILogger
    {
        private const string LOG_PATH = "C:\\ServiceCMSError\\";

        /// <summary>
        /// This method is for preapare the error massage on base of Exception Object
        /// </summary>
        /// <param name="serviceException"></param>
        /// <returns></returns>
        public string CreateErrorMessage(Exception serviceException)
        {
            StringBuilder messageBuilder = new StringBuilder();

            try
            {
                messageBuilder.AppendLine("----------------------------------" + DateTime.Now.ToString() + "----------------------------------");


                messageBuilder.Append("Exception : " + serviceException.ToString());
                if (serviceException.InnerException != null)
                {
                    messageBuilder.Append("InnerException :: " + serviceException.InnerException.ToString());
                }
                return messageBuilder.ToString();
            }
            catch
            {
                messageBuilder.Append("Exception:: Unknown Exception.");
                return messageBuilder.ToString();
            }

        }

        /// <summary>
        /// This method is for writting the Log file with message parameter
        /// </summary>
        /// <param name="message"></param>
        public void LogToFile(string message)
        {
            FileStream fileStream = null;
            StreamWriter streamWriter = null;
            try
            {
                string logFilePath = LOG_PATH;

                logFilePath = logFilePath + "ExceptionLog" + "-" + DateTime.Now.Year + "_" + DateTime.Now.Month.ToString().PadLeft(2, '0')+ "_" + DateTime.Now.Day.ToString().PadLeft(2, '0') + "." + "txt";

                if (logFilePath.Equals("")) return;
                #region Create the Log file directory if it does not exists
                DirectoryInfo logDirInfo = null;
                FileInfo logFileInfo = new FileInfo(logFilePath);
                logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();
                #endregion Create the Log file directory if it does not exists

                if (!logFileInfo.Exists)
                {
                    fileStream = logFileInfo.Create();
                }
                else
                {
                    fileStream = new FileStream(logFilePath, FileMode.Append);
                }
                streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(message);
            }
            finally
            {
                if (streamWriter != null) streamWriter.Close();
                if (fileStream != null) fileStream.Close();
            }

        }
    }
}
