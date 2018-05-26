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
    public partial class frmBookOrderResolution : DevExpress.XtraEditors.XtraForm
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

        public frmBookOrderResolution()
        {
            InitializeComponent();
        }

        public frmBookOrderResolution(object[] para)
        {
            this.para = para;
            InitializeComponent();
        }

        private void frmBookOrderResolution_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormClosed += frmBookOrderResolution_FormClosed;
                this.bandedGridView1.CellValueChanging += bandedGridView1_CellValueChanging;
                barSave.Enabled = false;
                barCancel.Enabled = false;
                barRefresh.Enabled = true;
                refreshData();
            }
            catch (Exception EX)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(EX.Message);
            }
        }

        private void bandedGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "GIVEDATE")
            {
                e.Appearance.BackColor = frmMain.greenColor;
            }
        }

        void bandedGridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle == -2147483646)
                return;
            DataRow tempRow = bandedGridView1.GetFocusedDataRow();
            DataRow mainRow = mainTableDTLGrid.Select("ORDERID = '" + tempRow["ORDERID"] + "'")[0];
            switch (e.Column.FieldName)
            {
                case "GIVEDATE":
                    if (e.Value == null)
                        mainRow["GIVEDATE"] = DBNull.Value;
                    else
                        mainRow["GIVEDATE"] = e.Value; break;
            }
            if (mainRow["ORDERDATE"] != DBNull.Value && mainRow["GIVEDATE"] != DBNull.Value)
                if (Convert.ToDateTime(mainRow["ORDERDATE"]) > Convert.ToDateTime(mainRow["GIVEDATE"]))
                {
                    tempRow.RowError = "<Олгох огноо> талбарын утга <Захиалсан огноо>-оос урагш байж болохгүй.";
                }
                else
                {
                    tempRow.ClearErrors();
                }
            if (!barSave.Enabled)
            {
                barSave.Enabled = true;
                barCancel.Enabled = true;
                barRefresh.Enabled = false;
            }
        }

        void frmBookOrderResolution_FormClosed(object sender, FormClosedEventArgs e)
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
                foreach (DataRow dr in (gridControl1.DataSource as DataTable).Select())
                {
                    if (!string.IsNullOrEmpty(dr.RowError))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(dr.RowError);
                        return;
                    }
                }
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

                string studentID = string.Empty;
                if (txtStudentID.Tag != null)
                {
                    studentID = "WHERE TBLBOOKORDER.STUDENTID = '" + Convert.ToString(txtStudentID.Tag) + "'";
                }
                mainTableDTLGrid = new DataTable();
                adapterDTLGrid = new SqlDataAdapter("SELECT * FROM TBLBOOKORDER " + (string.IsNullOrEmpty(studentID) ? " WHERE STATUS = '0' " : studentID + " AND STATUS = '0' ") + " ORDER BY CREATED DESC", frmMain.conn);
                builderDTLGrid = new SqlCommandBuilder(adapterDTLGrid);
                adapterDTLGrid.Fill(mainTableDTLGrid);
                frmMain.dataTableColumnNameToUpper(mainTableDTLGrid);

                mainTableDTLGridView = new DataTable();
                adapterDTLGridView = new SqlDataAdapter(@"SELECT TBLBOOKORDER.*,
                                                                   TBLSTUDENT.FIRSTNAME             STUDENTNAME,
                                                                   TBLSTUDENT.CODE                  STUDENTCODE,
                                                                   TBLSTUDENT.LASTNAME,
                                                                   TBLSTUDENT.REGNO,
                                                                   TBLSTUDENT.GENDER,
                                                                   TBLBOOK.NAME                     BOOKNAME,
                                                                   TBLBOOK.CODE                     BOOKCODE,
                                                                   TBLBOOKREMAINDER.REMAINDER,
                                                                   TBLBOOKREMAINDER.FIRSTRETURNDATE
                                                              FROM TBLBOOKORDER
                                                              LEFT JOIN TBLSTUDENT
                                                                ON TBLSTUDENT.STUDENTID = TBLBOOKORDER.STUDENTID
                                                              LEFT JOIN TBLBOOK
                                                                ON TBLBOOK.BOOKID = TBLBOOKORDER.BOOKID
                                                              LEFT JOIN TBLBOOKREMAINDER
                                                                ON TBLBOOKREMAINDER.BOOKID = TBLBOOK.BOOKID
                                                             " + (string.IsNullOrEmpty(studentID) ? " WHERE TBLBOOKORDER.STATUS = '0' " : studentID + " AND TBLBOOKORDER.STATUS = '0' ") + @"
                                                             ORDER BY TBLBOOKORDER.CREATED", frmMain.conn);
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

        private void barExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmMain.ExportExcel(gridControl1, bandedGridView1);
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

    }
}