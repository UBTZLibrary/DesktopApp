namespace UBTZLibrary.GeneralInfo
{
    partial class frmAuthor
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
            this.lblCode = new DevExpress.XtraEditors.LabelControl();
            this.lblFirstName = new DevExpress.XtraEditors.LabelControl();
            this.lblLastName = new DevExpress.XtraEditors.LabelControl();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.txtFirstName = new DevExpress.XtraEditors.TextEdit();
            this.txtLastName = new DevExpress.XtraEditors.TextEdit();
            this.txtIsActive = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIsActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
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
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(19, 20);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(24, 13);
            this.lblCode.TabIndex = 4;
            this.lblCode.Text = "Код:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.Location = new System.Drawing.Point(19, 47);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(22, 13);
            this.lblFirstName.TabIndex = 5;
            this.lblFirstName.Text = "Нэр:";
            // 
            // lblLastName
            // 
            this.lblLastName.Location = new System.Drawing.Point(340, 20);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(90, 13);
            this.lblLastName.TabIndex = 6;
            this.lblLastName.Text = "Эцэг/Эх/-ийн нэр:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(122, 17);
            this.txtCode.MenuManager = this.barManager1;
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.MaxLength = 100;
            this.txtCode.Size = new System.Drawing.Size(180, 20);
            this.txtCode.TabIndex = 0;
            this.txtCode.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.EditValueChanging);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(122, 43);
            this.txtFirstName.MenuManager = this.barManager1;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Properties.MaxLength = 60;
            this.txtFirstName.Size = new System.Drawing.Size(180, 20);
            this.txtFirstName.TabIndex = 1;
            this.txtFirstName.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.EditValueChanging);
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(438, 17);
            this.txtLastName.MenuManager = this.barManager1;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Properties.MaxLength = 200;
            this.txtLastName.Size = new System.Drawing.Size(180, 20);
            this.txtLastName.TabIndex = 2;
            this.txtLastName.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.EditValueChanging);
            // 
            // txtIsActive
            // 
            this.txtIsActive.Location = new System.Drawing.Point(340, 44);
            this.txtIsActive.Name = "txtIsActive";
            this.txtIsActive.Properties.Caption = "Идэвхтэй эсэх:";
            this.txtIsActive.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtIsActive.Properties.ValueChecked = "Y";
            this.txtIsActive.Properties.ValueUnchecked = "N";
            this.txtIsActive.Size = new System.Drawing.Size(115, 19);
            this.txtIsActive.TabIndex = 3;
            this.txtIsActive.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.EditValueChanging);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblCode);
            this.panelControl1.Controls.Add(this.txtIsActive);
            this.panelControl1.Controls.Add(this.lblFirstName);
            this.panelControl1.Controls.Add(this.txtLastName);
            this.panelControl1.Controls.Add(this.lblLastName);
            this.panelControl1.Controls.Add(this.txtFirstName);
            this.panelControl1.Controls.Add(this.txtCode);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 22);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(678, 459);
            this.panelControl1.TabIndex = 11;
            // 
            // frmAuthor
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
            this.Name = "frmAuthor";
            this.Text = "Зохиогчийн бүртгэл";
            this.Load += new System.EventHandler(this.frmAuthor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIsActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
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
        private DevExpress.XtraEditors.CheckEdit txtIsActive;
        private DevExpress.XtraEditors.TextEdit txtLastName;
        private DevExpress.XtraEditors.TextEdit txtFirstName;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.LabelControl lblLastName;
        private DevExpress.XtraEditors.LabelControl lblFirstName;
        private DevExpress.XtraEditors.LabelControl lblCode;
        private DevExpress.XtraBars.BarButtonItem barClose;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}