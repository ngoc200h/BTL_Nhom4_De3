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
        public frmDSMon()
        {
            InitializeComponent();
        }

        private void frmDSMon_Load(object sender, EventArgs e)
        {
            LoadDSMon();
        }
        Database dt = new Database();
        private void Reset()
        {
            txtMaMon.Text = "";
            txtTenMon.Text = "";
            txtDVHT.Text = "";
        }
        private void LoadDSMon()
        {
            string sql1 = "select * from Mon";
            dgvMon.DataSource = dt.TaoBang(sql1);
            //Mon (MaMon, TenMon, DVHT)
            dgvMon.Columns["MaMon"].HeaderText = "Mã Môn";
            dgvMon.Columns["TenMon"].HeaderText = "Tên Môn";
            dgvMon.Columns["DVHT"].HeaderText = "Đơn Vị Học Trình";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Reset();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;

            txtMaMon.Enabled = true;
            txtMaMon.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa  " + txtMaMon.Text
        + " không? Nếu có ấn nút Lưu, không thì ấn nút Hủy", "Xóa sản phẩm",
        MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string sql = "delete from Mon where MaMon='" + txtMaMon.Text + "'";
                    dt.ExcuteNonQuery(sql);
                    string sql1 = "select * from Mon";
                    dgvMon.DataSource = dt.TaoBang(sql1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa ko nổi.. " + ex.ToString());
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "update Mon set TenMon='" + txtTenMon.Text
            + "' where MaMon='" + txtMaMon.Text + "' where DVHT='" + txtDVHT.Text + "'";
            dt.ExcuteNonQuery(sql);
            LoadDSMon();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = "insert into Mon values('" + txtMaMon.Text + "','"
    + txtTenMon.Text + "','" + txtDVHT.Text + "')";
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
            LoadDSMon();
        }

        private void dgvMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvMon.Rows[e.RowIndex];
            txtMaMon.Text = Convert.ToString(row.Cells["MaMon"].Value);
            txtTenMon.Text = Convert.ToString(row.Cells["TenMon"].Value);
            txtDVHT.Text = Convert.ToString(row.Cells["DVHT"].Value);
        }
    }
}
