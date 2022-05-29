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
    public partial class frmDSPhongHoc : Form
    {
        DataTable tblPhong;
        public frmDSPhongHoc()
        {
            InitializeComponent();
        }

        private void frmDSPhongHoc_Load(object sender, EventArgs e)
        {
            txtMaPhong.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDSPhongHoc();
        }
        private void LoadDSPhongHoc()
        {
            string sql;
            sql = "select * from Phong_Hoc";
            tblPhong = Database.LoadDataToTable(sql);
            dgvPhongHoc.DataSource = tblPhong; ;
            //Phong_Hoc (MaPhong, TenPhong)
            dgvPhongHoc.Columns["MaPhong"].HeaderText = "Mã Phòng Học";
            dgvPhongHoc.Columns["TenPhong"].HeaderText = "Tên Phòng Học";
        }
        private void ResetValues()
        {
            txtMaPhong.Text = "";
            txtTenPhong.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtMaPhong.Enabled = true;
            txtMaPhong.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblPhong.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaPhong.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE Phong_Hoc WHERE MaPhong=N'" + txtMaPhong.Text + "'";
                Database.RunSqlDel(sql);
                LoadDSPhongHoc();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblPhong.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaPhong.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenPhong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPhong.Focus();
                return;
            }
            sql = "UPDATE Phong_Hoc SET TenPhong=N'" + txtTenPhong.Text.ToString() + "' WHERE MaPhong=N'" + txtMaPhong.Text + "'";
            Database.RunSql(sql);
            LoadDSPhongHoc();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            //check dữ liệu ko dc để trống
            if (txtMaPhong.Text.Trim() == "")
            {
                MessageBox.Show("Mã phòng ko đc để trống!");
                txtMaPhong.Focus();
                return;
            }
            if (txtTenPhong.Text.Trim() == "")
            {
                MessageBox.Show("Tên phòng ko đc để trống!");
                txtTenPhong.Focus();
                return;
            }
            sql = "SELECT MaPhong FROM Phong_Hoc WHERE MaPhong=N'" +
            txtMaPhong.Text.Trim() + "'";
            if (Database.CheckKey(sql))
            {
                MessageBox.Show("Mã phòng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPhong.Focus();
                txtMaPhong.Text = "";
                return;
            }
            sql = "INSERT INTO Phong_Hoc(MaPhong, TenPhong) VALUES(N'" + txtMaPhong.Text + "',N'" + txtTenPhong.Text + "')";
            Database.RunSql(sql);
            LoadDSPhongHoc();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaPhong.Enabled = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaPhong.Enabled = false;
        }

        private void dgvPhongHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvPhongHoc.Rows[e.RowIndex];
            txtMaPhong.Text = Convert.ToString(row.Cells["MaPhong"].Value);
            txtTenPhong.Text = Convert.ToString(row.Cells["TenPhong"].Value);
        }
    }
}
