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
    public partial class frmBook : DevExpress.XtraEditors.XtraForm
    {
        string formMode = string.Empty;
        string entryID = string.Empty;
        private object[] para;
        bool isSetValue = true;
        bool isSetImage = false;
        decimal FocusedAuthorid;
        DataTable mainTable;
        DataTable mainTableDTL;
        DataTable mainTableDTLGrid;
        DataTable mainTableDTLGridView;
        SqlDataAdapter adapter;
        SqlDataAdapter adapterDTL;
        SqlDataAdapter adapterDTLGrid;
        SqlDataAdapter adapterDTLGridView;
        SqlCommandBuilder builder;
        SqlCommandBuilder builderDTL;
        SqlCommandBuilder builderDTLGrid;

        public frmBook()
        {
            InitializeComponent();
        }

        public frmBook(object[] para)
        {
            this.para = para;
            InitializeComponent();
        }

        private void frmBook_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormClosed += frmBook_FormClosed;
                (gridView1.Columns["CODE"].ColumnEdit as RepositoryItemButtonEdit).ButtonClick += colCode_ButtonClick;
                (gridView1.Columns["FIRSTNAME"].ColumnEdit as RepositoryItemButtonEdit).ButtonClick += colFirstName_ButtonClick;
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

        void frmBook_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mainTable != null)
                mainTable.Dispose();
            if (mainTableDTL != null)
                mainTableDTL.Dispose();
            if (mainTableDTLGrid != null)
                mainTableDTLGrid.Dispose();
            if (mainTableDTLGridView != null)
                mainTableDTLGridView.Dispose();
            if (adapter != null)
                adapter.Dispose();
            if (adapterDTL != null)
                adapterDTL.Dispose();
            if (adapterDTLGrid != null)
                adapterDTLGrid.Dispose();
            if (adapterDTLGridView != null)
                adapterDTLGridView.Dispose();
            if (builder != null)
                builder.Dispose();
            if (builderDTL != null)
                builderDTL.Dispose();
            if (builderDTLGrid != null)
                builderDTLGrid.Dispose();
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
                return;
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
                            if (dc.Caption.Equals("CATEGORYID"))
                            {
                                if (obj.Tag == null)
                                    dr[dc.Caption] = DBNull.Value;
                                else
                                    dr[dc.Caption] = obj.Tag;
                                isEdit = true;
                            }
                            else if (dc.Caption.Equals("PRINTEDYEAR"))
                            {
                                dr[dc.Caption] = Convert.ToDateTime(e.NewValue).ToString("yyyy");
                                isEdit = true;
                            }
                            else
                            {
                                if (e.NewValue == null)
                                    dr[dc.Caption] = DBNull.Value;
                                else
                                    dr[dc.Caption] = e.NewValue;
                                isEdit = true;
                            }
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

        private void txtCategoryID_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmCategoryList frmObjCategoryList = new frmCategoryList(new object[] { "Browse", "ISACTIVE = 'Y'" });
            frmObjCategoryList.FormClosed += frmObjCategoryList_FormClosed;
            frmObjCategoryList.ShowDialog();
        }

        private void txtCategoryName_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtCategoryID.Tag = null;
            txtCategoryName.Text = string.Empty;
            txtCategoryID.Text = string.Empty;
        }

        void frmObjCategoryList_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataRow dr = ((frmCategoryList)sender).returnRow;
            if (dr == null)
                return;
            txtCategoryID.Tag = Convert.ToString(dr["CATEGORYID"]);
            txtCategoryName.Text = Convert.ToString(dr["NAME"]);
            txtCategoryID.Text = Convert.ToString(dr["CODE"]);

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
                    newRow["BOOKID"] = mainTable.Select("", "", DataViewRowState.CurrentRows)[0]["BOOKID"];
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
                                switch (dc.Caption)
                                {
                                    case "CATEGORYID":
                                        txtCategoryID.Tag = Convert.ToString(dr[dc.Caption]);

                                        DataTable tableTemp = new DataTable();
                                        SqlCommand command = new SqlCommand();
                                        command.Connection = frmMain.conn;
                                        command.CommandText = "SELECT * FROM TBLCATEGORY WHERE CATEGORYID = " + (dr["CATEGORYID"] == DBNull.Value ? -1 : dr["CATEGORYID"]);
                                        command.CommandType = CommandType.Text;
                                        SqlDataReader reader = command.ExecuteReader();
                                        tableTemp.Load(reader);
                                        frmMain.dataTableColumnNameToUpper(tableTemp);
                                        if (tableTemp.Rows.Count > 0)
                                        {
                                            txtCategoryID.Text = Convert.ToString(tableTemp.Rows[0]["CODE"]);
                                            txtCategoryName.Text = Convert.ToString(tableTemp.Rows[0]["NAME"]);
                                        }
                                        else
                                        {
                                            txtCategoryID.Text = string.Empty;
                                            txtCategoryName.Text = string.Empty;
                                        }
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

        void setControlColorChange()
        {
            txtCode.BackColor = frmMain.greenColor;
            txtName.BackColor = frmMain.greenColor;
            txtCategoryID.BackColor = frmMain.greenColor;
        }

        bool getIsSave()
        {
            string errorMessage = string.Empty;
            string rowError = string.Empty;
            if (mainTable == null)
                return false;


            List<string> fieldName = new List<string>();
            fieldName.Add("Code");
            fieldName.Add("Name");
            fieldName.Add("CategoryID");
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
                    dr.RowError = "<Код> талбарт утга оруулах шаардлагатай!";
                    rowError = "Зохиогч <Код> талбарт утга оруулах шаардлагатай!";
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
                            string sql = @"DELETE FROM TBLBOOKREMAINDER WHERE BOOKID = @BOOKID";
                            SqlCommand command = new SqlCommand(sql, frmMain.conn);
                            command.Parameters.Add(new SqlParameter("BOOKID", dr["BOOKID"]));
                            command.ExecuteNonQuery();
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

                        decimal newID;
                        mainTable = new DataTable();
                        mainTable.TableName = "TBLBOOK";
                        adapter = new SqlDataAdapter(@"SELECT * FROM TBLBOOK WHERE BOOKID = -1", frmMain.conn);
                        builder = new SqlCommandBuilder(adapter);
                        adapter.Fill(mainTable);
                        frmMain.dataTableColumnNameToUpper(mainTable);
                        mainTable.Clear();
                        DataRow newRow = mainTable.NewRow();
                        newID = frmMain.NewID("TBLBOOK", "BOOKID");
                        newRow["BOOKID"] = newID;
                        newRow["ISACTIVE"] = "Y";
                        newRow["CREATED"] = DateTime.Now;
                        newRow["CREATEDBY"] = frmLogin.LoginUserID;
                        newRow["IPADDRESS"] = frmMain.GetIPAddress();
                        newRow["MACADDRESS"] = frmMain.GetMACAddress();
                        mainTable.Rows.Add(newRow);

                        mainTableDTL = new DataTable();
                        mainTableDTL.TableName = "TBLBOOKPICTURE";
                        adapterDTL = new SqlDataAdapter(@"SELECT * FROM TBLBOOKPICTURE WHERE BOOKID = '-1'", frmMain.conn);
                        builderDTL = new SqlCommandBuilder(adapterDTL);
                        adapterDTL.Fill(mainTableDTL);
                        frmMain.dataTableColumnNameToUpper(mainTableDTL);
                        mainTableDTL.Clear();
                        newRow = mainTableDTL.NewRow();
                        newRow["BOOKID"] = newID;
                        mainTableDTL.Rows.Add(newRow);

                        mainTableDTLGrid = new DataTable();
                        adapterDTLGrid = new SqlDataAdapter(@"SELECT * FROM TBLBOOKAUTHOR WHERE BOOKID = '-1'", frmMain.conn);
                        builderDTLGrid = new SqlCommandBuilder(adapterDTLGrid);
                        adapterDTLGrid.Fill(mainTableDTLGrid);
                        frmMain.dataTableColumnNameToUpper(mainTableDTLGrid);

                        mainTableDTLGridView = new DataTable();
                        adapterDTLGridView = new SqlDataAdapter(@"select tblBook.Bookid,
                                                       tblAuthor.Authorid,
                                                       tblAuthor.Code,
                                                       tblAuthor.Firstname,
                                                       tblAuthor.Lastname,
                                                       tblBookAuthor.Note
                                                  from tblBookAuthor
                                                  left join tblBook
                                                    on tblBook.BookID = tblBookAuthor.BookID
                                                  left join tblAuthor
                                                    on tblAuthor.AuthorID = tblBookAuthor.AuthorID
                                                 where tblBookAuthor.Bookid = '-1'", frmMain.conn);
                        adapterDTLGridView.Fill(mainTableDTLGridView);
                        frmMain.dataTableColumnNameToUpper(mainTableDTLGridView);
                        gridControl1.DataSource = mainTableDTLGridView;

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
                            foreach (DataRow dr in mainTable.Select("", "", DataViewRowState.CurrentRows))
                            {
                                string sql = @"insert into TBLBOOKREMAINDER
                                                      (BOOKID,TOTAL,REMAINDER,CREATEDBY,UPDATEDBY,IPADDRESS,MACADDRESS)
                                                    values
                                                      (@BOOKID,@TOTAL,@REMAINDER,@CREATEDBY,@UPDATEDBY,@IPADDRESS,@MACADDRESS)";
                                SqlCommand command = new SqlCommand(sql, frmMain.conn);
                                command.Parameters.Add(new SqlParameter("BOOKID", dr["BOOKID"]));
                                command.Parameters.Add(new SqlParameter("TOTAL", dr["TOTALVOLUMENUM"]));
                                command.Parameters.Add(new SqlParameter("REMAINDER", dr["TOTALVOLUMENUM"]));
                                command.Parameters.Add(new SqlParameter("CREATEDBY", frmLogin.LoginUserID));
                                command.Parameters.Add(new SqlParameter("UPDATEDBY", frmLogin.LoginUserID));
                                command.Parameters.Add(new SqlParameter("IPADDRESS", frmMain.GetIPAddress()));
                                command.Parameters.Add(new SqlParameter("MACADDRESS", frmMain.GetMACAddress()));
                                command.ExecuteNonQuery();
                            }
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
                            entryID = Convert.ToString(dr["BOOKID"]);
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
                        mainTable.TableName = "TBLBOOK";
                        adapter = new SqlDataAdapter(@"SELECT * FROM TBLBOOK WHERE BOOKID = '" + entryID + "'", frmMain.conn);
                        builder = new SqlCommandBuilder(adapter);
                        adapter.Fill(mainTable);
                        frmMain.dataTableColumnNameToUpper(mainTable);

                        mainTableDTL = new DataTable();
                        mainTableDTL.TableName = "TBLBOOKPICTURE";
                        adapterDTL = new SqlDataAdapter(@"SELECT * FROM TBLBOOKPICTURE WHERE BOOKID = '" + entryID + "'", frmMain.conn);
                        builderDTL = new SqlCommandBuilder(adapterDTL);
                        adapterDTL.Fill(mainTableDTL);
                        frmMain.dataTableColumnNameToUpper(mainTableDTL);

                        mainTableDTLGrid = new DataTable();
                        adapterDTLGrid = new SqlDataAdapter(@"SELECT * FROM TBLBOOKAUTHOR WHERE BOOKID = '" + entryID + "'", frmMain.conn);
                        builderDTLGrid = new SqlCommandBuilder(adapterDTLGrid);
                        adapterDTLGrid.Fill(mainTableDTLGrid);
                        frmMain.dataTableColumnNameToUpper(mainTableDTLGrid);

                        mainTableDTLGridView = new DataTable();
                        adapterDTLGridView = new SqlDataAdapter(@"select tblBookAuthor.Bookid,
                                                       tblBookAuthor.Authorid,
                                                       tblAuthor.Code,
                                                       tblAuthor.Firstname,
                                                       tblAuthor.Lastname,
                                                       tblBookAuthor.Note
                                                  from tblBookAuthor
                                                  left join tblBook
                                                    on tblBook.BookID = tblBookAuthor.BookID
                                                  left join tblAuthor
                                                    on tblAuthor.AuthorID = tblBookAuthor.AuthorID
                                                 where tblBookAuthor.Bookid = '" + entryID + "'", frmMain.conn);
                        adapterDTLGridView.Fill(mainTableDTLGridView);
                        frmMain.dataTableColumnNameToUpper(mainTableDTLGridView);
                        gridControl1.DataSource = mainTableDTLGridView;

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

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            decimal newID = -1;
            DataRow tempRow;
            if (e != null && e.RowHandle == -2147483647)
                tempRow = gridView1.GetFocusedDataRow();
            else
                tempRow = (gridControl1.DataSource as DataTable).Select("AUTHORID is null")[0];
            DataRow newRow = mainTableDTLGrid.NewRow();
            newRow["BOOKID"] = mainTable.Rows[0]["BOOKID"];
            tempRow["BOOKID"] = mainTable.Rows[0]["BOOKID"];
            foreach (DataRow dr in mainTableDTLGrid.Select("", "", DataViewRowState.CurrentRows))
            {
                if (dr["AUTHORID"] != DBNull.Value && Convert.ToDecimal(dr["AUTHORID"]) < newID)
                    newID = Convert.ToDecimal(dr["AUTHORID"]);
            }
            newRow["AUTHORID"] = newID;
            tempRow["AUTHORID"] = newID;
            FocusedAuthorid = newID;
            mainTableDTLGrid.Rows.Add(newRow);
            if (!barSave.Enabled)
            {
                barNew.Enabled = false;
                barSave.Enabled = true;
                barDelete.Enabled = false;
                barCancel.Enabled = true;
                barRefresh.Enabled = false;
            }
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            DataRow tempRow = gridView1.GetFocusedDataRow();
            if (e.Column.FieldName.Equals("CODE") && tempRow != null && tempRow["AUTHORID"] != DBNull.Value)
                FocusedAuthorid = Convert.ToDecimal(tempRow["AUTHORID"]);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow tempRow = gridView1.GetFocusedDataRow();
            DataRow mainRow = mainTableDTLGrid.Select("AUTHORID = '" + tempRow["AUTHORID"] + "'")[0];
            switch (e.Column.FieldName)
            {
                case "NOTE": mainRow["NOTE"] = e.Value; break;
                case "CODE": mainRow["AUTHORID"] = tempRow["AUTHORID"]; FocusedAuthorid = Convert.ToDecimal(tempRow["AUTHORID"]); break;
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

        void colFirstName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow tempRow = gridView1.GetFocusedDataRow();
            if (tempRow == null)
                return;
            if (tempRow["AUTHORID"] == DBNull.Value)
                foreach (DataRow dr in mainTableDTLGrid.Select("AUTHORID is null", "", DataViewRowState.CurrentRows))
                    dr.Delete();
            else
                foreach (DataRow dr in mainTableDTLGrid.Select("AUTHORID = '" + tempRow["AUTHORID"] + "'", "", DataViewRowState.CurrentRows))
                    dr.Delete();

            tempRow.Delete();

            if (!barSave.Enabled)
            {
                barNew.Enabled = false;
                barSave.Enabled = true;
                barDelete.Enabled = false;
                barCancel.Enabled = true;
                barRefresh.Enabled = false;
            }
        }

        void colCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string whereStr = "ISACTIVE = 'Y'";
            foreach (DataRow dr in mainTableDTLGrid.Select("", "", DataViewRowState.CurrentRows))
            {
                if (dr["AUTHORID"] == DBNull.Value)
                    continue;
                whereStr += " AND AUTHORID <> " + Convert.ToString(dr["AUTHORID"]);
            }
            frmAuthorList frmAuthorList = new frmAuthorList(new object[] { "Browse", whereStr });
            frmAuthorList.FormClosed += frmAuthorList_FormClosed;
            frmAuthorList.ShowDialog();
        }

        void frmAuthorList_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataRow dr = ((frmAuthorList)sender).returnRow;
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

            DataRow tempRow = (gridControl1.DataSource as DataTable).Select("AUTHORID = '" + FocusedAuthorid + "'")[0];

            mainTableDTLGrid.Select("AUTHORID = '" + FocusedAuthorid + "'")[0]["AUTHORID"] = dr["AUTHORID"];
            FocusedAuthorid = Convert.ToDecimal(dr["AUTHORID"]);
            tempRow["AUTHORID"] = dr["AUTHORID"];
            tempRow["CODE"] = dr["CODE"];
            tempRow["FIRSTNAME"] = dr["FIRSTNAME"];
            tempRow["LASTNAME"] = dr["LASTNAME"];

            if (!barSave.Enabled)
            {
                barNew.Enabled = false;
                barSave.Enabled = true;
                barDelete.Enabled = false;
                barCancel.Enabled = true;
                barRefresh.Enabled = false;
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "CODE")
            {
                e.Appearance.BackColor = frmMain.greenColor;
            }
        }

    }
}