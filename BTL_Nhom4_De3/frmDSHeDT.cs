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
    public partial class frmDSHeDT : Form
    {
        DataTable tblHeDT;
        public frmDSHeDT()
        {
            InitializeComponent();
        }

        private void frmDSHeDT_Load(object sender, EventArgs e)
        {
            txtMaHeDT.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDSHeDT();
        }
        Database dt = new Database();
        private void ResetValues()
        {
            txtMaHeDT.Text = "";
            txtTenHeDT.Text = "";
        }
        private void LoadDSHeDT()
        {
            string sql;
            sql = "select * from HeDaoTao";
            tblHeDT = Database.LoadDataToTable(sql);
            dgvHeDT.DataSource = tblHeDT; ;
            //HeDaoTao (MaHeDT, TenHeDT)
            dgvHeDT.Columns["MaHeDT"].HeaderText = "Mã Hệ Đào Tạo";
            dgvHeDT.Columns["TenHeDT"].HeaderText = "Tên Hệ Đào Tạo";
        }

        private void dgvHeDT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvHeDT.Rows[e.RowIndex];
            txtMaHeDT.Text = Convert.ToString(row.Cells["MaHeDT"].Value);
            txtTenHeDT.Text = Convert.ToString(row.Cells["TenHeDT"].Value);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtMaHeDT.Enabled = true;
            txtMaHeDT.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblHeDT.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHeDT.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE HeDaoTao WHERE MaHeDT=N'" + txtMaHeDT.Text + "'";
                Database.RunSqlDel(sql);
                LoadDSHeDT();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblHeDT.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaHeDT.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenHeDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenHeDT.Focus();
                return;
            }
            sql = "UPDATE HeDaoTao SET TenHeDT=N'" + txtTenHeDT.Text.ToString() + "' WHERE MaHeDT=N'" + txtMaHeDT.Text + "'";
            Database.RunSql(sql);
            LoadDSHeDT();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            //check dữ liệu ko dc để trống
            if (txtMaHeDT.Text.Trim() == "")
            {
                MessageBox.Show("Mã hệ ko đc để trống!");
                txtMaHeDT.Focus();
                return;
            }
            if (txtTenHeDT.Text.Trim() == "")
            {
                MessageBox.Show("Tên hệ ko đc để trống!");
                txtTenHeDT.Focus();
                return;
            }
            sql = "SELECT MaHeDT FROM HeDaoTao WHERE MaHeDT=N'" +
            txtMaHeDT.Text.Trim() + "'";
            if (Database.CheckKey(sql))
            {
                MessageBox.Show("Mã này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHeDT.Focus();
                txtMaHeDT.Text = "";
                return;
            }
            sql = "INSERT INTO HeDaoTao(MaHeDT, TenHeDT) VALUES(N'" + txtMaHeDT.Text + "',N'" + txtTenHeDT.Text + "')";
            Database.RunSql(sql);
            LoadDSHeDT();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaHeDT.Enabled = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaHeDT.Enabled = false;
        }
    }
}
