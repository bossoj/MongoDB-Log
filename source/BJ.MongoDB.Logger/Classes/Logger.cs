using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Threading;
using System.Collections.Generic;
using System.Globalization;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;


namespace BJ.MongoDB.Logger
{
    /// <summary>
    /// Using format log4net Appender into MongoDB database
    /// Format of log event (for exception):
    /// <code>
    /// { 
    ///     "timestamp" : "Wed Apr 28 2010 00:01:41 GMT+0200 (Central Europe Daylight Time)",
    ///     "level": "ERROR", 
    ///     "thread": "7", 
    ///     "userName": "jsk", 
    ///     "message": "I'm sorry", 
    ///     "loggerName": "log4net_MongoDB.Tests.MongoDBAppenderTests",
    ///     "fileName": "C:\jsk\work\opensource\log4mongo-net\src\log4mongo-net.Tests\MongoDBAppenderTests.cs", 
    ///     "method": "TestException", 
    ///     "lineNumber": "102", 
    ///     "className": "log4mongo_net.Tests.MongoDBAppenderTests", 
    ///     "exception": { 
    ///                     "message": "Something wrong happened", 
    ///                     "source": null, 
    ///                     "stackTrace": null, 
    ///                     "innerException": { 
    ///                                         "message": "I'm the inner", 
    ///                                         "source": null, 
    ///                                         "stackTrace": null 
    ///                                       } 
    ///                  },
    ///     "properties": {
    ///                     "name1": "value1",
    ///                     "name2": "value2",
    ///                     "name3": "value3"
    ///                   }
    /// }
    /// </code>
    /// </summary>
    public class Logger : ILogger
    {
        #region Fields

        private string _connectionString = string.Empty;
        private string _collection = "Logs";

        private Properties _properties;

        #endregion
        

        #region Constructors

        public Logger(string connectionString = null, string collection = null)
        {
            if (connectionString != null)
                _connectionString = connectionString;

            if (collection != null) 
                _collection = collection;
        }

        #endregion
  

        #region Properties

        /// <summary>
        /// MongoDB database connection in the format:
        /// mongodb://[username:password@]host1[:port1][,host2[:port2],...[,hostN[:portN]]][/[database][?options]]
        /// See http://www.mongodb.org/display/DOCS/Connections
        /// </summary>
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        /// <summary>
        /// MongoDB database collection 
        /// If no collection specified, default to "Logs"
        /// </summary>
        protected string Collection
        {
            get { return _collection; }
            set { _collection = value; }
        }

        protected MongoCollection<LogItem> LogsCollection
        {
            get
            {
                return GetDatabase().GetCollection<LogItem>(Collection);
            }
        }

        /// <summary>
        /// Global Properties
        /// </summary>
        public Properties Properties
        {
            get { return _properties ?? (_properties = new Properties()); }
        }

        #endregion


        #region Private methods

        private MongoDatabase GetDatabase()
        {
            try
            {
                MongoUrl url = MongoUrl.Create(ConnectionString);
                MongoClient client = new MongoClient(url);
                MongoServer server = client.GetServer();
                MongoDatabase db = server.GetDatabase(url.DatabaseName);

                return db;
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                string str = String.Format("Ошибка подключения к базе. {0}", ex.Message);
                throw new LoggerConnectionException(str, ex);
            }
            catch (MongoConnectionException ex)
            {
                string str = String.Format("Ошибка подключения к базе. {0}", ex.Message);
                throw new LoggerConnectionException(str, ex);
            }
            catch (MongoCommandException ex)
            {
                string str = String.Format("Не верная строка подключения к базе. {0}", ex.Message);
                throw new LoggerConnectionException(str, ex);
            }
        }

        private static BsonDocument BuildExceptionBsonDocument(Exception ex)
        {
            var result = new BsonDocument {
				{"message", ex.Message ?? String.Empty}, 
				{"source", ex.Source ?? String.Empty}, 
				{"stackTrace", ex.StackTrace ?? String.Empty}
			};

            if (ex.InnerException != null)
            {
                result.Add("innerException", BuildExceptionBsonDocument(ex.InnerException));
            }

            return result;
        }

        private static BsonDocument BuildPropertiesBsonDocument(Properties props, Properties globProps)
        {            
            var result = new BsonDocument();

            if (globProps != null)
                result.AddRange(globProps.PropsDictionary);

            if (props != null)
                result.AddRange(props.PropsDictionary);

            return result;
        }

        #endregion
      

        #region Write Methods

        protected bool Write(string message, string level, Exception exception, Properties properties)
        {
            try
            {
                var userName = WindowsIdentity.GetCurrent() != null ? WindowsIdentity.GetCurrent().Name : String.Empty;
                var reflectedType = new StackFrame(2, true).GetMethod().ReflectedType;
                string classNamespace = reflectedType != null ? reflectedType.Namespace : String.Empty;
                string className = reflectedType != null ? reflectedType.Name : String.Empty;

                var log = new LogItem
                {
                    timestamp = new BsonDateTime(DateTime.Now),
                    level = level,
                    thread = Thread.CurrentThread.Name,
                    userName = userName,
                    message = message,
                    loggerName = GetType().Name,
                    domain = AppDomain.CurrentDomain.FriendlyName, 
                    machineName = Environment.MachineName,
                    fileName = new StackFrame(2, true).GetFileName(),
                    method = new StackFrame(2, true).GetMethod().Name,
                    lineNumber = new StackFrame(2, true).GetFileLineNumber().ToString(CultureInfo.InvariantCulture),
                    className = String.Format("{0}.{1}", classNamespace, className)
                };

                if (exception != null)                
                    log.exception = BuildExceptionBsonDocument(exception);

                log.properties = BuildPropertiesBsonDocument(properties, this.Properties);
                
                WriteConcernResult result = LogsCollection.Insert(log);

                return result.Ok;
                
            }
            catch (MongoException ex)
            {
                string str = String.Format("Ошибка записи в базу. {0}", ex.Message);
                throw new LoggerWriteException(str, ex);
            }
        }

        public bool Debug(string message, Exception exception = null, Properties properties = null)
        {
            return Write(message, LevelType.DEBUG, exception, properties);
        }

        public bool Info(string message, Exception exception = null, Properties properties = null)
        {
            return Write(message, LevelType.INFO, exception, properties);
        }

        public bool Warn(string message, Exception exception = null, Properties properties = null)
        {
            return Write(message, LevelType.WARN, exception, properties);
        }

        public bool Error(string message, Exception exception = null, Properties properties = null)
        {
            return Write(message, LevelType.ERROR, exception, properties);
        }

        public bool Fatal(string message, Exception exception = null, Properties properties = null)
        {
            return Write(message, LevelType.FATAL, exception, properties);
        }

        #endregion


        #region Read Methods

        public IEnumerable<LogItem> GetAll()
        {
            try
            {
                return LogsCollection.AsQueryable<LogItem>().ToList();
            }
            catch (MongoException ex)
            {
                string str = String.Format("Ошибка чтения из базы. {0}", ex.Message);
                throw new LoggerReadException(str, ex);
            }
        }

        public LogItem Find(ObjectId id)
        {
            try
            {
                return LogsCollection.AsQueryable<LogItem>().FirstOrDefault(c => c.Id == id);
            }
            catch (KeyNotFoundException ex)
            {
                string str = String.Format("Не верный формат сообщения журнала в хранилище ({0})", ex.Message);
                throw new LoggerReadException(str, ex);
            }
            catch (MongoException ex)
            {
                string str = String.Format("Ошибка чтения из базы. {0}", ex.Message);
                throw new LoggerReadException(str, ex);
            }
        }

        public IEnumerable<LogItem> Get(Expression<Func<LogItem, bool>> filter, Func<IQueryable<LogItem>, IOrderedQueryable<LogItem>> orderBy = null)
        {
            try
            {
                IQueryable<LogItem> query = LogsCollection.AsQueryable<LogItem>();

                query = query.Where(filter);

                if (orderBy != null)
                    return orderBy(query).ToList();

                return query.ToList();
            }
            catch (MongoException ex)
            {
                string str = String.Format("Ошибка чтения из базы. {0}", ex.Message);
                throw new LoggerReadException(str, ex);
            }
        }

        public IEnumerable<LogItem> Get(List<Expression<Func<LogItem, bool>>> filters, Func<IQueryable<LogItem>, IOrderedQueryable<LogItem>> orderBy = null)
        {
            try
            {
                IQueryable<LogItem> query = LogsCollection.AsQueryable<LogItem>();

                query = filters.Aggregate(query, (current, predicat) => current.Where(predicat));

                if (orderBy != null)
                    return orderBy(query).ToList();

                return query.ToList();
            }
            catch (MongoException ex)
            {
                string str = String.Format("Ошибка чтения из базы. {0}", ex.Message);
                throw new LoggerReadException(str, ex);
            }
        }

        #endregion


        #region Delete Methods

        public bool Remove(ObjectId id)
        {
            try
            {
                IMongoQuery query = Query.EQ("_id", id);
                WriteConcernResult result = LogsCollection.Remove(query);
 
                return result.DocumentsAffected == 1; 
            }
            catch (MongoException ex)
            {
                string str = String.Format("Ошибка удаления из базы. {0}", ex.Message);
                throw new LoggerDeleteException(str, ex);
            }
        }

        public bool Remove(LogItem item)
        {
            if (item == null) return false;

            try
            {
                IMongoQuery query = Query.EQ("_id", item.Id);
                WriteConcernResult result = LogsCollection.Remove(query);

                return result.DocumentsAffected == 1; 
            }
            catch (MongoException ex)
            {
                string str = String.Format("Ошибка удаления из базы. {0}", ex.Message);
                throw new LoggerDeleteException(str, ex);
            }
        }

        public bool RemoveAll()
        {
            try
            {
                WriteConcernResult result = LogsCollection.RemoveAll();

                return result.Ok; 
            }
            catch (MongoException ex)
            {
                string str = String.Format("Ошибка удаления из базы. {0}", ex.Message);
                throw new LoggerDeleteException(str, ex);
            }
        }

        #endregion

        #region Other Methods

        public long Count()
        {
            return LogsCollection.Count();
        }

        public long Count(Expression<Func<LogItem, bool>> filter)
        {
            return LogsCollection.AsQueryable<LogItem>().LongCount(filter);
        }

        public IEnumerable<string> Distinct(Expression<Func<LogItem, string>> filter)
        {
            try
            {
                return LogsCollection.AsQueryable<LogItem>().Select(filter).Distinct().ToList();

            }
            catch (MongoException ex)
            {
                string str = String.Format("Ошибка чтения из базы. {0}", ex.Message);
                throw new LoggerReadException(str, ex);
            }
        }

        #endregion
    }

}
