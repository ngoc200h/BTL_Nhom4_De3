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
        public frmDSChucVu()
        {
            InitializeComponent();
        }

        private void frmDSChucVu_Load(object sender, EventArgs e)
        {
            LoadDSChucVu();
        }

        Database dt = new Database();
        private void Reset()
        {
            txtMaChucVu.Text = "";
            txtTenChucVu.Text = "";
        }
        private void LoadDSChucVu()
        {
            string sql1 = "select * from ChucVu";
            dgvChucVu.DataSource = dt.TaoBang(sql1);
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
            Reset();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;

            txtMaChucVu.Enabled = true;
            txtMaChucVu.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa  " + txtMaChucVu.Text
                    + " không? Nếu có ấn nút Lưu, không thì ấn nút Hủy", "Xóa sản phẩm",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string sql = "delete from ChucVu where MaChucVu='" + txtMaChucVu.Text + "'";
                    dt.ExcuteNonQuery(sql);
                    string sql1 = "select * from ChucVu";
                    dgvChucVu.DataSource = dt.TaoBang(sql1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa ko nổi.. " + ex.ToString());
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "update ChucVu set TenChucVu='" + txtTenChucVu.Text + "' where MaChucVu='" + txtMaChucVu.Text + "'";
            dt.ExcuteNonQuery(sql);
            LoadDSChucVu();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = "insert into ChucVu values('" + txtMaChucVu.Text + "','" + txtTenChucVu.Text + "')";
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
            string sql1 = "select * from ChucVu";
            dgvChucVu.DataSource = dt.TaoBang(sql1);
            //LoadDMChatLieu();
        }
    }
}
