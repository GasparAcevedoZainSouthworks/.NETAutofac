using System;

namespace NET_Autofac.Models
{
    public interface ILoggerConsumer
    {
        void LogString(string strToLog);
        void LogInt(int intToLog);
    }
    public class LoggerConsumer : ILoggerConsumer
    {
        private ILogger logger;
        private IOutput output;
        public LoggerConsumer(ILogger logger)
        {
            this.logger = logger;
        }
        /// Constructor created only for using in the example "Constructor Specifier w/Autofac"
        public LoggerConsumer(ILogger logger, IOutput output)
        {
            this.logger = logger;
            this.output = output;
        }
        public void LogString(string strToLog)
        {
            logger.WriteLog(strToLog);
        }
        public void LogInt(int intToLog)
        {
            logger.WriteLog(intToLog.ToString());
        }
    }
}