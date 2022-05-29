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
    public partial class frmDSMon : Form
    {
        DataTable tblMon;
        public frmDSMon()
        {
            InitializeComponent();
        }

        private void frmDSMon_Load(object sender, EventArgs e)
        {
            txtMaMon.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDSMon();
        }
        private void ResetValues()
        {
            txtMaMon.Text = "";
            txtTenMon.Text = "";
            txtDVHT.Text = "";
        }
        private void LoadDSMon()
        {
            string sql;
            sql = "select MaMon, TenMon, DVHT from Mon";
            tblMon = Database.LoadDataToTable(sql);
            dgvMon.DataSource = tblMon;
            //Mon (MaMon, TenMon, DVHT)
            dgvMon.Columns["MaMon"].HeaderText = "Mã Môn";
            dgvMon.Columns["TenMon"].HeaderText = "Tên Môn";
            dgvMon.Columns["DVHT"].HeaderText = "Đơn Vị Học Trình";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtMaMon.Enabled = true;
            txtMaMon.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblMon.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaMon.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE Mon WHERE MaMon=N'" + txtMaMon.Text + "'";
                Database.RunSqlDel(sql);
                LoadDSMon();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblMon.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaMon.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenMon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên môn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMon.Focus();
                return;
            }
            sql = "UPDATE Mon SET TenMon=N'" + txtTenMon.Text.ToString() +
                "',DVHT = N'" + txtDVHT.Text.ToString() +
                "' WHERE MaMon=N'" + txtMaMon.Text + "'";
            Database.RunSql(sql);
            LoadDSMon();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            //check dữ liệu ko dc để trống
            if (txtMaMon.Text.Trim() == "")
            {
                MessageBox.Show("Mã môn ko đc để trống!");
                txtMaMon.Focus();
                return;
            }
            if (txtTenMon.Text.Trim() == "")
            {
                MessageBox.Show("Tên môn ko đc để trống!");
                txtTenMon.Focus();
                return;
            }
            sql = "SELECT MaMon FROM Mon WHERE MaMon=N'" +
            txtMaMon.Text.Trim() + "'";
            if (Database.CheckKey(sql))
            {
                MessageBox.Show("Mã môn này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaMon.Focus();
                txtMaMon.Text = "";
                return;
            }
            sql = "INSERT INTO Mon(MaMon, TenMon, DVHT) VALUES(N'" + txtMaMon.Text + 
                "',N'" + txtTenMon.Text +
                "',N'" + txtDVHT.Text + "')";
            Database.RunSql(sql);
            LoadDSMon();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaMon.Enabled = false;
        }

        private void dgvMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvMon.Rows[e.RowIndex];
            txtMaMon.Text = Convert.ToString(row.Cells["MaMon"].Value);
            txtTenMon.Text = Convert.ToString(row.Cells["TenMon"].Value);
            txtDVHT.Text = Convert.ToString(row.Cells["DVHT"].Value);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaMon.Enabled = false;
        }
    }
}
