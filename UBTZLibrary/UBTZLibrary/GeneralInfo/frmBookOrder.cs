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
using System.Data.SqlClient;
using UBTZLibrary.AssistantForm;
using System.IO;
using UBTZLibrary.Inquiry;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace UBTZLibrary.GeneralInfo
{
    public partial class frmBookOrder : DevExpress.XtraEditors.XtraForm
    {
        string formMode = string.Empty;
        string entryID = string.Empty;
        private object[] para;
        decimal FocusedOrderID;
        string whereStudentID = string.Empty;
        DataTable mainTableDTLGrid;
        DataTable mainTableDTLGridViewOrder;
        DataTable mainTableDTLGridViewGive;
        DataTable mainTableDTLGridViewReturned;

        SqlDataAdapter adapterDTLGrid;
        SqlDataAdapter adapterDTLGridViewOrder;
        SqlDataAdapter adapterDTLGridViewGive;
        SqlDataAdapter adapterDTLGridViewReturned;

        SqlCommandBuilder builderDTLGrid;

        public frmBookOrder()
        {
            InitializeComponent();
        }

        public frmBookOrder(object[] para)
        {
            this.para = para;
            InitializeComponent();
        }

        private void frmBookOrder_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormClosed += frmBookOrder_FormClosed;
                (gridViewGive.Columns["BOOKCODE"].ColumnEdit as RepositoryItemButtonEdit).ButtonClick += colBookCode_ButtonClick;
                (gridViewGive.Columns["BOOKNAME"].ColumnEdit as RepositoryItemButtonEdit).ButtonClick += colBookName_ButtonClick;
                gridViewReturned.CustomDrawCell += gridViewReturned_CustomDrawCell;
                barSave.ShortCut = Shortcut.CtrlS;
                getGenderLookUp();
                getReasonLookUp();
                setControlColorChange();
                setEnabledChange(false);
                if (para != null)
                {
                    txtStudentID.Tag = Convert.ToString(para[0]);
                    txtStudentID.Text = Convert.ToString(para[1]);
                    txtStudentName.Text = Convert.ToString(para[2]);
                    txtFirstName.EditValue = para[2];
                    txtLastName.EditValue = para[3];
                    txtRegNo.EditValue = para[4];
                    txtGender.EditValue = para[5];
                    txtPictureData.Image = getStudentPic(Convert.ToString(para[0]));
                    setModeChange("VIEW");
                }
                else
                {
                    barSave.Enabled = false;
                    barCancel.Enabled = false;
                    barRefresh.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Алдаа");
            }
        }

        void frmBookOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mainTableDTLGrid != null)
                mainTableDTLGrid.Dispose();
            if (mainTableDTLGridViewGive != null)
                mainTableDTLGridViewGive.Dispose();
            if (adapterDTLGrid != null)
                adapterDTLGrid.Dispose();
            if (adapterDTLGridViewGive != null)
                adapterDTLGridViewGive.Dispose();
            if (builderDTLGrid != null)
                builderDTLGrid.Dispose();
        }

        private void barSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            setModeChange("SAVE");
        }

        private void barRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            setModeChange("VIEW");
        }

        private void barCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            setModeChange("CANCEL");
        }

        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnOrderOfTakeLeft_Click(object sender, EventArgs e)
        {
            DataRow newRow, mainRow;
            bool isSave = false;
            foreach (DataRow dr in (gridControlGive.DataSource as DataTable).Select("CHECK = 'Y' AND ORDERDATE IS NOT NULL"))
            {
                newRow = (gridControlOrder.DataSource as DataTable).NewRow();
                newRow["ORDERID"] = dr["ORDERID"];
                newRow["STUDENTID"] = dr["STUDENTID"];
                newRow["BOOKID"] = dr["BOOKID"];

                newRow["BOOKCODE"] = dr["BOOKCODE"];
                newRow["BOOKNAME"] = dr["BOOKNAME"];
                newRow["STATUS"] = 0;
                newRow["ORDERDATE"] = dr["ORDERDATE"];
                newRow["GIVEDATE"] = dr["GIVEDATE"];

                mainRow = mainTableDTLGrid.Select("ORDERID = '" + dr["ORDERID"] + "'")[0];
                mainRow["STATUS"] = 0;
                mainRow["TAKEDATE"] = DBNull.Value;
                mainRow["RETURNDATE"] = DBNull.Value;
                dr.Delete();
                (gridControlOrder.DataSource as DataTable).Rows.Add(newRow);
                isSave = true;
            }
            if (!barSave.Enabled && isSave)
            {
                barSave.Enabled = true;
                barCancel.Enabled = true;
                barRefresh.Enabled = false;
            }
        }

        private void btnOrderOfTakeRight_Click(object sender, EventArgs e)
        {
            DataRow newRow, mainRow;
            bool isSave = false;
            foreach (DataRow dr in (gridControlOrder.DataSource as DataTable).Select("CHECK = 'Y'"))
            {
                newRow = (gridControlGive.DataSource as DataTable).NewRow();
                newRow["ORDERID"] = dr["ORDERID"];
                newRow["STUDENTID"] = dr["STUDENTID"];
                newRow["BOOKID"] = dr["BOOKID"];

                newRow["BOOKCODE"] = dr["BOOKCODE"];
                newRow["BOOKNAME"] = dr["BOOKNAME"];
                newRow["STATUS"] = 1;
                newRow["ORDERDATE"] = dr["ORDERDATE"];
                newRow["GIVEDATE"] = dr["GIVEDATE"];

                newRow["TAKEDATE"] = DateTime.Now;
                newRow["RETURNDATE"] = DateTime.Now.AddDays(3);

                mainRow = mainTableDTLGrid.Select("ORDERID = '" + dr["ORDERID"] + "'")[0];
                mainRow["STATUS"] = 1;
                mainRow["TAKEDATE"] = DateTime.Now;
                mainRow["RETURNDATE"] = DateTime.Now.AddDays(3);

                dr.Delete();
                (gridControlGive.DataSource as DataTable).Rows.Add(newRow);
                isSave = true;
            }
            if (!barSave.Enabled && isSave)
            {
                barSave.Enabled = true;
                barCancel.Enabled = true;
                barRefresh.Enabled = false;
            }
        }

        private void btnTakeOfReturnLeft_Click(object sender, EventArgs e)
        {
            DataRow newRow, mainRow;
            foreach (DataRow dr in (gridControlReturned.DataSource as DataTable).Select("CHECK = 'Y'"))
            {
                newRow = (gridControlGive.DataSource as DataTable).NewRow();
                newRow["ORDERID"] = dr["ORDERID"];
                newRow["STUDENTID"] = dr["STUDENTID"];
                newRow["BOOKID"] = dr["BOOKID"];

                newRow["BOOKCODE"] = dr["BOOKCODE"];
                newRow["BOOKNAME"] = dr["BOOKNAME"];
                newRow["STATUS"] = 1;
                newRow["ORDERDATE"] = dr["ORDERDATE"];
                newRow["GIVEDATE"] = dr["GIVEDATE"];

                newRow["TAKEDATE"] = dr["TAKEDATE"];
                newRow["RETURNDATE"] = dr["RETURNDATE"];

                mainRow = mainTableDTLGrid.Select("ORDERID = '" + dr["ORDERID"] + "'")[0];
                mainRow["STATUS"] = 1;
                mainRow["RETURNEDDATE"] = DBNull.Value;

                dr.Delete();
                (gridControlGive.DataSource as DataTable).Rows.Add(newRow);
            }
        }

        private void btnTakeOfReturnRight_Click(object sender, EventArgs e)
        {
            DataRow newRow, mainRow;
            bool isSave = false;
            foreach (DataRow dr in (gridControlGive.DataSource as DataTable).Select("CHECK = 'Y'"))
            {
                dr.ClearErrors();
                if (dr["RETURNDATE"] == DBNull.Value)
                {
                    dr.RowError = "<Буцааж өгөх огноо> талбарт утга оруулах шаардлагатай!";
                    continue;
                }
                newRow = (gridControlReturned.DataSource as DataTable).NewRow();
                newRow["ORDERID"] = dr["ORDERID"];
                newRow["STUDENTID"] = dr["STUDENTID"];
                newRow["BOOKID"] = dr["BOOKID"];

                newRow["BOOKCODE"] = dr["BOOKCODE"];
                newRow["BOOKNAME"] = dr["BOOKNAME"];
                newRow["STATUS"] = 2;
                newRow["REASON"] = 0;
                newRow["ORDERDATE"] = dr["ORDERDATE"];
                newRow["GIVEDATE"] = dr["GIVEDATE"];
                newRow["TAKEDATE"] = dr["TAKEDATE"];
                newRow["RETURNDATE"] = dr["RETURNDATE"];
                newRow["RETURNEDDATE"] = DateTime.Now;
                newRow["LATEDATE"] = (Convert.ToDateTime(dr["RETURNDATE"]) - DateTime.Now).Days >= 0 ? 0 : (Convert.ToDateTime(dr["RETURNDATE"]) - DateTime.Now).Days;
                mainRow = mainTableDTLGrid.Select("ORDERID = '" + dr["ORDERID"] + "'")[0];
                mainRow["STATUS"] = 2;
                mainRow["REASON"] = 0;
                mainRow["RETURNEDDATE"] = DateTime.Now;

                dr.Delete();
                (gridControlReturned.DataSource as DataTable).Rows.Add(newRow);
                isSave = true;
            }
            if (!barSave.Enabled && isSave)
            {
                barSave.Enabled = true;
                barCancel.Enabled = true;
                barRefresh.Enabled = false;
            }
        }

        private void gridViewGive_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            decimal newID = -1;
            DataRow tempRow;
            if (e != null && e.RowHandle == -2147483647)
                tempRow = gridViewGive.GetFocusedDataRow();
            else
                tempRow = (gridControlGive.DataSource as DataTable).Select("ORDERID is null")[0];

            FocusedOrderID = newID = frmMain.NewID("TBLBOOKORDER", "ORDERID");
            tempRow["ORDERID"] = newID;
            tempRow["STUDENTID"] = txtStudentID.Tag;
            tempRow["ORDERDATE"] = DBNull.Value;
            tempRow["STATUS"] = 1;

            DataRow newRow = mainTableDTLGrid.NewRow();
            newRow["ORDERID"] = newID;
            newRow["STUDENTID"] = txtStudentID.Tag;
            newRow["ORDERDATE"] = DBNull.Value;
            newRow["STATUS"] = 1;
            newRow["CREATED"] = DateTime.Now;
            newRow["CREATEDBY"] = frmLogin.LoginUserID;
            newRow["IPADDRESS"] = frmMain.GetIPAddress();
            newRow["MACADDRESS"] = frmMain.GetMACAddress();
            mainTableDTLGrid.Rows.Add(newRow);

            if (!barSave.Enabled)
            {
                barSave.Enabled = true;
                barCancel.Enabled = true;
                barRefresh.Enabled = false;
            }
        }

        private void gridViewGive_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            DataRow tempRow = gridViewGive.GetFocusedDataRow();

            if (tempRow != null && tempRow["ORDERID"] != DBNull.Value)
                FocusedOrderID = Convert.ToDecimal(tempRow["ORDERID"]);

            if (e.Column.FieldName.Equals("BOOKCODE") || e.Column.FieldName.Equals("BOOKNAME"))
                if (e.RowHandle > 0 && tempRow["BOOKID"] != DBNull.Value)
                    e.RepositoryItem.ReadOnly = true;
                else
                    e.RepositoryItem.ReadOnly = false;
        }

        private void gridViewGive_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow tempRow = gridViewGive.GetFocusedDataRow();
            DataRow mainRow = mainTableDTLGrid.Select("ORDERID = '" + tempRow["ORDERID"] + "'")[0];
            switch (e.Column.FieldName)
            {
                case "TAKEDATE": mainRow["TAKEDATE"] = e.Value; mainRow["RETURNDATE"] = Convert.ToDateTime(e.Value).AddDays(3); tempRow["RETURNDATE"] = mainRow["RETURNDATE"]; break;
                case "RETURNDATE": mainRow["RETURNDATE"] = e.Value; break;
            }
            if (mainRow["TAKEDATE"] != DBNull.Value && mainRow["RETURNDATE"] != DBNull.Value)
                if (Convert.ToDateTime(mainRow["TAKEDATE"]) > Convert.ToDateTime(mainRow["RETURNDATE"]))
                {
                    tempRow.RowError = "<Олгосон огноо> талбарын утга <Буцаах огноо>-оос хойш байж болохгүй.";
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

        private void gridViewReturned_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            DataRow tempRow = gridViewReturned.GetDataRow(e.RowHandle);

            if (e.Column.FieldName.Equals("REASON"))
                if (Convert.ToDecimal(tempRow["REASON"]) != 0)
                    e.RepositoryItem.ReadOnly = true;
                else
                    e.RepositoryItem.ReadOnly = false;
        }

        private void gridViewReturned_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow tempRow = gridViewReturned.GetFocusedDataRow();
            DataRow mainRow = mainTableDTLGrid.Select("ORDERID = '" + tempRow["ORDERID"] + "'")[0];
            switch (e.Column.FieldName)
            {
                case "NOTE": mainRow["NOTE"] = e.Value; break;
                case "RETURNEDDATE":
                    mainRow["RETURNEDDATE"] = e.Value;
                    tempRow["LATEDATE"] = (Convert.ToDateTime(mainRow["RETURNDATE"]) - Convert.ToDateTime(e.Value)).Days >= 0 ? 0 : (Convert.ToDateTime(mainRow["RETURNDATE"]) - Convert.ToDateTime(e.Value)).Days; break;
                case "REASON": mainRow["REASON"] = e.Value; break;
            }
            if (!barSave.Enabled)
            {
                barSave.Enabled = true;
                barCancel.Enabled = true;
                barRefresh.Enabled = false;
            }
        }

        void colBookName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow tempRow = gridViewGive.GetFocusedDataRow();
            if (tempRow == null)
                return;
            if (tempRow["ORDERID"] == DBNull.Value)
                foreach (DataRow dr in mainTableDTLGrid.Select("ORDERID is null", "", DataViewRowState.CurrentRows))
                    dr.Delete();
            else
                foreach (DataRow dr in mainTableDTLGrid.Select("ORDERID = '" + tempRow["ORDERID"] + "'", "", DataViewRowState.CurrentRows))
                    dr.Delete();

            tempRow.Delete();

            if (!barSave.Enabled)
            {
                barSave.Enabled = true;
                barCancel.Enabled = true;
                barRefresh.Enabled = false;
            }
        }

        void colBookCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow tempRow = gridViewGive.GetFocusedDataRow();
            if (tempRow != null && tempRow["BOOKID"] != DBNull.Value)
            {
                return;
            }

            string whereStr = "TBLBOOK.ISACTIVE = 'Y' AND BOOKID <> -1";
            frmBookList frmBookList = new frmBookList(new object[] { "Browse", whereStr });
            frmBookList.FormClosed += frmBookList_FormClosed;
            frmBookList.ShowDialog();
        }

        void frmBookList_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataRow dr = ((frmBookList)sender).returnRow;
            if (dr == null)
            {
                return;
            }
            else
            {
                DataRow row = gridViewGive.GetFocusedDataRow();
                if (row == null)
                {
                    (gridControlGive.DataSource as DataTable).Rows.Add();
                    gridViewGive_InitNewRow(null, null);
                }
            }

            DataRow tempRow = (gridControlGive.DataSource as DataTable).Select("ORDERID = '" + FocusedOrderID + "'")[0];

            mainTableDTLGrid.Select("ORDERID = '" + FocusedOrderID + "'")[0]["BOOKID"] = dr["BOOKID"];
            tempRow["BOOKID"] = dr["BOOKID"];
            tempRow["BOOKCODE"] = dr["CODE"];
            tempRow["BOOKNAME"] = dr["NAME"];
        }

        void gridViewReturned_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "LATEDATE")
            {
                DataRow dr = gridViewReturned.GetDataRow(e.RowHandle);
                if (dr["LATEDATE"] != DBNull.Value && Convert.ToDecimal(dr["LATEDATE"]) < 0)
                    e.Appearance.BackColor = Color.Red;
            }
        }

        private void gridViewReturned_CustomDrawCell_1(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "REASON" || e.Column.FieldName == "RETURNEDDATE")
            {
                e.Appearance.BackColor = frmMain.greenColor;
            }
        }

        private void gridViewGive_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "BOOKCODE" || e.Column.FieldName == "TAKEDATE" || e.Column.FieldName == "RETURNDATE")
            {
                e.Appearance.BackColor = frmMain.greenColor;
            }
        }

        private void txtStudentName_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtStudentID.Tag = null;
            txtStudentName.Text = string.Empty;
            txtStudentID.Text = string.Empty;
            txtFirstName.EditValue = null;
            txtLastName.EditValue = null;
            txtRegNo.EditValue = null;
            txtGender.EditValue = "N";
            txtPictureData.Image = null;
            setModeChange("CANCEL");
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
            txtFirstName.EditValue = dr["FIRSTNAME"];
            txtLastName.EditValue = dr["LASTNAME"];
            txtRegNo.EditValue = dr["REGNO"];
            txtGender.EditValue = dr["GENDER"];
            txtPictureData.Image = getStudentPic(Convert.ToString(dr["STUDENTID"]));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            setModeChange("VIEW");
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
            dr = dt.NewRow();
            dr["NAME"] = " ";
            dr["TYPE"] = "N";
            dt.Rows.Add(dr);
            txtGender.Properties.DataSource = dt;
            txtGender.EditValue = "N";
        }

        void getReasonLookUp()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NAME");
            dt.Columns.Add("TYPE");
            DataRow dr = dt.NewRow();
            dr["NAME"] = "-";
            dr["TYPE"] = 0;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["NAME"] = "Мөнгөн төлбөр";
            dr["TYPE"] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["NAME"] = "Өөр ном өгсөн";
            dr["TYPE"] = 2;
            dt.Rows.Add(dr);
            (gridViewReturned.Columns["REASON"].ColumnEdit as RepositoryItemLookUpEdit).DataSource = dt;
        }

        string getReasonName(int type)
        {
            string retName = string.Empty;
            switch (type)
            {
                case 0: retName = "-"; break;
                case 1: retName = "мөнгөн төлбөр өгсөн"; break;
                case 2: retName = "өөр ном өгсөн"; break;
            }
            return retName;
        }

        void setEnabledChange(bool enabled)
        {
            foreach (Control cnt in xtraScrollableControl1.Controls)
            {
                cnt.Enabled = enabled;
            }
        }

        void setControlColorChange()
        {
            txtStudentID.BackColor = frmMain.greenColor;
        }

        bool getIsSave()
        {
            string errorMessage = string.Empty;
            string rowError = string.Empty;
            bool isErrorGrid = false;

            foreach (DataRow dr in (gridControlGive.DataSource as DataTable).Select("", "", DataViewRowState.CurrentRows))
            {
                rowError = string.Empty;
                if (dr["BOOKCODE"] == DBNull.Value)
                {
                    rowError += string.IsNullOrEmpty(rowError) ? "<Код>" : ", <Код>";
                }
                if (dr["TAKEDATE"] == DBNull.Value)
                {
                    rowError += string.IsNullOrEmpty(rowError) ? "<Олгосон огноо>" : ", <Олгосон огноо>";
                }
                if (dr["RETURNDATE"] == DBNull.Value)
                {
                    rowError += string.IsNullOrEmpty(rowError) ? "<Буцааж өгөх огноо>" : ", <Буцааж өгөх огноо>";
                }
                if (!string.IsNullOrEmpty(rowError))
                {
                    dr.RowError = rowError + " талбарт утга оруулах шаардлагатай!";
                    rowError = "Олголт " + rowError + " талбарт утга оруулах шаардлагатай!";
                    isErrorGrid = true;
                }
            }

            if (isErrorGrid)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Олголт хэсэгт алдаа байна!");
                return false;
            }
            return true;
        }

        Image getStudentPic(string studentID)
        {
            try
            {
                DataTable mainTableDTL = new DataTable();
                mainTableDTL.TableName = "TBLSTUDENTPIC";
                SqlDataAdapter adapterDTL = new SqlDataAdapter(@"SELECT PICTUREDATA FROM TBLSTUDENTPIC WHERE STUDENTID = '" + studentID + "'", frmMain.conn);
                SqlCommandBuilder builderDTL = new SqlCommandBuilder(adapterDTL);
                adapterDTL.Fill(mainTableDTL);
                frmMain.dataTableColumnNameToUpper(mainTableDTL);
                DataRow dr = mainTableDTL.Select("", "", DataViewRowState.CurrentRows)[0];
                if (dr["PICTUREDATA"] == DBNull.Value)
                    return null;

                var data = (Byte[])(dr["PICTUREDATA"]);
                var stream = new MemoryStream(data);
                return Image.FromStream(stream);
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
            return null;
        }

        void setModeChange(string mode)
        {
            try
            {
                switch (mode)
                {
                    case "SAVE":
                        if (!barSave.Enabled)
                            return;
                        if (!getIsSave())
                            return;

                        if (mainTableDTLGrid.GetChanges() != null && mainTableDTLGrid.GetChanges().Rows.Count > 0)
                        {
                            foreach (DataRow dr in mainTableDTLGrid.Select("", "", DataViewRowState.Deleted))
                            {
                                if (Convert.ToDecimal(dr["STATUS", DataRowVersion.Original]) == 1)
                                {
                                    string sql = @"UPDATE TBLBOOKREMAINDER
                                                   SET REMAINDER  = ISNULL(REMAINDER, 0) + 1,
                                                       Updated    = getdate(),
                                                       UpdatedBy  = '" + frmLogin.LoginUserID + @"',
                                                       IPAddress  = '" + frmMain.GetIPAddress() + @"',
                                                       MACAddress = '" + frmMain.GetMACAddress() + @"'
                                                 WHERE BOOKID = '" + dr["BOOKID", DataRowVersion.Original] + @"'";
                                    SqlCommand command = new SqlCommand(sql, frmMain.conn);
                                    command.ExecuteNonQuery();
                                }
                                else if (Convert.ToDecimal(dr["STATUS", DataRowVersion.Original]) == 2 && Convert.ToDecimal(dr["REASON", DataRowVersion.Original]) == 1)
                                {
                                    string sql = @"begin
                                                  FOR DR IN (SELECT *
                                                               FROM TBLBOOKOUTDTL
                                                              WHERE BOOKOUTID in (SELECT BOOKOUTID
                                                                                   FROM TBLBOOKOUT
                                                                                  WHERE ORDERID = '" + dr["ORDERID", DataRowVersion.Original] + @"')) LOOP
                                                    UPDATE TBLBOOKREMAINDER
                                                       SET TOTAL = ISNULL(TOTAL, 0) + DR.TOTAL, REMAINDER  = ISNULL(REMAINDER, 0) + DR.TOTAL
                                                     WHERE BOOKID = DR.BOOKID;
                                                  END LOOP;

                                                  DELETE FROM TBLBOOKOUTDTL
                                                   WHERE BOOKOUTID in
                                                         (SELECT BOOKOUTID FROM TBLBOOKOUT WHERE ORDERID = '" + dr["ORDERID", DataRowVersion.Original] + @"');
                                                  DELETE FROM TBLBOOKOUT WHERE ORDERID = '" + dr["ORDERID", DataRowVersion.Original] + @"';
                                                end;";
                                    SqlCommand command = new SqlCommand(sql, frmMain.conn);
                                    command.ExecuteNonQuery();
                                }
                                else if (Convert.ToDecimal(dr["STATUS", DataRowVersion.Original]) == 2 && Convert.ToDecimal(dr["REASON", DataRowVersion.Original]) == 2)
                                {
                                    string sql = @"begin
                                                  FOR DR IN (SELECT *
                                                               FROM TBLBOOKOUTDTL
                                                              WHERE BOOKOUTID in (SELECT BOOKOUTID
                                                                                   FROM TBLBOOKOUT
                                                                                  WHERE ORDERID = '" + dr["ORDERID", DataRowVersion.Original] + @"')) LOOP
                                                    UPDATE TBLBOOKREMAINDER
                                                       SET TOTAL = ISNULL(TOTAL, 0) + DR.TOTAL, REMAINDER  = ISNULL(REMAINDER, 0) + DR.TOTAL
                                                     WHERE BOOKID = DR.BOOKID;
                                                  END LOOP;

                                                  FOR DR IN (SELECT *
                                                               FROM TBLBOOKPURCHASEDTL
                                                              WHERE PURCHASEID in (SELECT PURCHASEID
                                                                                    FROM TBLBOOKPURCHASE
                                                                                   WHERE ORDERID = '" + dr["ORDERID", DataRowVersion.Original] + @"')) LOOP
                                                    UPDATE TBLBOOKREMAINDER
                                                       SET TOTAL = ISNULL(TOTAL, 0) - DR.TOTAL, REMAINDER  = ISNULL(REMAINDER, 0) - DR.TOTAL
                                                     WHERE BOOKID = DR.BOOKID;
                                                  END LOOP;

                                                  DELETE FROM TBLBOOKPURCHASEDTL
                                                   WHERE PURCHASEID in
                                                         (SELECT PURCHASEID FROM TBLBOOKPURCHASE WHERE ORDERID = '" + dr["ORDERID", DataRowVersion.Original] + @"');
                                                  DELETE FROM TBLBOOKPURCHASE WHERE ORDERID = '" + dr["ORDERID", DataRowVersion.Original] + @"';

                                                  DELETE FROM TBLBOOKOUTDTL
                                                   WHERE BOOKOUTID in
                                                         (SELECT BOOKOUTID FROM TBLBOOKOUT WHERE ORDERID = '" + dr["ORDERID", DataRowVersion.Original] + @"');
                                                  DELETE FROM TBLBOOKOUT WHERE ORDERID = '" + dr["ORDERID", DataRowVersion.Original] + @"';
                                                end;";
                                    SqlCommand command = new SqlCommand(sql, frmMain.conn);
                                    command.ExecuteNonQuery();
                                }
                            }
                            foreach (DataRow dr in mainTableDTLGrid.Select("STATUS = '0' AND REASON = '0'", "", DataViewRowState.ModifiedCurrent))
                            {
                                if (Convert.ToDecimal(dr["STATUS", DataRowVersion.Original]) != 0)
                                {
                                    string sql = @"UPDATE TBLBOOKREMAINDER
                                                   SET REMAINDER  = ISNULL(REMAINDER, 0) + 1,
                                                       Updated    = getdate(),
                                                       UpdatedBy  = '" + frmLogin.LoginUserID + @"',
                                                       IPAddress  = '" + frmMain.GetIPAddress() + @"',
                                                       MACAddress = '" + frmMain.GetMACAddress() + @"'
                                                 WHERE BOOKID = '" + dr["BOOKID"] + @"'";
                                    SqlCommand command = new SqlCommand(sql, frmMain.conn);
                                    command.ExecuteNonQuery();
                                }
                            }
                            foreach (DataRow dr in mainTableDTLGrid.Select("STATUS = '1' AND REASON = '0'", "", DataViewRowState.Added | DataViewRowState.ModifiedCurrent))
                            {
                                if (dr.RowState == DataRowState.Added || (dr.RowState == DataRowState.Modified && ((Convert.ToDecimal(dr["STATUS", DataRowVersion.Original])) == 0 || (Convert.ToDecimal(dr["STATUS", DataRowVersion.Original])) == 2)))
                                {
                                    string sql = @"UPDATE TBLBOOKREMAINDER
                                                   SET REMAINDER  = ISNULL(REMAINDER, 0) - 1,
                                                       Updated    = getdate(),
                                                       UpdatedBy  = '" + frmLogin.LoginUserID + @"',
                                                       IPAddress  = '" + frmMain.GetIPAddress() + @"',
                                                       MACAddress = '" + frmMain.GetMACAddress() + @"'
                                                 WHERE BOOKID = '" + dr["BOOKID"] + @"'";
                                    SqlCommand command = new SqlCommand(sql, frmMain.conn);
                                    command.ExecuteNonQuery();
                                }
                            }
                            foreach (DataRow dr in mainTableDTLGrid.Select("STATUS = '2' AND REASON = '0'", "", DataViewRowState.ModifiedCurrent))
                            {
                                if (Convert.ToDecimal(dr["STATUS", DataRowVersion.Original]) != 2)
                                {
                                    string sql = @"UPDATE TBLBOOKREMAINDER
                                                   SET REMAINDER  = ISNULL(REMAINDER, 0) + 1,
                                                       Updated    = getdate(),
                                                       UpdatedBy  = '" + frmLogin.LoginUserID + @"',
                                                       IPAddress  = '" + frmMain.GetIPAddress() + @"',
                                                       MACAddress = '" + frmMain.GetMACAddress() + @"'
                                                 WHERE BOOKID = '" + dr["BOOKID"] + @"'";
                                    SqlCommand command = new SqlCommand(sql, frmMain.conn);
                                    command.ExecuteNonQuery();
                                }
                            }

                            foreach (DataRow dr in mainTableDTLGrid.Select("STATUS IN ('1','0') AND REASON <> '0'", "", DataViewRowState.ModifiedCurrent))
                            {
                                if (Convert.ToDecimal(dr["STATUS", DataRowVersion.Original]) != 2)
                                    continue;
                                string sql = string.Empty;
                                if (Convert.ToDecimal(dr["STATUS"]) == 1)
                                    sql = @"begin
                                                  FOR DR IN (SELECT *
                                                               FROM TBLBOOKOUTDTL
                                                              WHERE BOOKOUTID in (SELECT BOOKOUTID
                                                                                   FROM TBLBOOKOUT
                                                                                  WHERE ORDERID = '" + dr["ORDERID"] + @"')) LOOP
                                                    UPDATE TBLBOOKREMAINDER
                                                       SET TOTAL = ISNULL(TOTAL, 0) + DR.TOTAL
                                                     WHERE BOOKID = DR.BOOKID;
                                                  END LOOP;

                                                  FOR DR IN (SELECT *
                                                               FROM TBLBOOKPURCHASEDTL
                                                              WHERE PURCHASEID in (SELECT PURCHASEID
                                                                                    FROM TBLBOOKPURCHASE
                                                                                   WHERE ORDERID = '" + dr["ORDERID"] + @"')) LOOP
                                                    UPDATE TBLBOOKREMAINDER
                                                       SET TOTAL = ISNULL(TOTAL, 0) - DR.TOTAL, REMAINDER  = ISNULL(REMAINDER, 0) - DR.TOTAL
                                                     WHERE BOOKID = DR.BOOKID;
                                                  END LOOP;

                                                  DELETE FROM TBLBOOKPURCHASEDTL
                                                   WHERE PURCHASEID in
                                                         (SELECT PURCHASEID FROM TBLBOOKPURCHASE WHERE ORDERID = '" + dr["ORDERID"] + @"');
                                                  DELETE FROM TBLBOOKPURCHASE WHERE ORDERID = '" + dr["ORDERID"] + @"';

                                                  DELETE FROM TBLBOOKOUTDTL
                                                   WHERE BOOKOUTID in
                                                         (SELECT BOOKOUTID FROM TBLBOOKOUT WHERE ORDERID = '" + dr["ORDERID"] + @"');
                                                  DELETE FROM TBLBOOKOUT WHERE ORDERID = '" + dr["ORDERID"] + @"';
                                                end;";
                                else if (Convert.ToDecimal(dr["STATUS"]) == 0)
                                    sql = @"begin
                                                  FOR DR IN (SELECT *
                                                               FROM TBLBOOKOUTDTL
                                                              WHERE BOOKOUTID in (SELECT BOOKOUTID
                                                                                   FROM TBLBOOKOUT
                                                                                  WHERE ORDERID = '" + dr["ORDERID"] + @"')) LOOP
                                                    UPDATE TBLBOOKREMAINDER
                                                       SET TOTAL = ISNULL(TOTAL, 0) + DR.TOTAL, REMAINDER  = ISNULL(REMAINDER, 0) + DR.TOTAL
                                                     WHERE BOOKID = DR.BOOKID;
                                                  END LOOP;

                                                  FOR DR IN (SELECT *
                                                               FROM TBLBOOKPURCHASEDTL
                                                              WHERE PURCHASEID in (SELECT PURCHASEID
                                                                                    FROM TBLBOOKPURCHASE
                                                                                   WHERE ORDERID = '" + dr["ORDERID"] + @"')) LOOP
                                                    UPDATE TBLBOOKREMAINDER
                                                       SET TOTAL = ISNULL(TOTAL, 0) - DR.TOTAL, REMAINDER  = ISNULL(REMAINDER, 0) - DR.TOTAL
                                                     WHERE BOOKID = DR.BOOKID;
                                                  END LOOP;

                                                  DELETE FROM TBLBOOKPURCHASEDTL
                                                   WHERE PURCHASEID in
                                                         (SELECT PURCHASEID FROM TBLBOOKPURCHASE WHERE ORDERID = '" + dr["ORDERID"] + @"');
                                                  DELETE FROM TBLBOOKPURCHASE WHERE ORDERID = '" + dr["ORDERID"] + @"';

                                                  DELETE FROM TBLBOOKOUTDTL
                                                   WHERE BOOKOUTID in
                                                         (SELECT BOOKOUTID FROM TBLBOOKOUT WHERE ORDERID = '" + dr["ORDERID"] + @"');
                                                  DELETE FROM TBLBOOKOUT WHERE ORDERID = '" + dr["ORDERID"] + @"';
                                                end;";
                                SqlCommand command = new SqlCommand(sql, frmMain.conn);
                                command.ExecuteNonQuery();
                            }
                            foreach (DataRow dr in mainTableDTLGrid.Select("STATUS = '2' AND REASON <> '0'", "", DataViewRowState.Added | DataViewRowState.ModifiedCurrent))
                            {
                                if (dr.RowState == DataRowState.Modified && Convert.ToDecimal(dr["STATUS", DataRowVersion.Original]) == 2
                                    && Convert.ToDecimal(dr["REASON", DataRowVersion.Original]) != 0)
                                    continue;

                                DataRow bookRow = (gridControlReturned.DataSource as DataTable).Select("ORDERID = '" + dr["ORDERID"] + "'")[0];
                                string strMessage = txtLastName.Text + "-н " + txtFirstName.Text + " нь " + bookRow["BOOKCODE"] + " кодтой " + bookRow["BOOKNAME"] + " номыг " + getReasonName(Convert.ToInt16(dr["REASON"]));

                                if (dr.RowState == DataRowState.Modified && Convert.ToDecimal(dr["STATUS", DataRowVersion.Original]) == 1)
                                {
                                    decimal headerID = frmMain.NewID("TBLBOOKOUT", "BOOKOUTID");
                                    string sql = @"insert into tblBookOut
                                                  (BOOKOUTID, OUTDATE, STATUS, NOTE, ORDERID)
                                                values
                                                  ('" + headerID + "', getdate(), 2, '" + strMessage + ".', '" + dr["ORDERID"] + "')";
                                    SqlCommand command = new SqlCommand(sql, frmMain.conn);
                                    command.ExecuteNonQuery();

                                    decimal dtlID = frmMain.NewID("TBLBOOKOUTDTL", "OUTDTLID");
                                    sql = @"insert into tblBookOutDtl
                                          (OUTDTLID, BOOKOUTID, BOOKID, TOTAL, NOTE)
                                        values
                                          ('" + dtlID + "', '" + headerID + "', '" + dr["BOOKID"] + "', 1, '" + dr["NOTE"] + "')";
                                    command = new SqlCommand(sql, frmMain.conn);
                                    command.ExecuteNonQuery();

                                    sql = @"UPDATE TBLBOOKREMAINDER
                                                   SET TOTAL      = ISNULL(TOTAL, 0) - 1,
                                                       Updated    = getdate(),
                                                       UpdatedBy  = '" + frmLogin.LoginUserID + @"',
                                                       IPAddress  = '" + frmMain.GetIPAddress() + @"',
                                                       MACAddress = '" + frmMain.GetMACAddress() + @"'
                                                 WHERE BOOKID = '" + dr["BOOKID"] + @"'";
                                    command = new SqlCommand(sql, frmMain.conn);
                                    command.ExecuteNonQuery();
                                }
                                else
                                {
                                    decimal headerID = frmMain.NewID("TBLBOOKOUT", "BOOKOUTID");
                                    string sql = @"insert into tblBookOut
                                                  (BOOKOUTID, OUTDATE, STATUS, NOTE, ORDERID)
                                                values
                                                  ('" + headerID + "', getdate(), 2, '" + strMessage + ".', '" + dr["ORDERID"] + "')";
                                    SqlCommand command = new SqlCommand(sql, frmMain.conn);
                                    command.ExecuteNonQuery();

                                    decimal dtlID = frmMain.NewID("TBLBOOKOUTDTL", "OUTDTLID");
                                    sql = @"insert into tblBookOutDtl
                                          (OUTDTLID, BOOKOUTID, BOOKID, TOTAL, NOTE)
                                        values
                                          ('" + dtlID + "', '" + headerID + "', '" + dr["BOOKID"] + "', 1, '" + dr["NOTE"] + "')";
                                    command = new SqlCommand(sql, frmMain.conn);
                                    command.ExecuteNonQuery();

                                    sql = @"UPDATE TBLBOOKREMAINDER
                                                   SET TOTAL      = ISNULL(TOTAL, 0) - 1,
                                                       REMAINDER  = ISNULL(REMAINDER, 0) - 1,
                                                       Updated    = getdate(),
                                                       UpdatedBy  = '" + frmLogin.LoginUserID + @"',
                                                       IPAddress  = '" + frmMain.GetIPAddress() + @"',
                                                       MACAddress = '" + frmMain.GetMACAddress() + @"'
                                                 WHERE BOOKID = '" + dr["BOOKID"] + @"'";
                                    command = new SqlCommand(sql, frmMain.conn);
                                    command.ExecuteNonQuery();
                                }

                            }
                            foreach (DataRow dr in mainTableDTLGrid.Select("STATUS = '2' AND REASON = '2'", "", DataViewRowState.Added | DataViewRowState.ModifiedCurrent))
                            {
                                if (dr.RowState == DataRowState.Modified && Convert.ToDecimal(dr["STATUS", DataRowVersion.Original]) == 2
                                    && Convert.ToDecimal(dr["REASON", DataRowVersion.Original]) != 0)
                                    continue;

                                decimal headerID = frmMain.NewID("TBLBOOKPURCHASE", "PURCHASEID");
                                DataRow bookRow = (gridControlReturned.DataSource as DataTable).Select("ORDERID = '" + dr["ORDERID"] + "'")[0];
                                string strMessage = txtLastName.Text + "-н " + txtFirstName.Text + " нь " + bookRow["BOOKCODE"] + " кодтой " + bookRow["BOOKNAME"] + " номыг " + getReasonName(Convert.ToInt16(dr["REASON"]));
                                string sql = @"insert into tblBookPurchase
                                                  (PURCHASEID, PURCHASEDATE, STATUS, NOTE, ORDERID)
                                                values
                                                  ('" + headerID + "', getdate(), 0, '" + strMessage + ".', '" + dr["ORDERID"] + "')";
                                SqlCommand command = new SqlCommand(sql, frmMain.conn);
                                command.ExecuteNonQuery();

                                decimal dtlID = frmMain.NewID("TBLBOOKPURCHASEDTL", "PURCHASEDTLID");
                                sql = @"insert into tblBookPurchaseDtl
                                          (PURCHASEDTLID, PURCHASEID, BOOKID, TOTAL, NOTE)
                                        values
                                          ('" + dtlID + "', '" + headerID + "', '" + dr["BOOKID"] + "', 1, '" + dr["NOTE"] + "')";
                                command = new SqlCommand(sql, frmMain.conn);
                                command.ExecuteNonQuery();
                                if (dr.RowState == DataRowState.Added)
                                {
                                    sql = @"UPDATE TBLBOOKREMAINDER
                                                   SET REMAINDER  = ISNULL(REMAINDER, 0) - 1,
                                                       Updated    = getdate(),
                                                       UpdatedBy  = '" + frmLogin.LoginUserID + @"',
                                                       IPAddress  = '" + frmMain.GetIPAddress() + @"',
                                                       MACAddress = '" + frmMain.GetMACAddress() + @"'
                                                 WHERE BOOKID = '" + dr["BOOKID"] + @"'";
                                    command = new SqlCommand(sql, frmMain.conn);
                                    command.ExecuteNonQuery();
                                }
                                frmBookPurchase frmObj = new frmBookPurchase(new object[] { headerID });
                                frmObj.MdiParent = frmMain.ActiveForm;
                                frmObj.Show();
                            }
                            builderDTLGrid.GetInsertCommand();
                            builderDTLGrid.GetDeleteCommand();
                            builderDTLGrid.GetUpdateCommand();
                            adapterDTLGrid.Update(mainTableDTLGrid);
                            mainTableDTLGrid.AcceptChanges();
                        }

                        formMode = "VIEW";
                        barSave.Enabled = false;
                        barCancel.Enabled = false;
                        barRefresh.Enabled = true;
                        break;
                    case "CANCEL":
                        if (txtStudentID.Tag == null)
                        {
                            gridControlGive.DataSource = null;
                            gridControlOrder.DataSource = null;
                            gridControlReturned.DataSource = null;
                            setEnabledChange(false);
                        }
                        else
                        {
                            setModeChange("VIEW");
                            break;
                        }
                        barSave.Enabled = false;
                        barCancel.Enabled = false;
                        barRefresh.Enabled = false;
                        break;
                    case "VIEW":
                        if (txtStudentID.Tag == null)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("<Оюутан> талбарт утга оруулах шаардлагатай!");
                            return;
                        }
                        else
                        {
                            whereStudentID = Convert.ToString(txtStudentID.Tag);
                        }

                        mainTableDTLGrid = new DataTable();
                        adapterDTLGrid = new SqlDataAdapter(@"SELECT * FROM tblBookOrder WHERE STUDENTID = '" + whereStudentID + "'", frmMain.conn);
                        builderDTLGrid = new SqlCommandBuilder(adapterDTLGrid);
                        adapterDTLGrid.Fill(mainTableDTLGrid);
                        frmMain.dataTableColumnNameToUpper(mainTableDTLGrid);

                        mainTableDTLGridViewOrder = new DataTable();
                        adapterDTLGridViewOrder = new SqlDataAdapter(@"select 'N' ""CHECK"", tblBookOrder.*, tblBook.CODE BOOKCODE, tblBook.NAME BOOKNAME
                                                                      from tblBookOrder
                                                                      left join tblBook
                                                                        on tblBook.BookID = tblBookOrder.BookID
                                                                     WHERE STUDENTID = '" + whereStudentID + "' and status = '0'", frmMain.conn);
                        adapterDTLGridViewOrder.Fill(mainTableDTLGridViewOrder);
                        frmMain.dataTableColumnNameToUpper(mainTableDTLGridViewOrder);
                        gridControlOrder.DataSource = mainTableDTLGridViewOrder;

                        mainTableDTLGridViewGive = new DataTable();
                        adapterDTLGridViewGive = new SqlDataAdapter(@"select 'N' ""CHECK"", tblBookOrder.*, tblBook.CODE BOOKCODE, tblBook.NAME BOOKNAME
                                                                      from tblBookOrder
                                                                      left join tblBook
                                                                        on tblBook.BookID = tblBookOrder.BookID
                                                                     WHERE STUDENTID = '" + whereStudentID + "' and status = '1'", frmMain.conn);
                        adapterDTLGridViewGive.Fill(mainTableDTLGridViewGive);
                        frmMain.dataTableColumnNameToUpper(mainTableDTLGridViewGive);
                        gridControlGive.DataSource = mainTableDTLGridViewGive;

                        mainTableDTLGridViewReturned = new DataTable();
                        adapterDTLGridViewReturned = new SqlDataAdapter(@"select 'N' ""CHECK"",
                                                                           FLOOR(ISNULL(case
                                                                                 when DATEDIFF(dd, tblBookOrder.ReturnedDate, tblBookOrder.ReturnDate) >= 0 then
                                                                                  0
                                                                                 else
                                                                                  DATEDIFF(dd, tblBookOrder.ReturnedDate, tblBookOrder.ReturnDate)
                                                                               end,
                                                                               0)) LATEDATE,
                                                                           tblBookOrder.*,
                                                                           tblBook.CODE BOOKCODE,
                                                                           tblBook.NAME BOOKNAME
                                                                      from tblBookOrder
                                                                      left join tblBook
                                                                        on tblBook.BookID = tblBookOrder.BookID
                                                                     WHERE STUDENTID = '" + whereStudentID + "' and status = '2'", frmMain.conn);
                        adapterDTLGridViewReturned.Fill(mainTableDTLGridViewReturned);
                        frmMain.dataTableColumnNameToUpper(mainTableDTLGridViewReturned);
                        gridControlReturned.DataSource = mainTableDTLGridViewReturned;

                        barSave.Enabled = false;
                        barCancel.Enabled = false;
                        barRefresh.Enabled = true;

                        setEnabledChange(true);
                        break;
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

    }
}