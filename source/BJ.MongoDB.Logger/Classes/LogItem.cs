using MongoDB.Bson;

namespace BJ.MongoDB.Logger
{
    /// <summary>
    /// Запись журнала
    /// </summary>
    public class LogItem
    {
        public ObjectId Id { get; set; }
        public BsonDateTime timestamp { get; set; }
        public string level { get; set; }
        public string thread { get; set; }
        public string userName { get; set; }
        public string message { get; set; }
        public string loggerName { get; set; }
        public string domain { get; set; }
        public string machineName { get; set; }
        public string fileName { get; set; }
        public string method { get; set; }
        public string lineNumber { get; set; }
        public string className { get; set; }
        public BsonDocument exception { get; set; }
        public BsonDocument properties { get; set; }

        public LogItem()
        {
            exception = new BsonDocument();
            properties = new BsonDocument();
        }
    }
}
