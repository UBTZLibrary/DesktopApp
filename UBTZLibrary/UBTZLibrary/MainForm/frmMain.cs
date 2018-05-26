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
using DevExpress.XtraBars;
using DevExpress.XtraTabbedMdi;
using UBTZLibrary.Inquiry;
using System.Collections;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using UBTZLibrary.MainForm;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;

namespace UBTZLibrary
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public static string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        //"User Id=" + ConfigurationSettings.AppSettings["UserID"]
        //+ ";Password=" + ConfigurationSettings.AppSettings["Password"]
        //+ ";Data Source=" + ConfigurationSettings.AppSettings["DataSource"] + ";";
        public static Color greenColor = Color.FromArgb(192, 255, 192);
        public static SqlConnection conn;
        DataTable treeViewDataSource;

        public frmMain()
        {
            InitializeComponent();
            try
            {
                conn = new SqlConnection(frmMain.connStr);
                conn.Open();

                CNavBarLocalizer Localizer = new CNavBarLocalizer();
                DevExpress.XtraNavBar.NavBarLocalizer.Active = Localizer;

                CPivotGridLocalizer PivotGridLocalizer = new CPivotGridLocalizer();
                DevExpress.XtraPivotGrid.Localization.PivotGridLocalizer.Active = PivotGridLocalizer;

                CGridLocalizer GridLocalizer = new CGridLocalizer();
                DevExpress.XtraGrid.Localization.GridLocalizer.Active = GridLocalizer;
            }
            catch { }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            SetTreeViewDataSource();
            InitBarItem();
            TreeListColumn column = myTreeList.Columns.Add();
            column.Caption = "Нэр";
            column.FieldName = "NAME";
            column.Visible = true;
            column.VisibleIndex = 0;

            myTreeList.DoubleClick += new EventHandler(treeList1_DoubleClick);
            myTreeList.BeforeExpand += new BeforeExpandEventHandler(tree_BeforeExpand);
            myTreeList.AfterExpand += new NodeEventHandler(tree_AfterExpand);
            myTreeList.BeforeCollapse += new BeforeCollapseEventHandler(tree_BeforeCollapse);
            myTreeList.AfterCollapse += new NodeEventHandler(tree_AfterCollapse);

            myTreeList.DataSource = treeViewDataSource;
            myTreeList.BringToFront();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
            if (treeViewDataSource != null)
                treeViewDataSource.Dispose();
        }

        void tree_BeforeExpand(object sender, BeforeExpandEventArgs e)
        {
            (sender as TreeList).FocusedNode = e.Node;
        }

        void tree_AfterExpand(object sender, NodeEventArgs e)
        {
            (sender as TreeList).FocusedNode = e.Node;
        }

        void tree_BeforeCollapse(object sender, BeforeCollapseEventArgs e)
        {
            (sender as TreeList).FocusedNode = e.Node;
        }

        void tree_AfterCollapse(object sender, NodeEventArgs e)
        {
            (sender as TreeList).FocusedNode = e.Node;
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            DataRow tempSelectMenu = ((System.Data.DataRowView)(myTreeList.GetDataRecordByNode(myTreeList.FocusedNode))).Row;

            switch (Convert.ToString(tempSelectMenu["FORMNAME"]))
            {
                case "frmStudentList":
                    frmStudentList frmObjStudentList = new frmStudentList();
                    frmObjStudentList.KeyPress += frm_KeyPress;
                    frmObjStudentList.MdiParent = this;
                    frmObjStudentList.Show();
                    break;
                case "frmUserList":
                    frmUserList frmObjUserList = new frmUserList();
                    frmObjUserList.KeyPress += frm_KeyPress;
                    frmObjUserList.MdiParent = this;
                    frmObjUserList.Show();
                    break;

                case "frmCategoryList":
                    frmCategoryList frmObjCategoryList = new frmCategoryList();
                    frmObjCategoryList.KeyPress += frm_KeyPress;
                    frmObjCategoryList.MdiParent = this;
                    frmObjCategoryList.Show();
                    break;
                case "frmAuthorList":
                    frmAuthorList frmObjAuthorList = new frmAuthorList();
                    frmObjAuthorList.KeyPress += frm_KeyPress;
                    frmObjAuthorList.MdiParent = this;
                    frmObjAuthorList.Show();
                    break;
                case "frmBookList":
                    frmBookList frmObjBookList = new frmBookList();
                    frmObjBookList.KeyPress += frm_KeyPress;
                    frmObjBookList.MdiParent = this;
                    frmObjBookList.Show();
                    break;

                case "frmBookOutList":
                    frmBookOutList frmBookOutList = new frmBookOutList();
                    frmBookOutList.KeyPress += frm_KeyPress;
                    frmBookOutList.MdiParent = this;
                    frmBookOutList.Show();
                    break;
                case "frmBookPurchaseList":
                    frmBookPurchaseList frmBookPurchaseList = new frmBookPurchaseList();
                    frmBookPurchaseList.KeyPress += frm_KeyPress;
                    frmBookPurchaseList.MdiParent = this;
                    frmBookPurchaseList.Show();
                    break;
                case "frmBookRemainderList":
                    frmBookRemainderList frmBookRemainderList = new frmBookRemainderList();
                    frmBookRemainderList.KeyPress += frm_KeyPress;
                    frmBookRemainderList.MdiParent = this;
                    frmBookRemainderList.Show();
                    break;

                case "frmBookOrderResolution":
                    frmBookOrderResolution frmBookOrderResolution = new frmBookOrderResolution();
                    frmBookOrderResolution.KeyPress += frm_KeyPress;
                    frmBookOrderResolution.MdiParent = this;
                    frmBookOrderResolution.Show();
                    break;
                case "frmBookOrder":
                    frmBookOrder frmBookOrder = new frmBookOrder();
                    frmBookOrder.KeyPress += frm_KeyPress;
                    frmBookOrder.MdiParent = this;
                    frmBookOrder.Show();
                    break;
                case "frmBookOrderLateList":
                    frmBookOrderLateList frmBookOrderLateList = new frmBookOrderLateList();
                    frmBookOrderLateList.KeyPress += frm_KeyPress;
                    frmBookOrderLateList.MdiParent = this;
                    frmBookOrderLateList.Show();
                    break;
                case "frmBookOrderTakeList":
                    frmBookOrderTakeList frmBookOrderTakeList = new frmBookOrderTakeList();
                    frmBookOrderTakeList.KeyPress += frm_KeyPress;
                    frmBookOrderTakeList.MdiParent = this;
                    frmBookOrderTakeList.Show();
                    break;
                case "frmBookOrderPayList":
                    frmBookOrderPayList frmBookOrderPayList = new frmBookOrderPayList();
                    frmBookOrderPayList.KeyPress += frm_KeyPress;
                    frmBookOrderPayList.MdiParent = this;
                    frmBookOrderPayList.Show();
                    break;
            }
        }

        private void frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                ((Form)sender).Close();
        }

        private void barAllChildFormClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
        }

        private void barClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        public void InitBarItem()
        {
            BarCheckItem item;
            foreach (DevExpress.Skins.SkinContainer cnt in DevExpress.Skins.SkinManager.Default.Skins)
            {
                if (!cnt.SkinName.Contains("Office"))
                {
                    item = new BarCheckItem();
                    item.Caption = cnt.SkinName;
                    item.GroupIndex = 1;
                    barScreenDesign.AddItem(item);
                }
            }
            foreach (DevExpress.Skins.SkinContainer cnt in DevExpress.Skins.SkinManager.Default.Skins)
            {
                if (cnt.SkinName.Contains("Office"))
                {
                    item = new BarCheckItem();
                    item.Caption = cnt.SkinName;
                    item.GroupIndex = 1;
                    barScreenDesign.AddItem(item);
                }
            }
        }

        void barScreenDesign_ItemClick(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                DataTable dt;
                List<string> parentID = new List<string>();
                string rowFilterValue = string.Empty;
                (myTreeList.DataSource as DataTable).DefaultView.RowFilter = String.Format("NAME LIKE '%{0}%'", Convert.ToString(txtSearch.Text).Replace("'", "''"));
                dt = (myTreeList.DataSource as DataTable).DefaultView.ToTable();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (!parentID.Contains(Convert.ToString(dr["PARENTID"]))
                            && !string.IsNullOrEmpty(Convert.ToString(dr["PARENTID"]).Trim()))
                            parentID.Add(Convert.ToString(dr["PARENTID"]));

                    }
                    foreach (string value in parentID)
                    {
                        rowFilterValue += string.IsNullOrEmpty(rowFilterValue) ? "ID IN ('" + value + "'" : ", '" + value + "'";
                    }

                    rowFilterValue += ")";
                    int listCount;
                    while (true)
                    {
                        listCount = parentID.Count;
                        parentID = searchID(rowFilterValue, parentID, (myTreeList.DataSource as DataTable));

                        rowFilterValue = string.Empty;
                        foreach (string value in parentID)
                        {
                            rowFilterValue += string.IsNullOrEmpty(rowFilterValue) ? "ID IN ('" + value + "'" : ", '" + value + "'";
                        }
                        rowFilterValue += ")";

                        if (listCount == parentID.Count)
                            break;
                    }
                    (myTreeList.DataSource as DataTable).DefaultView.RowFilter = String.Format("NAME LIKE '%{0}%'", Convert.ToString(txtSearch.Text).Replace("'", "''")) + " OR " + rowFilterValue;
                }
                myTreeList.ExpandAll();
            }
            else
                (myTreeList.DataSource as DataTable).DefaultView.RowFilter = "";
        }

        private List<string> searchID(string rowFilterValue, List<string> parentID, DataTable dataSourse)
        {
            foreach (DataRow dr in dataSourse.Select(rowFilterValue))
            {
                if (!parentID.Contains(Convert.ToString(dr["PARENTID"]))
                     && !string.IsNullOrEmpty(Convert.ToString(dr["PARENTID"]).Trim()))
                    parentID.Add(Convert.ToString(dr["PARENTID"]));
            }
            return parentID;
        }

        public static void dataTableColumnNameToUpper(DataTable temp)
        {
            try
            {
                foreach (DataColumn dc in temp.Columns)
                {
                    try
                    {
                        dc.ColumnName = dc.ColumnName.ToUpper();
                        dc.Caption = dc.Caption.ToUpper();
                    }
                    catch (Exception)
                    {
 
                    }
                }
            }
            catch (Exception)
            {
 
            }
        }

        public static decimal NewID(string tableName, string fieldName)
        {
            try
            {
                DataTable mainTable = new DataTable();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT USEDINDEX FROM TBLINDEX WHERE UPPER(INDEXCODE) = UPPER('" + tableName + "')";
                command.CommandType = CommandType.Text;

                SqlDataReader dr = command.ExecuteReader();
                mainTable.Clear();
                mainTable.Load(dr);
                frmMain.dataTableColumnNameToUpper(mainTable);
                if (mainTable.Rows.Count > 0)
                {
                    command.CommandText = " UPDATE TBLINDEX SET USEDINDEX = '" + (Convert.ToDecimal(mainTable.Rows[0]["USEDINDEX"]) + 1) + "' WHERE UPPER(INDEXCODE) = UPPER('" + tableName + "')";
                    command.ExecuteNonQuery();
                    return Convert.ToDecimal(mainTable.Rows[0]["USEDINDEX"]);
                }
                else
                {
                    command.CommandText = " INSERT INTO TBLINDEX (INDEXCODE, USEDINDEX) VALUES ('" + tableName + "', (SELECT ISNULL(MAX(" + fieldName + "), 0) + 1 FROM " + tableName + ")) ";
                    command.ExecuteNonQuery();
                    command.CommandText = "SELECT USEDINDEX FROM TBLINDEX WHERE UPPER(INDEXCODE) = UPPER('" + tableName + "')";
                    dr = command.ExecuteReader();
                    mainTable.Clear();
                    mainTable.Load(dr);
                    frmMain.dataTableColumnNameToUpper(mainTable);
                    if (mainTable.Rows.Count > 0)
                    {
                        command.CommandText = " UPDATE TBLINDEX SET USEDINDEX = '" + (Convert.ToDecimal(mainTable.Rows[0]["USEDINDEX"]) + 1) + "' WHERE UPPER(INDEXCODE) = UPPER('" + tableName + "')";
                        command.ExecuteNonQuery();
                        return Convert.ToDecimal(mainTable.Rows[0]["USEDINDEX"]);
                    }
                }
                dr.Dispose();
                command.Dispose();
                mainTable.Dispose();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
            return 1;
        }

        public static string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            } return sMacAddress;
        }

        public static string GetIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Not Found!");
        }

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "Ariunmunkh.e";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x4a, 0x76, 0x65, 0x6a, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76, 0x7a });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "Ariunmunkh.e";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x4a, 0x76, 0x65, 0x6a, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76, 0x7a });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        void SetTreeViewDataSource()
        {
            treeViewDataSource = new DataTable();
            treeViewDataSource.Columns.Add("ID");
            treeViewDataSource.Columns.Add("ParentID");
            treeViewDataSource.Columns.Add("ICONINDEX");
            treeViewDataSource.Columns.Add("NAME");
            treeViewDataSource.Columns.Add("FORMNAME");

            DataRow newRow = treeViewDataSource.NewRow();
            newRow["ID"] = "0";
            newRow["ParentID"] = "-1";
            newRow["ICONINDEX"] = "1";
            newRow["NAME"] = "Хэрэглэгч";
            newRow["FORMNAME"] = DBNull.Value;
            treeViewDataSource.Rows.Add(newRow);
            newRow = treeViewDataSource.NewRow();
            newRow["ID"] = "1";
            newRow["ParentID"] = "0";
            newRow["ICONINDEX"] = "1";
            newRow["NAME"] = "Оюутны жагсаалт";
            newRow["FORMNAME"] = "frmStudentList";
            treeViewDataSource.Rows.Add(newRow);
            newRow = treeViewDataSource.NewRow();
            newRow["ID"] = "2";
            newRow["ParentID"] = "0";
            newRow["ICONINDEX"] = "1";
            newRow["NAME"] = "Хэрэглэгчийн жагсаалт";
            newRow["FORMNAME"] = "frmUserList";
            treeViewDataSource.Rows.Add(newRow);

            newRow = treeViewDataSource.NewRow();
            newRow["ID"] = "3";
            newRow["ParentID"] = "-1";
            newRow["ICONINDEX"] = "1";
            newRow["NAME"] = "Ном";
            newRow["FORMNAME"] = DBNull.Value;
            treeViewDataSource.Rows.Add(newRow);
            newRow = treeViewDataSource.NewRow();
            newRow["ID"] = "4";
            newRow["ParentID"] = "3";
            newRow["ICONINDEX"] = "1";
            newRow["NAME"] = "Ангилалын жагсаалт";
            newRow["FORMNAME"] = "frmCategoryList";
            treeViewDataSource.Rows.Add(newRow);
            newRow = treeViewDataSource.NewRow();
            newRow["ID"] = "5";
            newRow["ParentID"] = "3";
            newRow["ICONINDEX"] = "1";
            newRow["NAME"] = "Зохиогчийн жагсаалт";
            newRow["FORMNAME"] = "frmAuthorList";
            treeViewDataSource.Rows.Add(newRow);
            newRow = treeViewDataSource.NewRow();
            newRow["ID"] = "6";
            newRow["ParentID"] = "3";
            newRow["ICONINDEX"] = "1";
            newRow["NAME"] = "Номын жагсаалт";
            newRow["FORMNAME"] = "frmBookList";
            treeViewDataSource.Rows.Add(newRow);

            newRow = treeViewDataSource.NewRow();
            newRow["ID"] = "7";
            newRow["ParentID"] = "-1";
            newRow["ICONINDEX"] = "1";
            newRow["NAME"] = "Ном - Үлдэгдэл";
            newRow["FORMNAME"] = DBNull.Value;
            treeViewDataSource.Rows.Add(newRow);
            newRow = treeViewDataSource.NewRow();
            newRow["ID"] = "8";
            newRow["ParentID"] = "7";
            newRow["ICONINDEX"] = "1";
            newRow["NAME"] = "Ном - Үлдэгдэл";
            newRow["FORMNAME"] = "frmBookRemainderList";
            treeViewDataSource.Rows.Add(newRow);
            newRow = treeViewDataSource.NewRow();
            newRow["ID"] = "9";
            newRow["ParentID"] = "7";
            newRow["ICONINDEX"] = "1";
            newRow["NAME"] = "Орлогодсон номын жагсаалт";
            newRow["FORMNAME"] = "frmBookPurchaseList";
            treeViewDataSource.Rows.Add(newRow);
            newRow = treeViewDataSource.NewRow();
            newRow["ID"] = "10";
            newRow["ParentID"] = "7";
            newRow["ICONINDEX"] = "1";
            newRow["NAME"] = "Зарлагадсан номын жагсаалт";
            newRow["FORMNAME"] = "frmBookOutList";
            treeViewDataSource.Rows.Add(newRow);

            newRow = treeViewDataSource.NewRow();
            newRow["ID"] = "11";
            newRow["ParentID"] = "-1";
            newRow["ICONINDEX"] = "1";
            newRow["NAME"] = "Ном - Захиалга";
            newRow["FORMNAME"] = DBNull.Value;
            treeViewDataSource.Rows.Add(newRow);
            newRow = treeViewDataSource.NewRow();
            newRow["ID"] = "12";
            newRow["ParentID"] = "11";
            newRow["ICONINDEX"] = "1";
            newRow["NAME"] = "Ном - Захиалга шийдвэрлэх";
            newRow["FORMNAME"] = "frmBookOrderResolution";
            treeViewDataSource.Rows.Add(newRow);
            newRow = treeViewDataSource.NewRow();
            newRow["ID"] = "13";
            newRow["ParentID"] = "11";
            newRow["ICONINDEX"] = "1";
            newRow["NAME"] = "Ном олгох";
            newRow["FORMNAME"] = "frmBookOrder";
            treeViewDataSource.Rows.Add(newRow);
            newRow = treeViewDataSource.NewRow();
            newRow["ID"] = "14";
            newRow["ParentID"] = "11";
            newRow["ICONINDEX"] = "1";
            newRow["NAME"] = "Ном хоцроосон оюутнуудын лавлагаа";
            newRow["FORMNAME"] = "frmBookOrderLateList";
            treeViewDataSource.Rows.Add(newRow);
            newRow = treeViewDataSource.NewRow();
            newRow["ID"] = "15";
            newRow["ParentID"] = "11";
            newRow["ICONINDEX"] = "1";
            newRow["NAME"] = "Ном авсан оюутнуудын лавлагаа";
            newRow["FORMNAME"] = "frmBookOrderTakeList";
            treeViewDataSource.Rows.Add(newRow);
            newRow = treeViewDataSource.NewRow();
            newRow["ID"] = "16";
            newRow["ParentID"] = "11";
            newRow["ICONINDEX"] = "1";
            newRow["NAME"] = "Ном төлсөн оюутнуудын лавлагаа";
            newRow["FORMNAME"] = "frmBookOrderPayList";
            treeViewDataSource.Rows.Add(newRow);
        }

        public static void ExportExcel(GridControl gridControl, GridView MainGridView)
        {
            SaveFileDialog dialog = null;

            try
            {
                dialog = new SaveFileDialog();
                dialog.Filter = "Excel files|*.xlsx";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    gridControl.BeginUpdate();
                    List<GridColumn> gcs = new List<GridColumn>();
                    RepositoryItemCheckEdit temp = null;
                    foreach (GridColumn gc in MainGridView.Columns)
                    {
                        if (gc.ColumnEdit is RepositoryItemCheckEdit)
                        {
                            temp = gc.ColumnEdit as RepositoryItemCheckEdit;
                            gcs.Add(gc);
                            gc.ColumnEdit = new RepositoryItemTextEdit();
                        }
                    }
                    if (gridControl.LevelTree != null && gridControl.LevelTree.Nodes.Count > 0)
                    {
                        MainGridView.ZoomView();
                        MainGridView.OptionsPrint.PrintDetails = true;
                        foreach (GridLevelNode gln in gridControl.LevelTree.Nodes)
                            setPrintDTL(gln);
                    }
                    MainGridView.OptionsPrint.AutoWidth = false;
                    XlsxExportOptionsEx opt = new XlsxExportOptionsEx(TextExportMode.Value);
                    opt.ExportType = DevExpress.Export.ExportType.WYSIWYG;
                    gridControl.ExportToXlsx(dialog.FileName, opt);
                    if (gridControl.LevelTree != null && gridControl.LevelTree.Nodes.Count > 0)
                    {
                        MainGridView.NormalView();
                        foreach (GridLevelNode gln in gridControl.LevelTree.Nodes)
                            donePrintDTL(gln);
                    }
                    foreach (GridColumn gc in gcs)
                    {
                        gc.ColumnEdit = temp;
                    }
                    if (DevExpress.XtraEditors.XtraMessageBox.Show("Хадгалсан файлаа нээх үү?", "Асуулт", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process.Start(dialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                gridControl.EndUpdate();
                DevExpress.XtraEditors.XtraMessageBox.Show("ExportExcel: " + ex.Message);
            }
            finally
            {
                gridControl.EndUpdate();
                dialog = null;
            }
        }

        private static void setPrintDTL(GridLevelNode gln)
        {
            (gln.LevelTemplate as GridView).ZoomView();
            (gln.LevelTemplate as GridView).OptionsPrint.PrintDetails = true;
            (gln.LevelTemplate as GridView).OptionsPrint.AutoWidth = false;
            foreach (GridLevelNode gln1 in gln.Nodes)
                setPrintDTL(gln1);
        }

        private static void donePrintDTL(GridLevelNode gln)
        {
            (gln.LevelTemplate as GridView).NormalView();
            foreach (GridLevelNode gln1 in gln.Nodes)
                donePrintDTL(gln1);
        }

        public static void cnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && ((Control)(sender)).FindForm() != null)
                ((Control)(sender)).FindForm().Close();
        }

    }
}