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
    public partial class frmDSDanToc : Form
    {
        public frmDSDanToc()
        {
            InitializeComponent();
        }

        private void frmDSDanToc_Load(object sender, EventArgs e)
        {
            LoadDSDanToc();
        }
        private string tukhoa = "";
        private void LoadDSDanToc()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@tukhoa",
                value = tukhoa
            }
                                            );
            //dgvSinhVien.DataSource = new Database().SelectData("SelectAllKhoa", lstPara);
            dgvDanToc.DataSource = new Database().DanToc();
            //DanToc ( MaDToc, TenDToc)
            dgvDanToc.Columns["MaDToc"].HeaderText = "Mã Dân Tộc";
            dgvDanToc.Columns["TenDToc"].HeaderText = "Tên Dân Tộc";
        }
    }
}
