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
    public partial class frmDSTKB : Form
    {
        public frmDSTKB()
        {
            InitializeComponent();
        }

        private void frmDSTKB_Load(object sender, EventArgs e)
        {
            LoadDSTKB();
        }
        private string tukhoa = "";
        private void LoadDSTKB()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = tukhoa
            }
                                            );
            //dgvSinhVien.DataSource = new Database().SelectData("SelectAllKhoa", lstPara);
            dgvTKB.DataSource = new Database().ThoiKhoaBieu();
            //ThoiKhoaBieu (MaLop, MaMon, HocKy, ThuHoc, CaHoc, MaPhong)
            dgvTKB.Columns["MaLop"].HeaderText = "Mã Lớp";
            dgvTKB.Columns["MaMon"].HeaderText = "Mã Môn";
            dgvTKB.Columns["HocKy"].HeaderText = "Học Kỳ";
            dgvTKB.Columns["ThuHoc"].HeaderText = "Thứ Học";
            dgvTKB.Columns["CaHoc"].HeaderText = "Ca Học";
            dgvTKB.Columns["MaPhong"].HeaderText = "Mã Phòng";
        }
    }
}
