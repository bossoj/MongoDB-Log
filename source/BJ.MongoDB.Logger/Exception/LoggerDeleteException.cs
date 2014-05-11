using System;

namespace BJ.MongoDB.Logger
{
    [Serializable]
    public class LoggerDeleteException: ApplicationException
    {
        public LoggerDeleteException() { }

        public LoggerDeleteException(string message) : base(message) { }

        public LoggerDeleteException(string message, Exception inner) : base(message, inner) { }

        protected LoggerDeleteException(System.Runtime.Serialization.SerializationInfo info,
                                   System.Runtime.Serialization.StreamingContext contex)
            : base(info, contex) { }            
    }
}

