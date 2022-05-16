
namespace BTL_Nhom4_De3
{
    partial class frmDSPhongHoc
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
            this.dgvPhongHoc = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongHoc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPhongHoc
            // 
            this.dgvPhongHoc.AllowUserToAddRows = false;
            this.dgvPhongHoc.AllowUserToDeleteRows = false;
            this.dgvPhongHoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPhongHoc.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPhongHoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhongHoc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPhongHoc.Location = new System.Drawing.Point(0, 73);
            this.dgvPhongHoc.MultiSelect = false;
            this.dgvPhongHoc.Name = "dgvPhongHoc";
            this.dgvPhongHoc.ReadOnly = true;
            this.dgvPhongHoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhongHoc.Size = new System.Drawing.Size(586, 244);
            this.dgvPhongHoc.TabIndex = 7;
            // 
            // frmDSPhongHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 317);
            this.Controls.Add(this.dgvPhongHoc);
            this.Name = "frmDSPhongHoc";
            this.Text = "Danh Sách Phòng Học";
            this.Load += new System.EventHandler(this.frmDSPhongHoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongHoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPhongHoc;
    }
}