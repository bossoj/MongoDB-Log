namespace BJ.MongoDB.ClientUI
{
    partial class frmLog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label classNameLabel;
            System.Windows.Forms.Label domainLabel;
            System.Windows.Forms.Label fileNameLabel;
            System.Windows.Forms.Label levelLabel;
            System.Windows.Forms.Label lineNumberLabel;
            System.Windows.Forms.Label loggerNameLabel;
            System.Windows.Forms.Label machineNameLabel;
            System.Windows.Forms.Label messageLabel;
            System.Windows.Forms.Label methodLabel;
            System.Windows.Forms.Label threadLabel;
            System.Windows.Forms.Label userNameLabel;
            System.Windows.Forms.Label asLocalTimeLabel;
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLog));
            this.classNameTextBox = new System.Windows.Forms.TextBox();
            this.logItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.domainTextBox = new System.Windows.Forms.TextBox();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.levelTextBox = new System.Windows.Forms.TextBox();
            this.lineNumberTextBox = new System.Windows.Forms.TextBox();
            this.loggerNameTextBox = new System.Windows.Forms.TextBox();
            this.machineNameTextBox = new System.Windows.Forms.TextBox();
            this.methodTextBox = new System.Windows.Forms.TextBox();
            this.threadTextBox = new System.Windows.Forms.TextBox();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.asLocalTimeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.messageMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageCommon = new System.Windows.Forms.TabPage();
            this.tabPageProperties = new System.Windows.Forms.TabPage();
            this.gridControl_Properties = new DevExpress.XtraGrid.GridControl();
            this.gridView_Properties = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPageException = new System.Windows.Forms.TabPage();
            this.treeList_Exception = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            classNameLabel = new System.Windows.Forms.Label();
            domainLabel = new System.Windows.Forms.Label();
            fileNameLabel = new System.Windows.Forms.Label();
            levelLabel = new System.Windows.Forms.Label();
            lineNumberLabel = new System.Windows.Forms.Label();
            loggerNameLabel = new System.Windows.Forms.Label();
            machineNameLabel = new System.Windows.Forms.Label();
            messageLabel = new System.Windows.Forms.Label();
            methodLabel = new System.Windows.Forms.Label();
            threadLabel = new System.Windows.Forms.Label();
            userNameLabel = new System.Windows.Forms.Label();
            asLocalTimeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageMemoEdit.Properties)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageCommon.SuspendLayout();
            this.tabPageProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Properties)).BeginInit();
            this.tabPageException.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList_Exception)).BeginInit();
            this.SuspendLayout();
            // 
            // classNameLabel
            // 
            classNameLabel.AutoSize = true;
            classNameLabel.Location = new System.Drawing.Point(309, 248);
            classNameLabel.Name = "classNameLabel";
            classNameLabel.Size = new System.Drawing.Size(36, 13);
            classNameLabel.TabIndex = 1;
            classNameLabel.Text = "Class:";
            // 
            // domainLabel
            // 
            domainLabel.AutoSize = true;
            domainLabel.Location = new System.Drawing.Point(29, 245);
            domainLabel.Name = "domainLabel";
            domainLabel.Size = new System.Drawing.Size(30, 13);
            domainLabel.TabIndex = 3;
            domainLabel.Text = "App:";
            // 
            // fileNameLabel
            // 
            fileNameLabel.AutoSize = true;
            fileNameLabel.Location = new System.Drawing.Point(318, 326);
            fileNameLabel.Name = "fileNameLabel";
            fileNameLabel.Size = new System.Drawing.Size(27, 13);
            fileNameLabel.TabIndex = 5;
            fileNameLabel.Text = "File:";
            // 
            // levelLabel
            // 
            levelLabel.AutoSize = true;
            levelLabel.Location = new System.Drawing.Point(23, 272);
            levelLabel.Name = "levelLabel";
            levelLabel.Size = new System.Drawing.Size(36, 13);
            levelLabel.TabIndex = 7;
            levelLabel.Text = "Level:";
            // 
            // lineNumberLabel
            // 
            lineNumberLabel.AutoSize = true;
            lineNumberLabel.Location = new System.Drawing.Point(315, 299);
            lineNumberLabel.Name = "lineNumberLabel";
            lineNumberLabel.Size = new System.Drawing.Size(30, 13);
            lineNumberLabel.TabIndex = 9;
            lineNumberLabel.Text = "Line:";
            // 
            // loggerNameLabel
            // 
            loggerNameLabel.AutoSize = true;
            loggerNameLabel.Location = new System.Drawing.Point(301, 221);
            loggerNameLabel.Name = "loggerNameLabel";
            loggerNameLabel.Size = new System.Drawing.Size(44, 13);
            loggerNameLabel.TabIndex = 11;
            loggerNameLabel.Text = "Logger:";
            // 
            // machineNameLabel
            // 
            machineNameLabel.AutoSize = true;
            machineNameLabel.Location = new System.Drawing.Point(9, 353);
            machineNameLabel.Name = "machineNameLabel";
            machineNameLabel.Size = new System.Drawing.Size(50, 13);
            machineNameLabel.TabIndex = 13;
            machineNameLabel.Text = "Machine:";
            // 
            // messageLabel
            // 
            messageLabel.AutoSize = true;
            messageLabel.Location = new System.Drawing.Point(6, 3);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new System.Drawing.Size(53, 13);
            messageLabel.TabIndex = 15;
            messageLabel.Text = "Message:";
            // 
            // methodLabel
            // 
            methodLabel.AutoSize = true;
            methodLabel.Location = new System.Drawing.Point(298, 272);
            methodLabel.Name = "methodLabel";
            methodLabel.Size = new System.Drawing.Size(47, 13);
            methodLabel.TabIndex = 17;
            methodLabel.Text = "Method:";
            // 
            // threadLabel
            // 
            threadLabel.AutoSize = true;
            threadLabel.Location = new System.Drawing.Point(14, 299);
            threadLabel.Name = "threadLabel";
            threadLabel.Size = new System.Drawing.Size(45, 13);
            threadLabel.TabIndex = 19;
            threadLabel.Text = "Thread:";
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Location = new System.Drawing.Point(23, 326);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new System.Drawing.Size(33, 13);
            userNameLabel.TabIndex = 21;
            userNameLabel.Text = "User:";
            // 
            // asLocalTimeLabel
            // 
            asLocalTimeLabel.AutoSize = true;
            asLocalTimeLabel.Location = new System.Drawing.Point(3, 221);
            asLocalTimeLabel.Name = "asLocalTimeLabel";
            asLocalTimeLabel.Size = new System.Drawing.Size(56, 13);
            asLocalTimeLabel.TabIndex = 25;
            asLocalTimeLabel.Text = "DateTime:";
            // 
            // classNameTextBox
            // 
            this.classNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.logItemBindingSource, "className", true));
            this.classNameTextBox.Location = new System.Drawing.Point(393, 242);
            this.classNameTextBox.Name = "classNameTextBox";
            this.classNameTextBox.ReadOnly = true;
            this.classNameTextBox.Size = new System.Drawing.Size(269, 21);
            this.classNameTextBox.TabIndex = 8;
            this.classNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLog_KeyDown);
            // 
            // logItemBindingSource
            // 
            this.logItemBindingSource.DataSource = typeof(BJ.MongoDB.Logger.LogItem);
            // 
            // domainTextBox
            // 
            this.domainTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.logItemBindingSource, "domain", true));
            this.domainTextBox.Location = new System.Drawing.Point(106, 242);
            this.domainTextBox.Name = "domainTextBox";
            this.domainTextBox.ReadOnly = true;
            this.domainTextBox.Size = new System.Drawing.Size(172, 21);
            this.domainTextBox.TabIndex = 2;
            this.domainTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLog_KeyDown);
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.logItemBindingSource, "fileName", true));
            this.fileNameTextBox.Location = new System.Drawing.Point(393, 323);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.ReadOnly = true;
            this.fileNameTextBox.Size = new System.Drawing.Size(269, 21);
            this.fileNameTextBox.TabIndex = 11;
            this.fileNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLog_KeyDown);
            // 
            // levelTextBox
            // 
            this.levelTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.logItemBindingSource, "level", true));
            this.levelTextBox.Location = new System.Drawing.Point(106, 269);
            this.levelTextBox.Name = "levelTextBox";
            this.levelTextBox.ReadOnly = true;
            this.levelTextBox.Size = new System.Drawing.Size(172, 21);
            this.levelTextBox.TabIndex = 3;
            this.levelTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLog_KeyDown);
            // 
            // lineNumberTextBox
            // 
            this.lineNumberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.logItemBindingSource, "lineNumber", true));
            this.lineNumberTextBox.Location = new System.Drawing.Point(393, 296);
            this.lineNumberTextBox.Name = "lineNumberTextBox";
            this.lineNumberTextBox.ReadOnly = true;
            this.lineNumberTextBox.Size = new System.Drawing.Size(269, 21);
            this.lineNumberTextBox.TabIndex = 10;
            this.lineNumberTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLog_KeyDown);
            // 
            // loggerNameTextBox
            // 
            this.loggerNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.logItemBindingSource, "loggerName", true));
            this.loggerNameTextBox.Location = new System.Drawing.Point(393, 215);
            this.loggerNameTextBox.Name = "loggerNameTextBox";
            this.loggerNameTextBox.ReadOnly = true;
            this.loggerNameTextBox.Size = new System.Drawing.Size(269, 21);
            this.loggerNameTextBox.TabIndex = 7;
            this.loggerNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLog_KeyDown);
            // 
            // machineNameTextBox
            // 
            this.machineNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.logItemBindingSource, "machineName", true));
            this.machineNameTextBox.Location = new System.Drawing.Point(106, 350);
            this.machineNameTextBox.Name = "machineNameTextBox";
            this.machineNameTextBox.ReadOnly = true;
            this.machineNameTextBox.Size = new System.Drawing.Size(172, 21);
            this.machineNameTextBox.TabIndex = 6;
            this.machineNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLog_KeyDown);
            // 
            // methodTextBox
            // 
            this.methodTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.logItemBindingSource, "method", true));
            this.methodTextBox.Location = new System.Drawing.Point(393, 269);
            this.methodTextBox.Name = "methodTextBox";
            this.methodTextBox.ReadOnly = true;
            this.methodTextBox.Size = new System.Drawing.Size(269, 21);
            this.methodTextBox.TabIndex = 9;
            this.methodTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLog_KeyDown);
            // 
            // threadTextBox
            // 
            this.threadTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.logItemBindingSource, "thread", true));
            this.threadTextBox.Location = new System.Drawing.Point(106, 296);
            this.threadTextBox.Name = "threadTextBox";
            this.threadTextBox.ReadOnly = true;
            this.threadTextBox.Size = new System.Drawing.Size(172, 21);
            this.threadTextBox.TabIndex = 4;
            this.threadTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLog_KeyDown);
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.logItemBindingSource, "userName", true));
            this.userNameTextBox.Location = new System.Drawing.Point(106, 323);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.ReadOnly = true;
            this.userNameTextBox.Size = new System.Drawing.Size(172, 21);
            this.userNameTextBox.TabIndex = 5;
            this.userNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLog_KeyDown);
            // 
            // asLocalTimeDateTimePicker
            // 
            this.asLocalTimeDateTimePicker.CustomFormat = "dd.MM.yyyy H:mm:ss";
            this.asLocalTimeDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.logItemBindingSource, "timestamp.AsLocalTime", true));
            this.asLocalTimeDateTimePicker.Enabled = false;
            this.asLocalTimeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.asLocalTimeDateTimePicker.Location = new System.Drawing.Point(106, 215);
            this.asLocalTimeDateTimePicker.Name = "asLocalTimeDateTimePicker";
            this.asLocalTimeDateTimePicker.Size = new System.Drawing.Size(172, 21);
            this.asLocalTimeDateTimePicker.TabIndex = 1;
            this.asLocalTimeDateTimePicker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLog_KeyDown);
            // 
            // messageMemoEdit
            // 
            this.messageMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.logItemBindingSource, "message", true));
            this.messageMemoEdit.Enabled = false;
            this.messageMemoEdit.Location = new System.Drawing.Point(9, 19);
            this.messageMemoEdit.Name = "messageMemoEdit";
            this.messageMemoEdit.Size = new System.Drawing.Size(653, 180);
            this.messageMemoEdit.TabIndex = 12;
            this.messageMemoEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLog_KeyDown);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageCommon);
            this.tabControl.Controls.Add(this.tabPageProperties);
            this.tabControl.Controls.Add(this.tabPageException);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(683, 413);
            this.tabControl.TabIndex = 26;
            this.tabControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabControl_KeyDown);
            // 
            // tabPageCommon
            // 
            this.tabPageCommon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.tabPageCommon.Controls.Add(messageLabel);
            this.tabPageCommon.Controls.Add(this.messageMemoEdit);
            this.tabPageCommon.Controls.Add(this.classNameTextBox);
            this.tabPageCommon.Controls.Add(asLocalTimeLabel);
            this.tabPageCommon.Controls.Add(classNameLabel);
            this.tabPageCommon.Controls.Add(this.asLocalTimeDateTimePicker);
            this.tabPageCommon.Controls.Add(this.domainTextBox);
            this.tabPageCommon.Controls.Add(userNameLabel);
            this.tabPageCommon.Controls.Add(domainLabel);
            this.tabPageCommon.Controls.Add(this.userNameTextBox);
            this.tabPageCommon.Controls.Add(this.fileNameTextBox);
            this.tabPageCommon.Controls.Add(threadLabel);
            this.tabPageCommon.Controls.Add(fileNameLabel);
            this.tabPageCommon.Controls.Add(this.threadTextBox);
            this.tabPageCommon.Controls.Add(this.levelTextBox);
            this.tabPageCommon.Controls.Add(methodLabel);
            this.tabPageCommon.Controls.Add(levelLabel);
            this.tabPageCommon.Controls.Add(this.methodTextBox);
            this.tabPageCommon.Controls.Add(this.lineNumberTextBox);
            this.tabPageCommon.Controls.Add(lineNumberLabel);
            this.tabPageCommon.Controls.Add(machineNameLabel);
            this.tabPageCommon.Controls.Add(this.loggerNameTextBox);
            this.tabPageCommon.Controls.Add(this.machineNameTextBox);
            this.tabPageCommon.Controls.Add(loggerNameLabel);
            this.tabPageCommon.Location = new System.Drawing.Point(4, 22);
            this.tabPageCommon.Name = "tabPageCommon";
            this.tabPageCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCommon.Size = new System.Drawing.Size(675, 387);
            this.tabPageCommon.TabIndex = 0;
            this.tabPageCommon.Text = "Common";
            // 
            // tabPageProperties
            // 
            this.tabPageProperties.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.tabPageProperties.Controls.Add(this.gridControl_Properties);
            this.tabPageProperties.Location = new System.Drawing.Point(4, 22);
            this.tabPageProperties.Name = "tabPageProperties";
            this.tabPageProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProperties.Size = new System.Drawing.Size(675, 387);
            this.tabPageProperties.TabIndex = 1;
            this.tabPageProperties.Text = "Properties";
            // 
            // gridControl_Properties
            // 
            this.gridControl_Properties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_Properties.Location = new System.Drawing.Point(3, 3);
            this.gridControl_Properties.MainView = this.gridView_Properties;
            this.gridControl_Properties.Name = "gridControl_Properties";
            this.gridControl_Properties.Size = new System.Drawing.Size(669, 381);
            this.gridControl_Properties.TabIndex = 6;
            this.gridControl_Properties.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_Properties});
            // 
            // gridView_Properties
            // 
            this.gridView_Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.gridView_Properties.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView_Properties.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.MistyRose;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "ERROR";
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.Tomato;
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = "FATAL";
            styleFormatCondition3.Appearance.BackColor = System.Drawing.Color.LemonChiffon;
            styleFormatCondition3.Appearance.Options.UseBackColor = true;
            styleFormatCondition3.ApplyToRow = true;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition3.Value1 = "WARN";
            this.gridView_Properties.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2,
            styleFormatCondition3});
            this.gridView_Properties.GridControl = this.gridControl_Properties;
            this.gridView_Properties.Name = "gridView_Properties";
            this.gridView_Properties.OptionsBehavior.Editable = false;
            this.gridView_Properties.OptionsBehavior.ReadOnly = true;
            this.gridView_Properties.OptionsView.EnableAppearanceOddRow = true;
            this.gridView_Properties.OptionsView.ShowGroupPanel = false;
            this.gridView_Properties.OptionsView.ShowIndicator = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Name";
            this.gridColumn1.FieldName = "Name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 178;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Value";
            this.gridColumn2.FieldName = "Value";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 489;
            // 
            // tabPageException
            // 
            this.tabPageException.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.tabPageException.Controls.Add(this.treeList_Exception);
            this.tabPageException.Location = new System.Drawing.Point(4, 22);
            this.tabPageException.Name = "tabPageException";
            this.tabPageException.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageException.Size = new System.Drawing.Size(675, 387);
            this.tabPageException.TabIndex = 2;
            this.tabPageException.Text = "Exception";
            // 
            // treeList_Exception
            // 
            this.treeList_Exception.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.treeList_Exception.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList_Exception.Location = new System.Drawing.Point(3, 3);
            this.treeList_Exception.Name = "treeList_Exception";
            this.treeList_Exception.OptionsBehavior.Editable = false;
            this.treeList_Exception.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeList_Exception.OptionsView.ShowHorzLines = false;
            this.treeList_Exception.OptionsView.ShowIndicator = false;
            this.treeList_Exception.OptionsView.ShowPreview = true;
            this.treeList_Exception.OptionsView.ShowVertLines = false;
            this.treeList_Exception.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowForFocusedRow;
            this.treeList_Exception.Size = new System.Drawing.Size(669, 381);
            this.treeList_Exception.TabIndex = 1;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Name";
            this.treeListColumn1.FieldName = "Name";
            this.treeListColumn1.MinWidth = 32;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 170;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "Value";
            this.treeListColumn2.FieldName = "Value";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 481;
            // 
            // frmLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 438);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Log Item";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLog_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.logItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.messageMemoEdit.Properties)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageCommon.ResumeLayout(false);
            this.tabPageCommon.PerformLayout();
            this.tabPageProperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Properties)).EndInit();
            this.tabPageException.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList_Exception)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox classNameTextBox;
        private System.Windows.Forms.TextBox domainTextBox;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.TextBox levelTextBox;
        private System.Windows.Forms.TextBox lineNumberTextBox;
        private System.Windows.Forms.TextBox loggerNameTextBox;
        private System.Windows.Forms.TextBox machineNameTextBox;
        private System.Windows.Forms.TextBox methodTextBox;
        private System.Windows.Forms.TextBox threadTextBox;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.DateTimePicker asLocalTimeDateTimePicker;
        public System.Windows.Forms.BindingSource logItemBindingSource;
        private DevExpress.XtraEditors.MemoEdit messageMemoEdit;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageCommon;
        private System.Windows.Forms.TabPage tabPageProperties;
        private System.Windows.Forms.TabPage tabPageException;
        private DevExpress.XtraGrid.GridControl gridControl_Properties;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_Properties;
        private DevExpress.XtraTreeList.TreeList treeList_Exception;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}