using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using BJ.MongoDB.Logger;
using BJ.MongoDB.WebUI.Properties;

namespace BJ.MongoDB.WebUI.Models
{
    public class LogViewModel
    {
        private readonly IPagedList<LogItem> _entries;
        private readonly LogViewFilters _filters;

        public LogViewModel(LogViewFilters filters, IEnumerable<LogItem> entries)
        {
            _filters = filters;
            _entries = entries.ToPagedList(filters.PageInt, Settings.Default.pageSize);
        }

        public IPagedList<LogItem> Entries
        {
            get { return _entries; }
        }

        public LogViewFilters Filters
        {
            get { return _filters; }
        }
    }

    public class LogViewFilters
    {
        public LogViewFilters()
        {
            Level = new List<string>();
        }

        #region Properties

        public int? Page { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string SearchStr { get; set; }
        public string OrderBy { get; set; }
        public string App { get; set; }
        public List<string> Level { get; set; }

        #endregion

        public int PageInt
        {
            get 
            {
                return Page.HasValue ? Math.Max(Page.Value, 1) : 1; 
            }
        }

        public bool HasOrderBy
        {
            get
            {
                return !String.IsNullOrWhiteSpace(OrderBy);
            }
        }

        public bool? OrderByDescending
        {
            get
            {
                return (OrderBy.EndsWith("Desc"));
            }
        }

        public string OrderByColumn
        {
            get
            {
                if (OrderByDescending.HasValue)
                    return (OrderByDescending.Value ? OrderBy.Remove(OrderBy.Length - 4) : OrderBy);

                return String.Empty;
            }
        }

        public string OrderQuery
        {
            get
            {
                if (!HasOrderBy)
                    return String.Empty;

                string field = OrderByColumn;

                if (OrderByDescending != null && OrderByDescending.Value)
                    field += " desc";

                return field;
            }
        }

        public string GetColumnClass(string column)
        {
            if (OrderBy == null)
                return string.Empty;

            bool desc = OrderBy.EndsWith("Desc");
            string name = desc ? OrderBy.Remove(OrderBy.Length - 4) : OrderBy;

            if (name != column)
                return string.Empty;

            return desc ? "sort_desc" : "sort_asc";
        }

        public LogViewFilters SetPage(int page)
        {
            var result = (LogViewFilters)MemberwiseClone();
            result.Page = page;
            return result;
        }

        public LogViewFilters SetOrderBy(string orderBy)
        {
            var result = (LogViewFilters)MemberwiseClone();
            if (result.OrderBy != orderBy)
                result.OrderBy = orderBy;
            else
                result.OrderBy = orderBy + "Desc";
            return result;
        }

        public DateTime? ToDate(string value)
        {
            DateTime? result = null;
            DateTime date;
            if (DateTime.TryParse(value, out date))
                result = new DateTime?(date);
            return result;
        }
    }
}