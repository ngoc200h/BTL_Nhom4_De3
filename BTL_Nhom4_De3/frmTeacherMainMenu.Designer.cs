
namespace BTL_Nhom4_De3
{
    partial class frmTeacherMainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.danhSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sinhVienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chucVuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queQuanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danTocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinChungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TKB_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monHocToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.phongHocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khoaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chuyenNganhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heDTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.BackgroundImage = global::BTL_Nhom4_De3.Properties.Resources._288836171_568177591541693_2417355002403532930_n;
            this.pnlContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlContent.Controls.Add(this.lblUserName);
            this.pnlContent.Controls.Add(this.pictureBox1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlContent.Location = new System.Drawing.Point(0, 28);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1131, 555);
            this.pnlContent.TabIndex = 4;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.Teal;
            this.lblUserName.Location = new System.Drawing.Point(1019, 65);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(49, 20);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "User";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BTL_Nhom4_De3.Properties.Resources._1946429;
            this.pictureBox1.Location = new System.Drawing.Point(1009, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhSáchToolStripMenuItem,
            this.thôngTinChungToolStripMenuItem,
            this.thoatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1131, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // danhSáchToolStripMenuItem
            // 
            this.danhSáchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sinhVienToolStripMenuItem,
            this.diemToolStripMenuItem,
            this.chucVuToolStripMenuItem,
            this.queQuanToolStripMenuItem,
            this.danTocToolStripMenuItem});
            this.danhSáchToolStripMenuItem.Name = "danhSáchToolStripMenuItem";
            this.danhSáchToolStripMenuItem.Size = new System.Drawing.Size(154, 24);
            this.danhSáchToolStripMenuItem.Text = "Thông Tin Sinh Viên";
            // 
            // sinhVienToolStripMenuItem
            // 
            this.sinhVienToolStripMenuItem.Name = "sinhVienToolStripMenuItem";
            this.sinhVienToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sinhVienToolStripMenuItem.Text = "Sinh Viên";
            this.sinhVienToolStripMenuItem.Click += new System.EventHandler(this.sinhVienToolStripMenuItem_Click);
            // 
            // diemToolStripMenuItem
            // 
            this.diemToolStripMenuItem.Name = "diemToolStripMenuItem";
            this.diemToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.diemToolStripMenuItem.Text = "Điểm";
            this.diemToolStripMenuItem.Click += new System.EventHandler(this.diemToolStripMenuItem_Click);
            // 
            // chucVuToolStripMenuItem
            // 
            this.chucVuToolStripMenuItem.Name = "chucVuToolStripMenuItem";
            this.chucVuToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.chucVuToolStripMenuItem.Text = "Chức vụ";
            // 
            // queQuanToolStripMenuItem
            // 
            this.queQuanToolStripMenuItem.Name = "queQuanToolStripMenuItem";
            this.queQuanToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.queQuanToolStripMenuItem.Text = "Quê Quán";
            // 
            // danTocToolStripMenuItem
            // 
            this.danTocToolStripMenuItem.Name = "danTocToolStripMenuItem";
            this.danTocToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.danTocToolStripMenuItem.Text = "Dân Tộc";
            // 
            // thôngTinChungToolStripMenuItem
            // 
            this.thôngTinChungToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TKB_ToolStripMenuItem,
            this.monHocToolStripMenuItem1,
            this.phongHocToolStripMenuItem,
            this.lopToolStripMenuItem,
            this.khoaToolStripMenuItem1,
            this.chuyenNganhToolStripMenuItem,
            this.heDTToolStripMenuItem});
            this.thôngTinChungToolStripMenuItem.Name = "thôngTinChungToolStripMenuItem";
            this.thôngTinChungToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.thôngTinChungToolStripMenuItem.Text = "Thông tin Chung";
            // 
            // TKB_ToolStripMenuItem
            // 
            this.TKB_ToolStripMenuItem.Name = "TKB_ToolStripMenuItem";
            this.TKB_ToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.TKB_ToolStripMenuItem.Text = "Thời Khóa Biểu";
            this.TKB_ToolStripMenuItem.Click += new System.EventHandler(this.TKB_ToolStripMenuItem_Click);
            // 
            // monHocToolStripMenuItem1
            // 
            this.monHocToolStripMenuItem1.Name = "monHocToolStripMenuItem1";
            this.monHocToolStripMenuItem1.Size = new System.Drawing.Size(236, 26);
            this.monHocToolStripMenuItem1.Text = "Môn Học";
            this.monHocToolStripMenuItem1.Click += new System.EventHandler(this.monHocToolStripMenuItem1_Click);
            // 
            // phongHocToolStripMenuItem
            // 
            this.phongHocToolStripMenuItem.Name = "phongHocToolStripMenuItem";
            this.phongHocToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.phongHocToolStripMenuItem.Text = "Phòng Học";
            // 
            // lopToolStripMenuItem
            // 
            this.lopToolStripMenuItem.Name = "lopToolStripMenuItem";
            this.lopToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.lopToolStripMenuItem.Text = "Lớp";
            // 
            // khoaToolStripMenuItem1
            // 
            this.khoaToolStripMenuItem1.Name = "khoaToolStripMenuItem1";
            this.khoaToolStripMenuItem1.Size = new System.Drawing.Size(236, 26);
            this.khoaToolStripMenuItem1.Text = "Khoa";
            this.khoaToolStripMenuItem1.Click += new System.EventHandler(this.khoaToolStripMenuItem1_Click);
            // 
            // chuyenNganhToolStripMenuItem
            // 
            this.chuyenNganhToolStripMenuItem.Name = "chuyenNganhToolStripMenuItem";
            this.chuyenNganhToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.chuyenNganhToolStripMenuItem.Text = "Khoa - Chuyên Ngành";
            // 
            // heDTToolStripMenuItem
            // 
            this.heDTToolStripMenuItem.Name = "heDTToolStripMenuItem";
            this.heDTToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.heDTToolStripMenuItem.Text = "Hệ Đào Tạo";
            // 
            // thoatToolStripMenuItem
            // 
            this.thoatToolStripMenuItem.Name = "thoatToolStripMenuItem";
            this.thoatToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.thoatToolStripMenuItem.Text = "Thoát";
            this.thoatToolStripMenuItem.Click += new System.EventHandler(this.thoatToolStripMenuItem_Click);
            // 
            // frmTeacherMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 583);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmTeacherMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeacherMainMenu";
            this.Load += new System.EventHandler(this.frmTeacherMainMenu_Load);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem danhSáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sinhVienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chucVuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queQuanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danTocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinChungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TKB_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monHocToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem phongHocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khoaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem chuyenNganhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heDTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoatToolStripMenuItem;
    }
}