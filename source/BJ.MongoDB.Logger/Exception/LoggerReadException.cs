using System;

namespace BJ.MongoDB.Logger
{
    [Serializable]
    public class LoggerReadException: ApplicationException
    {
        public LoggerReadException() { }

        public LoggerReadException(string message) : base(message) { }

        public LoggerReadException(string message, Exception inner) : base(message, inner) { }

        protected LoggerReadException(System.Runtime.Serialization.SerializationInfo info,
                                   System.Runtime.Serialization.StreamingContext contex)
            : base(info, contex) { }            
    }
}
