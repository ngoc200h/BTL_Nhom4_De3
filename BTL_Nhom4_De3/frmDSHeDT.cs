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
    public partial class frmDSHeDT : Form
    {
        public frmDSHeDT()
        {
            InitializeComponent();
        }

        private void frmDSHeDT_Load(object sender, EventArgs e)
        {
            LoadDSHDT();
        }
        private string tukhoa = "";
        private void LoadDSHDT()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = tukhoa
            }
                                            );
            //dgvSinhVien.DataSource = new Database().SelectData("SelectAllKhoa", lstPara);
            dgvHeDT.DataSource = new Database().HeDaoTao();
            //HeDaoTao (MaHeDT, TenHeDT)
            dgvHeDT.Columns["MaHeDT"].HeaderText = "Mã Hệ Đào Tạo";
            dgvHeDT.Columns["TenHeDT"].HeaderText = "Tên Hệ Đào Tạo";
        }
        //
    }
}
