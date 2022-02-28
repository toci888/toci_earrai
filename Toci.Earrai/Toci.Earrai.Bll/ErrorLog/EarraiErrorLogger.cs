using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Common;

namespace Toci.Earrai.Bll.ErrorLog
{
    public class EarraiErrorLogger : IErrorLogger
    {
        private static string LogFile = "logs.txt";

        private static StreamWriter Swr;

        public void Log(List<Exception> ex)
        {
            if (Swr == null)
            {
                Swr = new StreamWriter(LogFile);
            }

            string logEntry = "";

            foreach (Exception exc in ex)
            {
                logEntry += "Error. Message: " + exc.Message + ", stack trace: " + exc.StackTrace + Environment.NewLine;
            }

            Swr.Write(logEntry);
            Swr.Flush();
        }
    }
}
