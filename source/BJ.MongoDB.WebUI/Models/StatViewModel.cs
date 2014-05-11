using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BJ.MongoDB.WebUI.Models
{
    public class StatViewModel
    {
        public SelectList AppsName { get; set; }
        public StatLevel StatLevel { get; set; }
        public StatAppItem StatApp { get; set; }
        public StatOS StatOS { get; set; }
    }

    public class StatLevelItem
    {
        public string AppName {get; set;}
        public long Debug { get; set; }
        public long Info { get; set; }
        public long Warn { get; set; }
        public long Error { get; set; }
        public long Fatal { get; set; }
        public long Total { get; set; }
    }

    //----------------------------------------------------------------------------------------

    public class StatLevel
    {
        private readonly List<StatLevelItem> _stat = new List<StatLevelItem>();

        public List<StatLevelItem> Result
        {
            get { return _stat; }
        }
    }

    //----------------------------------------------------------------------------------------

    public class StatAppItem
    {
        public string AppName { get; set; }
        public long Debug { get; set; }
        public long Info { get; set; }
        public long Warn { get; set; }
        public long Error { get; set; }
        public long Fatal { get; set; }
        public long DebugPct { get; set; }
        public long InfoPct { get; set; }
        public long WarnPct { get; set; }
        public long ErrorPct { get; set; }
        public long FatalPct { get; set; }
    }

    //----------------------------------------------------------------------------------------

    public class StatOSItem
    {
        public string OSName { get; set; }
        public long Debug { get; set; }
        public long Info { get; set; }
        public long Warn { get; set; }
        public long Error { get; set; }
        public long Fatal { get; set; }
        public long Total { get; set; }
    }

    //----------------------------------------------------------------------------------------

    public class StatOS
    {
        private readonly List<StatOSItem> _stat = new List<StatOSItem>();

        public List<StatOSItem> Result
        {
            get { return _stat; }
        }
    }

}