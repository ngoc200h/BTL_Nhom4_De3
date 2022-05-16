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
    public partial class frmDSPhongHoc : Form
    {
        public frmDSPhongHoc()
        {
            InitializeComponent();
        }

        private void frmDSPhongHoc_Load(object sender, EventArgs e)
        {
            LoadDSPhongHoc();
        }
        private string tukhoa = "";
        private void LoadDSPhongHoc()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = tukhoa
            }
                                            );
            //dgvSinhVien.DataSource = new Database().SelectData("SelectAllKhoa", lstPara);
            dgvPhongHoc.DataSource = new Database().Phong_Hoc();
            //Phong_Hoc (MaPhong, TenPhong)
            dgvPhongHoc.Columns["MaPhong"].HeaderText = "Mã Phòng Học";
            dgvPhongHoc.Columns["TenPhong"].HeaderText = "Tên Phòng Học";
        }
    }
}
