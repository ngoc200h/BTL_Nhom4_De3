using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BTL_Nhom4_De3
{
    public partial class frmDSKhoa : Form
    {
        DataTable tblKhoa;
        public frmDSKhoa()
        {
            InitializeComponent();
        }

        private void frmDSKhoa_Load(object sender, EventArgs e)
        {
            txtMaKhoa.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDSKhoa();
        }
        private void ResetValues()
        {
            txtMaKhoa.Text = "";
            txtTenKhoa.Text = "";
            txtDiaChi.Text = "";
            txtWebsite.Text = "";
        }
        private void LoadDSKhoa()
        {
            string sql;
            sql = "select * from Khoa";
            tblKhoa = Database.LoadDataToTable(sql);
            dgvKhoa.DataSource = tblKhoa; ;
            //Khoa (MaKhoa, TenKhoa, DiaChi, Website)
            dgvKhoa.Columns["MaKhoa"].HeaderText = "Mã Khoa";
            dgvKhoa.Columns["TenKhoa"].HeaderText = "Tên Khoa";
            dgvKhoa.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgvKhoa.Columns["Website"].HeaderText = "Website";
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtMaKhoa.Enabled = true;
            txtMaKhoa.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKhoa.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKhoa.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE Khoa WHERE MaKhoa=N'" + txtMaKhoa.Text + "'";
                Database.RunSqlDel(sql);
                LoadDSKhoa();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKhoa.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaKhoa.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenKhoa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên Khoa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKhoa.Focus();
                return;
            }
            sql = "UPDATE Khoa SET TenKhoa=N'" + txtTenKhoa.Text.ToString() +
                "',DiaChi = N'" + txtDiaChi.Text.ToString() +
                "',Website = N'" + txtWebsite.Text.ToString() +
                "' WHERE MaKhoa=N'" + txtMaKhoa.Text + "'";
            Database.RunSql(sql);
            LoadDSKhoa();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            //check dữ liệu ko dc để trống
            if (txtMaKhoa.Text.Trim() == "")
            {
                MessageBox.Show("Mã Khoa ko đc để trống!");
                txtMaKhoa.Focus();
                return;
            }
            if (txtTenKhoa.Text.Trim() == "")
            {
                MessageBox.Show("Tên Khoa ko đc để trống!");
                txtTenKhoa.Focus();
                return;
            }
            sql = "SELECT MaKhoa FROM Khoa WHERE MaKhoa=N'" +
            txtMaKhoa.Text.Trim() + "'";
            if (Database.CheckKey(sql))
            {
                MessageBox.Show("Mã Khoa này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKhoa.Focus();
                txtMaKhoa.Text = "";
                return;
            }
            sql = "INSERT INTO Khoa(MaKhoa, TenKhoa, DiaChi, Website) VALUES(N'" + txtMaKhoa.Text + 
                "',N'" + txtTenKhoa.Text +
                "',N'" + txtDiaChi.Text +
                "',N'" + txtWebsite.Text + "')";
            Database.RunSql(sql);
            LoadDSKhoa();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaKhoa.Enabled = false;
        }

        private void dgvKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvKhoa.Rows[e.RowIndex];
            txtMaKhoa.Text = Convert.ToString(row.Cells["MaKhoa"].Value);
            txtTenKhoa.Text = Convert.ToString(row.Cells["TenKhoa"].Value);
            txtDiaChi.Text = Convert.ToString(row.Cells["DiaChi"].Value);
            txtWebsite.Text = Convert.ToString(row.Cells["Website"].Value);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaKhoa.Enabled = false;
        }
    }
}
