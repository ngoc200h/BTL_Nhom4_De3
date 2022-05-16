
namespace BTL_Nhom4_De3
{
    partial class frmDSDanToc
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
            this.dgvDanToc = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanToc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDanToc
            // 
            this.dgvDanToc.AllowUserToAddRows = false;
            this.dgvDanToc.AllowUserToDeleteRows = false;
            this.dgvDanToc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanToc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanToc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDanToc.Location = new System.Drawing.Point(0, 61);
            this.dgvDanToc.MultiSelect = false;
            this.dgvDanToc.Name = "dgvDanToc";
            this.dgvDanToc.ReadOnly = true;
            this.dgvDanToc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanToc.Size = new System.Drawing.Size(370, 191);
            this.dgvDanToc.TabIndex = 23;
            // 
            // frmDSDanToc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 252);
            this.Controls.Add(this.dgvDanToc);
            this.Name = "frmDSDanToc";
            this.Text = "Danh Sách Dân Tộc";
            this.Load += new System.EventHandler(this.frmDSDanToc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanToc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDanToc;
    }
}