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
    public partial class frmTeacherMainMenu : Form
    {
        public frmTeacherMainMenu()
        {
            InitializeComponent();
        }

        private void frmTeacherMainMenu_Load(object sender, EventArgs e)
        {
            Database.Connect();
            chucVuToolStripMenuItem.Enabled = false;
            queQuanToolStripMenuItem.Enabled = false;
            danTocToolStripMenuItem.Enabled = false;
            monHocToolStripMenuItem1.Enabled = false;
            phongHocToolStripMenuItem.Enabled = false;
            khoaToolStripMenuItem1.Enabled = false;
            chuyenNganhToolStripMenuItem.Enabled = false;
            lopToolStripMenuItem.Enabled = false;
            heDTToolStripMenuItem.Enabled = false;
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

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sinhVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSSV f = new frmDSSV();
            AddForm(f);
        }

        private void khoaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void diemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSDiem f = new frmDSDiem();
            AddForm(f);
        }

        private void monHocToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void TKB_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSTKB f = new frmDSTKB();
            AddForm(f);
        }
    }
}
