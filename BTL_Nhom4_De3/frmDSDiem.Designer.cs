
namespace BTL_Nhom4_De3
{
    partial class frmDSDiem
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
            this.dgvDiem = new System.Windows.Forms.DataGridView();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.cboMaLop = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.cboMaMon = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboLanThi = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnInDSDiem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.txtDiem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInBangDiem = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDiem
            // 
            this.dgvDiem.AllowUserToAddRows = false;
            this.dgvDiem.AllowUserToDeleteRows = false;
            this.dgvDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDiem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDiem.Location = new System.Drawing.Point(0, 229);
            this.dgvDiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDiem.MultiSelect = false;
            this.dgvDiem.Name = "dgvDiem";
            this.dgvDiem.ReadOnly = true;
            this.dgvDiem.RowHeadersWidth = 51;
            this.dgvDiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiem.Size = new System.Drawing.Size(1131, 311);
            this.dgvDiem.TabIndex = 6;
            this.dgvDiem.Click += new System.EventHandler(this.dgvDiem_Click);
            // 
            // btnBoQua
            // 
            this.btnBoQua.Location = new System.Drawing.Point(963, 129);
            this.btnBoQua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(100, 28);
            this.btnBoQua.TabIndex = 56;
            this.btnBoQua.Text = "Bỏ Qua";
            this.btnBoQua.UseVisualStyleBackColor = true;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // cboMaLop
            // 
            this.cboMaLop.FormattingEnabled = true;
            this.cboMaLop.Location = new System.Drawing.Point(144, 39);
            this.cboMaLop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboMaLop.Name = "cboMaLop";
            this.cboMaLop.Size = new System.Drawing.Size(160, 24);
            this.cboMaLop.TabIndex = 55;
            this.cboMaLop.SelectedIndexChanged += new System.EventHandler(this.cboMaLop_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 54;
            this.label3.Text = "Mã Lớp";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(748, 181);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 28);
            this.btnLuu.TabIndex = 49;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(963, 94);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 28);
            this.btnSua.TabIndex = 48;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(963, 58);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 28);
            this.btnXoa.TabIndex = 47;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(700, 57);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 28);
            this.btnTimKiem.TabIndex = 46;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // cboMaMon
            // 
            this.cboMaMon.FormattingEnabled = true;
            this.cboMaMon.Location = new System.Drawing.Point(144, 83);
            this.cboMaMon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboMaMon.Name = "cboMaMon";
            this.cboMaMon.Size = new System.Drawing.Size(160, 24);
            this.cboMaMon.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 87);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 57;
            this.label4.Text = "Mã Môn";
            // 
            // cboHocKy
            // 
            this.cboHocKy.FormattingEnabled = true;
            this.cboHocKy.Location = new System.Drawing.Point(493, 36);
            this.cboHocKy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(160, 24);
            this.cboHocKy.TabIndex = 60;
            this.cboHocKy.SelectedIndexChanged += new System.EventHandler(this.cboHocKy_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(417, 39);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 59;
            this.label5.Text = "Học Kỳ";
            // 
            // cboLanThi
            // 
            this.cboLanThi.FormattingEnabled = true;
            this.cboLanThi.Location = new System.Drawing.Point(493, 84);
            this.cboLanThi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboLanThi.Name = "cboLanThi";
            this.cboLanThi.Size = new System.Drawing.Size(160, 24);
            this.cboLanThi.TabIndex = 62;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(417, 87);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 61;
            this.label6.Text = "Lần Thi";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboLanThi);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.cboHocKy);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboMaLop);
            this.groupBox1.Controls.Add(this.cboMaMon);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(48, 37);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(840, 137);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điền thông tin để  nhập điểm";
            // 
            // btnInDSDiem
            // 
            this.btnInDSDiem.Location = new System.Drawing.Point(963, 181);
            this.btnInDSDiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInDSDiem.Name = "btnInDSDiem";
            this.btnInDSDiem.Size = new System.Drawing.Size(100, 28);
            this.btnInDSDiem.TabIndex = 68;
            this.btnInDSDiem.Text = "In DS Điểm";
            this.btnInDSDiem.UseVisualStyleBackColor = true;
            this.btnInDSDiem.Click += new System.EventHandler(this.btnInDSDiem_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 185);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 64;
            this.label1.Text = "Mã Sinh Viên";
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(217, 181);
            this.txtMaSV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(135, 22);
            this.txtMaSV.TabIndex = 65;
            // 
            // txtDiem
            // 
            this.txtDiem.Location = new System.Drawing.Point(643, 181);
            this.txtDiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDiem.Name = "txtDiem";
            this.txtDiem.Size = new System.Drawing.Size(59, 22);
            this.txtDiem.TabIndex = 67;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(593, 185);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 66;
            this.label2.Text = "Điểm";
            // 
            // btnInBangDiem
            // 
            this.btnInBangDiem.Location = new System.Drawing.Point(361, 181);
            this.btnInBangDiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInBangDiem.Name = "btnInBangDiem";
            this.btnInBangDiem.Size = new System.Drawing.Size(181, 28);
            this.btnInBangDiem.TabIndex = 69;
            this.btnInBangDiem.Text = "In Bảng Điểm theo MSV";
            this.btnInBangDiem.UseVisualStyleBackColor = true;
            this.btnInBangDiem.Click += new System.EventHandler(this.btnInBangDiem_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(213, 209);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 17);
            this.label7.TabIndex = 70;
            this.label7.Text = "Cú pháp: SV + số";
            // 
            // frmDSDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 540);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnInBangDiem);
            this.Controls.Add(this.btnInDSDiem);
            this.Controls.Add(this.txtDiem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaSV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBoQua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.dgvDiem);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmDSDiem";
            this.Text = "Danh Sách Điểm";
            this.Load += new System.EventHandler(this.frmDSDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDiem;
        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.ComboBox cboMaLop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.ComboBox cboMaMon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboLanThi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.TextBox txtDiem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInDSDiem;
        private System.Windows.Forms.Button btnInBangDiem;
        private System.Windows.Forms.Label label7;
    }
}