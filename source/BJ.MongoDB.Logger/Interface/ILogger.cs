using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using MongoDB.Bson;


namespace BJ.MongoDB.Logger
{
    public interface ILogger
    {
        #region Properties

        /// <summary>
        /// Глобальные свойства
        /// </summary>
        Properties Properties { get; }

        #endregion

        #region Write Methods

        bool Debug(string message, Exception exception = null, Properties properties = null);
        bool Info(string message, Exception exception = null, Properties properties = null);
        bool Warn(string message, Exception exception = null, Properties properties = null);
        bool Error(string message, Exception exception = null, Properties properties = null);
        bool Fatal(string message, Exception exception = null, Properties properties = null);

        #endregion

        #region Read Methods

        /// <summary>
        /// Получить все записи журнала
        /// </summary>
        /// <returns>Записи журнала</returns>
        /// <exception cref="LoggerReadException">Ошибка чтения из базы</exception>
        IEnumerable<LogItem> GetAll();

        /// <summary>
        /// Поиск записи журнала по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор записи журнала</param>
        /// <returns>Запись журнала</returns>
        /// <exception cref="LoggerReadException">Ошибка чтения из базы</exception>
        LogItem Find(ObjectId id);
        
        /// <summary>
        /// Получить записи журнала по фильтру
        /// </summary>
        /// <param name="filter">Условия поиска</param>
        /// <param name="orderBy">Условия сортировки</param>
        /// <returns>Записи журнала</returns>
        /// <exception cref="LoggerReadException">Ошибка чтения из базы</exception>
        IEnumerable<LogItem> Get(Expression<Func<LogItem, bool>> filter, Func<IQueryable<LogItem>, IOrderedQueryable<LogItem>> orderBy = null);

        /// <summary>
        /// Получить записи журнала по фильтру
        /// </summary>
        /// <param name="filters">Условия поиска</param>
        /// <param name="orderBy">Условия сортировки</param>
        /// <returns>Записи журнала</returns>
        /// <exception cref="LoggerReadException">Ошибка чтения из базы</exception>
        IEnumerable<LogItem> Get(List<Expression<Func<LogItem, bool>>> filters, Func<IQueryable<LogItem>, IOrderedQueryable<LogItem>> orderBy = null);

        #endregion

        #region Delete Methods

        /// <summary>
        /// Удалить запись журнала
        /// </summary>
        /// <param name="id">Идентификатор записи журнала</param>
        /// <returns>Результат удаления</returns>
        /// <exception cref="LoggerDeleteException">Ошибка удаления из базы</exception>
        bool Remove(ObjectId id);
        
        /// <summary>
        /// Удалить запись журнала
        /// </summary>
        /// <param name="item">Запись журнала</param>
        /// <returns>Результат удаления</returns>
        /// <exception cref="LoggerDeleteException">Ошибка удаления из базы</exception>
        bool Remove(LogItem item);
        
        /// <summary>
        /// Удалить все записи журнала
        /// </summary>
        /// <returns>Результат удаления</returns>
        /// <exception cref="LoggerDeleteException">Ошибка удаления из базы</exception>
        bool RemoveAll();

        #endregion

        #region Other Methods

        /// <summary>
        /// Получить кол-во записей журнала 
        /// </summary>
        /// <returns>Кол-во записей журнала</returns>
        long Count();

        /// <summary>
        /// Получить кол-во записей журнала по фильтру
        /// </summary>
        /// <param name="filter">Условия поиска</param>
        /// <returns>Кол-во записей журнала</returns>
        long Count(Expression<Func<LogItem, bool>> filter);

        /// <summary>
        /// Получить список уникальных объектов
        /// </summary>
        /// <param name="filter">Свойство записи журнала</param>
        /// <returns>Список уникальных объектов</returns>
        /// <exception cref="LoggerReadException">Ошибка чтения из базы</exception>
        IEnumerable<string> Distinct(Expression<Func<LogItem, string>> filter);

        #endregion
    }
}
