using System.Collections.Generic;
using BJ.MongoDB.Logger;
using BJ.MongoDB.WebUI.Models;
using MongoDB.Bson;

namespace BJ.MongoDB.WebUI.Classes
{
    /// <summary>
    /// Служба журнала сообщений
    /// </summary>
    public interface ILogService
    {
        /// <summary>
        /// Получить общее количество сообщений
        /// </summary>
        /// <returns></returns>
        long CountLogs();

        /// <summary>
        /// Получение наименований уникальных приложений в хранилище
        /// </summary>
        /// <returns>Списко имен приложений</returns>
        IEnumerable<string> GetAppsName();

        /// <summary>
        /// Получение наименований уникальных приложений в хранилище и кол-во их записей
        /// </summary>
        /// <returns>Словарь приложений и кол-ва записей</returns>
        IDictionary<string, string> GetAppsNameWithCount();

        /// <summary>
        /// Получение наименований уникальных OC в хранилище
        /// </summary>
        /// <returns>Списко имен приложений</returns>
        IList<string> GetOSName();

        /// <summary>
        /// Получение статистики по уровням сообщений
        /// </summary>
        /// <returns>Статистика по уровням</returns>
        StatLevel GetStatLevel();

        /// <summary>
        /// Получение статистики по приложениям
        /// </summary>
        /// <param name="app">Приложение</param>
        /// <returns>Статистика по приложению</returns>
        StatAppItem GetStatApp(string app);

        /// <summary>
        /// Получение статистики по ОС (операционным системам)
        /// </summary>
        /// <returns>Cтатистики по ОС</returns>
        StatOS GetStatOS();

        /// <summary>
        /// Получение статистики по времени
        /// </summary>
        /// <returns></returns>
        void GetStatTime();

        /// <summary>
        /// Получение журнала сообщений
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        LogViewModel GetLogs(LogViewFilters filters);

        /// <summary>
        /// Поиск записи журнала по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор записи журнала</param>
        /// <returns>Запись журнала</returns>
        /// <exception cref="LoggerReadException">Ошибка чтения из базы</exception>
        LogItem Find(string id);
    }
}