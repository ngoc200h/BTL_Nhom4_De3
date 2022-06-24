using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Nhom4_De3
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Database.Connect();
        }

        private void AddForm(Form f)
        {
            this.pnlContent.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            this.Text = f.Text;
            this.pnlContent.Controls.Add(f);
            f.Show();
        }
        private void HDSDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHDSD f = new frmHDSD();
            AddForm(f);
        }

        private void sinhVienToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDSSV f = new frmDSSV();
            AddForm(f);
        }

        private void diemToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDSDiem f = new frmDSDiem();
            AddForm(f);
        }

        private void chucVuToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDSChucVu f = new frmDSChucVu();
            AddForm(f);
        }

        private void queQuanToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDSQue f = new frmDSQue();
            f.StartPosition = FormStartPosition.CenterScreen;
            AddForm(f);
        }

        private void danTocToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDSDanToc f = new frmDSDanToc();
            AddForm(f);
        }

        private void TKB_ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDSTKB f = new frmDSTKB();
            AddForm(f);
        }

        private void monHocToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmDSMon f = new frmDSMon();
            AddForm(f);
        }

        private void phongHocToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDSPhongHoc f = new frmDSPhongHoc();
            AddForm(f);
        }

        private void lopToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDSLop f = new frmDSLop();
            AddForm(f);
        }

        private void khoaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDSKhoa f = new frmDSKhoa();
            AddForm(f);
        }

        private void chuyenNganhToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDSChuyenNganh f = new frmDSChuyenNganh();
            AddForm(f);
        }

        private void heDTToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDSHeDT f = new frmDSHeDT();
            AddForm(f);
        }

        private void thoatToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            const string message = "Ｄｏ ｙｏｕ ｗａｎｔ ｔｏ ｅｘｉｔ ?";
            const string caption = "Thông báo nhẹ";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (result == DialogResult.Yes)
            {
                this.Close();

            }
        }
    }
}
