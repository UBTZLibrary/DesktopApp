namespace UBTZLibrary.Inquiry
{
    partial class frmBookRemainderList
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.BOOKID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.CODE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.NAME = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.TOTAL = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.REMAINDER = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.FIRSTRETURNDATE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.NOTE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.COLGENDER = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.barManager2 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barAction = new DevExpress.XtraBars.BarSubItem();
            this.barClose = new DevExpress.XtraBars.BarButtonItem();
            this.barSave = new DevExpress.XtraBars.BarButtonItem();
            this.barCancel = new DevExpress.XtraBars.BarButtonItem();
            this.barRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barExcel = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.dataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.COLGENDER)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 22);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(824, 494);
            this.panelControl1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.bandedGridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.COLGENDER,
            this.repositoryItemCheckEdit1,
            this.repositoryItemDateEdit1});
            this.gridControl1.Size = new System.Drawing.Size(820, 490);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.BOOKID,
            this.CODE,
            this.NAME,
            this.TOTAL,
            this.REMAINDER,
            this.FIRSTRETURNDATE,
            this.NOTE});
            this.bandedGridView1.GridControl = this.gridControl1;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.bandedGridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.bandedGridView1.OptionsFind.AlwaysVisible = true;
            this.bandedGridView1.OptionsFind.FindNullPrompt = "Хайх";
            this.bandedGridView1.OptionsFind.ShowClearButton = false;
            this.bandedGridView1.OptionsFind.ShowFindButton = false;
            this.bandedGridView1.OptionsView.ShowAutoFilterRow = true;
            this.bandedGridView1.OptionsView.ShowFooter = true;
            this.bandedGridView1.OptionsView.ShowGroupPanel = false;
            this.bandedGridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.bandedGridView1_CustomDrawCell);
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Ном";
            this.gridBand1.Columns.Add(this.BOOKID);
            this.gridBand1.Columns.Add(this.CODE);
            this.gridBand1.Columns.Add(this.NAME);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 150;
            // 
            // BOOKID
            // 
            this.BOOKID.Caption = "Дугаар";
            this.BOOKID.FieldName = "BOOKID";
            this.BOOKID.Name = "BOOKID";
            this.BOOKID.OptionsColumn.AllowEdit = false;
            // 
            // CODE
            // 
            this.CODE.Caption = "Код";
            this.CODE.FieldName = "CODE";
            this.CODE.Name = "CODE";
            this.CODE.OptionsColumn.AllowEdit = false;
            this.CODE.Visible = true;
            // 
            // NAME
            // 
            this.NAME.Caption = "Нэр";
            this.NAME.FieldName = "NAME";
            this.NAME.Name = "NAME";
            this.NAME.OptionsColumn.AllowEdit = false;
            this.NAME.Visible = true;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "Үлдэгдэл";
            this.gridBand2.Columns.Add(this.TOTAL);
            this.gridBand2.Columns.Add(this.REMAINDER);
            this.gridBand2.Columns.Add(this.FIRSTRETURNDATE);
            this.gridBand2.Columns.Add(this.NOTE);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 337;
            // 
            // TOTAL
            // 
            this.TOTAL.Caption = "Нийт";
            this.TOTAL.FieldName = "TOTAL";
            this.TOTAL.Name = "TOTAL";
            this.TOTAL.OptionsColumn.AllowEdit = false;
            this.TOTAL.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL", "Нийт:{0:0}")});
            this.TOTAL.Visible = true;
            // 
            // REMAINDER
            // 
            this.REMAINDER.Caption = "Үлдэгдэл";
            this.REMAINDER.FieldName = "REMAINDER";
            this.REMAINDER.Name = "REMAINDER";
            this.REMAINDER.OptionsColumn.AllowEdit = false;
            this.REMAINDER.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "REMAINDER", "Нийт:{0:0}")});
            this.REMAINDER.Visible = true;
            // 
            // FIRSTRETURNDATE
            // 
            this.FIRSTRETURNDATE.Caption = "Эхний буцаах огноо";
            this.FIRSTRETURNDATE.ColumnEdit = this.repositoryItemDateEdit1;
            this.FIRSTRETURNDATE.FieldName = "FIRSTRETURNDATE";
            this.FIRSTRETURNDATE.Name = "FIRSTRETURNDATE";
            this.FIRSTRETURNDATE.OptionsColumn.AllowEdit = false;
            this.FIRSTRETURNDATE.Visible = true;
            this.FIRSTRETURNDATE.Width = 112;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.DisplayFormat.FormatString = "yyyy.MM.dd";
            this.repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.EditFormat.FormatString = "yyyy.MM.dd";
            this.repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.Mask.EditMask = "yyyy.MM.dd";
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // NOTE
            // 
            this.NOTE.Caption = "Тайлбар";
            this.NOTE.FieldName = "NOTE";
            this.NOTE.Name = "NOTE";
            this.NOTE.Visible = true;
            // 
            // COLGENDER
            // 
            this.COLGENDER.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.True;
            this.COLGENDER.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.COLGENDER.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", "Хүйс")});
            this.COLGENDER.DisplayMember = "NAME";
            this.COLGENDER.Name = "COLGENDER";
            this.COLGENDER.ShowFooter = false;
            this.COLGENDER.ShowHeader = false;
            this.COLGENDER.ValueMember = "TYPE";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.ValueChecked = "Y";
            this.repositoryItemCheckEdit1.ValueUnchecked = "N";
            // 
            // barManager2
            // 
            this.barManager2.AllowQuickCustomization = false;
            this.barManager2.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager2.DockControls.Add(this.barDockControl1);
            this.barManager2.DockControls.Add(this.barDockControl2);
            this.barManager2.DockControls.Add(this.barDockControl3);
            this.barManager2.DockControls.Add(this.barDockControl4);
            this.barManager2.Form = this;
            this.barManager2.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barRefresh,
            this.barAction,
            this.barClose,
            this.barSave,
            this.barCancel,
            this.barExcel});
            this.barManager2.MainMenu = this.bar2;
            this.barManager2.MaxItemId = 8;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barAction, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSave, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCancel, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barExcel, true)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barAction
            // 
            this.barAction.Caption = "Үйлдэл";
            this.barAction.Id = 3;
            this.barAction.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barClose)});
            this.barAction.Name = "barAction";
            // 
            // barClose
            // 
            this.barClose.Caption = "Гарах";
            this.barClose.Id = 4;
            this.barClose.Name = "barClose";
            this.barClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barClose_ItemClick);
            // 
            // barSave
            // 
            this.barSave.Caption = "Хадгалах";
            this.barSave.Id = 5;
            this.barSave.Name = "barSave";
            this.barSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSave_ItemClick);
            // 
            // barCancel
            // 
            this.barCancel.Caption = "Болих";
            this.barCancel.Id = 6;
            this.barCancel.Name = "barCancel";
            this.barCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCancel_ItemClick);
            // 
            // barRefresh
            // 
            this.barRefresh.Caption = "Шинэчлэх";
            this.barRefresh.Id = 2;
            this.barRefresh.Name = "barRefresh";
            this.barRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barRefresh_ItemClick);
            // 
            // barExcel
            // 
            this.barExcel.Caption = "Excel файл";
            this.barExcel.Id = 7;
            this.barExcel.Name = "barExcel";
            this.barExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barExcel_ItemClick);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Manager = this.barManager2;
            this.barDockControl1.Size = new System.Drawing.Size(824, 22);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 516);
            this.barDockControl2.Manager = this.barManager2;
            this.barDockControl2.Size = new System.Drawing.Size(824, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 22);
            this.barDockControl3.Manager = this.barManager2;
            this.barDockControl3.Size = new System.Drawing.Size(0, 494);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(824, 22);
            this.barDockControl4.Manager = this.barManager2;
            this.barDockControl4.Size = new System.Drawing.Size(0, 494);
            // 
            // dataSetBindingSource
            // 
            this.dataSetBindingSource.DataSource = typeof(System.Data.DataSet);
            this.dataSetBindingSource.Position = 0;
            // 
            // frmBookRemainderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 516);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.KeyPreview = true;
            this.Name = "frmBookRemainderList";
            this.Text = "Ном - Үлдэгдэл";
            this.Load += new System.EventHandler(this.frmBookRemainderList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.COLGENDER)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarManager barManager2;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barRefresh;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraBars.BarSubItem barAction;
        private DevExpress.XtraBars.BarButtonItem barClose;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit COLGENDER;
        private System.Windows.Forms.BindingSource dataSetBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn BOOKID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn CODE;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn NAME;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TOTAL;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn REMAINDER;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn FIRSTRETURNDATE;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn NOTE;
        private DevExpress.XtraBars.BarButtonItem barSave;
        private DevExpress.XtraBars.BarButtonItem barCancel;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarButtonItem barExcel;


    }
}