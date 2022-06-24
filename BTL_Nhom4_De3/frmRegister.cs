using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BTL_Nhom4_De3
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }
        
        SqlConnection Conn = new SqlConnection(@"Data Source= localhost;" +
                                                "Initial Catalog = QuanLySinhVien;" +
                                                "Integrated Security=True");
        private void btnRegister_Click(object sender, EventArgs e)
        {

            if (txtUsername.Text == "" && txtPassword.Text == "" && txtConfirmPass.Text == "")
            {
                MessageBox.Show("Username and Password fieds are empty", "Registration Failed ");
            }
            else if (txtPassword.Text == txtConfirmPass.Text)
            {

                Conn.Open();
                string tk = txtUsername.Text;
                string mk = txtPassword.Text;
                string CheckExsit = "select * from UserAccount where TenTK = '" + tk + "'  ";
                string register = "Insert into UserAccount (TenTk, MKTK) Values ('" + tk + "', '" + mk + "');";

                SqlCommand cmdChkEx = new SqlCommand(CheckExsit, Conn);
                SqlDataReader data = cmdChkEx.ExecuteReader();
                if (data.Read() == false)
                {
                    Conn.Close();
                    MessageBox.Show("Your account has been successfully created", "Registration successfully ");
                    Conn.Open();
                    SqlCommand cmd = new SqlCommand(register, Conn);
                    SqlDataReader dta = cmd.ExecuteReader();
                }
                else
                {
                    MessageBox.Show("This account already exsit", "Registration fail ");
                    Conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Password does not match", "Please re-enter");
                txtPassword.Text = "";
                txtConfirmPass.Text = "";
                txtPassword.Focus();
            }

        }

        private void BackToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin f = new frmLogin();
            f.ShowDialog();
            this.Close();
        }

        private void checkBxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBxShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfirmPass.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtConfirmPass.PasswordChar = '*';
            }
        }
    }
}
