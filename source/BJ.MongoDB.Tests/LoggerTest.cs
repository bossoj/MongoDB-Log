using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MongoDB.Bson;

using BJ.MongoDB.Logger;


namespace BJ.MongoDB.Tests
{
    [TestClass]
    public class LoggerTest
    {
        private string connectionString = "mongodb://read:read@localhost:27017/local?safe=true";
        private string collection = "LogsTest";

        Logger.ILogger logger;

        //======================================================================================
        
        [TestInitialize]
        public void TestInitialize()
        {
            logger = new Logger.Logger(connectionString, collection);
            logger.RemoveAll();
        }

        [TestCleanup]
        public void TestCleanup()
        {            
            logger.RemoveAll();
        }

        //======================================================================================

        [ClassInitialize]
        static public void ClassInitialize(TestContext context)
        {
        }

        [ClassCleanup]
        static public void ClassCleanup()
        {
        }

        //======================================================================================

        [TestMethod]
        public void Test_write()
        {
            // arrange
            string message = "Test message";

            // act
            var target = logger.Info(message);
            var logItem = logger.GetAll().FirstOrDefault();

            // assert
            Assert.IsTrue(target, "Logger has not write message");
            Assert.AreEqual(1, logger.Count(), "Count items not equal");
            Assert.AreEqual(message, logItem.message, "Messages not equal");
            Assert.AreEqual(1, logger.GetAll().Count(), "Logs count not equal");
        }

        [TestMethod]
        public void Test_level()
        {
            // arrange
            string messageDebug = "Test message Debug";
            string messageInfo = "Test message Info";
            string messageWarn = "Test message Warn";
            string messageError = "Test message Error";
            string messageFatal = "Test message Fatal";

            // act
            logger.Debug(messageDebug);
            logger.Info(messageInfo);
            logger.Warn(messageWarn);
            logger.Error(messageError);
            logger.Fatal(messageFatal);

            var logItemDebug = logger.Get(x => x.message == messageDebug).FirstOrDefault();
            var logItemInfo = logger.Get(x => x.message == messageInfo).FirstOrDefault();
            var logItemWarn = logger.Get(x => x.message == messageWarn).FirstOrDefault();
            var logItemError = logger.Get(x => x.message == messageError).FirstOrDefault();
            var logItemFatal = logger.Get(x => x.message == messageFatal).FirstOrDefault();

            // assert
            Assert.IsNotNull(logItemDebug, "Not found Debug message");
            Assert.IsNotNull(logItemInfo, "Not found Info message");
            Assert.IsNotNull(logItemWarn, "Not found Warn message");
            Assert.IsNotNull(logItemError, "Not found Error message");
            Assert.IsNotNull(logItemFatal, "Not found Fatal message");
        }

        [TestMethod]
        public void Test_base_information()
        {
            // arrange
            string message = "Test message";

            // act
            logger.Info(message);
            var logItem = logger.GetAll().FirstOrDefault();

            // assert
            Assert.IsInstanceOfType(logItem.timestamp, typeof(BsonDateTime), "timestamp is not type BsonDateTime");
            Assert.AreEqual(Thread.CurrentThread.Name, logItem.thread, "threadName not equal");
            Assert.AreEqual(WindowsIdentity.GetCurrent().Name, logItem.userName, "userName not equal");
            Assert.AreEqual("Logger", logItem.loggerName, "loggerName not equal");
            Assert.AreEqual(AppDomain.CurrentDomain.FriendlyName, logItem.domain, "domain not equal");
            Assert.AreEqual(Environment.MachineName, logItem.machineName, "machineName not equal");
            Assert.AreEqual(message, logItem.message, "message not equal");
        }

        [TestMethod]
        public void Test_location_information()
        {
            // arrange
            string message = "Test message";

            // act
            logger.Info(message);
            var logItem = logger.GetAll().FirstOrDefault();

            // assert
            Assert.AreEqual(new StackFrame(0, true).GetFileName(), logItem.fileName, "fileName not equal");
            Assert.AreEqual(new StackFrame(0, true).GetMethod().Name, logItem.method, "method not equal");
            Assert.AreEqual(String.Format("{0}.{1}", new StackFrame(0, true).GetMethod().ReflectedType.Namespace, 
                new StackFrame(0, true).GetMethod().ReflectedType.Name), logItem.className, "className not equal");
        }

        [TestMethod]
        public void Test_exception()
        {
            // arrange
            var ex = new Exception("Something wrong happened", new Exception("I'm the inner"));

            // act
            var target = logger.Error("I'm sorry", ex);
            var logItem = logger.GetAll().FirstOrDefault();
            var exception = logItem.exception as BsonDocument;
            var innerException = exception["innerException"] as BsonDocument;

            // assert
            Assert.IsTrue(target, "Logger has not write message");

            Assert.AreEqual("ERROR", logItem.level, "Level not equal");
            Assert.IsInstanceOfType(exception, typeof(BsonDocument), "exception is not type BsonDocument");

            Assert.IsNotNull(exception, "LogItem does not contain expected exception");
            Assert.AreEqual("Something wrong happened", exception["message"].AsString, "Exception message not equal");

            Assert.AreEqual(String.Empty, exception["source"].AsString, "Exception source not equal");
            Assert.AreEqual(String.Empty, exception["stackTrace"].AsString, "Exception stackTrace not equal");

            Assert.IsNotNull(innerException, "LogItem does not contain expected inner exception");
            Assert.AreEqual("I'm the inner", innerException["message"].AsString, "Inner exception message not equal");
        }

        [TestMethod]
        public void Test_local_properties()
        {
            // arrange
            string message = "Test message";
            Properties prop = new Properties("Local property", "Local value");

            // act
            var target = logger.Info(message, properties: prop);
            var logItem = logger.GetAll().FirstOrDefault();
            var result = logItem.properties;

            // assert
            Assert.IsTrue(target, "Logger has not write message");
            Assert.IsInstanceOfType(result, typeof(BsonDocument), "properties is not type BsonDocument");
            Assert.AreEqual("Local value", result["Local property"].AsString, "property not equal");
            Assert.AreEqual(1, result.Count(), "property count not equal");
        }

        [TestMethod]
        public void Test_global_properties()
        {
            // arrange
            string message = "Test message";
            logger.Properties.Add("Global property", "Global value");

            // act
            var target = logger.Info(message);
            var logItem = logger.GetAll().FirstOrDefault();
            var result = logItem.properties;

            // assert
            Assert.IsTrue(target, "Logger has not write message");
            Assert.IsInstanceOfType(result, typeof(BsonDocument), "properties is not type BsonDocument");
            Assert.AreEqual("Global value", result["Global property"].AsString, "property not equal");
            Assert.AreEqual(1, result.Count(), "property count not equal");
        }

        [TestMethod]
        public void Test_multiple_events()
        {
            // arrange
            const int numberOfEvents = 10;

            // act
            for (var i = 0; i < numberOfEvents; ++i)
                logger.Info(i.ToString());

            // assert
            Assert.AreEqual(numberOfEvents, logger.Count(), "Count items not equal");
        }

        //[TestMethod]
        //public void GenerateLogs()
        //{
        //    string connectionString = "mongodb://read:read@localhost:27017/local?safe=true";
        //    string collection = "Logs2";

        //    Logger.ILogger logger = new Logger.Logger(connectionString, collection);

        //    logger.Properties.Add(Const.OperatingSystem, Environment.OSVersion.VersionString);
        //    logger.Properties.Add("OS", "Windows 8");

        //    for (int i = 0; i < 5; i++)
        //    {
        //        var ex = new Exception("Something wrong happened", new Exception("I'm the inner", new Exception("I'm the two inner")));
        //        Properties prop = new Properties(Const.Stacktrace, "true - Enable display of chance to win");
        //        var target = logger.Error("I'm sorry" + i.ToString(), ex, prop);
        //    }
        //}
    }
}
