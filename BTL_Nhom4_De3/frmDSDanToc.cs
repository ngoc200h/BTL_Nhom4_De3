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
    public partial class frmDSDanToc : Form
    {
        DataTable tblDT;
        public frmDSDanToc()
        {
            InitializeComponent();
        }

        private void frmDSDanToc_Load(object sender, EventArgs e)
        {
            txtMaDT.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDSDT();
        }

        private void ResetValues()
        {
            txtMaDT.Text = "";
            txtTenDT.Text = "";
        }
        private void LoadDSDT()
        {
            string sql;
            sql = "select * from DanToc";
            tblDT = Database.LoadDataToTable(sql);
            dgvDT.DataSource = tblDT; ;
            //DanToc (MaDToc, TenDToc)
            dgvDT.Columns["MaDToc"].HeaderText = "Mã Dân Tộc";
            dgvDT.Columns["TenDToc"].HeaderText = "Tên Dân Tộc";
        }

        private void dgvDT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvDT.Rows[e.RowIndex];
            txtMaDT.Text = Convert.ToString(row.Cells["MaDToc"].Value);
            txtTenDT.Text = Convert.ToString(row.Cells["TenDToc"].Value);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtMaDT.Enabled = true;
            txtMaDT.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblDT.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaDT.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE DanToc WHERE MaDToc=N'" + txtMaDT.Text + "'";
                Database.RunSqlDel(sql);
                LoadDSDT();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblDT.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaDT.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên dân tộc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDT.Focus();
                return;
            }
            sql = "UPDATE DanToc SET TenDToc=N'" + txtTenDT.Text.ToString() + "' WHERE MaDToc=N'" + txtMaDT.Text + "'";
            Database.RunSql(sql);
            LoadDSDT();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            //check dữ liệu ko dc để trống
            if (txtMaDT.Text.Trim() == "")
            {
                MessageBox.Show("Mã dân tộc ko đc để trống!");
                txtMaDT.Focus();
                return;
            }
            if (txtTenDT.Text.Trim() == "")
            {
                MessageBox.Show("Tên dân tộc ko đc để trống!");
                txtTenDT.Focus();
                return;
            }
            sql = "SELECT MaDToc FROM DanToc WHERE MaDToc=N'" +
            txtMaDT.Text.Trim() + "'";
            if (Database.CheckKey(sql))
            {
                MessageBox.Show("Mã này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDT.Focus();
                txtMaDT.Text = "";
                return;
            }
            sql = "INSERT INTO DanToc(MaDToc, TenDToc) VALUES(N'" + txtMaDT.Text + "',N'" + txtTenDT.Text + "')";
            Database.RunSql(sql);
            LoadDSDT();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaDT.Enabled = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaDT.Enabled = false;
        }
    }
}
