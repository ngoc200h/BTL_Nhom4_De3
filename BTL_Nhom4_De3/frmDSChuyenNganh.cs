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
    public partial class frmDSChuyenNganh : Form
    {
        public frmDSChuyenNganh()
        {
            InitializeComponent();
        }

        private void frmDSChuyenNganh_Load(object sender, EventArgs e)
        {
            LoadDSChuyenNganh();
        }

        Database dt = new Database();
        private void Reset()
        {
            txtMaChuyenNganh.Text = "";
            txtTenChuyenNganh.Text = "";
            cbbMaKhoa.Text = "";
        }
        private void LoadDSChuyenNganh()
        {
            string sql1 = "select * from Chuyen_Nganh";
            dgvChuyenNganh.DataSource = dt.TaoBang(sql1);
            //Chuyen_Nganh( MaCN, MaKhoa, TenCN)
            dgvChuyenNganh.Columns["MaCN"].HeaderText = "Mã Chuyên Ngành";
            dgvChuyenNganh.Columns["MaKhoa"].HeaderText = "Mã Khoa";
            dgvChuyenNganh.Columns["TenCN"].HeaderText = "Tên Chuyên Ngành";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Reset();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;

            txtMaChuyenNganh.Enabled = true;
            txtMaChuyenNganh.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa  " + txtMaChuyenNganh.Text
                    + " không? Nếu có ấn nút Lưu, không thì ấn nút Hủy", "Xóa sản phẩm",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string sql = "delete from Chuyen_Nganh where MaCN='" + txtMaChuyenNganh.Text + "'";
                    dt.ExcuteNonQuery(sql);
                    string sql1 = "select * from Chuyen_Nganh";
                    dgvChuyenNganh.DataSource = dt.TaoBang(sql1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa ko nổi.. " + ex.ToString());
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "update Chuyen_Nganh set TenCN='" + txtTenChuyenNganh.Text 
                        + "' where MaCN='" + txtMaChuyenNganh.Text + "' where MaKhoa='" + cbbMaKhoa.Text + "'";
            dt.ExcuteNonQuery(sql);
            LoadDSChuyenNganh();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = "insert into ChucVu values('" + txtMaChuyenNganh.Text + "','" 
                + txtTenChuyenNganh.Text + "','" + cbbMaKhoa.Text + "')";
            try
            {
                dt.ExcuteNonQuery(sql);
                btnLuu.Enabled = false;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Đã tồn tại mã chuyên ngành hoặc điền thiếu", "Úi có lỗi");
            }
            LoadDSChuyenNganh();
        }

        private void dgvChuyenNganh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvChuyenNganh.Rows[e.RowIndex];
            txtMaChuyenNganh.Text = Convert.ToString(row.Cells["MaCN"].Value);
            txtTenChuyenNganh.Text = Convert.ToString(row.Cells["TenCN"].Value);
        }
    }
}
