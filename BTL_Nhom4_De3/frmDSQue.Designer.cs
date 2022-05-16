
namespace BTL_Nhom4_De3
{
    partial class frmDSQue
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
            this.dgvQue = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQue)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvQue
            // 
            this.dgvQue.AllowUserToAddRows = false;
            this.dgvQue.AllowUserToDeleteRows = false;
            this.dgvQue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvQue.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvQue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvQue.Location = new System.Drawing.Point(0, 95);
            this.dgvQue.MultiSelect = false;
            this.dgvQue.Name = "dgvQue";
            this.dgvQue.ReadOnly = true;
            this.dgvQue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQue.Size = new System.Drawing.Size(561, 228);
            this.dgvQue.TabIndex = 7;
            // 
            // frmDSQue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 323);
            this.Controls.Add(this.dgvQue);
            this.Name = "frmDSQue";
            this.Text = "Danh Sách Quê";
            this.Load += new System.EventHandler(this.frmDSQue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvQue;
    }
}