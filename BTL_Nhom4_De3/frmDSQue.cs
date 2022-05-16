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
    public partial class frmDSQue : Form
    {
        public frmDSQue()
        {
            InitializeComponent();
        }

        private void frmDSQue_Load(object sender, EventArgs e)
        {
            LoadDSQue();
        }
        private string tukhoa = "";
        private void LoadDSQue()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = tukhoa
            }
                                            );
            //dgvSinhVien.DataSource = new Database().SelectData("SelectAllKhoa", lstPara);
            dgvQue.DataSource = new Database().Que();
            //Que (MaQue, TenQue)
            dgvQue.Columns["MaQue"].HeaderText = "Mã Quê";
            dgvQue.Columns["TenQue"].HeaderText = "Tên Quê";
        }
    }
}
