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
    public partial class frmBookList : DevExpress.XtraEditors.XtraForm
    {
        DataTable mainTable;
        SqlCommand command;
        private object[] para;
        public DataRow returnRow;

        public frmBookList()
        {
            InitializeComponent();
        }

        public frmBookList(object[] para)
        {
            this.para = para;
            InitializeComponent();
        }

        private void frmBookList_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormClosed += frmBookList_FormClosed;
                mainTable = new DataTable();
                if (para != null)
                {
                    barNew.Enabled = false;
                    barRefresh.Enabled = false;
                }
                else
                {
                    barNew.ShortCut = Shortcut.CtrlN;
                }
                refreshData();
            }
            catch (Exception EX)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(EX.Message);
            }
            finally
            {
            }
        }

        void frmBookList_FormClosed(object sender, FormClosedEventArgs e)
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
            frmBook frmObj = new frmBook(new object[] { dr["BOOKID"] });
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
            frmBook frmObj = new frmBook();
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
                    command.CommandText = "SELECT TBLBOOK.*, TBLCATEGORY.NAME CATEGORYNAME FROM TBLBOOK LEFT JOIN TBLCATEGORY ON TBLCATEGORY.CATEGORYID = TBLBOOK.CATEGORYID WHERE " + para[1] + " ORDER BY TBLBOOK.CREATED";
                else
                    command.CommandText = "SELECT TBLBOOK.*, TBLCATEGORY.NAME CATEGORYNAME FROM TBLBOOK LEFT JOIN TBLCATEGORY ON TBLCATEGORY.CATEGORYID = TBLBOOK.CATEGORYID ORDER BY TBLBOOK.CREATED";
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
            finally
            {
            }
        }

        private void barExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmMain.ExportExcel(gridControl1, gridView1);
        }

    }
}