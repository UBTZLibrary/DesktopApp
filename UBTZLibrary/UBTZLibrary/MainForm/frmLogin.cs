using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace UBTZLibrary
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public static bool isLogin = false;
        public static string LoginUserID = string.Empty;
        SqlConnection conn;
        SqlCommand command;
        DataTable mainTable;

        public frmLogin()
        {
            InitializeComponent();
            conn = new SqlConnection(frmMain.connStr);
        }

        private void pictureEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.Properties.PasswordChar = '\0'; pictureEdit1.Image = null;
        }

        private void pictureEdit1_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.Properties.PasswordChar = '*'; pictureEdit1.Image = Properties.Resources.eye;
        }

        private void btnReGenPass_Click(object sender, EventArgs e)
        {
            if (txtUserName.EditValue == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("<Нэвтрэх нэр> талбарт утга оруулах шаардлагатай!");
                return;
            }
            try
            {
                string userid = Convert.ToString(txtUserName.EditValue);
                string your_id = ConfigurationSettings.AppSettings["SystemEmail"];
                string your_password = ConfigurationSettings.AppSettings["SystemEmailPassword"];

                DevExpress.Utils.WaitDialogForm dlg = new DevExpress.Utils.WaitDialogForm("Имэйл илгээж байна....", "Түр хүлээнэ үү.");
                dlg.Show();

                SmtpClient client = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential(your_id, your_password),
                    Timeout = 10000,
                };
                string[] retMessage = getLoginPassword(userid);
                if (retMessage[0] == "Бүртгэлгүй хэрэглэгч байна.")
                {
                    dlg.Close();
                    DevExpress.XtraEditors.XtraMessageBox.Show("Бүртгэлгүй хэрэглэгч байна.");
                    client.Dispose();
                    return;
                }
                if (txtUserName.Text.Equals("Administrator"))
                {
                    retMessage[1] = ConfigurationSettings.AppSettings["AdminEmail"];
                }
                MailMessage mm = new MailMessage(your_id, retMessage[1], "УБТЗ номын сангийн хэрэглэгчийн нууц үг", "Хэрэглэгч: " + userid + '\n' + "Нууц үг: " + retMessage[0]);
                mm.BodyEncoding = UTF8Encoding.UTF8;
                client.Send(mm);
                dlg.Close();
                DevExpress.XtraEditors.XtraMessageBox.Show(retMessage[1] + " имэйл рүү амжилттай илгээлээ.");
                client.Dispose();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.ToString());
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.EditValue == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("<Нэвтрэх нэр> талбарт утга оруулах шаардлагатай!");
                return;
            }
            if (txtPassword.EditValue == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("<Нууц үг> талбарт утга оруулах шаардлагатай!");
                return;
            }
            if (getLoginAccess(Convert.ToString(txtUserName.EditValue), frmMain.Encrypt(Convert.ToString(txtPassword.EditValue))))
            {
                isLogin = true;
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string[] getLoginPassword(string userID)
        {
            String fullName = string.Empty;
            conn.Open();
            command = new SqlCommand(@"SELECT TBLUSER.USERID,
                                               TBLUSER.PASSWORD,
                                               ISNULL(TBLSTUDENT.EMAIL, TBLSTUDENT.EMAIL2) EMAIL
                                          FROM TBLUSER
                                          LEFT JOIN TBLSTUDENT
                                            ON TBLUSER.STUDENTID = TBLSTUDENT.STUDENTID
                                         WHERE TBLUSER.USERID = @USERID", conn);
            //command.BindByName = true;
            command.Parameters.Add(new SqlParameter("@USERID", txtUserName.EditValue));

            SqlDataReader oraReader = command.ExecuteReader();
            mainTable = new DataTable();
            mainTable.Load(oraReader);
            frmMain.dataTableColumnNameToUpper(mainTable);
            oraReader.Close();
            conn.Close();

            if (mainTable.Rows.Count == 1)
            {
                DataRow mainRow = mainTable.Rows[0];
                string email = string.Empty;
                string password = string.Empty;
                if (mainRow["PASSWORD"] != DBNull.Value)
                    password = frmMain.Decrypt(Convert.ToString(mainRow["PASSWORD"]));
                if (mainRow["EMAIL"] != DBNull.Value)
                    email = Convert.ToString(mainRow["EMAIL"]);
                return new string[] { password, email };
            }
            else
            {
                return new string[] { "Бүртгэлгүй хэрэглэгч байна.", string.Empty };
            }
        }

        bool getLoginAccess(string userID, string password)
        {
            String fullName = string.Empty;
            conn.Open();
            command = new SqlCommand("SELECT * FROM TBLUSER WHERE USERID = @USERID", conn);
            //command.BindByName = true;
            command.Parameters.Add(new SqlParameter("@USERID", txtUserName.EditValue));

            SqlDataReader oraReader = command.ExecuteReader();
            mainTable = new DataTable();
            mainTable.Load(oraReader);
            frmMain.dataTableColumnNameToUpper(mainTable);
            oraReader.Close();
            conn.Close();

            if (mainTable.Rows.Count == 1)
            {
                DataRow mainRow = mainTable.Rows[0];
                if (Convert.ToString(mainRow["PASSWORD"]).Equals(password))
                {
                    if (Convert.ToString(mainRow["ISACTIVE"]).Equals("N"))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Идэвхгүй хэрэглэгч байна.");
                        return false;
                    }
                    else
                    {
                        LoginUserID = Convert.ToString(mainRow["USERID"]);
                        return true;
                    }
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Нууц үг буруу байна.");
                    return false;
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Бүртгэлгүй хэрэглэгч байна.");
                return false;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                btnLogin_Click(null, null);
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
            if (command != null)
                command.Dispose();
            if (mainTable != null)
                mainTable.Dispose();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUserName.Text = "Administrator";
        }

    }
}
