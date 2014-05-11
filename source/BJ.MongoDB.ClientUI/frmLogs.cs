using BJ.MongoDB.ClientUI.Properties;
using BJ.MongoDB.Logger;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using KS.Lib.App.Dialogs;
using KS.Lib.Utils;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;


namespace BJ.MongoDB.ClientUI
{
    public partial class frmLogs : XtraForm
    {

        #region Fields

        private readonly string connectionString = Settings.Default.csMongoDB;
        private readonly string formatException = Settings.Default.FormatException;
        private readonly string collection = Settings.Default.Collection;

        private DateTime DateStart { get; set; }
        private List<string> levelList { get; set; }
        private List<string> domainList { get; set; }

        private DateTime _SelectedDateEnd;
        private DateTime _SelectedDateStart;

        private readonly PrintableComponentLink printableComponentLink = new PrintableComponentLink();

        #endregion

        #region Properties

        public DateTime SelectedDateStart
        {
            get
            {
                return _SelectedDateStart;
            }
            set
            {
                _SelectedDateStart = value;
                btnSelectedDateStart.Caption = value.ToString("dd.MM.yyyy");
            }
        }

        public DateTime SelectedDateEnd
        {
            get
            {
                return _SelectedDateEnd;
            }
            set
            {
                _SelectedDateEnd = value;
                btnSelectedDateEnd.Caption = value.ToString("dd.MM.yyyy");
            }
        }

        public LogItem SelectedLog
        {
            get { return gridView_Logs.GetFocusedRow() as LogItem; }
        }

        #endregion

        #region Domain
            
        /// <summary>
        /// Load data from DataBase
        /// </summary>
        public void LoadData()
        {
            try
            {
                var dbLog = new Logger.Logger(connectionString, collection);
                
                var queryLogs = dbLog.Get(c => levelList.Contains(c.level)
                                        && (c.timestamp < new BsonDateTime(SelectedDateEnd.AddDays(1)))
                                        && (c.timestamp >= new BsonDateTime(SelectedDateStart)));

                if (domainList.Count > 0)
                    queryLogs = queryLogs.Where(c => domainList.Contains(c.domain));

                gridControl_Logs.DataSource = queryLogs;                                    
            }
            catch (LoggerReadException ex)
            {
                MessageBox.Show(String.Format(formatException, ex.Message, ex.StackTrace),
                                "Error data access", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                      
        public frmLogs()
        {
            InitializeComponent();
        }

        private void frmLogs_Load(object sender, EventArgs e)
        {
            InitParam();

            InitDateTime();

            InitStatus();

            InitPrint();

            LoadData();
        }

        /// <summary>
        /// Initialization print component
        /// </summary>
        private void InitPrint()
        {
            printingSystem.Links.AddRange(new object[] { printableComponentLink });
            printableComponentLink.Component = gridControl_Logs;
            printableComponentLink.Landscape = true;
        }

        /// <summary>
        /// Initialization date
        /// </summary>
        private void InitDateTime()
        {
            SelectedDateEnd = DateTime.Now;
            SelectedDateStart = DateStart;
        }

        /// <summary>
        /// Update date
        /// </summary>
        private void UpdateDateTime()
        {
            SelectedDateEnd = DateTime.Now;
        }

        /// <summary>
        /// Initialization parameters
        /// </summary>
        private void InitParam()
        {
            try
            {
                levelList = Settings.Default.Level.Cast<string>().ToList<string>();
                domainList = Settings.Default.App.Cast<string>().ToList<string>();
                DateStart = DateTime.Now.AddDays(-Settings.Default.Day);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(String.Format(formatException, ex.Message, ex.StackTrace),
                                "Error initialization parameters", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            //TODO  -level ERROR,FATAL -app - lastday 7
        }

        /// <summary>
        /// Initialization status bar
        /// </summary>
        private void InitStatus()
        {
            siLevel.Caption = String.Join(", ", levelList.ToArray());

            if (domainList.Count == 0)
                siApp.Caption = "ALL";
            else
                siApp.Caption = String.Join(", ", domainList.ToArray());

            if (Settings.Default.Day == 0)
                siLastDay.Caption = "ALL";
            else
                siLastDay.Caption = Settings.Default.Day.ToString();

            this.Text += String.Format("  v{0}.{1}", Assembly.GetExecutingAssembly().GetName().Version.Major, Assembly.GetExecutingAssembly().GetName().Version.Minor);
        }

        /// <summary>
        /// Show log item
        /// </summary>
        private void LoadLogItem()
        {
            if (SelectedLog != null)
            {
                using (frmLog frm = new frmLog(SelectedLog))
                {                    
                    frm.ShowDialog();
                }
            }
        }
          
        #endregion

        #region Interface 

        private void bntReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpdateDateTime();

            LoadData();        
        }

        private void gridView_Logs_DoubleClick(object sender, EventArgs e)
        {
            LoadLogItem();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadLogItem();
        }

        private void gridControl_Logs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
                LoadLogItem();
        }

        private void btnSelectedDateStart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime d = SelectedDateStart;
            if (DateDialog.Execute(ref d))
            {
                SelectedDateStart = d;
                if (SelectedDateStart > SelectedDateEnd)
                    SelectedDateEnd = d;
                LoadData();
            }        
        }

        private void btnSelectedDateEnd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime d = SelectedDateEnd;
            if (DateDialog.Execute(ref d))
            {
                SelectedDateEnd = d;
                if (SelectedDateEnd < SelectedDateStart)
                    SelectedDateStart = d;
                LoadData();
            }        
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {                     
            printableComponentLink.PrintDlg();
        }

        private void btnPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printableComponentLink.ShowPreview();
        }

        /// <summary>
        /// Export to Excel
        /// </summary>
        private void btnExpToExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string tempFileName = Path.ChangeExtension(Path.GetTempFileName(), ".xlsx");
            gridView_Logs.ExportToXlsx(tempFileName);
            if (File.Exists(tempFileName))
            {
                ProcessLauncher plauncher = new ProcessLauncher(tempFileName) 
                {   
                    Verb = "open", 
                    WaitForExit = false, 
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Maximized 
                };
                plauncher.Execute();
            }        
        }


        #endregion
    }
}