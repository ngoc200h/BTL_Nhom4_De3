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
    public partial class frmDSDiem : Form
    {
        public frmDSDiem()
        {
            InitializeComponent();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {

        }

        private void frmDSDiem_Load(object sender, EventArgs e)
        {
            LoadDSDiem();
        }
        private string tukhoa = "";
        private void LoadDSDiem()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = tukhoa
            }
                                            );
            //dgvSinhVien.DataSource = new Database().SelectData("SelectAllKhoa", lstPara);
            dgvDiem.DataSource = new Database().Diem();
            //Diem (MaSV, MaLop, MaMon, HocKy, LanThi, Diem)
            dgvDiem.Columns["MaSV"].HeaderText = "Mã Sinh Viên";
            dgvDiem.Columns["MaLop"].HeaderText = "Mã Lớp";
            dgvDiem.Columns["MaMon"].HeaderText = "Mã Môn";
            dgvDiem.Columns["HocKy"].HeaderText = "Học Kỳ";
            dgvDiem.Columns["LanThi"].HeaderText = "Lần Thi";
            dgvDiem.Columns["Diem"].HeaderText = "Điểm";
        }
    }
}
