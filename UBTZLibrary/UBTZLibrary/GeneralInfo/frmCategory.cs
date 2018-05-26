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

namespace UBTZLibrary.GeneralInfo
{
    public partial class frmCategory : DevExpress.XtraEditors.XtraForm
    {
        string formMode = string.Empty;
        decimal entryID = 0;
        private object[] para;
        bool isSetValue = true;
        DataTable mainTable;
        SqlDataAdapter adapter;
        SqlCommandBuilder builder;

        public frmCategory()
        {
            InitializeComponent();
        }

        public frmCategory(object[] para)
        {
            this.para = para;
            InitializeComponent();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormClosed += frmCategory_FormClosed;
                barSave.ShortCut = Shortcut.CtrlS;
                if (para == null)
                {
                    formMode = "ACTION";
                    setModeChange("ADD");
                }
                else
                {
                    formMode = "VIEW";
                    entryID = Convert.ToDecimal(para[0]);
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

        void frmCategory_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mainTable != null)
                mainTable.Dispose();
            if (adapter != null)
                adapter.Dispose();
            if (builder != null)
                builder.Dispose();
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
                    return;
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
                    barNew.Enabled = false;
                    barSave.Enabled = true;
                    barDelete.Enabled = false;
                    barCancel.Enabled = true;
                    barRefresh.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
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
                else if (cnt is SpinEdit || cnt is TextEdit || cnt is DateEdit || cnt is MemoEdit || cnt is CheckEdit)
                {
                    foreach (DataColumn dc in mainTable.Columns)
                    {
                        if (cnt.Name.Substring(3).Equals(dc.Caption, StringComparison.InvariantCultureIgnoreCase))
                        {
                            foreach (DataRow dr in mainTable.Select("", "", DataViewRowState.CurrentRows))
                            {
                                (cnt as BaseEdit).EditValue = dr[dc.Caption];
                            }
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
                cnt.Enabled = enabled;
            }
        }

        void setControlColorChange()
        {
            txtCode.BackColor = frmMain.greenColor;
            txtName.BackColor = frmMain.greenColor;
        }

        bool getIsSave()
        {
            string errorMessage = string.Empty;

            if (mainTable == null)
                return false;

            foreach (Control cnt in panelControl1.Controls)
            {
                if (cnt is SpinEdit || cnt is TextEdit || cnt is DateEdit || cnt is MemoEdit || cnt is CheckEdit)
                {
                    if (cnt.BackColor == frmMain.greenColor)
                        foreach (DataColumn dc in mainTable.Columns)
                        {
                            if (cnt.Name.Substring(3).Equals(dc.Caption, StringComparison.InvariantCultureIgnoreCase))
                            {
                                foreach (DataRow dr in mainTable.Select("", "", DataViewRowState.CurrentRows))
                                {
                                    if (dr[dc.Caption] == DBNull.Value)
                                        errorMessage += string.IsNullOrEmpty(errorMessage) ? panelControl1.Controls["lbl" + cnt.Name.Substring(3)].Text : ", " + panelControl1.Controls["lbl" + cnt.Name.Substring(3)].Text;
                                    else if (string.IsNullOrEmpty(Convert.ToString(dr[dc.Caption])))
                                        errorMessage += string.IsNullOrEmpty(errorMessage) ? panelControl1.Controls["lbl" + cnt.Name.Substring(3)].Text : ", " + panelControl1.Controls["lbl" + cnt.Name.Substring(3)].Text;
                                }
                            }
                        }
                }
            }
            if (string.IsNullOrEmpty(errorMessage))
                return true;
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("<" + errorMessage.Replace("@", string.Empty) + "> талбарт утга оруулах шаардлагатай!");
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
                        mainTable.TableName = "TBLCATEGORY";
                        adapter = new SqlDataAdapter(@"SELECT * FROM TBLCATEGORY WHERE TBLCATEGORY.CATEGORYID = -1", frmMain.conn);
                        builder = new SqlCommandBuilder(adapter);
                        adapter.Fill(mainTable);
                        frmMain.dataTableColumnNameToUpper(mainTable);
                        mainTable.Clear();
                        DataRow newRow = mainTable.NewRow();
                        newRow["ISACTIVE"] = "Y";
                        newRow["CATEGORYID"] = frmMain.NewID("TBLCATEGORY", "CATEGORYID");
                        newRow["CREATED"] = DateTime.Now;
                        newRow["CREATEDBY"] = frmLogin.LoginUserID;
                        newRow["IPADDRESS"] = frmMain.GetIPAddress();
                        newRow["MACADDRESS"] = frmMain.GetMACAddress();
                        mainTable.Rows.Add(newRow);
                        setEnabledChange(true);
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
                        foreach (DataRow dr in mainTable.Select("", "", DataViewRowState.CurrentRows))
                        {
                            entryID = (dr["CATEGORYID"]==DBNull.Value?-1: Convert.ToDecimal(dr["CATEGORYID"]));
                        }
                        formMode = "VIEW";
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
                        mainTable.TableName = "TBLCATEGORY";
                        adapter = new SqlDataAdapter(@"SELECT * FROM TBLCATEGORY WHERE TBLCATEGORY.CATEGORYID = " + entryID , frmMain.conn);
                        builder = new SqlCommandBuilder(adapter);
                        adapter.Fill(mainTable);
                        frmMain.dataTableColumnNameToUpper(mainTable);

                        barNew.Enabled = true;
                        barSave.Enabled = false;
                        barDelete.Enabled = true;
                        barCancel.Enabled = false;
                        barRefresh.Enabled = true;

                        setEnabledChange(true);
                        setDataBinding();
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