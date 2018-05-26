using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using UBTZLibrary.GeneralInfo;
using DevExpress.XtraEditors.Repository;
using System.Data.SqlClient;

namespace UBTZLibrary.Inquiry
{
    public partial class frmBookRemainderList : DevExpress.XtraEditors.XtraForm
    {
        string formMode = string.Empty;
        string entryID = string.Empty;
        DataTable mainTableDTLGrid;
        DataTable mainTableDTLGridView;
        SqlDataAdapter adapterDTLGrid;
        SqlDataAdapter adapterDTLGridView;
        SqlCommandBuilder builderDTLGrid;
        private object[] para;
        public DataRow returnRow;

        public frmBookRemainderList()
        {
            InitializeComponent();
        }

        public frmBookRemainderList(object[] para)
        {
            this.para = para;
            InitializeComponent();
        }

        private void frmBookRemainderList_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormClosed += frmBookRemainderList_FormClosed;
                this.bandedGridView1.CellValueChanging += bandedGridView1_CellValueChanging;
                refreshData();
            }
            catch (Exception EX)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(EX.Message);
            }
        }

        void bandedGridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle == -2147483646)
                return;
            DataRow tempRow = bandedGridView1.GetFocusedDataRow();
            DataRow mainRow = mainTableDTLGrid.Select("BOOKID = '" + tempRow["BOOKID"] + "'")[0];
            switch (e.Column.FieldName)
            {
                case "NOTE": mainRow["NOTE"] = e.Value; break;
            }

            if (!barSave.Enabled)
            {
                barSave.Enabled = true;
                barCancel.Enabled = true;
                barRefresh.Enabled = false;
            }
        }

        void frmBookRemainderList_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mainTableDTLGrid != null)
                mainTableDTLGrid.Dispose();
            if (mainTableDTLGridView != null)
                mainTableDTLGridView.Dispose();
            if (adapterDTLGrid != null)
                adapterDTLGrid.Dispose();
            if (adapterDTLGridView != null)
                adapterDTLGridView.Dispose();
            if (builderDTLGrid != null)
                builderDTLGrid.Dispose();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = bandedGridView1.GetFocusedDataRow();
            if (dr == null)
                return;
            if (para != null)
            {
                returnRow = dr;
                Close();
                return;
            }
            frmBook frmBook = new frmBook(new object[] { dr["BOOKID"] });
            frmBook.FormClosed += frmObj_FormClosed;
            frmBook.MdiParent = frmMain.ActiveForm;
            frmBook.Show();
        }

        private void barCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refreshData();
        }

        private void barSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!barSave.Enabled)
                    return;
                if (mainTableDTLGrid.GetChanges() != null && mainTableDTLGrid.GetChanges().Rows.Count > 0)
                {
                    builderDTLGrid.GetUpdateCommand();
                    adapterDTLGrid.Update(mainTableDTLGrid);
                    mainTableDTLGrid.AcceptChanges();
                }
                formMode = "VIEW";
                barSave.Enabled = false;
                barCancel.Enabled = false;
                barRefresh.Enabled = true;
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        void frmObj_FormClosed(object sender, FormClosedEventArgs e)
        {
            refreshData();
        }

        private void barRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refreshData();
        }

        void refreshData()
        {
            DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Ачаалж байна...", "Түр хүлээнэ үү.");

            try
            {
                dlg.Show();

                mainTableDTLGrid = new DataTable();
                adapterDTLGrid = new SqlDataAdapter("SELECT * FROM TBLBOOKREMAINDER ORDER BY CREATED DESC", frmMain.conn);
                builderDTLGrid = new SqlCommandBuilder(adapterDTLGrid);
                adapterDTLGrid.Fill(mainTableDTLGrid);
                frmMain.dataTableColumnNameToUpper(mainTableDTLGrid);

                mainTableDTLGridView = new DataTable();
                adapterDTLGridView = new SqlDataAdapter("SELECT TBLBOOKREMAINDER.*, TBLBOOK.NAME, TBLBOOK.CODE FROM TBLBOOKREMAINDER LEFT JOIN TBLBOOK ON TBLBOOK.BOOKID = TBLBOOKREMAINDER.BOOKID ORDER BY TBLBOOKREMAINDER.CREATED", frmMain.conn);
                adapterDTLGridView.Fill(mainTableDTLGridView);
                frmMain.dataTableColumnNameToUpper(mainTableDTLGridView);
                gridControl1.DataSource = mainTableDTLGridView;

                barSave.Enabled = false;
                barCancel.Enabled = false;
                barRefresh.Enabled = true;
                
                dlg.Close();
            }
            catch (Exception ex)
            {
                dlg.Close();
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        private void barExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmMain.ExportExcel(gridControl1, bandedGridView1);
        }

        private void bandedGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "NOTE")
            {
                e.Appearance.BackColor = Color.FromArgb(234, 255, 234);
            }
        }

    }
}