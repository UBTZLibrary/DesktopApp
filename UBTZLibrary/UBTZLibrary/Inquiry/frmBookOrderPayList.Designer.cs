namespace UBTZLibrary.Inquiry
{
    partial class frmBookOrderPayList
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
            this.STUDENTID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.STUDENTCODE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.STUDENTNAME = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.BOOKCODE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.BOOKNAME = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.REASON = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.TAKEDATE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.RETURNEDDATE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.NOTE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.OUT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.PURCHASE = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.ORDERID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.BOOKID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.COLGENDER = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.barManager2 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barAction = new DevExpress.XtraBars.BarSubItem();
            this.barClose = new DevExpress.XtraBars.BarButtonItem();
            this.barRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barExcel = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.dataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtBookName = new DevExpress.XtraEditors.ButtonEdit();
            this.txtBookID = new DevExpress.XtraEditors.ButtonEdit();
            this.lblBookID = new DevExpress.XtraEditors.LabelControl();
            this.txtStudentName = new DevExpress.XtraEditors.ButtonEdit();
            this.txtStudentID = new DevExpress.XtraEditors.ButtonEdit();
            this.lblStudentID = new DevExpress.XtraEditors.LabelControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.COLGENDER)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBookName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBookID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStudentName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStudentID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 94);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1188, 544);
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
            this.repositoryItemDateEdit1,
            this.repositoryItemButtonEdit1,
            this.repositoryItemButtonEdit2,
            this.repositoryItemLookUpEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1184, 540);
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
            this.ORDERID,
            this.STUDENTID,
            this.BOOKID,
            this.STUDENTCODE,
            this.STUDENTNAME,
            this.BOOKCODE,
            this.BOOKNAME,
            this.REASON,
            this.TAKEDATE,
            this.RETURNEDDATE,
            this.NOTE,
            this.OUT,
            this.PURCHASE});
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
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Оюутан";
            this.gridBand1.Columns.Add(this.STUDENTID);
            this.gridBand1.Columns.Add(this.STUDENTCODE);
            this.gridBand1.Columns.Add(this.STUDENTNAME);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 150;
            // 
            // STUDENTID
            // 
            this.STUDENTID.Caption = "Дугаар";
            this.STUDENTID.FieldName = "STUDENTID";
            this.STUDENTID.Name = "STUDENTID";
            this.STUDENTID.OptionsColumn.AllowEdit = false;
            // 
            // STUDENTCODE
            // 
            this.STUDENTCODE.Caption = "Код";
            this.STUDENTCODE.FieldName = "STUDENTCODE";
            this.STUDENTCODE.Name = "STUDENTCODE";
            this.STUDENTCODE.OptionsColumn.AllowEdit = false;
            this.STUDENTCODE.Visible = true;
            // 
            // STUDENTNAME
            // 
            this.STUDENTNAME.Caption = "Нэр";
            this.STUDENTNAME.FieldName = "STUDENTNAME";
            this.STUDENTNAME.Name = "STUDENTNAME";
            this.STUDENTNAME.OptionsColumn.AllowEdit = false;
            this.STUDENTNAME.Visible = true;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "Ном";
            this.gridBand2.Columns.Add(this.BOOKCODE);
            this.gridBand2.Columns.Add(this.BOOKNAME);
            this.gridBand2.Columns.Add(this.REASON);
            this.gridBand2.Columns.Add(this.TAKEDATE);
            this.gridBand2.Columns.Add(this.RETURNEDDATE);
            this.gridBand2.Columns.Add(this.NOTE);
            this.gridBand2.Columns.Add(this.OUT);
            this.gridBand2.Columns.Add(this.PURCHASE);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 677;
            // 
            // BOOKCODE
            // 
            this.BOOKCODE.Caption = "Код";
            this.BOOKCODE.FieldName = "BOOKCODE";
            this.BOOKCODE.Name = "BOOKCODE";
            this.BOOKCODE.OptionsColumn.AllowEdit = false;
            this.BOOKCODE.Visible = true;
            this.BOOKCODE.Width = 80;
            // 
            // BOOKNAME
            // 
            this.BOOKNAME.Caption = "Нэр";
            this.BOOKNAME.FieldName = "BOOKNAME";
            this.BOOKNAME.Name = "BOOKNAME";
            this.BOOKNAME.OptionsColumn.AllowEdit = false;
            this.BOOKNAME.Visible = true;
            this.BOOKNAME.Width = 80;
            // 
            // REASON
            // 
            this.REASON.Caption = "Шийдвэрлэлт";
            this.REASON.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.REASON.FieldName = "REASON";
            this.REASON.Name = "REASON";
            this.REASON.OptionsColumn.AllowEdit = false;
            this.REASON.Visible = true;
            this.REASON.Width = 95;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", "NAME")});
            this.repositoryItemLookUpEdit1.DisplayMember = "NAME";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.ShowFooter = false;
            this.repositoryItemLookUpEdit1.ShowHeader = false;
            this.repositoryItemLookUpEdit1.ValueMember = "TYPE";
            // 
            // TAKEDATE
            // 
            this.TAKEDATE.Caption = "Олгосон огноо";
            this.TAKEDATE.ColumnEdit = this.repositoryItemDateEdit1;
            this.TAKEDATE.FieldName = "TAKEDATE";
            this.TAKEDATE.Name = "TAKEDATE";
            this.TAKEDATE.OptionsColumn.AllowEdit = false;
            this.TAKEDATE.Visible = true;
            this.TAKEDATE.Width = 80;
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
            // RETURNEDDATE
            // 
            this.RETURNEDDATE.Caption = "Шийдвэрлэсэн огноо";
            this.RETURNEDDATE.ColumnEdit = this.repositoryItemDateEdit1;
            this.RETURNEDDATE.FieldName = "RETURNEDDATE";
            this.RETURNEDDATE.Name = "RETURNEDDATE";
            this.RETURNEDDATE.OptionsColumn.AllowEdit = false;
            this.RETURNEDDATE.Visible = true;
            this.RETURNEDDATE.Width = 112;
            // 
            // NOTE
            // 
            this.NOTE.Caption = "Тайлбар";
            this.NOTE.FieldName = "NOTE";
            this.NOTE.Name = "NOTE";
            this.NOTE.OptionsColumn.AllowEdit = false;
            this.NOTE.Visible = true;
            this.NOTE.Width = 80;
            // 
            // OUT
            // 
            this.OUT.Caption = "Зарлагадалт";
            this.OUT.ColumnEdit = this.repositoryItemButtonEdit1;
            this.OUT.FieldName = "OUT";
            this.OUT.Name = "OUT";
            this.OUT.Visible = true;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.SpinRight)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // PURCHASE
            // 
            this.PURCHASE.Caption = "Орлогодолт";
            this.PURCHASE.ColumnEdit = this.repositoryItemButtonEdit2;
            this.PURCHASE.FieldName = "PURCHASE";
            this.PURCHASE.Name = "PURCHASE";
            this.PURCHASE.Visible = true;
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.AutoHeight = false;
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.SpinLeft)});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            this.repositoryItemButtonEdit2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // ORDERID
            // 
            this.ORDERID.Caption = "Захиалгын дугаар";
            this.ORDERID.FieldName = "ORDERID";
            this.ORDERID.Name = "ORDERID";
            this.ORDERID.OptionsColumn.AllowEdit = false;
            // 
            // BOOKID
            // 
            this.BOOKID.Caption = "Номын дугаар";
            this.BOOKID.FieldName = "BOOID";
            this.BOOKID.Name = "BOOKID";
            this.BOOKID.OptionsColumn.AllowEdit = false;
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
            this.barDockControl1.Size = new System.Drawing.Size(1188, 22);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 638);
            this.barDockControl2.Manager = this.barManager2;
            this.barDockControl2.Size = new System.Drawing.Size(1188, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 22);
            this.barDockControl3.Manager = this.barManager2;
            this.barDockControl3.Size = new System.Drawing.Size(0, 616);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(1188, 22);
            this.barDockControl4.Manager = this.barManager2;
            this.barDockControl4.Size = new System.Drawing.Size(0, 616);
            // 
            // dataSetBindingSource
            // 
            this.dataSetBindingSource.DataSource = typeof(System.Data.DataSet);
            this.dataSetBindingSource.Position = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txtBookName);
            this.panelControl2.Controls.Add(this.txtBookID);
            this.panelControl2.Controls.Add(this.lblBookID);
            this.panelControl2.Controls.Add(this.txtStudentName);
            this.panelControl2.Controls.Add(this.txtStudentID);
            this.panelControl2.Controls.Add(this.lblStudentID);
            this.panelControl2.Controls.Add(this.btnSearch);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 22);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1188, 72);
            this.panelControl2.TabIndex = 5;
            // 
            // txtBookName
            // 
            this.txtBookName.Location = new System.Drawing.Point(267, 43);
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.txtBookName.Properties.ReadOnly = true;
            this.txtBookName.Size = new System.Drawing.Size(150, 20);
            this.txtBookName.TabIndex = 30;
            // 
            // txtBookID
            // 
            this.txtBookID.Location = new System.Drawing.Point(117, 43);
            this.txtBookID.Name = "txtBookID";
            this.txtBookID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtBookID.Properties.ReadOnly = true;
            this.txtBookID.Size = new System.Drawing.Size(150, 20);
            this.txtBookID.TabIndex = 29;
            // 
            // lblBookID
            // 
            this.lblBookID.Location = new System.Drawing.Point(21, 46);
            this.lblBookID.Name = "lblBookID";
            this.lblBookID.Size = new System.Drawing.Size(23, 13);
            this.lblBookID.TabIndex = 28;
            this.lblBookID.Text = "Ном:";
            // 
            // txtStudentName
            // 
            this.txtStudentName.Location = new System.Drawing.Point(267, 17);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.txtStudentName.Properties.ReadOnly = true;
            this.txtStudentName.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtStudentName_Properties_ButtonClick);
            this.txtStudentName.Size = new System.Drawing.Size(150, 20);
            this.txtStudentName.TabIndex = 26;
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(117, 17);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtStudentID.Properties.ReadOnly = true;
            this.txtStudentID.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtStudentID_Properties_ButtonClick);
            this.txtStudentID.Size = new System.Drawing.Size(150, 20);
            this.txtStudentID.TabIndex = 25;
            // 
            // lblStudentID
            // 
            this.lblStudentID.Location = new System.Drawing.Point(21, 20);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(45, 13);
            this.lblStudentID.TabIndex = 24;
            this.lblStudentID.Text = "Оюутан:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(456, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Хайх";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmBookOrderPayList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 638);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.KeyPreview = true;
            this.Name = "frmBookOrderPayList";
            this.Text = "Ном төлсөн оюутнуудын лавлагаа";
            this.Load += new System.EventHandler(this.frmBookOrderPayList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.COLGENDER)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBookName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBookID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStudentName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStudentID.Properties)).EndInit();
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
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn STUDENTID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn STUDENTCODE;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn STUDENTNAME;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn REASON;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn TAKEDATE;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn BOOKCODE;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn BOOKNAME;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn NOTE;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn RETURNEDDATE;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn ORDERID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn BOOKID;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.ButtonEdit txtStudentName;
        private DevExpress.XtraEditors.ButtonEdit txtStudentID;
        private DevExpress.XtraEditors.LabelControl lblStudentID;
        private DevExpress.XtraEditors.ButtonEdit txtBookName;
        private DevExpress.XtraEditors.ButtonEdit txtBookID;
        private DevExpress.XtraEditors.LabelControl lblBookID;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn OUT;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn PURCHASE;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraBars.BarButtonItem barExcel;


    }
}