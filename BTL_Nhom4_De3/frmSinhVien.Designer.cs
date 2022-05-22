
namespace BTL_Nhom4_De3
{
    partial class frmSinhVien
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenSV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rbtNam = new System.Windows.Forms.RadioButton();
            this.rbtNu = new System.Windows.Forms.RadioButton();
            this.mtbNgaySinh = new System.Windows.Forms.MaskedTextBox();
            this.cbKhoa = new System.Windows.Forms.ComboBox();
            this.cbLop = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbQue = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbDantoc = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbChuyenNganh = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbHedt = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbChucvu = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên SV";
            // 
            // txtTenSV
            // 
            this.txtTenSV.Location = new System.Drawing.Point(167, 30);
            this.txtTenSV.Name = "txtTenSV";
            this.txtTenSV.Size = new System.Drawing.Size(290, 20);
            this.txtTenSV.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày Sinh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Giới Tính";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mã Khoa";
            // 
            // rbtNam
            // 
            this.rbtNam.AutoSize = true;
            this.rbtNam.Checked = true;
            this.rbtNam.Location = new System.Drawing.Point(195, 119);
            this.rbtNam.Name = "rbtNam";
            this.rbtNam.Size = new System.Drawing.Size(47, 17);
            this.rbtNam.TabIndex = 7;
            this.rbtNam.TabStop = true;
            this.rbtNam.Text = "Nam";
            this.rbtNam.UseVisualStyleBackColor = true;
            // 
            // rbtNu
            // 
            this.rbtNu.AutoSize = true;
            this.rbtNu.Location = new System.Drawing.Point(330, 119);
            this.rbtNu.Name = "rbtNu";
            this.rbtNu.Size = new System.Drawing.Size(39, 17);
            this.rbtNu.TabIndex = 8;
            this.rbtNu.Text = "Nữ";
            this.rbtNu.UseVisualStyleBackColor = true;
            // 
            // mtbNgaySinh
            // 
            this.mtbNgaySinh.Location = new System.Drawing.Point(167, 72);
            this.mtbNgaySinh.Mask = "00/00/0000";
            this.mtbNgaySinh.Name = "mtbNgaySinh";
            this.mtbNgaySinh.Size = new System.Drawing.Size(75, 20);
            this.mtbNgaySinh.TabIndex = 9;
            this.mtbNgaySinh.ValidatingType = typeof(System.DateTime);
            // 
            // cbKhoa
            // 
            this.cbKhoa.FormattingEnabled = true;
            this.cbKhoa.Location = new System.Drawing.Point(100, 168);
            this.cbKhoa.Name = "cbKhoa";
            this.cbKhoa.Size = new System.Drawing.Size(121, 21);
            this.cbKhoa.TabIndex = 10;
            this.cbKhoa.SelectedIndexChanged += new System.EventHandler(this.cbKhoa_SelectedIndexChanged_1);
            // 
            // cbLop
            // 
            this.cbLop.FormattingEnabled = true;
            this.cbLop.Location = new System.Drawing.Point(100, 195);
            this.cbLop.Name = "cbLop";
            this.cbLop.Size = new System.Drawing.Size(121, 21);
            this.cbLop.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Mã Lớp";
            // 
            // cbQue
            // 
            this.cbQue.FormattingEnabled = true;
            this.cbQue.Location = new System.Drawing.Point(100, 222);
            this.cbQue.Name = "cbQue";
            this.cbQue.Size = new System.Drawing.Size(121, 21);
            this.cbQue.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Mã Quê";
            // 
            // cbDantoc
            // 
            this.cbDantoc.FormattingEnabled = true;
            this.cbDantoc.Location = new System.Drawing.Point(395, 163);
            this.cbDantoc.Name = "cbDantoc";
            this.cbDantoc.Size = new System.Drawing.Size(121, 21);
            this.cbDantoc.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(295, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Mã Dân tộc";
            // 
            // cbChuyenNganh
            // 
            this.cbChuyenNganh.FormattingEnabled = true;
            this.cbChuyenNganh.Location = new System.Drawing.Point(395, 192);
            this.cbChuyenNganh.Name = "cbChuyenNganh";
            this.cbChuyenNganh.Size = new System.Drawing.Size(121, 21);
            this.cbChuyenNganh.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(295, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Mã Chuyên ngành";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbHedt
            // 
            this.cbHedt.FormattingEnabled = true;
            this.cbHedt.Location = new System.Drawing.Point(395, 222);
            this.cbHedt.Name = "cbHedt";
            this.cbHedt.Size = new System.Drawing.Size(121, 21);
            this.cbHedt.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(295, 225);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Mã Hệ đào tạo";
            // 
            // cbChucvu
            // 
            this.cbChucvu.FormattingEnabled = true;
            this.cbChucvu.Location = new System.Drawing.Point(395, 249);
            this.cbChucvu.Name = "cbChucvu";
            this.cbChucvu.Size = new System.Drawing.Size(121, 21);
            this.cbChucvu.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(295, 252);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Mã Chức vụ";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(167, 298);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 23;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
           //this.btnLuu.Click += new System.EventHandler(this.//btnLuu_Click_1);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(314, 298);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 24;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 333);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.cbChucvu);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbHedt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbChuyenNganh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbDantoc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbQue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbLop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbKhoa);
            this.Controls.Add(this.mtbNgaySinh);
            this.Controls.Add(this.rbtNu);
            this.Controls.Add(this.rbtNam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTenSV);
            this.Controls.Add(this.label1);
            this.Name = "frmSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSinhVien";
            this.Load += new System.EventHandler(this.frmSinhVien_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenSV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbtNam;
        private System.Windows.Forms.RadioButton rbtNu;
        private System.Windows.Forms.MaskedTextBox mtbNgaySinh;
        private System.Windows.Forms.ComboBox cbKhoa;
        private System.Windows.Forms.ComboBox cbLop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbQue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbDantoc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbChuyenNganh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbHedt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbChucvu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
    }
}