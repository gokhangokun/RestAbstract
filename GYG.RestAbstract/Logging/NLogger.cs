namespace GYG.RestAbstract.Logging
{
    using System;
    using NLog;
    public class NLogger : INLogger
    {
        private static Logger Logger => LogManager.GetCurrentClassLogger();

        public void Debug(string message)
        {
            Logger.Debug(message);
        }

        public void Error(string message)
        {
            Logger.Error(message);
        }

        public void ErrorException(string message, Exception exception)
        {
            Logger.ErrorException(message, exception);
        }

        public void Info(string message)
        {
            Logger.Info(message);
        }

        public void Warn(string message)
        {
            Logger.Warn(message);
        }
    }
}
