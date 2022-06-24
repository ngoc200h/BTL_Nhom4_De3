
namespace BTL_Nhom4_De3
{
    partial class frmHDSD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHDSD));
            this.cboChung = new System.Windows.Forms.ComboBox();
            this.cboSV = new System.Windows.Forms.ComboBox();
            this.cboQA = new System.Windows.Forms.ComboBox();
            this.txtChung = new System.Windows.Forms.TextBox();
            this.txtSV = new System.Windows.Forms.TextBox();
            this.txtQA = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cboChung
            // 
            this.cboChung.FormattingEnabled = true;
            this.cboChung.Location = new System.Drawing.Point(200, 106);
            this.cboChung.Name = "cboChung";
            this.cboChung.Size = new System.Drawing.Size(121, 21);
            this.cboChung.TabIndex = 0;
            this.cboChung.Text = "Thông tin Chung";
            this.cboChung.SelectedIndexChanged += new System.EventHandler(this.cboChung_SelectedIndexChanged);
            // 
            // cboSV
            // 
            this.cboSV.FormattingEnabled = true;
            this.cboSV.Location = new System.Drawing.Point(200, 181);
            this.cboSV.Name = "cboSV";
            this.cboSV.Size = new System.Drawing.Size(121, 21);
            this.cboSV.TabIndex = 1;
            this.cboSV.Text = "Thông tin Sinh Viên";
            this.cboSV.SelectedIndexChanged += new System.EventHandler(this.cboSV_SelectedIndexChanged);
            // 
            // cboQA
            // 
            this.cboQA.FormattingEnabled = true;
            this.cboQA.Location = new System.Drawing.Point(200, 276);
            this.cboQA.Name = "cboQA";
            this.cboQA.Size = new System.Drawing.Size(121, 21);
            this.cboQA.TabIndex = 2;
            this.cboQA.Text = "Q&A";
            this.cboQA.SelectedIndexChanged += new System.EventHandler(this.cboQA_SelectedIndexChanged);
            // 
            // txtChung
            // 
            this.txtChung.Location = new System.Drawing.Point(340, 106);
            this.txtChung.Multiline = true;
            this.txtChung.Name = "txtChung";
            this.txtChung.Size = new System.Drawing.Size(244, 60);
            this.txtChung.TabIndex = 3;
            // 
            // txtSV
            // 
            this.txtSV.Location = new System.Drawing.Point(340, 182);
            this.txtSV.Multiline = true;
            this.txtSV.Name = "txtSV";
            this.txtSV.Size = new System.Drawing.Size(244, 78);
            this.txtSV.TabIndex = 4;
            // 
            // txtQA
            // 
            this.txtQA.Location = new System.Drawing.Point(340, 276);
            this.txtQA.Multiline = true;
            this.txtQA.Name = "txtQA";
            this.txtQA.Size = new System.Drawing.Size(244, 60);
            this.txtQA.TabIndex = 5;
            // 
            // frmHDSD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtQA);
            this.Controls.Add(this.txtSV);
            this.Controls.Add(this.txtChung);
            this.Controls.Add(this.cboQA);
            this.Controls.Add(this.cboSV);
            this.Controls.Add(this.cboChung);
            this.DoubleBuffered = true;
            this.Name = "frmHDSD";
            this.Text = "Hướng dẫn sử dụng";
            this.Load += new System.EventHandler(this.frmHDSD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboChung;
        private System.Windows.Forms.ComboBox cboSV;
        private System.Windows.Forms.ComboBox cboQA;
        private System.Windows.Forms.TextBox txtChung;
        private System.Windows.Forms.TextBox txtSV;
        private System.Windows.Forms.TextBox txtQA;
    }
}