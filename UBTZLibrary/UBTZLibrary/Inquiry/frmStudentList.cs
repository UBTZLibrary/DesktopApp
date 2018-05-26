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
    public partial class frmStudentList : DevExpress.XtraEditors.XtraForm
    {
        DataTable mainTable;
        SqlCommand command;
        private object[] para;
        public DataRow returnRow;

        public frmStudentList()
        {
            InitializeComponent();
        }

        public frmStudentList(object[] para)
        {
            this.para = para;
            InitializeComponent();
        }

        private void frmStudentList_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormClosed += frmStudentList_FormClosed;
                if (para != null)
                {
                    barNew.Enabled = false;
                    barRefresh.Enabled = false;
                }
                else
                {
                    barNew.ShortCut = Shortcut.CtrlN;
                }
                mainTable = new DataTable();
                getGenderLookUp();
                refreshData();
            }
            catch (Exception EX)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(EX.Message);
            }
        }

        void frmStudentList_FormClosed(object sender, FormClosedEventArgs e)
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
            frmStudent frmObj = new frmStudent(new object[] { dr["STUDENTID"] });
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
            frmStudent frmObj = new frmStudent();
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
                command.CommandText = "SELECT TBLSTUDENT.*, Addr1 +' '+ Addr2 ADDRESS FROM TBLSTUDENT ORDER BY CREATED DESC";
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

        void getGenderLookUp()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NAME");
            dt.Columns.Add("TYPE");
            DataRow dr = dt.NewRow();
            dr["NAME"] = "Эрэгтэй";
            dr["TYPE"] = "M";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["NAME"] = "Эмэгтэй";
            dr["TYPE"] = "F";
            dt.Rows.Add(dr);
            (gridView1.Columns["GENDER"].ColumnEdit as RepositoryItemLookUpEdit).DataSource = dt;
        }

        private void barExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmMain.ExportExcel(gridControl1, gridView1);
        }

    }
}