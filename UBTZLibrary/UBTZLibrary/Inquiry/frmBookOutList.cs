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
    public partial class frmBookOutList : DevExpress.XtraEditors.XtraForm
    {
        DataTable mainTable;
        SqlCommand command;
        private object[] para;
        public DataRow returnRow;

        public frmBookOutList()
        {
            InitializeComponent();
        }

        public frmBookOutList(object[] para)
        {
            this.para = para;
            InitializeComponent();
        }

        private void frmBookOutList_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormClosed += frmBookOutList_FormClosed;
                if (para != null)
                {
                    barNew.Enabled = false;
                    barRefresh.Enabled = false;
                }
                else
                {
                    barNew.ShortCut = Shortcut.CtrlN;
                }
                getStatusLookUp();
                mainTable = new DataTable();
                refreshData();
            }
            catch (Exception EX)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(EX.Message);
            }
        }

        void frmBookOutList_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mainTable != null)
                mainTable.Dispose();
            if (command != null)
                command.Dispose();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr == null)
                return;
            if (para != null)
            {
                returnRow = dr;
                Close();
                return;
            }
            frmBookOut frmObj = new frmBookOut(new object[] { dr["BOOKOUTID"] });
            frmObj.FormClosed += frmObj_FormClosed;
            frmObj.MdiParent = frmMain.ActiveForm;
            frmObj.Show();
        }

        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBookOut frmObj = new frmBookOut();
            frmObj.FormClosed += frmObj_FormClosed;
            frmObj.MdiParent = frmMain.ActiveForm;
            frmObj.Show();
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

                command = new SqlCommand();
                command.Connection = frmMain.conn;
                if (para != null)
                    command.CommandText = "SELECT * FROM TBLBOOKOUT WHERE " + para[1] + " ORDER BY CREATED DESC";
                else
                    command.CommandText = "SELECT * FROM TBLBOOKOUT ORDER BY CREATED DESC";
                command.CommandType = CommandType.Text;

                SqlDataReader dr = command.ExecuteReader();
                mainTable.Clear();
                mainTable.Load(dr);
                frmMain.dataTableColumnNameToUpper(mainTable);
                gridControl1.DataSource = mainTable;
                command.Dispose();

                dlg.Close();
            }
            catch (Exception ex)
            {
                dlg.Close();
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        void getStatusLookUp()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NAME");
            dt.Columns.Add("TYPE");
            DataRow dr = dt.NewRow();
            dr["NAME"] = "Бүртгэж байна";
            dr["TYPE"] = 0;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["NAME"] = "Баталсан";
            dr["TYPE"] = 2;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["NAME"] = "Цуцалсан";
            dr["TYPE"] = 9;
            dt.Rows.Add(dr);
            (gridView1.Columns["STATUS"].ColumnEdit as RepositoryItemLookUpEdit).DataSource = dt;
        }

        private void barExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmMain.ExportExcel(gridControl1, gridView1);
        }

    }
}