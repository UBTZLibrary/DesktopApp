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
using System.Data.SqlClient;

namespace UBTZLibrary.Inquiry
{
    public partial class frmCategoryList : DevExpress.XtraEditors.XtraForm
    {
        DataTable mainTable;
        SqlCommand command;
        private object[] para;
        public DataRow returnRow;

        public frmCategoryList()
        {
            InitializeComponent();
        }

        public frmCategoryList(object[] para)
        {
            this.para = para;
            InitializeComponent();
        }

        private void frmCategoryList_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormClosed += frmCategoryList_FormClosed;
                this.gridControl1.DoubleClick += gridControl1_DoubleClick;
                if (para != null)
                {
                    bar2.Dispose();
                }
                mainTable = new DataTable();
                barNew.ShortCut = Shortcut.CtrlN;
                refreshData();
            }
            catch (Exception EX)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(EX.Message);
            }
        }

        void frmCategoryList_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mainTable != null)
                mainTable.Dispose();
            if (command != null)
                command.Dispose();
        }

        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCategory frmObj = new frmCategory();
            frmObj.FormClosed += frmObj_FormClosed;
            frmObj.MdiParent = frmMain.ActiveForm;
            frmObj.Show();
        }

        void gridControl1_DoubleClick(object sender, EventArgs e)
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
            frmCategory frmObj = new frmCategory(new object[] { dr["CATEGORYID"] });
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
                    command.CommandText = "SELECT * FROM TBLCATEGORY WHERE " + para[1] + " ORDER BY CREATED DESC";
                else
                    command.CommandText = "SELECT * FROM TBLCATEGORY ORDER BY CREATED DESC";
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

        private void barExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmMain.ExportExcel(gridControl1, gridView1);
        }

    }
}