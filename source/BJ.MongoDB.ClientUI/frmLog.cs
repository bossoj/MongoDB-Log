using System;
using System.Collections.Generic;
using System.Windows.Forms;

using DevExpress.XtraTreeList.Nodes;
using MongoDB.Bson;

using BJ.MongoDB.ClientUI.Properties;
using BJ.MongoDB.Logger;

namespace BJ.MongoDB.ClientUI
{
    public partial class frmLog : DevExpress.XtraEditors.XtraForm
    {
        #region Fields, Properties

        private readonly string _formatException = Settings.Default.FormatException;

        private LogItem logItem;

        #endregion

        #region Constructors

        public frmLog(LogItem logItem)
        {
            InitializeComponent();

            this.logItem = logItem;

            InitForm();
        }

        #endregion

        #region Domain layer

        private void InitForm()
        {           
            logItemBindingSource.DataSource = logItem;

            if (logItem.properties != null && logItem.properties.ElementCount > 0)
            {
                InitProperties();
            }

            if (logItem.exception != null && logItem.exception.ElementCount > 0)
            {
                InitException();
            }
        }

        private void InitProperties()
        {
            gridControl_Properties.DataSource = logItem.properties.Elements;
        }

        private void InitException()
        {
            try
            {
                BsonDocument doc = logItem.exception;
                TreeListNode rootNode = null;

                treeList_Exception.BeginUnboundLoad();

                do
                {
                    var message = doc.GetElement("message").Value.AsString;
                    var source = doc.GetElement("source").Value.AsString;
                    var stackTrace = doc.GetElement("stackTrace").Value.AsString;

                    treeList_Exception.AppendNode(new object[] { "message", message }, rootNode);
                    treeList_Exception.AppendNode(new object[] { "source", source }, rootNode);
                    treeList_Exception.AppendNode(new object[] { "stackTrace", stackTrace }, rootNode);

                    if (doc.Contains("innerException"))
                    {
                        var innerException = doc.GetElement("innerException").Value.AsBsonDocument;
                        rootNode = treeList_Exception.AppendNode(new object[] { "innerException", string.Empty }, rootNode);
                        doc = innerException;
                    }
                    else
                    {
                        break;
                    }

                }
                while (true);

                treeList_Exception.EndUnboundLoad();
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show(String.Format(_formatException, ex.Message, ex.StackTrace),
                                "Error format message in DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Interface layer

        private void frmLog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void tabControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        #endregion
    }
}