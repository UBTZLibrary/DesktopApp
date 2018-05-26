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
using UBTZLibrary.Inquiry;
using DevExpress.XtraEditors.Repository;

namespace UBTZLibrary.GeneralInfo
{
    public partial class frmBookPurchase : DevExpress.XtraEditors.XtraForm
    {
        string formMode = string.Empty;
        string entryID = string.Empty;
        private object[] para;
        bool isSetValue = true;
        decimal FocusedPurchaseDtlID;
        DataTable mainTable;
        DataTable mainTableDTLGrid;
        DataTable mainTableDTLGridView;
        SqlDataAdapter adapter;
        SqlDataAdapter adapterDTLGrid;
        SqlDataAdapter adapterDTLGridView;
        SqlCommandBuilder builder;
        SqlCommandBuilder builderDTLGrid;

        public frmBookPurchase()
        {
            InitializeComponent();
        }

        public frmBookPurchase(object[] para)
        {
            this.para = para;
            InitializeComponent();
        }

        private void frmBookPurchase_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormClosed += frmBookPurchase_FormClosed;
                this.gridView1.InitNewRow += gridView1_InitNewRow;

                this.gridView1.CellValueChanged += gridView1_CellValueChanged;
                this.gridView1.CustomRowCellEditForEditing += gridView1_CustomRowCellEditForEditing;

                (gridView1.Columns["CODE"].ColumnEdit as RepositoryItemButtonEdit).ButtonClick += colCode_ButtonClick;
                (gridView1.Columns["NAME"].ColumnEdit as RepositoryItemButtonEdit).ButtonClick += colName_ButtonClick;

                barSave.ShortCut = Shortcut.CtrlS;
                getStatusLookUp();
                if (para == null)
                {
                    formMode = "ACTION";
                    setModeChange("ADD");
                }
                else
                {
                    formMode = "VIEW";
                    entryID = Convert.ToString(para[0]);
                    setModeChange("VIEW");
                }

                setControlColorChange();
                setDataBinding();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Алдаа");
            }
        }

        void frmBookPurchase_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mainTable != null)
                mainTable.Dispose();
            if (mainTableDTLGrid != null)
                mainTableDTLGrid.Dispose();
            if (mainTableDTLGridView != null)
                mainTableDTLGridView.Dispose();

            if (adapter != null)
                adapter.Dispose();
            if (adapterDTLGrid != null)
                adapterDTLGrid.Dispose();
            if (adapterDTLGridView != null)
                adapterDTLGridView.Dispose();

            if (builder != null)
                builder.Dispose();
            if (builderDTLGrid != null)
                builderDTLGrid.Dispose();
        }

        void colName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow tempRow = gridView1.GetFocusedDataRow();
            if (tempRow == null)
                return;
            if (tempRow["PURCHASEDTLID"] == DBNull.Value)
                foreach (DataRow dr in mainTableDTLGrid.Select("PURCHASEDTLID is null", "", DataViewRowState.CurrentRows))
                    dr.Delete();
            else
                foreach (DataRow dr in mainTableDTLGrid.Select("PURCHASEDTLID = '" + tempRow["PURCHASEDTLID"] + "'", "", DataViewRowState.CurrentRows))
                    dr.Delete();

            tempRow.Delete();

            if (!barSave.Enabled)
            {
                txtStatus.ReadOnly = true;
                barNew.Enabled = false;
                barSave.Enabled = true;
                barDelete.Enabled = false;
                barCancel.Enabled = true;
                barRefresh.Enabled = false;
            }
        }

        void colCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string whereStr = "TBLBOOK.ISACTIVE = 'Y'";
            foreach (DataRow dr in mainTableDTLGrid.Select("", "", DataViewRowState.CurrentRows))
            {
                if (dr["BOOKID"] == DBNull.Value)
                    continue;
                whereStr += " AND TBLBOOK.BOOKID <> " + Convert.ToString(dr["BOOKID"]);
            }
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
                DataRow row = gridView1.GetFocusedDataRow();
                if (row == null)
                {
                    (gridControl1.DataSource as DataTable).Rows.Add();
                    gridView1_InitNewRow(null, null);
                }
            }

            DataRow tempRow = (gridControl1.DataSource as DataTable).Select("PURCHASEDTLID = '" + FocusedPurchaseDtlID + "'")[0];

            mainTableDTLGrid.Select("PURCHASEDTLID = '" + FocusedPurchaseDtlID + "'")[0]["BOOKID"] = dr["BOOKID"];

            tempRow["BOOKID"] = dr["BOOKID"];
            tempRow["CODE"] = dr["CODE"];
            tempRow["NAME"] = dr["NAME"];

            if (!barSave.Enabled)
            {
                txtStatus.ReadOnly = true;
                barNew.Enabled = false;
                barSave.Enabled = true;
                barDelete.Enabled = false;
                barCancel.Enabled = true;
                barRefresh.Enabled = false;
            }
        }

        void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow tempRow = gridView1.GetFocusedDataRow();
            DataRow mainRow = mainTableDTLGrid.Select("PURCHASEDTLID = '" + tempRow["PURCHASEDTLID"] + "'")[0];
            switch (e.Column.FieldName)
            {
                case "NOTE": mainRow["NOTE"] = e.Value; break;
                case "TOTAL": mainRow["TOTAL"] = e.Value;
                    if (mainRow["TOTAL"] != DBNull.Value && mainRow["UNITPRICE"] != DBNull.Value)
                        mainRow["TOTALPRICE"] = Convert.ToDecimal(mainRow["TOTAL"]) * Convert.ToDecimal(mainRow["UNITPRICE"]);
                    else
                        mainRow["TOTALPRICE"] = 0;
                    tempRow["TOTALPRICE"] = mainRow["TOTALPRICE"];
                    break;
                case "UNITPRICE": mainRow["UNITPRICE"] = e.Value;
                    if (mainRow["TOTAL"] != DBNull.Value && mainRow["UNITPRICE"] != DBNull.Value)
                        mainRow["TOTALPRICE"] = Convert.ToDecimal(mainRow["TOTAL"]) * Convert.ToDecimal(mainRow["UNITPRICE"]);
                    else
                        mainRow["TOTALPRICE"] = 0;
                    tempRow["TOTALPRICE"] = mainRow["TOTALPRICE"];
                    break;

                case "CODE": mainRow["BOOKID"] = tempRow["BOOKID"]; break;
            }

            if (!barSave.Enabled)
            {
                txtStatus.ReadOnly = true;
                barNew.Enabled = false;
                barSave.Enabled = true;
                barDelete.Enabled = false;
                barCancel.Enabled = true;
                barRefresh.Enabled = false;
            }
        }

        void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            DataRow tempRow = gridView1.GetFocusedDataRow();
            if (e.Column.FieldName.Equals("CODE") && tempRow != null && tempRow["PURCHASEDTLID"] != DBNull.Value)
                FocusedPurchaseDtlID = Convert.ToDecimal(tempRow["PURCHASEDTLID"]);
        }

        void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            decimal newID = -1;
            DataRow tempRow;
            if (e != null && e.RowHandle == -2147483647)
                tempRow = gridView1.GetFocusedDataRow();
            else
                tempRow = (gridControl1.DataSource as DataTable).Select("PURCHASEDTLID is null")[0];

            newID = frmMain.NewID("TBLBOOKPURCHASEDTL", "PURCHASEDTLID");

            DataRow newRow = mainTableDTLGrid.NewRow();
            newRow["PURCHASEID"] = mainTable.Rows[0]["PURCHASEID"];
            tempRow["PURCHASEID"] = mainTable.Rows[0]["PURCHASEID"];

            newRow["CREATED"] = DateTime.Now;
            newRow["CREATEDBY"] = frmLogin.LoginUserID;
            newRow["IPADDRESS"] = frmMain.GetIPAddress();
            newRow["MACADDRESS"] = frmMain.GetMACAddress();

            newRow["PURCHASEDTLID"] = newID;
            tempRow["PURCHASEDTLID"] = newID;

            FocusedPurchaseDtlID = newID;
            mainTableDTLGrid.Rows.Add(newRow);

            if (!barSave.Enabled)
            {
                txtStatus.ReadOnly = true;
                barNew.Enabled = false;
                barSave.Enabled = true;
                barDelete.Enabled = false;
                barCancel.Enabled = true;
                barRefresh.Enabled = false;
            }
        }

        private void barNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            setModeChange("ADD");
        }

        private void barSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            setModeChange("SAVE");
        }

        private void barDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            setModeChange("DELETE");
        }

        private void barCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            setModeChange("CANCEL");
        }

        private void barRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            setModeChange("VIEW");
        }

        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                BaseEdit obj = (sender as BaseEdit);
                bool isEdit = false;
                if (mainTable == null || isSetValue)
                {

                }
                else
                {
                    foreach (DataColumn dc in mainTable.Columns)
                    {
                        if (obj.Name.Substring(3).Equals(dc.Caption, StringComparison.InvariantCultureIgnoreCase))
                        {
                            foreach (DataRow dr in mainTable.Select("", "", DataViewRowState.CurrentRows))
                            {
                                if (e.NewValue == null)
                                    dr[dc.Caption] = DBNull.Value;
                                else
                                    dr[dc.Caption] = e.NewValue;
                                isEdit = true;
                            }
                        }
                    }
                    if (isEdit && !barSave.Enabled)
                    {
                        if (obj.Name == "txtStatus")
                            setStatusDataSourceFilter("EDIT");
                        else
                            txtStatus.ReadOnly = true;
                        barNew.Enabled = false;
                        barSave.Enabled = true;
                        barDelete.Enabled = false;
                        barCancel.Enabled = true;
                        barRefresh.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        void getStatusLookUp()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NAME");
            dt.Columns.Add("TYPE", typeof(short));
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
            txtStatus.Properties.DataSource = dt;
        }

        void setDataBinding()
        {
            isSetValue = true;

            foreach (Control cnt in panelControl1.Controls)
            {
                cnt.KeyPress += frmMain.cnt_KeyPress;
                if (mainTable == null)
                    return;
                else if (cnt is PictureEdit)
                {

                }
                else if (cnt is SpinEdit || cnt is TextEdit || cnt is DateEdit || cnt is MemoEdit || cnt is CheckEdit || cnt is LookUpEdit)
                {
                    foreach (DataColumn dc in mainTable.Columns)
                    {
                        if (cnt.Name.Substring(3).Equals(dc.Caption, StringComparison.InvariantCultureIgnoreCase))
                        {
                            foreach (DataRow dr in mainTable.Select("", "", DataViewRowState.CurrentRows))
                            {
                                (cnt as BaseEdit).EditValue = dr[dc.Caption];
                            }
                            break;
                        }
                    }
                }
            }

            isSetValue = false;
        }

        void setEnabledChange(bool enabled)
        {
            foreach (Control cnt in panelControl1.Controls)
            {
                if (cnt is PictureEdit)
                {
                    (cnt as PictureEdit).ReadOnly = !enabled;
                }
                else if (cnt is SpinEdit || cnt is TextEdit || cnt is DateEdit || cnt is MemoEdit || cnt is CheckEdit || cnt is LookUpEdit)
                {
                    (cnt as BaseEdit).ReadOnly = !enabled;
                }
            }
            gridView1.OptionsBehavior.Editable = enabled;
        }

        void setControlColorChange()
        {
            txtPurchaseDate.BackColor = frmMain.greenColor;
            txtStatus.BackColor = frmMain.greenColor;
        }

        bool getIsSave()
        {
            string errorMessage = string.Empty;
            string rowError = string.Empty;
            if (mainTable == null)
                return false;


            List<string> fieldName = new List<string>();
            fieldName.Add("PurchaseDate");
            fieldName.Add("Status");
            foreach (string name in fieldName)
            {
                foreach (DataRow dr in mainTable.Select("", "", DataViewRowState.CurrentRows))
                {
                    if (dr[name.ToUpper()] == DBNull.Value)
                        errorMessage += string.IsNullOrEmpty(errorMessage) ? panelControl1.Controls["lbl" + name].Text : ", " + panelControl1.Controls["lbl" + name].Text;
                    else if (string.IsNullOrEmpty(Convert.ToString(dr[name.ToUpper()])))
                        errorMessage += string.IsNullOrEmpty(errorMessage) ? panelControl1.Controls["lbl" + name].Text : ", " + panelControl1.Controls["lbl" + name].Text;
                }
            }
            foreach (DataRow dr in (gridControl1.DataSource as DataTable).Select("", "", DataViewRowState.CurrentRows))
            {
                if (dr["CODE"] == DBNull.Value)
                {
                    rowError += string.IsNullOrEmpty(rowError) ? "Код" : ", Код";
                }
                if (dr["TOTAL"] == DBNull.Value)
                {
                    rowError += string.IsNullOrEmpty(rowError) ? "Нийт тоо" : ", Нийт тоо";
                }
                else if (Convert.ToDecimal(dr["TOTAL"]) == 0)
                {
                    rowError += string.IsNullOrEmpty(rowError) ? "Нийт тоо" : ", Нийт тоо";
                }
                if (!string.IsNullOrEmpty(rowError))
                {
                    dr.RowError = "<" + rowError + "> талбарт утга оруулах шаардлагатай!";
                    rowError = "Номнууд <" + rowError + "> талбарт утга оруулах шаардлагатай!";
                }
            }

            if (string.IsNullOrEmpty(errorMessage))
                if (string.IsNullOrEmpty(rowError))
                    return true;
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(rowError);
                    return false;
                }
            else
            {
                if (string.IsNullOrEmpty(rowError))
                    DevExpress.XtraEditors.XtraMessageBox.Show("<" + errorMessage.Replace("@", string.Empty) + "> талбарт утга оруулах шаардлагатай!");
                else
                    DevExpress.XtraEditors.XtraMessageBox.Show("<" + errorMessage.Replace("@", string.Empty) + "> талбарт утга оруулах шаардлагатай!" + '\n' + rowError);
                return false;
            }
        }

        void setModeChange(string mode)
        {
            try
            {
                switch (mode)
                {
                    case "DELETE":
                        if (DevExpress.XtraEditors.XtraMessageBox.Show("Мэдээллийг устгах уу?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                            return;

                        foreach (DataRow dr in mainTable.Select("", "", DataViewRowState.CurrentRows))
                        {
                            dr.Delete();
                        }
                        builder.GetDeleteCommand();
                        adapter.Update(mainTable);

                        foreach (DataRow dr in mainTableDTLGrid.Select("", "", DataViewRowState.CurrentRows))
                        {
                            dr.Delete();
                        }
                        builderDTLGrid.GetDeleteCommand();
                        adapterDTLGrid.Update(mainTableDTLGrid);
                        mainTableDTLGrid.AcceptChanges();

                        foreach (Control cnt in panelControl1.Controls)
                        {
                            if (cnt is PictureEdit)
                            {
                                (cnt as PictureEdit).Image = null;
                            }
                            else if (cnt is LookUpEdit)
                            {
                                (cnt as LookUpEdit).ItemIndex = 0;
                            }
                            else if (cnt is SpinEdit || cnt is TextEdit || cnt is DateEdit || cnt is MemoEdit)
                            {
                                (cnt as BaseEdit).EditValue = null;
                            }
                            else
                            {
                                //
                            }
                        }
                        setEnabledChange(false);
                        formMode = "ACTION";
                        barNew.Enabled = true;
                        barSave.Enabled = false;
                        barDelete.Enabled = false;
                        barCancel.Enabled = false;
                        barRefresh.Enabled = false;
                        break;
                    case "ADD":

                        mainTable = new DataTable();
                        mainTable.TableName = "TBLBOOKPURCHASE";
                        adapter = new SqlDataAdapter("SELECT * FROM TBLBOOKPURCHASE WHERE TBLBOOKPURCHASE.PURCHASEID = '-1'", frmMain.conn);
                        builder = new SqlCommandBuilder(adapter);
                        adapter.Fill(mainTable);
                        frmMain.dataTableColumnNameToUpper(mainTable);
                        mainTable.Clear();
                        DataRow newRow = mainTable.NewRow();
                        decimal newID = frmMain.NewID("TBLBOOKPURCHASE", "PURCHASEID");
                        newRow["PURCHASEID"] = newID;
                        newRow["STATUS"] = 0;
                        newRow["PURCHASEDATE"] = DateTime.Now;
                        newRow["CREATED"] = DateTime.Now;
                        newRow["CREATEDBY"] = frmLogin.LoginUserID;
                        newRow["IPADDRESS"] = frmMain.GetIPAddress();
                        newRow["MACADDRESS"] = frmMain.GetMACAddress();
                        mainTable.Rows.Add(newRow);


                        mainTableDTLGrid = new DataTable();
                        adapterDTLGrid = new SqlDataAdapter(@"SELECT * FROM TBLBOOKPURCHASEDTL WHERE BOOKID = '-1'", frmMain.conn);
                        builderDTLGrid = new SqlCommandBuilder(adapterDTLGrid);
                        adapterDTLGrid.Fill(mainTableDTLGrid);
                        frmMain.dataTableColumnNameToUpper(mainTableDTLGrid);

                        mainTableDTLGridView = new DataTable();
                        adapterDTLGridView = new SqlDataAdapter(@"select tblBookPurchaseDtl.Purchasedtlid,
                                                                           tblBookPurchaseDtl.Purchaseid,
                                                                           tblBookPurchaseDtl.Bookid,
                                                                           tblbook.code,
                                                                           tblbook.name,
                                                                           tblBookPurchaseDtl.Total,
                                                                           tblBookPurchaseDtl.Unitprice,
                                                                           tblBookPurchaseDtl.Totalprice,
                                                                           tblBookPurchaseDtl.Note
                                                                      from tblBookPurchaseDtl
                                                                      left join tblbook
                                                                        on tblbook.bookid = tblBookPurchaseDtl.Bookid
                                                                     where tblBookPurchaseDtl.PurchaseID = '-1'", frmMain.conn);
                        adapterDTLGridView.Fill(mainTableDTLGridView);
                        frmMain.dataTableColumnNameToUpper(mainTableDTLGridView);
                        gridControl1.DataSource = mainTableDTLGridView;

                        setEnabledChange(true);
                        setStatusDataSourceFilter("ADD");
                        setDataBinding();

                        barNew.Enabled = false;
                        barSave.Enabled = true;
                        barDelete.Enabled = false;
                        barCancel.Enabled = true;
                        barRefresh.Enabled = false;
                        break;
                    case "SAVE":
                        if (!barSave.Enabled)
                            return;
                        if (!getIsSave())
                            return;
                        if (!setBookRemainderChange(Convert.ToString(txtStatus.EditValue)))
                            return;
                        if (mainTable.Select("", "", DataViewRowState.Added).Length > 0)
                        {
                            builder.GetInsertCommand();
                            adapter.Update(mainTable);
                        }
                        if (mainTable.Select("", "", DataViewRowState.ModifiedCurrent).Length > 0)
                        {
                            foreach (DataRow dr in mainTable.Select("", "", DataViewRowState.CurrentRows))
                            {
                                dr["UPDATED"] = DateTime.Now;
                                dr["UPDATEDBY"] = frmLogin.LoginUserID;
                                dr["IPADDRESS"] = frmMain.GetIPAddress();
                                dr["MACADDRESS"] = frmMain.GetMACAddress();
                            }
                            builder.GetUpdateCommand();
                            adapter.Update(mainTable);
                        }
                        if (mainTableDTLGrid.GetChanges() != null && mainTableDTLGrid.GetChanges().Rows.Count > 0)
                        {
                            builderDTLGrid.GetInsertCommand();
                            builderDTLGrid.GetDeleteCommand();
                            builderDTLGrid.GetUpdateCommand();
                            adapterDTLGrid.Update(mainTableDTLGrid);
                            mainTableDTLGrid.AcceptChanges();
                        }
                        foreach (DataRow dr in mainTable.Select("", "", DataViewRowState.CurrentRows))
                        {
                            entryID = Convert.ToString(dr["PURCHASEID"]);
                        }

                        formMode = "VIEW";
                        setModeChange("VIEW");
                        barNew.Enabled = true;
                        barSave.Enabled = false;
                        barDelete.Enabled = true;
                        barCancel.Enabled = false;
                        barRefresh.Enabled = true;
                        break;
                    case "CANCEL":

                        switch (this.formMode)
                        {
                            case "ACTION":
                                mainTable = null;
                                foreach (Control cnt in panelControl1.Controls)
                                {
                                    if (cnt is PictureEdit)
                                    {
                                        (cnt as PictureEdit).Image = null;
                                    }
                                    else if (cnt is LookUpEdit)
                                    {
                                        (cnt as LookUpEdit).ItemIndex = 0;
                                    }
                                    else if (cnt is SpinEdit || cnt is TextEdit || cnt is DateEdit || cnt is MemoEdit || cnt is CheckEdit)
                                    {
                                        (cnt as BaseEdit).EditValue = null;
                                    }
                                    else
                                    {
                                        //
                                    }
                                }
                                setEnabledChange(false);
                                barNew.Enabled = true;
                                barSave.Enabled = false;
                                barDelete.Enabled = false;
                                barCancel.Enabled = false;
                                barRefresh.Enabled = false;
                                break;
                            case "VIEW":
                                setModeChange("VIEW");
                                break;
                        }

                        break;
                    case "VIEW":

                        mainTable = new DataTable();
                        mainTable.TableName = "TBLBOOKPURCHASE";
                        adapter = new SqlDataAdapter("SELECT * FROM TBLBOOKPURCHASE WHERE TBLBOOKPURCHASE.PURCHASEID = '" + entryID + "'", frmMain.conn);
                        builder = new SqlCommandBuilder(adapter);
                        adapter.Fill(mainTable);
                        frmMain.dataTableColumnNameToUpper(mainTable);

                        mainTableDTLGrid = new DataTable();
                        adapterDTLGrid = new SqlDataAdapter(@"SELECT * FROM TBLBOOKPURCHASEDTL WHERE PURCHASEID = '" + entryID + "'", frmMain.conn);
                        builderDTLGrid = new SqlCommandBuilder(adapterDTLGrid);
                        adapterDTLGrid.Fill(mainTableDTLGrid);
                        frmMain.dataTableColumnNameToUpper(mainTableDTLGrid);

                        mainTableDTLGridView = new DataTable();
                        adapterDTLGridView = new SqlDataAdapter(@"select tblBookPurchaseDtl.Purchasedtlid,
                                                                           tblBookPurchaseDtl.Purchaseid,
                                                                           tblBookPurchaseDtl.Bookid,
                                                                           tblbook.code,
                                                                           tblbook.name,
                                                                           tblBookPurchaseDtl.Total,
                                                                           tblBookPurchaseDtl.Unitprice,
                                                                           tblBookPurchaseDtl.Totalprice,
                                                                           tblBookPurchaseDtl.Note
                                                                      from tblBookPurchaseDtl
                                                                      left join tblbook
                                                                        on tblbook.bookid = tblBookPurchaseDtl.Bookid
                                                                     where tblBookPurchaseDtl.PurchaseID = '" + entryID + "'", frmMain.conn);
                        adapterDTLGridView.Fill(mainTableDTLGridView);
                        frmMain.dataTableColumnNameToUpper(mainTableDTLGridView);
                        gridControl1.DataSource = mainTableDTLGridView;

                        barNew.Enabled = true;
                        barSave.Enabled = false;
                        barDelete.Enabled = true;
                        barCancel.Enabled = false;
                        barRefresh.Enabled = true;

                        setEnabledChange(true);
                        setStatusDataSourceFilter("VIEW");
                        setDataBinding();
                        break;
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        void setStatusDataSourceFilter(string UIMode)
        {
            if (mainTable != null && mainTable.Rows.Count > 0)
            {
                int status = 0;
                if (mainTable == null || mainTable.Select("", "", DataViewRowState.CurrentRows).Length == 0)
                    status = 0;
                else if (mainTable.Rows[0].RowState != DataRowState.Added && mainTable.Rows[0].RowState != DataRowState.Detached)
                    status = Convert.ToInt32(mainTable.Rows[0]["STATUS", DataRowVersion.Original]);
                else status = Convert.ToInt32(mainTable.Rows[0]["STATUS"]);

                if (UIMode == "ADD")
                {
                    if (txtStatus.Properties.DataSource != null)
                    {
                        (txtStatus.Properties.DataSource as DataTable).DefaultView.RowFilter = "TYPE < 1";
                    }
                }
                else if (UIMode == "VIEW")
                {
                    if (status > 0)
                    {
                        setEnabledChange(false);
                        barDelete.Enabled = true;
                        barDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                        if (status == 2)
                        {
                            barDelete.Enabled = false;
                            barDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                            txtStatus.Properties.ReadOnly = false;
                            (txtStatus.Properties.DataSource as DataTable).DefaultView.RowFilter = "TYPE > 1";
                        }
                        else if (status == 9)
                        {
                            (txtStatus.Properties.DataSource as DataTable).DefaultView.RowFilter = "TYPE = 9";
                        }
                    }
                    else
                    {
                        (txtStatus.Properties.DataSource as DataTable).DefaultView.RowFilter = "TYPE <= 2";
                    }
                }
                else if (UIMode == "EDIT")
                {
                    txtStatus.Properties.ReadOnly = false;
                    (txtStatus.Properties.DataSource as DataTable).DefaultView.RowFilter = "TYPE = 2 or TYPE = 9 or TYPE = 0";
                    setEnabledChange(false);
                }
            }

        }

        bool setBookRemainderChange(string status)
        {
            switch (status)
            {
                case "0": break;
                case "2":

                    foreach (DataRow dr in mainTableDTLGrid.Select("", "", DataViewRowState.CurrentRows))
                    {
                        SqlCommand command = new SqlCommand();
                        command.Connection = frmMain.conn;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"UPDATE TBLBOOKREMAINDER
                                                   SET TOTAL      = ISNULL(TOTAL, 0) + '" + dr["TOTAL"] + @"',
                                                       REMAINDER  = ISNULL(REMAINDER, 0) + '" + dr["TOTAL"] + @"',
                                                       Updated    = getdate(),
                                                       UpdatedBy  = '" + frmLogin.LoginUserID + @"',
                                                       IPAddress  = '" + frmMain.GetIPAddress() + @"',
                                                       MACAddress = '" + frmMain.GetMACAddress() + @"'
                                                 WHERE BOOKID = '" + dr["BOOKID"] + @"'";
                        command.ExecuteNonQuery();
                    }

                    break;
                case "9":
                    string messageStr = string.Empty;
                    foreach (DataRow dr in mainTableDTLGridView.Select("", "", DataViewRowState.CurrentRows))
                    {
                        SqlCommand command = new SqlCommand();
                        DataTable tempTable = new DataTable();
                        command.Connection = frmMain.conn;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "SELECT ISNULL(REMAINDER, 0) - '" + dr["TOTAL"] + "' REMAINDER FROM TBLBOOKREMAINDER WHERE BOOKID = '" + dr["BOOKID"] + "'";
                        SqlDataReader dataReader = command.ExecuteReader();
                        tempTable.Clear();
                        tempTable.Load(dataReader);
                        frmMain.dataTableColumnNameToUpper(tempTable);
                        if (tempTable.Rows.Count > 0 && Convert.ToDecimal(tempTable.Rows[0]["REMAINDER"]) < 0)
                        {
                            messageStr += string.IsNullOrEmpty(messageStr) ? Convert.ToString(dr["NAME"]) : ", " + Convert.ToString(dr["NAME"]);
                        }

                    }
                    if (!string.IsNullOrEmpty(messageStr))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("<" + messageStr + "> номны үлдэгдэл хүрэлцэхгүй байна.");
                        return false;
                    }
                    foreach (DataRow dr in mainTableDTLGrid.Select("", "", DataViewRowState.CurrentRows))
                    {
                        SqlCommand command = new SqlCommand();
                        command.Connection = frmMain.conn;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"UPDATE TBLBOOKREMAINDER
                                                   SET TOTAL      = ISNULL(TOTAL, 0) - '" + dr["TOTAL"] + @"',
                                                       REMAINDER  = ISNULL(REMAINDER, 0) - '" + dr["TOTAL"] + @"',
                                                       Updated    = getdate(),
                                                       UpdatedBy  = '" + frmLogin.LoginUserID + @"',
                                                       IPAddress  = '" + frmMain.GetIPAddress() + @"',
                                                       MACAddress = '" + frmMain.GetMACAddress() + @"'
                                                 WHERE BOOKID = '" + dr["BOOKID"] + @"'";
                        command.ExecuteNonQuery();
                    }
                    break;
            }
            return true;
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "CODE" || e.Column.FieldName == "TOTAL")
            {
                e.Appearance.BackColor = frmMain.greenColor;
            }
        }

    }
}