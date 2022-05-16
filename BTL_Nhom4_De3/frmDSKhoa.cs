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
    public partial class frmDSKhoa : Form
    {
        public frmDSKhoa()
        {
            InitializeComponent();
        }

        private void frmDSKhoa_Load(object sender, EventArgs e)
        {
            LoadDSKhoa();//gọi tới hàm load sinh viên khi form đc load
        }

        private string tukhoa = "";
        private void LoadDSKhoa()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = tukhoa
            }
                                            );
            //dgvSinhVien.DataSource = new Database().SelectData("SelectAllKhoa", lstPara);
            dgvKhoa.DataSource = new Database().Khoa();
            //Khoa (MaKhoa, TenKhoa, DiaChi, Website)
            dgvKhoa.Columns["MaKhoa"].HeaderText = "Mã Khoa";
            dgvKhoa.Columns["TenKhoa"].HeaderText = "Tên Khoa";
            dgvKhoa.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgvKhoa.Columns["Website"].HeaderText = "Website";
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            tukhoa = txtTuKhoa.Text;
            LoadDSKhoa();
        }
    }
}
