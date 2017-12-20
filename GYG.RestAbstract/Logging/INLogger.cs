namespace GYG.RestAbstract.Logging
{
    using System;
    public interface INLogger
    {
        void Debug(string message);

        void Error(string message);
        void ErrorException(string message, Exception exception);

        void Info(string message);

        void Warn(string message);
    }
}
