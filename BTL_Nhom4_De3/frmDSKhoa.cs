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
    public partial class frmDSKhoa : Form
    {
        public frmDSKhoa()
        {
            InitializeComponent();
        }

        private void frmDSKhoa_Load(object sender, EventArgs e)
        {
            LoadDSKhoa();
        }

        Database dt = new Database();
        private void Reset()
        {
            txtMaKhoa.Text = "";
            txtTenKhoa.Text = "";
            txtDiaChi.Text = "";
            txtWebsite.Text = "";
        }
        private void LoadDSKhoa()
        {
            string sql1 = "select * from Khoa";
            dgvKhoa.DataSource = dt.TaoBang(sql1);
            //Khoa (MaKhoa, TenKhoa, DiaChi, Website)
            dgvKhoa.Columns["MaKhoa"].HeaderText = "Mã Khoa";
            dgvKhoa.Columns["TenKhoa"].HeaderText = "Tên Khoa";
            dgvKhoa.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgvKhoa.Columns["Website"].HeaderText = "Website";
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            Reset();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;

            txtMaKhoa.Enabled = true;
            txtMaKhoa.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa  " + txtMaKhoa.Text
                + " không? Nếu có ấn nút Lưu, không thì ấn nút Hủy", "Xóa sản phẩm",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string sql = "delete from Khoa where MaKhoa='" + txtMaKhoa.Text + "'";
                    dt.ExcuteNonQuery(sql);
                    string sql1 = "select * from Khoa";
                    dgvKhoa.DataSource = dt.TaoBang(sql1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa ko nổi.. " + ex.ToString());
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "update Khoa set TenKhoa='" + txtTenKhoa.Text
                + "' where MaKhoa='" + txtMaKhoa.Text + "' where DiaChi='" 
                + txtDiaChi.Text + "' where Website='" + txtWebsite.Text + "'";
            dt.ExcuteNonQuery(sql);
            LoadDSKhoa();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = "insert into Mon values('" + txtMaKhoa.Text + "','"
                + txtTenKhoa.Text + "','" + txtDiaChi.Text + "','" + txtWebsite.Text + "')";
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
            LoadDSKhoa();
        }

        private void dgvKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvKhoa.Rows[e.RowIndex];
            txtMaKhoa.Text = Convert.ToString(row.Cells["MaKhoa"].Value);
            txtTenKhoa.Text = Convert.ToString(row.Cells["TenKhoa"].Value);
            txtDiaChi.Text = Convert.ToString(row.Cells["DiaChi"].Value);
            txtWebsite.Text = Convert.ToString(row.Cells["Website"].Value);
        }
    }
}
