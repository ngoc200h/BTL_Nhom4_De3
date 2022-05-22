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
        public frmDSQue()
        {
            InitializeComponent();
        }

        private void frmDSQue_Load(object sender, EventArgs e)
        {
            LoadDSQue();
        }
        Database dt = new Database();
        private void Reset()
        {
            txtMaQue.Text = "";
            txtTenQue.Text = "";
        }
        private void LoadDSQue()
        {
            string sql1 = "select * from Que";
            dgvQue.DataSource = dt.TaoBang(sql1);
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
            Reset();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;

            txtMaQue.Enabled = true;
            txtMaQue.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa  " + txtMaQue.Text
                + " không? Nếu có ấn nút Lưu, không thì ấn nút Hủy", "Xóa sản phẩm",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string sql = "delete from Que where MaQue='" + txtMaQue.Text + "'";
                    dt.ExcuteNonQuery(sql);
                    string sql1 = "select * from Que";
                    dgvQue.DataSource = dt.TaoBang(sql1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa ko nổi.. " + ex.ToString());
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "update Que set TenQue='" + txtTenQue.Text + "' where MaQue='" + txtMaQue.Text + "'";
            dt.ExcuteNonQuery(sql);
            LoadDSQue();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = "insert into Que values('" + txtMaQue.Text + "','" + txtTenQue.Text + "')";
            try
            {
                dt.ExcuteNonQuery(sql);
                btnLuu.Enabled = false;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Đã tồn tại mã chức vụ hoặc điền thiếu", "Úi có lỗi");
            }
            LoadDSQue();
        }
    }
}
