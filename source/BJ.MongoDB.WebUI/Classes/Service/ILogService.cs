using System.Collections.Generic;
using BJ.MongoDB.Logger;
using BJ.MongoDB.WebUI.Models;
using MongoDB.Bson;

namespace BJ.MongoDB.WebUI.Classes
{
    /// <summary>
    /// ������ ������� ���������
    /// </summary>
    public interface ILogService
    {
        /// <summary>
        /// �������� ����� ���������� ���������
        /// </summary>
        /// <returns></returns>
        long CountLogs();

        /// <summary>
        /// ��������� ������������ ���������� ���������� � ���������
        /// </summary>
        /// <returns>������ ���� ����������</returns>
        IEnumerable<string> GetAppsName();

        /// <summary>
        /// ��������� ������������ ���������� ���������� � ��������� � ���-�� �� �������
        /// </summary>
        /// <returns>������� ���������� � ���-�� �������</returns>
        IDictionary<string, string> GetAppsNameWithCount();

        /// <summary>
        /// ��������� ������������ ���������� OC � ���������
        /// </summary>
        /// <returns>������ ���� ����������</returns>
        IList<string> GetOSName();

        /// <summary>
        /// ��������� ���������� �� ������� ���������
        /// </summary>
        /// <returns>���������� �� �������</returns>
        StatLevel GetStatLevel();

        /// <summary>
        /// ��������� ���������� �� �����������
        /// </summary>
        /// <param name="app">����������</param>
        /// <returns>���������� �� ����������</returns>
        StatAppItem GetStatApp(string app);

        /// <summary>
        /// ��������� ���������� �� �� (������������ ��������)
        /// </summary>
        /// <returns>C��������� �� ��</returns>
        StatOS GetStatOS();

        /// <summary>
        /// ��������� ���������� �� �������
        /// </summary>
        /// <returns></returns>
        void GetStatTime();

        /// <summary>
        /// ��������� ������� ���������
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        LogViewModel GetLogs(LogViewFilters filters);

        /// <summary>
        /// ����� ������ ������� �� ��������������
        /// </summary>
        /// <param name="id">������������� ������ �������</param>
        /// <returns>������ �������</returns>
        /// <exception cref="LoggerReadException">������ ������ �� ����</exception>
        LogItem Find(string id);
    }
}