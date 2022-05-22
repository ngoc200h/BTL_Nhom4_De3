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
        public frmDSDanToc()
        {
            InitializeComponent();
        }


        private void frmDSDanToc_Load(object sender, EventArgs e)
        {
            LoadDSDT();
        }

        Database dt = new Database();
        private void Reset()
        {
            txtMaDT.Text = "";
            txtTenDT.Text = "";
        }
        private void LoadDSDT()
        {
            string sql1 = "select * from DanToc";
            dgvDT.DataSource = dt.TaoBang(sql1);
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
            Reset();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;

            txtMaDT.Enabled = true;
            txtMaDT.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa  " + txtMaDT.Text
                + " không? Nếu có ấn nút Lưu, không thì ấn nút Hủy", "Xóa sản phẩm",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string sql = "delete from DanToc where MaDToc='" + txtMaDT.Text + "'";
                    dt.ExcuteNonQuery(sql);
                    string sql1 = "select * from DanToc";
                    dgvDT.DataSource = dt.TaoBang(sql1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa ko nổi.. " + ex.ToString());
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "update DanToc set TenDToc='" + txtTenDT.Text + "' where MaDToc='" + txtMaDT.Text + "'";
            dt.ExcuteNonQuery(sql);
            LoadDSDT();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = "insert into DanToc values('" + txtMaDT.Text + "','" + txtTenDT.Text + "')";
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
            LoadDSDT();
        }
    }
}
