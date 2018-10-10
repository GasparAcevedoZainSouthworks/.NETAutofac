using System;

namespace NET_Autofac.Models
{
    public interface ILogger
    {
        void WriteLog(string logData);
    }
    public class Logger : ILogger
    {
        public void WriteLog(string logData)
        {
            Console.WriteLine(string.Format("Logged info: {0}", logData));
        }
    }
}