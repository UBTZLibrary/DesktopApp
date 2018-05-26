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

namespace UBTZLibrary.GeneralInfo
{
    public partial class frmUser : DevExpress.XtraEditors.XtraForm
    {
        string formMode = string.Empty;
        string entryID = string.Empty;
        private object[] para;
        bool isSetValue = true;
        DataTable mainTable;
        SqlDataAdapter adapter;
        SqlCommandBuilder builder;

        public frmUser()
        {
            InitializeComponent();
        }

        public frmUser(object[] para)
        {
            this.para = para;
            InitializeComponent();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormClosed += frmUser_FormClosed;
                barSave.ShortCut = Shortcut.CtrlS;
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

        void frmUser_FormClosed(object sender, FormClosedEventArgs e)
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
                            if (dc.Caption.Equals("STUDENTID"))
                            {
                                if (obj.Tag == null)
                                    dr[dc.Caption] = DBNull.Value;
                                else
                                    dr[dc.Caption] = obj.Tag;
                            }
                            else if (dc.Caption.Equals("PASSWORD"))
                            {
                                dr[dc.Caption] = frmMain.Encrypt(Convert.ToString(e.NewValue));
                            }
                            else
                            {
                                if (e.NewValue == null)
                                    dr[dc.Caption] = DBNull.Value;
                                else
                                    dr[dc.Caption] = e.NewValue;
                            }
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

        void setControlColorChange()
        {
            txtUserID.BackColor = frmMain.greenColor;
            txtPassword.BackColor = frmMain.greenColor;
            txtStudentID.BackColor = frmMain.greenColor;
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
                                switch (dc.Caption)
                                {
                                    case "STUDENTID":
                                        txtStudentID.Tag = Convert.ToString(dr[dc.Caption]);

                                        DataTable tableTemp = new DataTable();
                                        SqlCommand command = new SqlCommand();
                                        command.Connection = frmMain.conn;
                                        command.CommandText = "SELECT * FROM TBLSTUDENT WHERE STUDENTID = " + (dr["STUDENTID"] == DBNull.Value ? -1 : dr["STUDENTID"]);
                                        command.CommandType = CommandType.Text;
                                        SqlDataReader reader = command.ExecuteReader();
                                        tableTemp.Load(reader);
                                        frmMain.dataTableColumnNameToUpper(tableTemp);
                                        if (tableTemp.Rows.Count > 0)
                                        {
                                            txtStudentID.Text = Convert.ToString(tableTemp.Rows[0]["CODE"]);
                                            txtStudentName.Text = Convert.ToString(tableTemp.Rows[0]["FIRSTNAME"]);
                                        }
                                        else
                                        {
                                            txtStudentID.Text = string.Empty;
                                            txtStudentName.Text = string.Empty;
                                        }
                                        break;
                                    case "PASSWORD":
                                        (cnt as BaseEdit).EditValue = frmMain.Decrypt(Convert.ToString(dr[dc.Caption]));
                                        break;
                                    default: (cnt as BaseEdit).EditValue = dr[dc.Caption]; break;
                                }
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
                        mainTable.TableName = "TBLUSER";
                        adapter = new SqlDataAdapter("SELECT * FROM TBLUSER WHERE TBLUSER.USERID = '-1'", frmMain.conn);
                        builder = new SqlCommandBuilder(adapter);
                        adapter.Fill(mainTable);
                frmMain.dataTableColumnNameToUpper(mainTable);
                        mainTable.Clear();
                        DataRow newRow = mainTable.NewRow();
                        newRow["ISACTIVE"] = "Y";
                        newRow["CREATED"] = DateTime.Now;
                        newRow["CREATEDBY"] = frmLogin.LoginUserID;
                        newRow["IPADDRESS"] = frmMain.GetIPAddress();
                        newRow["MACADDRESS"] = frmMain.GetMACAddress();
                        mainTable.Rows.Add(newRow);
                        setEnabledChange(true);
                        setDataBinding();
                        txtUserID.ReadOnly = false;
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
                            entryID = Convert.ToString(dr["USERID"]);
                        }
                        formMode = "VIEW";
                        txtUserID.ReadOnly = true;
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
                        mainTable.TableName = "TBLUSER";
                        adapter = new SqlDataAdapter("SELECT * FROM TBLUSER WHERE TBLUSER.USERID = '" + entryID + "'", frmMain.conn);
                        builder = new SqlCommandBuilder(adapter);
                        adapter.Fill(mainTable);
                frmMain.dataTableColumnNameToUpper(mainTable);

                        barNew.Enabled = true;
                        barSave.Enabled = false;
                        barDelete.Enabled = true;
                        barCancel.Enabled = false;
                        barRefresh.Enabled = true;
                        txtUserID.ReadOnly = true;
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

        private void pictureEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.Properties.PasswordChar = '\0'; pictureEdit1.Image = null;
        }

        private void pictureEdit1_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.Properties.PasswordChar = '*'; pictureEdit1.Image = Properties.Resources.eye;
        }

    }
}