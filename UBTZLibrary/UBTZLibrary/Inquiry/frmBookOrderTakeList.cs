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
    public partial class frmBookOrderTakeList : DevExpress.XtraEditors.XtraForm
    {
        string formMode = string.Empty;
        string entryID = string.Empty;

        DataTable mainTable;
        SqlCommand command;

        private object[] para;
        public DataRow returnRow;

        public frmBookOrderTakeList()
        {
            InitializeComponent();
        }

        public frmBookOrderTakeList(object[] para)
        {
            this.para = para;
            InitializeComponent();
        }

        private void frmBookOrderTakeList_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormClosed += frmBookOrderTakeList_FormClosed;
                this.txtBookName.Properties.ButtonClick += txtBookName_Properties_ButtonClick;
                this.txtBookID.Properties.ButtonClick += txtBookID_Properties_ButtonClick;
                txtIsReturned.EditValue = "NULL";
                mainTable = new DataTable();
            }
            catch (Exception EX)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(EX.Message);
            }
        }

        void frmBookOrderTakeList_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mainTable != null)
                mainTable.Dispose();
            if (command != null)
                command.Dispose();
        }

        private void barCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            refreshData();
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

                string whereStr = " WHERE TBLBOOKORDER.STATUS = 1";
                if (txtStudentID.Tag != null)
                {
                    whereStr += " AND TBLBOOKORDER.STUDENTID = '" + Convert.ToString(txtStudentID.Tag) + "'";
                }
                if (txtBookID.Tag != null)
                {
                    whereStr += " AND TBLBOOKORDER.BOOKID = '" + Convert.ToString(txtBookID.Tag) + "'";
                }
                if (Convert.ToString(txtIsReturned.EditValue).Equals("Y"))
                {
                    whereStr += " AND TBLBOOKORDER.LATEDAY > 0";
                }
                try
                {
                    command = new SqlCommand();
                    command.Connection = frmMain.conn;
                    command.CommandText = @"SELECT TBLBOOKORDER.*,
                                                   TBLSTUDENT.CODE      STUDENTCODE,
                                                   TBLSTUDENT.FIRSTNAME STUDENTNAME,
                                                   TBLSTUDENT.LASTNAME,
                                                   TBLSTUDENT.REGNO,
                                                   TBLSTUDENT.GENDER,
                                                   TBLBOOK.CODE         BOOKCODE,
                                                   TBLBOOK.NAME         BOOKNAME
                                              FROM (SELECT CASE
                                                             WHEN DATEDIFF(dd, TBLBOOKORDER.RETURNDATE, ISNULL(TBLBOOKORDER.RETURNEDDATE, getdate())) <= 0 THEN
                                                              0
                                                             ELSE
                                                              FLOOR(DATEDIFF(dd, TBLBOOKORDER.RETURNDATE, ISNULL(TBLBOOKORDER.RETURNEDDATE, getdate())))
                                                           END LATEDAY,
                                                           TBLBOOKORDER.*
                                                      FROM TBLBOOKORDER) TBLBOOKORDER
                                              LEFT JOIN TBLSTUDENT
                                                ON TBLBOOKORDER.STUDENTID = TBLSTUDENT.STUDENTID
                                              LEFT JOIN TBLBOOK
                                                ON TBLBOOK.BOOKID = TBLBOOKORDER.BOOKID" + whereStr;
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
            catch (Exception ex)
            {
                dlg.Close();
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        void txtBookID_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmBookList frmBookList = new frmBookList(new object[] { "Browse", "TBLBOOK.ISACTIVE = 'Y' AND 1 = 1" });
            frmBookList.FormClosed += frmBookList_FormClosed;
            frmBookList.ShowDialog();
        }

        void frmBookList_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataRow dr = ((frmBookList)sender).returnRow;
            if (dr == null)
                return;
            txtBookID.Tag = Convert.ToString(dr["BOOKID"]);
            txtBookName.Text = Convert.ToString(dr["NAME"]);
            txtBookID.Text = Convert.ToString(dr["CODE"]);
        }

        void txtBookName_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtBookID.Tag = null;
            txtBookName.Text = string.Empty;
            txtBookID.Text = string.Empty;
        }

        private void txtStudentName_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtStudentID.Tag = null;
            txtStudentName.Text = string.Empty;
            txtStudentID.Text = string.Empty;
        }

        private void txtStudentID_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmStudentList frmObjStudentList = new frmStudentList(new object[] { "Browse" });
            frmObjStudentList.FormClosed += frmObjStudentList_FormClosed;
            frmObjStudentList.ShowDialog();
        }

        void frmObjStudentList_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataRow dr = ((frmStudentList)sender).returnRow;
            if (dr == null)
                return;
            txtStudentID.Tag = Convert.ToString(dr["STUDENTID"]);
            txtStudentName.Text = Convert.ToString(dr["FIRSTNAME"]);
            txtStudentID.Text = Convert.ToString(dr["CODE"]);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            refreshData();
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
            frmBookOrder frmBookOrder = new frmBookOrder(new object[] { dr["STUDENTID"], dr["STUDENTCODE"], dr["STUDENTNAME"], dr["LASTNAME"], dr["REGNO"], dr["GENDER"] });
            frmBookOrder.FormClosed += frmObj_FormClosed;
            frmBookOrder.MdiParent = frmMain.ActiveForm;
            frmBookOrder.Show();
        }

        private void barExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmMain.ExportExcel(gridControl1, bandedGridView1);
        }

    }
}