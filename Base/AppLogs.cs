using System;
using System.Web;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Threading.Tasks;

namespace Base
{
    public sealed class AppLogs
    {
        private static volatile AppLogs SingletonInstance;
        private static object syncRoot = new Object();
        public string RequestID
        {
            get; set;
        }
        private AppLogs() { }
        public static AppLogs ErrorsLogInstance
        {
            get
            {
                if (SingletonInstance == null)
                {
                    lock (syncRoot)
                    {
                        if (SingletonInstance == null)
                            SingletonInstance = new AppLogs();
                    }
                }

                return SingletonInstance;
            }
        }
        
        public void ManageException(Exception Exce, string projectName)
        {
            try
            {
                string ErrorMessage = "|| ExceptionMessage ||:- " + Exce.Message + Environment.NewLine + "  || ExceptionSource ||:- " + Exce.StackTrace + Environment.NewLine + " || ExceptionTargetSite ||:- " + Exce.TargetSite + Environment.NewLine + "  ||  ExceptionData ||:- " + Exce.Data + Environment.NewLine + Environment.NewLine + "||ExceptionInnerException||:-  " + Environment.NewLine + Exce.InnerException;
                LogMessage(ErrorMessage.ToString(), projectName);
            }
            catch (Exception ex)
            {
                string msgErr = ex.Message;
            }


        }
        
        public void LogMessage(string message, string projectName)
        {
            FileStream fileStream = null;
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                message = message + "   :::   " + DateTime.Now.TimeOfDay.ToString();
                message = message + Environment.NewLine;
                string systemdate = Convert.ToString(DateTime.Now.Date);
                stringBuilder.AppendFormat("{0}{1}", message, Environment.NewLine);
                string errorfilename = DateTime.Now.Date.ToString("dd/MM/yyyy");
                errorfilename = errorfilename.Replace("/", "_");
                string filename = AppDomain.CurrentDomain.BaseDirectory + (@"AppLogs\" + projectName + @"\LogFiles\");
                CreateValicdateDirectory(filename);
                filename += "error" + errorfilename;
                if ((File.Exists(filename + ".log")))
                {
                    fileStream = File.Open(filename + ".log", FileMode.Append, FileAccess.Write);
                }
                else
                {
                    fileStream = File.Create(filename + ".log");
                }
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.Write(stringBuilder.ToString());
                streamWriter.Close();
                streamWriter = null;
            }
            catch (Exception ex)
            {
                string errMsg = ex.Message;
            }
            finally
            {
                if ((fileStream != null))
                {
                    fileStream.Close();
                }
                fileStream = null;
                stringBuilder = null;
            }
        }
        public static void RequestLogMessage(string message, string fileName, string RequestID)
        {
            FileStream fileStream = null;
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                string subfolder = DateTime.Now.Year.ToString("00") + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Day.ToString("00") ;
                string path = AppDomain.CurrentDomain.BaseDirectory + (@"LogFiles\" + subfolder + @"\");

                string finalPath = path + @"\" + RequestID;
                if (!Directory.Exists(finalPath))
                {
                    Directory.CreateDirectory(finalPath);
                }
                string systemdate = Convert.ToString(DateTime.Now.Date);
                stringBuilder.Append(message);

                fileName = finalPath + @"\" + fileName;
                if ((File.Exists(fileName + ".log")))
                {
                    fileStream = File.Open(fileName + ".log", FileMode.Append, FileAccess.Write);
                }
                else
                {
                    fileStream = File.Create(fileName + ".log");
                }
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.Write(stringBuilder.ToString());
                streamWriter.Close();
                streamWriter = null;
            }
            catch (Exception ex)
            {
                string errMsg = ex.Message;
            }
            finally
            {
                if ((fileStream != null))
                {
                    fileStream.Close();
                }
                fileStream = null;
                stringBuilder = null;
            }
        }

        private static Random random = new Random();
        public static string RandomString()
        {
            int length = 10;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        #region Private Methods
        private static void CreateValicdateDirectory(string DirectoryPath)
        {
            try
            {
                string[] pathParts = DirectoryPath.Split('\\');
                IList<string> PathList = pathParts;
                List<String> list = new List<string>(pathParts);
                for (int i = 0; i < pathParts.Length; i++)
                {
                    if (i > 0)
                        pathParts[i] = Path.Combine(pathParts[i - 1], pathParts[i]);

                    if (!Directory.Exists(pathParts[i]))
                        Directory.CreateDirectory(pathParts[i]);
                }
            }
            catch (Exception ex)
            {
                string msgErr = ex.Message;
            }

        }
        #endregion
    }
}
