using System;
using System.IO;

namespace LoggingOperationsAssembly
{
    public class LoggingOps
    {
        public static string filePath = null;

        /// <summary>
        /// A method that creates the log file for the project. The input is <paramref name="FileName"/>, the expected outputs are:
        /// If the file doesn't exist, the method will return the path of the file.
        /// If the file already exists, it only saves the path to the file.
        /// If the file doesn't exist, then the return value is null.
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static string CreateLogFile(string FileName)
        {
            string fPath = null;

           
            string desiredPath = @"A:\.net faculta lab\proiect 3\MagazinOnline";
            string fullPath = Path.Combine(desiredPath, FileName);

            if (!File.Exists(fullPath))
            {
                File.Create(fullPath).Close(); 
                fPath = Path.GetDirectoryName(fullPath);
                return fPath;
            }
            else if (File.Exists(fullPath) && fPath == null)
            {
                fPath = Path.GetDirectoryName(fullPath);
                return fPath;
            }
            else
            {
                Console.WriteLine("WARNING: The file already exists. No actions must be taken, all good.");
                return null;
            }
        }

        /// <summary>
        /// This method writes a log activity inside the log file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool WriteLog(string filePath, string message)
        {
            if (File.Exists(filePath))
            {
                using (StreamWriter w = File.AppendText(filePath))
                {
                    w.WriteLine($"{DateTime.UtcNow} : {message}");
                    return true;
                }
            }
            else
            {
                Console.WriteLine("ERROR: The logging file does not exist.");
                return false;
            }
        }
    }
}
