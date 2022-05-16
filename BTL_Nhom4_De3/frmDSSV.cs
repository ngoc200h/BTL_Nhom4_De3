using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Nhom4_De3
{
    public partial class frmDSSV : Form
    {
        public frmDSSV()
        {
            InitializeComponent();
        }

        private string tukhoa = "";
        private void frmDSSV_Load(object sender, EventArgs e)
        {
            LoadDSSV();//gọi tới hàm load sinh viên khi form đc load
        }
        private void LoadDSSV()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = tukhoa
            }
                                            );

            //dgvSinhVien.DataSource = new Database().SelectData("SelectAllSinhVien", lstPara);
            dgvSinhVien.DataSource = new Database().SinhVien();
            //SinhVien (MaSV, TenSV, MaKhoa, MaLop, NgSinh, GTinh, MaQue, MaDToc, MaCN, MaHeDT, MaChucVu)
            dgvSinhVien.Columns["MaSV"].HeaderText = "Mã SV";
            dgvSinhVien.Columns["TenSV"].HeaderText = "Tên SV";
            dgvSinhVien.Columns["MaKhoa"].HeaderText = "Mã Khoa";
            dgvSinhVien.Columns["MaLop"].HeaderText = "Mã Lớp";
            dgvSinhVien.Columns["NgSinh"].HeaderText = "Ngày Sinh";
            dgvSinhVien.Columns["GTinh"].HeaderText = "Giới Tính";
            dgvSinhVien.Columns["MaQue"].HeaderText = "Mã Quê";
            dgvSinhVien.Columns["MaDToc"].HeaderText = "Mã Dân tộc";
            dgvSinhVien.Columns["MaCN"].HeaderText = "Mã Chuyên ngành";
            dgvSinhVien.Columns["MaHeDT"].HeaderText = "Mã Hệ đào tạo";
            dgvSinhVien.Columns["MaChucVu"].HeaderText = "Mã Chức vụ";
        }

        private void dgvSinhVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var msv = dgvSinhVien.Rows[e.RowIndex].Cells["MaSV"].Value.ToString();
                new frmSinhVien(msv).ShowDialog();
                LoadDSSV();
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            new frmSinhVien(null).ShowDialog();
            LoadDSSV();
        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            try
            {
                tukhoa = txtTuKhoa.Text;
                LoadDSSV();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hổng có tìm thấy~");
            }
        }
    }
}
