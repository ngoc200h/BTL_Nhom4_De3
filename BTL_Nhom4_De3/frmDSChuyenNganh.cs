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
        private string tukhoa = "";
        private void LoadDSChuyenNganh()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = tukhoa
            }
                                            );
            //dgvSinhVien.DataSource = new Database().SelectData("SelectAllKhoa", lstPara);
            dgvChuyenNganh.DataSource = new Database().Chuyen_Nganh();
            //Chuyen_Nganh( MaCN, MaKhoa, TenCN)
            dgvChuyenNganh.Columns["MaCN"].HeaderText = "Mã Chuyên Ngành";
            dgvChuyenNganh.Columns["MaKhoa"].HeaderText = "Mã Khoa";
            dgvChuyenNganh.Columns["TenCN"].HeaderText = "Tên Chuyên Ngành";
        }
    }
}
