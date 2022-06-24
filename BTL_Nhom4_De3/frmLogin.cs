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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        SqlConnection Conn = new SqlConnection(@"Data Source= localhost;" +
                                                "Initial Catalog = QuanLySinhVien;" +
                                                "Integrated Security=True");
        string tk;
        string mk;
        private void CreateAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRegister f = new frmRegister();
            f.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conn.Open();
            tk = txtUsername.Text;
            mk = txtPassword.Text;
            string login = "select * from UserAccount where TenTK = '" + tk + "' and MKTK = '" + mk + "'   ";
            SqlCommand cmd = new SqlCommand(login, Conn);
            SqlDataReader dta = cmd.ExecuteReader();
            if (dta.Read() == true)
            {
                if (tk == "Admin ")
                {
                    frmMain f = new frmMain();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    frmTeacherMainMenu f = new frmTeacherMainMenu();
                    f.Show();
                    this.Hide();
                }
                
            }
            else
            {
                MessageBox.Show("Dang nhap that bai");
            }
        }

        private void checkBxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBxShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
