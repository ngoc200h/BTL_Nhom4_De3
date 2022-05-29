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
    public partial class frmDSQue : Form
    {
        DataTable tblQue;
        public frmDSQue()
        {
            InitializeComponent();
        }

        private void frmDSQue_Load(object sender, EventArgs e)
        {
            txtMaQue.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDSQue();
        }
        private void ResetValues()
        {
            txtMaQue.Text = "";
            txtTenQue.Text = "";
        }
        private void LoadDSQue()
        {
            string sql;
            sql = "select * from Que";
            tblQue = Database.LoadDataToTable(sql);
            dgvQue.DataSource = tblQue; ;
            //Que (MaQue, TenQue)
            dgvQue.Columns["MaQue"].HeaderText = "Mã Quê";
            dgvQue.Columns["TenQue"].HeaderText = "Tên Quê";
        }

        private void dgvQue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvQue.Rows[e.RowIndex];
            txtMaQue.Text = Convert.ToString(row.Cells["MaQue"].Value);
            txtTenQue.Text = Convert.ToString(row.Cells["TenQue"].Value);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtMaQue.Enabled = true;
            txtMaQue.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblQue.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaQue.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE Que WHERE MaQue=N'" + txtMaQue.Text + "'";
                Database.RunSqlDel(sql);
                LoadDSQue();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblQue.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaQue.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenQue.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên quê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenQue.Focus();
                return;
            }
            sql = "UPDATE Que SET TenQue=N'" + txtTenQue.Text.ToString() + "' WHERE MaQue=N'" + txtMaQue.Text + "'";
            Database.RunSql(sql);
            LoadDSQue();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            //check dữ liệu ko dc để trống
            if (txtMaQue.Text.Trim() == "")
            {
                MessageBox.Show("Mã quê ko đc để trống!");
                txtMaQue.Focus();
                return;
            }
            if (txtTenQue.Text.Trim() == "")
            {
                MessageBox.Show("Tên quê ko đc để trống!");
                txtTenQue.Focus();
                return;
            }
            sql = "SELECT MaQue FROM Que WHERE MaQue=N'" +
            txtMaQue.Text.Trim() + "'";
            if (Database.CheckKey(sql))
            {
                MessageBox.Show("Mã quê này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaQue.Focus();
                txtMaQue.Text = "";
                return;
            }
            sql = "INSERT INTO Que(MaQue, TenQue) VALUES(N'" + txtMaQue.Text + "',N'" + txtTenQue.Text + "')";
            Database.RunSql(sql);
            LoadDSQue();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaQue.Enabled = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaQue.Enabled = false;
        }
    }
}
