
namespace BTL_Nhom4_De3
{
    partial class frmDSHeDT
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
            this.dgvHeDT = new System.Windows.Forms.DataGridView();
            this.txtTenHeDT = new System.Windows.Forms.TextBox();
            this.txtMaHeDT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeDT)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHeDT
            // 
            this.dgvHeDT.AllowUserToAddRows = false;
            this.dgvHeDT.AllowUserToDeleteRows = false;
            this.dgvHeDT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHeDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHeDT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvHeDT.Location = new System.Drawing.Point(0, 139);
            this.dgvHeDT.MultiSelect = false;
            this.dgvHeDT.Name = "dgvHeDT";
            this.dgvHeDT.ReadOnly = true;
            this.dgvHeDT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHeDT.Size = new System.Drawing.Size(623, 213);
            this.dgvHeDT.TabIndex = 22;
            this.dgvHeDT.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHeDT_CellClick);
            // 
            // txtTenHeDT
            // 
            this.txtTenHeDT.Location = new System.Drawing.Point(278, 58);
            this.txtTenHeDT.Name = "txtTenHeDT";
            this.txtTenHeDT.Size = new System.Drawing.Size(100, 20);
            this.txtTenHeDT.TabIndex = 42;
            // 
            // txtMaHeDT
            // 
            this.txtMaHeDT.Location = new System.Drawing.Point(278, 23);
            this.txtMaHeDT.Name = "txtMaHeDT";
            this.txtMaHeDT.Size = new System.Drawing.Size(100, 20);
            this.txtMaHeDT.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Tên Hệ Đào Tạo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Mã Hệ Đào Tạo";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(450, 100);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 38;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(332, 100);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 37;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(200, 100);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 36;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(81, 100);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 35;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // frmDSHeDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 352);
            this.Controls.Add(this.txtTenHeDT);
            this.Controls.Add(this.txtMaHeDT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvHeDT);
            this.Name = "frmDSHeDT";
            this.Text = "Danh Sách Hệ Đào Tạo";
            this.Load += new System.EventHandler(this.frmDSHeDT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeDT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvHeDT;
        private System.Windows.Forms.TextBox txtTenHeDT;
        private System.Windows.Forms.TextBox txtMaHeDT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
    }
}