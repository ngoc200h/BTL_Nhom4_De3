using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace BTL_Nhom4_De3
{
    public partial class frmSinhVien : Form
    {
        public frmSinhVien(string msv)
        {
            this.msv = msv;
            InitializeComponent();
        }
        private string msv;
        private SqlConnection conn;
        private string sql;
        private DataTable dt;
        private SqlCommand cmd;

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(msv))
            {
                this.Text = "Thêm mới sinh viên";
            }
            else
            {
                this.Text = "Cập nhật thông tin sinh viên";
                //var r = new Database().Select("selectSV '" + msv + "'");

                //txtTenSV.Text = r["TenSV"].ToString();
                //mtbNgaySinh.Text = r["NgSinh"].ToString();
                //if (int.Parse(r["GTinh"].ToString()) == 1)
                //{
                //    rbtNam.Checked = true;
                //}
                //else
                //{
                //    rbtNu.Checked = true;
                //}

            }
            //txtTenSV.Enabled = false;
            //btnLuu.Enabled = false;
            //btnHuy.Enabled = false;
            //Load_DataGridView();
            //Functions.FillCombo("Select MaKhoa from Khoa", cbKhoa, "MaKhoa", "TenKhoa");   

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void cbKhoa_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string cmd = "SELECT MaKhoa FROM Khoa";
            SqlDataAdapter adap = new SqlDataAdapter(cmd, conn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            cbKhoa.SelectedIndex = -1;
        }


    }
}

