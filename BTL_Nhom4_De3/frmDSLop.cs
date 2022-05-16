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
    public partial class frmDSLop : Form
    {
        public frmDSLop()
        {
            InitializeComponent();
        }

        private void frmDSLop_Load(object sender, EventArgs e)
        {
            LoadDSLop();
        }
        private string tukhoa = "";
        private void LoadDSLop()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = tukhoa
            }
                                            );
            //dgvSinhVien.DataSource = new Database().SelectData("SelectAllKhoa", lstPara);
            dgvLop.DataSource = new Database().Lop();
            //Lop (MaLop, TenLop, MaKhoa, KhoaHoc, SiSo)
            dgvLop.Columns["MaLop"].HeaderText = "Mã Lớp";
            dgvLop.Columns["TenLop"].HeaderText = "Tên Lớp";
            dgvLop.Columns["MaKhoa"].HeaderText = "Mã Khoa";
            dgvLop.Columns["KhoaHoc"].HeaderText = "Khóa Học";
            dgvLop.Columns["SiSo"].HeaderText = "Sĩ Số";
        }
    }
}
