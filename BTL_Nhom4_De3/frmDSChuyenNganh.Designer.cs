﻿
namespace BTL_Nhom4_De3
{
    partial class frmDSChuyenNganh
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
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvChuyenNganh = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuyenNganh)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Location = new System.Drawing.Point(286, 14);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(176, 20);
            this.txtTuKhoa.TabIndex = 25;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(487, 12);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 24;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Từ Khóa";
            // 
            // dgvChuyenNganh
            // 
            this.dgvChuyenNganh.AllowUserToAddRows = false;
            this.dgvChuyenNganh.AllowUserToDeleteRows = false;
            this.dgvChuyenNganh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChuyenNganh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChuyenNganh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvChuyenNganh.Location = new System.Drawing.Point(0, 62);
            this.dgvChuyenNganh.MultiSelect = false;
            this.dgvChuyenNganh.Name = "dgvChuyenNganh";
            this.dgvChuyenNganh.ReadOnly = true;
            this.dgvChuyenNganh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChuyenNganh.Size = new System.Drawing.Size(574, 242);
            this.dgvChuyenNganh.TabIndex = 22;
            // 
            // frmDSChuyenNganh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 304);
            this.Controls.Add(this.txtTuKhoa);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvChuyenNganh);
            this.Name = "frmDSChuyenNganh";
            this.Text = "Danh Sách Chuyên Ngành";
            this.Load += new System.EventHandler(this.frmDSChuyenNganh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuyenNganh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvChuyenNganh;
    }
}