using System;

namespace BJ.MongoDB.Logger
{
    [Serializable]
    public class LoggerWriteException : ApplicationException
    {
        public LoggerWriteException() { }

        public LoggerWriteException(string message) : base(message) { }

        public LoggerWriteException(string message, Exception inner) : base(message, inner) { }

        protected LoggerWriteException(System.Runtime.Serialization.SerializationInfo info,
                                   System.Runtime.Serialization.StreamingContext contex)
            : base(info, contex) { }
    }
}
