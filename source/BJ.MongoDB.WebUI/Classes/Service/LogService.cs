using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

using MongoDB.Bson;

using BJ.MongoDB.Logger;
using BJ.MongoDB.WebUI.Models;


namespace BJ.MongoDB.WebUI.Classes
{
    /// <summary>
    /// Служба журнала сообщений
    /// </summary>
    public class LogService : ILogService
    {
        #region Fields

        private readonly ILogger _logger;

        #endregion

        #region Constructors

        public LogService(ILogger logger)
        {
            if (logger == null)
                throw new ArgumentNullException("logger");

            this._logger = logger;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Получить общее количество сообщений
        /// </summary>
        /// <returns></returns>
        public long CountLogs()
        {
            return _logger.Count();
        }

        /// <summary>
        /// Получение наименований уникальных приложений в хранилище
        /// </summary>
        /// <returns>Списко имен приложений</returns>
        public IEnumerable<string> GetAppsName()
        {
            var apps = _logger.Distinct(x => x.domain);

            var result = new List<string>();
            result.Add(String.Empty);
            result.AddRange(apps);

            return result;
        }

        //----------------------------------------------------------------------------------------

        /// <summary>
        /// Получение наименований уникальных приложений в хранилище и кол-во их записей
        /// </summary>
        /// <returns>Словарь приложений и кол-ва записей</returns>
        public IDictionary<string, string> GetAppsNameWithCount()
        {
            var apps = _logger.Distinct(x => x.domain);

            var result = new Dictionary<string, string>();
            foreach (string nameApp in apps)
            {
                string countLog = _logger.Count(x => x.domain == nameApp).ToString(CultureInfo.InvariantCulture);
                result.Add(nameApp, countLog);
            }

            return result;
        }

        //----------------------------------------------------------------------------------------


        /// <summary>
        /// Получение наименований уникальных OC в хранилище
        /// </summary>
        /// <returns>Списко имен приложений</returns>
        public IList<string> GetOSName()
        {
            //var OSs = _logger.Distinct(x => x.domain);
            
            //var result = new List<string>();
            //result.Add(String.Empty);
            //foreach (var nameApp in Logs)
            //    result.Add(nameApp);


            //foreach (var elem in item.properties.Elements)
            //{
            //    if (elem.Name == Const.Stacktrace)
            //    {
            //        result = elem.Value.ToString();
            //        break;
            //    }
            //}

            return new List<string>();
        }

        //----------------------------------------------------------------------------------------

        /// <summary>
        /// Получение статистики по уровням сообщений
        /// </summary>
        /// <returns>Статистика по уровням</returns>
        public StatLevel GetStatLevel()
        {
            var apps = _logger.Distinct(x => x.domain);

            var result = new StatLevel();
            foreach (var nameApp in apps)
            {
                string app = nameApp;
                result.Result.Add(new StatLevelItem
                {
                    AppName = app,
                    Debug = _logger.Count(x => x.domain == app && x.level == LevelType.DEBUG),
                    Info = _logger.Count(x => x.domain == app && x.level == LevelType.INFO),
                    Warn = _logger.Count(x => x.domain == app && x.level == LevelType.WARN),
                    Error = _logger.Count(x => x.domain == app && x.level == LevelType.ERROR),
                    Fatal = _logger.Count(x => x.domain == app && x.level == LevelType.FATAL),
                    Total = _logger.Count(x => x.domain == app)
                });
            }

            result.Result.Add(new StatLevelItem
            {
                AppName = "Итого",
                Debug = result.Result.Sum(x => x.Debug),
                Info = result.Result.Sum(x => x.Info),
                Warn = result.Result.Sum(x => x.Warn),
                Error = result.Result.Sum(x => x.Error),
                Fatal = result.Result.Sum(x => x.Fatal),
                Total = result.Result.Sum(x => x.Total)
            });

            return result;
        }

        //------------------------------------------------------------------------------------------

        /// <summary>
        /// Получение статистики по приложениям
        /// </summary>
        /// <param name="app">Приложение</param>
        /// <returns>Статистика по приложению</returns>
        public StatAppItem GetStatApp(string app)
        {
            var total = _logger.Count(x => x.domain == app);
            var debug = _logger.Count(x => x.domain == app && x.level == LevelType.DEBUG);
            var info = _logger.Count(x => x.domain == app && x.level == LevelType.INFO);
            var warn = _logger.Count(x => x.domain == app && x.level == LevelType.WARN);
            var error = _logger.Count(x => x.domain == app && x.level == LevelType.ERROR);
            var fatal = _logger.Count(x => x.domain == app && x.level == LevelType.FATAL);

            var result = new StatAppItem
            {
                AppName = app,
                Debug = debug,
                Info = info,
                Warn = warn,
                Error = error,
                Fatal = fatal,
                DebugPct = debug * 100 / total,
                InfoPct = info * 100 / total,
                WarnPct = warn * 100 / total,
                ErrorPct = error * 100 / total,
                FatalPct = fatal * 100 / total
            };

            return result;
        }

        //----------------------------------------------------------------------------------------

        /// <summary>
        /// Получение статистики по ОС (операционным системам)
        /// </summary>
        /// <returns>Cтатистики по ОС</returns>
        public StatOS GetStatOS()
        {
            //var Logs = logger.GetAll().Select(x => x.properties.Contains(Const.OperatingSystem)).Distinct().ToList();

            //var result = new StatOS();
            //foreach (var nameApp in Logs)
            //{
            //    result.Result.Add(new StatOSItem
            //    {
            //        OSName = nameApp,
            //        Debug = logger.Where(x => x.domain == nameApp && x.level == LevelType.DEBUG).Count(),
            //        Info = logger.Where(x => x.domain == nameApp && x.level == LevelType.INFO).Count(),
            //        Warn = logger.Where(x => x.domain == nameApp && x.level == LevelType.WARN).Count(),
            //        Error = logger.Where(x => x.domain == nameApp && x.level == LevelType.ERROR).Count(),
            //        Fatal = logger.Where(x => x.domain == nameApp && x.level == LevelType.FATAL).Count(),
            //        Total = logger.Where(x => x.domain == nameApp).Count()
            //    });
            //}

            //result.Result.Add(new StatOSItem
            //{
            //    OSName = "Unknown",
            //    Debug = result.Result.Sum(x => x.Debug),
            //    Info = result.Result.Sum(x => x.Info),
            //    Warn = result.Result.Sum(x => x.Warn),
            //    Error = result.Result.Sum(x => x.Error),
            //    Fatal = result.Result.Sum(x => x.Fatal),
            //    Total = result.Result.Sum(x => x.Total)
            //});

            return new StatOS();
        }

        //----------------------------------------------------------------------------------------

        /// <summary>
        /// Получение статистики по времени
        /// </summary>
        /// <returns></returns>
        public void GetStatTime()
        {
        }

        //----------------------------------------------------------------------------------------

        /// <summary>
        /// Получение журнала сообщений
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public LogViewModel GetLogs(LogViewFilters filters)
        {
            var filter = new List<Expression<Func<LogItem, bool>>>();

            // получаем даты из класса фильтра
            DateTime? dateFrom = filters.ToDate(filters.DateFrom);
            DateTime? dateTo = filters.ToDate(filters.DateTo);

            // фильтрация по приложению
            if (!String.IsNullOrWhiteSpace(filters.App))
                filter.Add(c => c.domain == filters.App);

            // фильтрация по начальной дате
            if (dateFrom.HasValue)
                filter.Add(c => c.timestamp >= new BsonDateTime(dateFrom.Value));

            // фильтрация по конечной дате
            if (dateTo.HasValue)
                filter.Add(c => c.timestamp < new BsonDateTime(dateTo.Value.AddDays(1)));

            // фильтрация по уровню сообщений
            if (filters.Level != null && filters.Level.Count > 0)
                filter.Add(c => filters.Level.Contains(c.level));

            // фильтрация тексту 
            // TODO подумать по каким полям искать
            if (!String.IsNullOrWhiteSpace(filters.SearchStr))
            {
                List<string> listSearch = filters.SearchStr.Split(',').Select(x => x.Trim().ToUpper()).ToList();

                foreach (string strSearch in listSearch)
                {
                    string str = strSearch;
                    filter.Add((s => s.userName.ToUpper().Contains(str)
                                     || s.loggerName.ToUpper().Contains(str)
                                     || s.machineName.ToUpper().Contains(str)
                                     || s.className.ToUpper().Contains(str)
                                     || s.method.ToUpper().Contains(str)
                                     || s.fileName.ToUpper().Contains(str)
                                     || s.domain.ToUpper().Contains(str)
                                     || s.message.ToUpper().Contains(str)));
                }
            }

            // сортировка
            Func<IQueryable<LogItem>, IOrderedQueryable<LogItem>> orderBy = item => item.OrderByDescending(x => x.timestamp);

            if (filters.HasOrderBy)
            {
                switch (filters.OrderByColumn.ToLower())
                {
                    case "datetime":
                        if (filters.OrderByDescending != null && filters.OrderByDescending.Value)
                            orderBy = item => item.OrderByDescending(x => x.timestamp);
                        else
                            orderBy = item => item.OrderBy(x => x.timestamp);
                        break;

                    case "level":
                        if (filters.OrderByDescending != null && filters.OrderByDescending.Value)
                            orderBy = item => item.OrderByDescending(x => x.level);
                        else
                            orderBy = item => item.OrderBy(x => x.level);
                        break;

                    case "app":
                        if (filters.OrderByDescending != null && filters.OrderByDescending.Value)
                            orderBy = item => item.OrderByDescending(x => x.domain);
                        else
                            orderBy = item => item.OrderBy(x => x.domain);
                        break;

                    case "thread":
                        if (filters.OrderByDescending != null && filters.OrderByDescending.Value)
                            orderBy = item => item.OrderByDescending(x => x.thread);
                        else
                            orderBy = item => item.OrderBy(x => x.thread);
                        break;

                    case "logger":
                        if (filters.OrderByDescending != null && filters.OrderByDescending.Value)
                            orderBy = item => item.OrderByDescending(x => x.loggerName);
                        else
                            orderBy = item => item.OrderBy(x => x.loggerName);
                        break;

                    case "user":
                        if (filters.OrderByDescending != null && filters.OrderByDescending.Value)
                            orderBy = item => item.OrderByDescending(x => x.userName);
                        else
                            orderBy = item => item.OrderBy(x => x.userName);
                        break;

                    case "machine":
                        if (filters.OrderByDescending != null && filters.OrderByDescending.Value)
                            orderBy = item => item.OrderByDescending(x => x.machineName);
                        else
                            orderBy = item => item.OrderBy(x => x.machineName);
                        break;
                }
            }

            var query = _logger.Get(filter, orderBy);

            return new LogViewModel(filters, query);
        }

        public LogItem Find(string id)
        {
            try
            {
                var Id = new ObjectId(id);
                return _logger.Find(Id);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //string str = String.Format("Не верный ID сообщения журнала. {0}", ex.Message);
                //throw new LoggerReadException(str, ex);
                return null;
            }
        }

        #endregion
    }
}