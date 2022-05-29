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
    public partial class frmDSLop : Form
    {
        DataTable tblLop;
        public frmDSLop()
        {
            InitializeComponent();
        }

        private void frmDSLop_Load(object sender, EventArgs e)
        {
            txtMaLop.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDSLop();
            Database.FillDataToCombo("SELECT MaKhoa, TenKhoa FROM Khoa", cboMaKhoa,
                        "MaKhoa", "TenKhoa");
            cboMaKhoa.SelectedIndex = -1;
            ResetValues();
        }
        private void ResetValues()
        {
            txtMaLop.Text = "";
            txtTenLop.Text = "";
            cboMaKhoa.Text = "";
            txtKhoaHoc.Text = "";
        }
        private void LoadDSLop()
        {
            string sql;
            sql = "select * from Lop";
            tblLop = Database.LoadDataToTable(sql);
            dgvLop.DataSource = tblLop; ;
            //Lop (MaLop, TenLop, MaKhoa, KhoaHoc, SiSo)
            dgvLop.Columns["MaLop"].HeaderText = "Mã Lớp";
            dgvLop.Columns["TenLop"].HeaderText = "Tên Lớp";
            dgvLop.Columns["MaKhoa"].HeaderText = "Mã Khoa";
            dgvLop.Columns["KhoaHoc"].HeaderText = "Khóa Học";
            dgvLop.Columns["SiSo"].HeaderText = "Sĩ Số";
        }

        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string ma;
            DataGridViewRow row = new DataGridViewRow();
            row = dgvLop.Rows[e.RowIndex];
            txtMaLop.Text = Convert.ToString(row.Cells["MaLop"].Value);
            txtTenLop.Text = Convert.ToString(row.Cells["TenLop"].Value);
            ma = dgvLop.CurrentRow.Cells["MaKhoa"].Value.ToString();
            cboMaKhoa.Text = Database.GetFieldValues("SELECT TenKhoa FROM Khoa WHERE MaKhoa = N'" + ma + "'");
            txtKhoaHoc.Text = Convert.ToString(row.Cells["KhoaHoc"].Value);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtMaLop.Enabled = true;
            txtMaLop.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblLop.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaLop.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE Lop WHERE MaLop=N'" + txtMaLop.Text + "'";
                Database.RunSqlDel(sql);
                LoadDSLop();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblLop.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaLop.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenLop.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLop.Focus();
                return;
            }
            sql = "UPDATE Lop SET TenLop=N'" + txtTenLop.Text.ToString() +
                "',MaKhoa=N'" + cboMaKhoa.SelectedValue.ToString() +
                "',KhoaHoc = N'" + txtKhoaHoc.Text.ToString() +
                "' WHERE MaLop=N'" + txtMaLop.Text + "'";
            Database.RunSql(sql);
            LoadDSLop();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            //check dữ liệu ko dc để trống
            if (txtMaLop.Text.Trim() == "")
            {
                MessageBox.Show("Mã lớp ko đc để trống!");
                txtMaLop.Focus();
                return;
            }
            if (txtTenLop.Text.Trim() == "")
            {
                MessageBox.Show("Tên ko đc để trống!");
                txtTenLop.Focus();
                return;
            }
            sql = "SELECT MaLop FROM Lop WHERE MaCLop=N'" +
            txtMaLop.Text.Trim() + "'";
            if (Database.CheckKey(sql))
            {
                MessageBox.Show("Mã lớp này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLop.Focus();
                txtMaLop.Text = "";
                return;
            }
            sql = "INSERT INTO Lop(MaLop, TenLop, MaKhoa, KhoaHoc) VALUES(N'" + txtMaLop.Text + 
                "',N'" + txtTenLop.Text +
                "',N'" + cboMaKhoa.SelectedValue.ToString() + 
                "',N'" + txtKhoaHoc.Text + "')";
            Database.RunSql(sql);
            LoadDSLop();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaLop.Enabled = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaLop.Enabled = false;
        }
    }
}
