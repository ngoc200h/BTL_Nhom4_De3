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
    public partial class frmDSChuyenNganh : Form
    {
        DataTable tblCN;
        public frmDSChuyenNganh()
        {
            InitializeComponent();
        }

        private void frmDSChuyenNganh_Load(object sender, EventArgs e)
        {
            txtMaChuyenNganh.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDSChuyenNganh();
            Database.FillDataToCombo("SELECT MaKhoa, TenKhoa FROM Khoa", cboMaKhoa,
                                    "MaKhoa", "TenKhoa");
            cboMaKhoa.SelectedIndex = -1;
            ResetValues();
        }
        private void ResetValues()
        {
            txtMaChuyenNganh.Text = "";
            txtTenChuyenNganh.Text = "";
            cboMaKhoa.Text = "";
        }
        private void LoadDSChuyenNganh()
        {
            string sql;
            sql = "SELECT * FROM Chuyen_Nganh";
            tblCN = Database.LoadDataToTable(sql);
            dgvChuyenNganh.DataSource = tblCN;
            //Chuyen_Nganh( MaCN, MaKhoa, TenCN)
            dgvChuyenNganh.Columns["MaCN"].HeaderText = "Mã Chuyên Ngành";
            dgvChuyenNganh.Columns["MaKhoa"].HeaderText = "Mã Khoa";
            dgvChuyenNganh.Columns["TenCN"].HeaderText = "Tên Chuyên Ngành";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaChuyenNganh.Enabled = true;
            txtMaChuyenNganh.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCN.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaChuyenNganh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE Chuyen_Nganh WHERE MaCN=N'" + txtMaChuyenNganh.Text + "'";
                Database.RunSqlDel(sql);
                LoadDSChuyenNganh();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCN.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            if (txtMaChuyenNganh.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenChuyenNganh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chuyên ngành", "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtTenChuyenNganh.Focus();
                return;
            }
            if (cboMaKhoa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn mã khoa", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaKhoa.Focus();
                return;
            }
            sql = "UPDATE Chuyen_Nganh SET  TenCN=N'" + txtTenChuyenNganh.Text.Trim().ToString() +
                "',MaKhoa=N'" + cboMaKhoa.SelectedValue.ToString() +
                "' WHERE MaCN=N'" + txtMaChuyenNganh.Text + "'";
            Database.RunSql(sql);
            LoadDSChuyenNganh();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaChuyenNganh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã chuyên ngành", "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtMaChuyenNganh.Focus();
                return;
            }
            if (txtTenChuyenNganh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chuyên ngành", "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtTenChuyenNganh.Focus();
                return;
            }
            if (cboMaKhoa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khoa", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaKhoa.Focus();
                return;
            }
            sql = "SELECT MaCN FROM Chuyen_Nganh WHERE MaCN=N'" + txtMaChuyenNganh.Text.Trim() + "'";
            if (Database.CheckKey(sql))
            {
                MessageBox.Show("Mã này đã có, bạn phải nhập mã khác", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaChuyenNganh.Focus();
                txtMaChuyenNganh.Text = "";
                return;
            }
            sql = "INSERT INTO Chuyen_Nganh( MaCN, MaKhoa, TenCN) VALUES(N'" + txtMaChuyenNganh.Text.Trim() +
                    "',N'" + cboMaKhoa.SelectedValue.ToString()  + 
                    "',N'" + txtTenChuyenNganh.Text.Trim() + "')";
            Database.RunSql(sql);
            LoadDSChuyenNganh();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaChuyenNganh.Enabled = false;
        }

        private void dgvChuyenNganh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string ma;
            DataGridViewRow row = new DataGridViewRow();
            row = dgvChuyenNganh.Rows[e.RowIndex];
            txtMaChuyenNganh.Text = Convert.ToString(row.Cells["MaCN"].Value);
            txtTenChuyenNganh.Text = Convert.ToString(row.Cells["TenCN"].Value);
            ma = dgvChuyenNganh.CurrentRow.Cells["MaKhoa"].Value.ToString();
            cboMaKhoa.Text = Database.GetFieldValues("SELECT TenKhoa FROM Khoa WHERE MaKhoa = N'" + ma + "'");
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaChuyenNganh.Enabled = false;
        }
    }
}
