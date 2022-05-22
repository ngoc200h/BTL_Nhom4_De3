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
        public frmDSHeDT()
        {
            InitializeComponent();
        }

        private void frmDSHeDT_Load(object sender, EventArgs e)
        {
            LoadDSHeDT();
        }
        Database dt = new Database();
        private void Reset()
        {
            txtMaHeDT.Text = "";
            txtTenHeDT.Text = "";
        }
        private void LoadDSHeDT()
        {
            string sql1 = "select * from HeDaoTao";
            dgvHeDT.DataSource = dt.TaoBang(sql1);
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
            Reset();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;

            txtMaHeDT.Enabled = true;
            txtMaHeDT.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa  " + txtMaHeDT.Text
                    + " không? Nếu có ấn nút Lưu, không thì ấn nút Hủy", "Xóa sản phẩm",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string sql = "delete from HeDaoTao where MaHeDT='" + txtMaHeDT.Text + "'";
                    dt.ExcuteNonQuery(sql);
                    string sql1 = "select * from HeDaotao";
                    dgvHeDT.DataSource = dt.TaoBang(sql1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa ko nổi.. " + ex.ToString());
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "update HeDaoTao set TenHeDT='" + txtTenHeDT.Text + "' where MaHeDT='" + txtMaHeDT.Text + "'";
            dt.ExcuteNonQuery(sql);
            LoadDSHeDT();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = "insert into HeDaoTao values('" + txtMaHeDT.Text + "','" + txtTenHeDT.Text + "')";
            try
            {
                dt.ExcuteNonQuery(sql);
                btnLuu.Enabled = false;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Đã tồn tại dữ liệu hoặc điền thiếu/điền sai", "Úi có lỗi");
            }
            LoadDSHeDT();
        }
    }
}
