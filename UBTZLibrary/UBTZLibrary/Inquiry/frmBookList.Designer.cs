namespace UBTZLibrary.Inquiry
{
    partial class frmBookList
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
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BOOKID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CATEGORYNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VOLUMENUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TOTALVOLUMENUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PRINTEDYEAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PRINTEDVERSION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ISBN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ISACTIVE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.PRICE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LANGUAGE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PAGESIZE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PRINTEDPLACE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WITHCD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ISEBOOK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.COLGENDER = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.barManager2 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barAction = new DevExpress.XtraBars.BarSubItem();
            this.barClose = new DevExpress.XtraBars.BarButtonItem();
            this.barNew = new DevExpress.XtraBars.BarButtonItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.COLGENDER)).BeginInit();
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
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.COLGENDER,
            this.repositoryItemCheckEdit1});
            this.gridControl1.Size = new System.Drawing.Size(820, 490);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BOOKID,
            this.CODE,
            this.NAME,
            this.CATEGORYNAME,
            this.VOLUMENUM,
            this.TOTALVOLUMENUM,
            this.PRINTEDYEAR,
            this.PRINTEDVERSION,
            this.ISBN,
            this.ISACTIVE,
            this.PRICE,
            this.LANGUAGE,
            this.PAGESIZE,
            this.PRINTEDPLACE,
            this.WITHCD,
            this.ISEBOOK});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindNullPrompt = "Хайх";
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // BOOKID
            // 
            this.BOOKID.Caption = "Дугаар";
            this.BOOKID.FieldName = "BOOKID";
            this.BOOKID.Name = "BOOKID";
            // 
            // CODE
            // 
            this.CODE.Caption = "Код";
            this.CODE.FieldName = "CODE";
            this.CODE.Name = "CODE";
            this.CODE.Visible = true;
            this.CODE.VisibleIndex = 0;
            // 
            // NAME
            // 
            this.NAME.Caption = "Нэр";
            this.NAME.FieldName = "NAME";
            this.NAME.Name = "NAME";
            this.NAME.Visible = true;
            this.NAME.VisibleIndex = 1;
            // 
            // CATEGORYNAME
            // 
            this.CATEGORYNAME.Caption = "Ангилал";
            this.CATEGORYNAME.FieldName = "CATEGORYNAME";
            this.CATEGORYNAME.Name = "CATEGORYNAME";
            this.CATEGORYNAME.Visible = true;
            this.CATEGORYNAME.VisibleIndex = 2;
            // 
            // VOLUMENUM
            // 
            this.VOLUMENUM.Caption = "Хэд дэхь боть";
            this.VOLUMENUM.FieldName = "VOLUMENUM";
            this.VOLUMENUM.Name = "VOLUMENUM";
            this.VOLUMENUM.Visible = true;
            this.VOLUMENUM.VisibleIndex = 3;
            // 
            // TOTALVOLUMENUM
            // 
            this.TOTALVOLUMENUM.Caption = "Нийт ботийн тоо";
            this.TOTALVOLUMENUM.FieldName = "TOTALVOLUMENUM";
            this.TOTALVOLUMENUM.Name = "TOTALVOLUMENUM";
            this.TOTALVOLUMENUM.Visible = true;
            this.TOTALVOLUMENUM.VisibleIndex = 4;
            // 
            // PRINTEDYEAR
            // 
            this.PRINTEDYEAR.Caption = "Хэвлэсэн он";
            this.PRINTEDYEAR.FieldName = "PRINTEDYEAR";
            this.PRINTEDYEAR.Name = "PRINTEDYEAR";
            this.PRINTEDYEAR.Visible = true;
            this.PRINTEDYEAR.VisibleIndex = 5;
            // 
            // PRINTEDVERSION
            // 
            this.PRINTEDVERSION.Caption = "Хэд дэх хэвлэл";
            this.PRINTEDVERSION.FieldName = "PRINTEDVERSION";
            this.PRINTEDVERSION.Name = "PRINTEDVERSION";
            this.PRINTEDVERSION.Visible = true;
            this.PRINTEDVERSION.VisibleIndex = 6;
            // 
            // ISBN
            // 
            this.ISBN.Caption = "ISBN";
            this.ISBN.FieldName = "ISBN";
            this.ISBN.Name = "ISBN";
            this.ISBN.Visible = true;
            this.ISBN.VisibleIndex = 7;
            // 
            // ISACTIVE
            // 
            this.ISACTIVE.Caption = "Идэвхтэй эсэх";
            this.ISACTIVE.ColumnEdit = this.repositoryItemCheckEdit1;
            this.ISACTIVE.FieldName = "ISACTIVE";
            this.ISACTIVE.Name = "ISACTIVE";
            this.ISACTIVE.Visible = true;
            this.ISACTIVE.VisibleIndex = 8;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.ValueChecked = "Y";
            this.repositoryItemCheckEdit1.ValueUnchecked = "N";
            // 
            // PRICE
            // 
            this.PRICE.Caption = "Үнэ";
            this.PRICE.FieldName = "PRICE";
            this.PRICE.Name = "PRICE";
            this.PRICE.Visible = true;
            this.PRICE.VisibleIndex = 9;
            // 
            // LANGUAGE
            // 
            this.LANGUAGE.Caption = "Бичигдсэн хэл";
            this.LANGUAGE.FieldName = "LANGUAGE";
            this.LANGUAGE.Name = "LANGUAGE";
            this.LANGUAGE.Visible = true;
            this.LANGUAGE.VisibleIndex = 10;
            // 
            // PAGESIZE
            // 
            this.PAGESIZE.Caption = "Хуудсын тоо";
            this.PAGESIZE.FieldName = "PAGESIZE";
            this.PAGESIZE.Name = "PAGESIZE";
            this.PAGESIZE.Visible = true;
            this.PAGESIZE.VisibleIndex = 11;
            // 
            // PRINTEDPLACE
            // 
            this.PRINTEDPLACE.Caption = "Хэвлэсэн газар";
            this.PRINTEDPLACE.FieldName = "PRINTEDPLACE";
            this.PRINTEDPLACE.Name = "PRINTEDPLACE";
            this.PRINTEDPLACE.Visible = true;
            this.PRINTEDPLACE.VisibleIndex = 12;
            // 
            // WITHCD
            // 
            this.WITHCD.Caption = "СD-тэй";
            this.WITHCD.ColumnEdit = this.repositoryItemCheckEdit1;
            this.WITHCD.FieldName = "WITHCD";
            this.WITHCD.Name = "WITHCD";
            this.WITHCD.Visible = true;
            this.WITHCD.VisibleIndex = 13;
            // 
            // ISEBOOK
            // 
            this.ISEBOOK.Caption = "e-Номтой";
            this.ISEBOOK.ColumnEdit = this.repositoryItemCheckEdit1;
            this.ISEBOOK.FieldName = "ISEBOOK";
            this.ISEBOOK.Name = "ISEBOOK";
            this.ISEBOOK.Visible = true;
            this.ISEBOOK.VisibleIndex = 14;
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
            this.barNew,
            this.barRefresh,
            this.barAction,
            this.barClose,
            this.barExcel});
            this.barManager2.MainMenu = this.bar2;
            this.barManager2.MaxItemId = 6;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barAction, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barNew, true),
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
            // barNew
            // 
            this.barNew.Caption = "Шинэ";
            this.barNew.Id = 1;
            this.barNew.Name = "barNew";
            this.barNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barNew_ItemClick);
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
            this.barExcel.Id = 5;
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
            // frmBookList
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
            this.Name = "frmBookList";
            this.Text = "Номын жагсаалт";
            this.Load += new System.EventHandler(this.frmBookList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.COLGENDER)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem barNew;
        private DevExpress.XtraBars.BarButtonItem barRefresh;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn BOOKID;
        private DevExpress.XtraGrid.Columns.GridColumn CODE;
        private DevExpress.XtraGrid.Columns.GridColumn NAME;
        private DevExpress.XtraGrid.Columns.GridColumn CATEGORYNAME;
        private DevExpress.XtraGrid.Columns.GridColumn VOLUMENUM;
        private DevExpress.XtraGrid.Columns.GridColumn TOTALVOLUMENUM;
        private DevExpress.XtraGrid.Columns.GridColumn PRINTEDYEAR;
        private DevExpress.XtraGrid.Columns.GridColumn PRINTEDVERSION;
        private DevExpress.XtraGrid.Columns.GridColumn ISBN;
        private DevExpress.XtraBars.BarSubItem barAction;
        private DevExpress.XtraBars.BarButtonItem barClose;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit COLGENDER;
        private System.Windows.Forms.BindingSource dataSetBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn ISACTIVE;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraBars.BarButtonItem barExcel;
        private DevExpress.XtraGrid.Columns.GridColumn PRICE;
        private DevExpress.XtraGrid.Columns.GridColumn LANGUAGE;
        private DevExpress.XtraGrid.Columns.GridColumn PAGESIZE;
        private DevExpress.XtraGrid.Columns.GridColumn PRINTEDPLACE;
        private DevExpress.XtraGrid.Columns.GridColumn WITHCD;
        private DevExpress.XtraGrid.Columns.GridColumn ISEBOOK;


    }
}