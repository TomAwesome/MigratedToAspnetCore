using System;
using log4net;

namespace AwesomeLogger
{
    public class Logger<T>
    {
        readonly ILog logger;

        public Logger() : this(LogManager.GetLogger(typeof(T)))
        {
            
        }

        public Logger(ILog logger)
        {
            this.logger = logger;
        }

        public void Error(string message, Exception ex)
        {
            logger.Error(message, ex);
        }

        public void Warn(string message, Exception ex)
        {
            logger.Warn(message, ex);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }
    }
}
