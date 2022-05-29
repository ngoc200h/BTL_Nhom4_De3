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
    public partial class frmDSChucVu : Form
    {
        DataTable tblCV;
        public frmDSChucVu()
        {
            InitializeComponent();
        }

        private void frmDSChucVu_Load(object sender, EventArgs e)
        {
            txtMaChucVu.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDSChucVu();
        }

        private void ResetValues()
        {
            txtMaChucVu.Text = "";
            txtTenChucVu.Text = "";
        }
        private void LoadDSChucVu()
        {
            string sql;
            sql = "select * from ChucVu";
            tblCV = Database.LoadDataToTable(sql);
            dgvChucVu.DataSource = tblCV;
            //ChucVu(MaChucVu, TenChucVu)
            dgvChucVu.Columns["MaChucVu"].HeaderText = "Mã Chức Vụ";
            dgvChucVu.Columns["TenChucVu"].HeaderText = "Tên Chức Vụ";
        }

        private void dgvChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvChucVu.Rows[e.RowIndex];
            txtMaChucVu.Text = Convert.ToString(row.Cells["MaChucVu"].Value);
            txtTenChucVu.Text = Convert.ToString(row.Cells["TenChucVu"].Value);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtMaChucVu.Enabled = true;
            txtMaChucVu.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaChucVu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE ChucVu WHERE MaChucVu=N'" + txtMaChucVu.Text + "'";
                Database.RunSqlDel(sql);
                LoadDSChucVu();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaChucVu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenChucVu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenChucVu.Focus();
                return;
            }
            sql = "UPDATE ChucVu SET TenChucVu=N'" + txtTenChucVu.Text.ToString() + "' WHERE MaChucVu=N'" + txtMaChucVu.Text + "'";
            Database.RunSql(sql);
            LoadDSChucVu();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            string sql;
            //check dữ liệu ko dc để trống
            if (txtMaChucVu.Text.Trim() == "")
            {
                MessageBox.Show("Mã chức vụ ko đc để trống!");
                txtMaChucVu.Focus();
                return;
            }
            if (txtTenChucVu.Text.Trim() == "")
            {
                MessageBox.Show("Tên chức vụ ko đc để trống!");
                txtTenChucVu.Focus();
                return;
            }
            sql = "SELECT MaChucVu FROM ChucVu WHERE MaChucVu=N'" +
            txtMaChucVu.Text.Trim() + "'";
            if (Database.CheckKey(sql))
            {
                MessageBox.Show("Mã chức vụ này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaChucVu.Focus();
                txtMaChucVu.Text = "";
                return;
            }
            sql = "INSERT INTO ChucVu(MaChucVu, TenChucVu) VALUES(N'" + txtMaChucVu.Text + "',N'" + txtTenChucVu.Text + "')";
            Database.RunSql(sql);
            LoadDSChucVu();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaChucVu.Enabled = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaChucVu.Enabled = false;
        }
    }
}
