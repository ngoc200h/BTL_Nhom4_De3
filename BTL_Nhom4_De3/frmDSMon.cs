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
        private string tukhoa = "";
        private void LoadDSMon()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = tukhoa
            }
                                            );
            //dgvSinhVien.DataSource = new Database().SelectData("SelectAllKhoa", lstPara);
            dgvMon.DataSource = new Database().Mon();
            //Mon (MaMon, TenMon, DVHT)
            dgvMon.Columns["MaMon"].HeaderText = "Mã Môn";
            dgvMon.Columns["TenMon"].HeaderText = "Tên Môn";
            dgvMon.Columns["DVHT"].HeaderText = "Đơn Vị Học Trình";
        }
    }
}
