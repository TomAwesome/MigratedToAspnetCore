using System;

namespace AwesomeLogger
{
    public interface ILogger
    {
        void Debug(string message);
        void Error(string message, Exception ex);
        void Info(string message);
        void Warn(string message, Exception ex);
    }
}