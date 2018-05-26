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

namespace UBTZLibrary.GeneralInfo
{
    public partial class frmStudent : DevExpress.XtraEditors.XtraForm
    {
        string formMode = string.Empty;
        string entryID = string.Empty;
        private object[] para;
        bool isSetValue = true;
        bool isSetImage = false;
        DataTable mainTable;
        DataTable mainTableDTL;
        SqlDataAdapter adapter;
        SqlDataAdapter adapterDTL;
        SqlCommandBuilder builder;
        SqlCommandBuilder builderDTL;

        public frmStudent()
        {
            InitializeComponent();
        }

        public frmStudent(object[] para)
        {
            this.para = para;
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormClosed += frmStudent_FormClosed;
                barSave.ShortCut = Shortcut.CtrlS;
                getGenderLookUp();
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

        void frmStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mainTable != null)
                mainTable.Dispose();
            if (mainTableDTL != null)
                mainTableDTL.Dispose();
            if (adapter != null)
                adapter.Dispose();
            if (adapterDTL != null)
                adapterDTL.Dispose();
            if (builder != null)
                builder.Dispose();
            if (builderDTL != null)
                builderDTL.Dispose();
        }

        private void txtPictureData_EditValueChanged(object sender, EventArgs e)
        {
            if (isSetValue)
                return;
            setImageData((Bitmap)txtPictureData.Image);
        }

        private void txtPictureData_DoubleClick(object sender, EventArgs e)
        {
            if (mainTableDTL == null || isSetValue)
                return;
            if (isSetImage || txtPictureData.Image == null)
                return;
            frmImageCropResize frmObject = new frmImageCropResize(txtPictureData.Image);
            frmObject.FormClosed += frmObject_FormClosed;
            frmObject.ShowDialog();
        }

        void frmObject_FormClosed(object sender, FormClosedEventArgs e)
        {
            isSetImage = true;
            frmImageCropResize frmObject = (frmImageCropResize)sender;
            if (frmObject.returnObject == null)
            {
                isSetImage = false;
                return;
            }
            if (frmObject.isEdit)
            {
                txtPictureData.Image = frmObject.returnObject;
                setImageData(frmObject.returnObject);
            }
            isSetImage = false;
        }

        private void EditValueChanged(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
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

        private void barNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            setModeChange("ADD");
        }

        private void barDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            setModeChange("DELETE");
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

        void setImageData(Bitmap returnObject)
        {
            if (returnObject != null)
            {
                if (mainTableDTL.Select("", "", DataViewRowState.CurrentRows).Length == 0)
                {
                    DataRow newRow = mainTableDTL.NewRow();
                    newRow["STUDENTID"] = mainTable.Select("", "", DataViewRowState.CurrentRows)[0]["STUDENTID"];
                    mainTableDTL.Rows.Add(newRow);
                }

                foreach (DataRow dr in mainTableDTL.Select("", "", DataViewRowState.CurrentRows))
                {
                    Bitmap temp = returnObject;

                    MemoryStream stream = new MemoryStream();
                    temp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] image = stream.ToArray();

                    dr["PICTUREDATA"] = image;

                    Bitmap objBitmap;
                    if (temp.Height > temp.Width)
                        objBitmap = new Bitmap(temp, new Size(temp.Width * 100 / temp.Height, 100));
                    else
                        objBitmap = new Bitmap(temp, new Size(100, temp.Height * 100 / temp.Width));

                    stream = new MemoryStream();
                    objBitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    image = stream.ToArray();
                    dr["PICTUREDATA"] = image;
                }
            }

            if (!barSave.Enabled)
            {
                barNew.Enabled = false;
                barSave.Enabled = true;
                barDelete.Enabled = false;
                barCancel.Enabled = true;
                barRefresh.Enabled = false;
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
            txtGender.Properties.DataSource = dt;
            txtGender.ItemIndex = 0;
        }

        void getStatusLookUp()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NAME");
            dt.Columns.Add("TYPE");
            DataRow dr = dt.NewRow();
            dr["NAME"] = "Идэвхтэй";
            dr["TYPE"] = "AC";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["NAME"] = "Түдгэлзүүлсэн";
            dr["TYPE"] = "BL";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["NAME"] = "Идэвхгүй";
            dr["TYPE"] = "IN";
            dt.Rows.Add(dr);
            txtStatus.Properties.DataSource = dt;
            txtStatus.ItemIndex = 0;
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
                    if (mainTableDTL == null)
                    {
                        (cnt as PictureEdit).Image = null;
                        continue;
                    }
                    foreach (DataRow dr in mainTableDTL.Select("", "", DataViewRowState.CurrentRows))
                    {
                        if (dr["PICTUREDATA"] == DBNull.Value)
                        {
                            (cnt as PictureEdit).Image = null;
                            continue;
                        }
                        var data = (Byte[])(dr["PICTUREDATA"]);
                        var stream = new MemoryStream(data);
                        (cnt as PictureEdit).Image = Image.FromStream(stream);
                    }
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
            txtFirstName.BackColor = frmMain.greenColor;
            txtStatus.BackColor = frmMain.greenColor;
            txtGender.BackColor = frmMain.greenColor;
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

                        foreach (DataRow dr in mainTableDTL.Select("", "", DataViewRowState.CurrentRows))
                        {
                            dr.Delete();
                        }
                        builderDTL.GetDeleteCommand();
                        adapterDTL.Update(mainTable);

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

                        decimal newID;
                        mainTable = new DataTable();
                        mainTable.TableName = "TBLSTUDENT";
                        adapter = new SqlDataAdapter(@"SELECT * FROM TBLSTUDENT WHERE STUDENTID = -1", frmMain.conn);
                        builder = new SqlCommandBuilder(adapter);
                        adapter.Fill(mainTable);
                frmMain.dataTableColumnNameToUpper(mainTable);
                        mainTable.Clear();
                        DataRow newRow = mainTable.NewRow();
                        newID = frmMain.NewID("TBLSTUDENT", "STUDENTID");
                        newRow["STUDENTID"] = newID;
                        newRow["STATUS"] = "AC";
                        newRow["GENDER"] = "M";
                        newRow["LASTNAMELENGTH"] = 1;
                        newRow["CREATED"] = DateTime.Now;
                        newRow["CREATEDBY"] = frmLogin.LoginUserID;
                        newRow["IPADDRESS"] = frmMain.GetIPAddress();
                        newRow["MACADDRESS"] = frmMain.GetMACAddress();
                        mainTable.Rows.Add(newRow);

                        mainTableDTL = new DataTable();
                        mainTableDTL.TableName = "TBLSTUDENTPIC";
                        adapterDTL = new SqlDataAdapter(@"SELECT * FROM TBLSTUDENTPIC WHERE STUDENTID = -1", frmMain.conn);
                        builderDTL = new SqlCommandBuilder(adapterDTL);
                        adapterDTL.Fill(mainTableDTL);
                frmMain.dataTableColumnNameToUpper(mainTableDTL);
                        mainTableDTL.Clear();
                        newRow = mainTableDTL.NewRow();
                        newRow["STUDENTID"] = newID;
                        mainTableDTL.Rows.Add(newRow);

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
                        if (mainTableDTL.Select("", "", DataViewRowState.Added).Length > 0)
                        {
                            builderDTL.GetInsertCommand();
                            adapterDTL.Update(mainTableDTL);
                        }
                        if (mainTableDTL.Select("", "", DataViewRowState.ModifiedCurrent).Length > 0)
                        {
                            builderDTL.GetUpdateCommand();
                            adapterDTL.Update(mainTableDTL);
                        }
                        foreach (DataRow dr in mainTable.Select("", "", DataViewRowState.CurrentRows))
                        {
                            entryID = Convert.ToString(dr["STUDENTID"]);
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
                                mainTableDTL = null;
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
                        mainTable.TableName = "TBLSTUDENT";
                        adapter = new SqlDataAdapter(@"SELECT * FROM TBLSTUDENT WHERE STUDENTID = '" + entryID + "'", frmMain.conn);
                        builder = new SqlCommandBuilder(adapter);
                        adapter.Fill(mainTable);
                frmMain.dataTableColumnNameToUpper(mainTable);

                        mainTableDTL = new DataTable();
                        mainTableDTL.TableName = "TBLSTUDENTPIC";
                        adapterDTL = new SqlDataAdapter(@"SELECT * FROM TBLSTUDENTPIC WHERE STUDENTID = '" + entryID + "'", frmMain.conn);
                        builderDTL = new SqlCommandBuilder(adapterDTL);
                        adapterDTL.Fill(mainTableDTL);
                frmMain.dataTableColumnNameToUpper(mainTableDTL);

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