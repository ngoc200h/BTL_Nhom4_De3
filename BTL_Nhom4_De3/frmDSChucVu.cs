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
    public partial class frmDSChucVu : Form
    {
        public frmDSChucVu()
        {
            InitializeComponent();
        }

        private void frmDSChucVu_Load(object sender, EventArgs e)
        {
            LoadDSChucVu();
        }
        private string tukhoa = "";
        private void LoadDSChucVu()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = tukhoa
            }
                                            );
            //dgvSinhVien.DataSource = new Database().SelectData("SelectAllKhoa", lstPara);
            dgvChucVu.DataSource = new Database().ChucVu();
            //ChucVu(MaChucVu, TenChucVu)
            dgvChucVu.Columns["MaChucVu"].HeaderText = "Mã Chức Vụ";
            dgvChucVu.Columns["TenChucVu"].HeaderText = "Tên Chức Vụ";
        }
    }
}
