namespace UBTZLibrary.GeneralInfo
{
    partial class frmBookPurchase
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barAction = new DevExpress.XtraBars.BarSubItem();
            this.barClose = new DevExpress.XtraBars.BarButtonItem();
            this.barNew = new DevExpress.XtraBars.BarButtonItem();
            this.barSave = new DevExpress.XtraBars.BarButtonItem();
            this.barDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barCancel = new DevExpress.XtraBars.BarButtonItem();
            this.barRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.lblPurchaseDate = new DevExpress.XtraEditors.LabelControl();
            this.lblNote = new DevExpress.XtraEditors.LabelControl();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PURCHASEDTLID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PURCHASEID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.TOTAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.UNITPRICE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TOTALPRICE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NOTE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtPurchaseDate = new DevExpress.XtraEditors.DateEdit();
            this.txtStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.txtNote = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchaseDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchaseDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barNew,
            this.barRefresh,
            this.barDelete,
            this.barSave,
            this.barCancel,
            this.barAction,
            this.barClose});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 8;
            this.barManager1.MdiMenuMergeStyle = DevExpress.XtraBars.BarMdiMenuMergeStyle.Never;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barAction, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barNew, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSave, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barDelete, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCancel, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barRefresh, true)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barAction
            // 
            this.barAction.Caption = "Үйлдэл";
            this.barAction.Id = 6;
            this.barAction.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barClose)});
            this.barAction.Name = "barAction";
            // 
            // barClose
            // 
            this.barClose.Caption = "Гарах";
            this.barClose.Id = 7;
            this.barClose.Name = "barClose";
            this.barClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barClose_ItemClick);
            // 
            // barNew
            // 
            this.barNew.Caption = "Шинэ";
            this.barNew.Id = 1;
            this.barNew.Name = "barNew";
            this.barNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barNew_ItemClick);
            // 
            // barSave
            // 
            this.barSave.Caption = "Хадгалах";
            this.barSave.Id = 4;
            this.barSave.Name = "barSave";
            this.barSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSave_ItemClick);
            // 
            // barDelete
            // 
            this.barDelete.Caption = "Устгах";
            this.barDelete.Id = 3;
            this.barDelete.Name = "barDelete";
            this.barDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barDelete_ItemClick);
            // 
            // barCancel
            // 
            this.barCancel.Caption = "Болих";
            this.barCancel.Id = 5;
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
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(678, 22);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 481);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(678, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 22);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 459);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(678, 22);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 459);
            // 
            // lblPurchaseDate
            // 
            this.lblPurchaseDate.Location = new System.Drawing.Point(19, 20);
            this.lblPurchaseDate.Name = "lblPurchaseDate";
            this.lblPurchaseDate.Size = new System.Drawing.Size(35, 13);
            this.lblPurchaseDate.TabIndex = 0;
            this.lblPurchaseDate.Text = "Огноо:";
            // 
            // lblNote
            // 
            this.lblNote.Location = new System.Drawing.Point(19, 47);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(46, 13);
            this.lblNote.TabIndex = 1;
            this.lblNote.Text = "Тайлбар:";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(354, 20);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(34, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Төлөв:";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Controls.Add(this.txtPurchaseDate);
            this.panelControl1.Controls.Add(this.txtStatus);
            this.panelControl1.Controls.Add(this.txtNote);
            this.panelControl1.Controls.Add(this.lblPurchaseDate);
            this.panelControl1.Controls.Add(this.lblNote);
            this.panelControl1.Controls.Add(this.lblStatus);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 22);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(678, 459);
            this.panelControl1.TabIndex = 11;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(12, 111);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemButtonEdit2});
            this.gridControl1.Size = new System.Drawing.Size(654, 336);
            this.gridControl1.TabIndex = 7;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.PURCHASEDTLID,
            this.PURCHASEID,
            this.CODE,
            this.NAME,
            this.TOTAL,
            this.UNITPRICE,
            this.TOTALPRICE,
            this.NOTE});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.ViewCaption = "Номнууд";
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            // 
            // PURCHASEDTLID
            // 
            this.PURCHASEDTLID.Caption = "Дугаар";
            this.PURCHASEDTLID.FieldName = "PURCHASEDTLID";
            this.PURCHASEDTLID.Name = "PURCHASEDTLID";
            // 
            // PURCHASEID
            // 
            this.PURCHASEID.Caption = "Дугаар";
            this.PURCHASEID.FieldName = "PURCHASEID";
            this.PURCHASEID.Name = "PURCHASEID";
            // 
            // CODE
            // 
            this.CODE.Caption = "Код";
            this.CODE.ColumnEdit = this.repositoryItemButtonEdit1;
            this.CODE.FieldName = "CODE";
            this.CODE.Name = "CODE";
            this.CODE.OptionsColumn.ReadOnly = true;
            this.CODE.Visible = true;
            this.CODE.VisibleIndex = 0;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // NAME
            // 
            this.NAME.Caption = "Нэр";
            this.NAME.ColumnEdit = this.repositoryItemButtonEdit2;
            this.NAME.FieldName = "NAME";
            this.NAME.Name = "NAME";
            this.NAME.OptionsColumn.ReadOnly = true;
            this.NAME.Visible = true;
            this.NAME.VisibleIndex = 1;
            // 
            // repositoryItemButtonEdit2
            // 
            this.repositoryItemButtonEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.repositoryItemButtonEdit2.Name = "repositoryItemButtonEdit2";
            // 
            // TOTAL
            // 
            this.TOTAL.Caption = "Нийт тоо";
            this.TOTAL.FieldName = "TOTAL";
            this.TOTAL.Name = "TOTAL";
            this.TOTAL.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL", "Нийт:{0:0.##}")});
            this.TOTAL.Visible = true;
            this.TOTAL.VisibleIndex = 2;
            // 
            // UNITPRICE
            // 
            this.UNITPRICE.Caption = "Нэгжийн үнэ";
            this.UNITPRICE.FieldName = "UNITPRICE";
            this.UNITPRICE.Name = "UNITPRICE";
            this.UNITPRICE.Visible = true;
            this.UNITPRICE.VisibleIndex = 3;
            // 
            // TOTALPRICE
            // 
            this.TOTALPRICE.Caption = "Нийт үнэ";
            this.TOTALPRICE.FieldName = "TOTALPRICE";
            this.TOTALPRICE.Name = "TOTALPRICE";
            this.TOTALPRICE.OptionsColumn.AllowEdit = false;
            this.TOTALPRICE.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTALPRICE", "Нийт:{0:0.##}")});
            this.TOTALPRICE.Visible = true;
            this.TOTALPRICE.VisibleIndex = 4;
            // 
            // NOTE
            // 
            this.NOTE.Caption = "Тайлбар";
            this.NOTE.FieldName = "NOTE";
            this.NOTE.Name = "NOTE";
            this.NOTE.Visible = true;
            this.NOTE.VisibleIndex = 5;
            // 
            // txtPurchaseDate
            // 
            this.txtPurchaseDate.EditValue = null;
            this.txtPurchaseDate.Location = new System.Drawing.Point(122, 17);
            this.txtPurchaseDate.MenuManager = this.barManager1;
            this.txtPurchaseDate.Name = "txtPurchaseDate";
            this.txtPurchaseDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPurchaseDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPurchaseDate.Properties.DisplayFormat.FormatString = "yyyy.MM.dd";
            this.txtPurchaseDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtPurchaseDate.Properties.EditFormat.FormatString = "yyyy.MM.dd";
            this.txtPurchaseDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtPurchaseDate.Properties.Mask.EditMask = "yyyy.MM.dd";
            this.txtPurchaseDate.Size = new System.Drawing.Size(180, 20);
            this.txtPurchaseDate.TabIndex = 2;
            this.txtPurchaseDate.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.EditValueChanging);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(422, 17);
            this.txtStatus.MenuManager = this.barManager1;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtStatus.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NAME", "NAME")});
            this.txtStatus.Properties.DisplayMember = "NAME";
            this.txtStatus.Properties.ShowFooter = false;
            this.txtStatus.Properties.ShowHeader = false;
            this.txtStatus.Properties.ValueMember = "TYPE";
            this.txtStatus.Size = new System.Drawing.Size(180, 20);
            this.txtStatus.TabIndex = 4;
            this.txtStatus.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.EditValueChanging);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(122, 46);
            this.txtNote.MenuManager = this.barManager1;
            this.txtNote.Name = "txtNote";
            this.txtNote.Properties.MaxLength = 1000;
            this.txtNote.Size = new System.Drawing.Size(480, 45);
            this.txtNote.TabIndex = 5;
            this.txtNote.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.EditValueChanging);
            // 
            // frmBookPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(678, 481);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.Name = "frmBookPurchase";
            this.Text = "Ном - Орлогодох";
            this.Load += new System.EventHandler(this.frmBookPurchase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchaseDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchaseDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barNew;
        private DevExpress.XtraBars.BarButtonItem barRefresh;
        private DevExpress.XtraBars.BarButtonItem barSave;
        private DevExpress.XtraBars.BarButtonItem barDelete;
        private DevExpress.XtraBars.BarButtonItem barCancel;
        private DevExpress.XtraBars.BarSubItem barAction;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.LabelControl lblNote;
        private DevExpress.XtraEditors.LabelControl lblPurchaseDate;
        private DevExpress.XtraBars.BarButtonItem barClose;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.MemoEdit txtNote;
        private DevExpress.XtraEditors.LookUpEdit txtStatus;
        private DevExpress.XtraEditors.DateEdit txtPurchaseDate;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn PURCHASEDTLID;
        private DevExpress.XtraGrid.Columns.GridColumn PURCHASEID;
        private DevExpress.XtraGrid.Columns.GridColumn CODE;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn NAME;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn TOTAL;
        private DevExpress.XtraGrid.Columns.GridColumn UNITPRICE;
        private DevExpress.XtraGrid.Columns.GridColumn TOTALPRICE;
        private DevExpress.XtraGrid.Columns.GridColumn NOTE;
    }
}