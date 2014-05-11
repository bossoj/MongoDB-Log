using System;

namespace BJ.MongoDB.Logger
{
    [Serializable]
    public class LoggerConnectionException : ApplicationException
    {
        public LoggerConnectionException() { }

        public LoggerConnectionException(string message) : base(message) { }

        public LoggerConnectionException(string message, Exception inner) : base(message, inner) { }

        protected LoggerConnectionException(System.Runtime.Serialization.SerializationInfo info,
                                   System.Runtime.Serialization.StreamingContext contex)
            : base(info, contex) { }
    }
}
