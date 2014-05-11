using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BJ.MongoDB.Logger;
using MongoDB.Bson;

namespace BJ.MongoDB.WebUI.Models
{
    public class LogItemViewModel
    {
        #region Fields

        private readonly LogItem _item;

        #endregion

        #region Constructors

        public LogItemViewModel(LogItem item)
        {
            this._item = item;

            SetStacktrace();
            SetException();
            SetProperties();
        }

        #endregion

        #region Properties

        public LogItem Item
        {
            get { return _item; }
        }

        public string Stacktrace { get; private set; }

        public string Exception { get; private set; }

        public Dictionary<string, string> Properties { get; private set; }

        #endregion

        #region Private methods

        private void SetStacktrace()
        {
            var result = String.Empty;

            foreach (var elem in _item.properties.Elements)
            {
                if (elem.Name == Const.Stacktrace)
                {
                    result = elem.Value.ToString();
                    break;
                }
            }

            Stacktrace = result;
        }

        private void SetException()
        {
            BsonDocument doc = _item.exception;
            var sb = new StringBuilder();
            string tab = String.Empty;

            //var stackTrace2 = doc.GetValue("2222").AsString;
            do
            {
                var message = doc.GetValue("message", String.Empty).AsString;
                var source = doc.GetValue("source", String.Empty).AsString;
                var stackTrace = doc.GetValue("stackTrace", String.Empty).AsString;

                sb.AppendFormat("{1}message:\t {0}{2}", message, tab, Environment.NewLine);
                sb.AppendFormat("{1}source:\t {0}{2}", source, tab, Environment.NewLine);
                sb.AppendFormat("{1}stackTrace:\t {0}{2}", stackTrace, tab, Environment.NewLine);

                if (doc.Contains("innerException"))
                {
                    sb.AppendFormat("{0}innerException:{1}", tab, Environment.NewLine);
                    var innerException = doc.GetElement("innerException").Value.AsBsonDocument;
                    doc = innerException;
                    tab += "\t";
                }
                else
                {
                    break;
                }

            }
            while (true);

            Exception = sb.ToString();
        }

        private void SetProperties()
        {
            var result = _item.properties.Elements.ToDictionary(elem => elem.Name, elem => elem.Value.ToString());

            Properties = result;
        }

        #endregion
    }
}