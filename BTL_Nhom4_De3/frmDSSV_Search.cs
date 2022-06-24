using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Nhom4_De3
{
    public partial class frmDSSV_Search : Form
    {
        DataTable tblSV;
        public frmDSSV_Search()
        {
            InitializeComponent();
        }


        private void ResetValues()
        {
            cboMaKhoa.Text = "";
            cboMaQue.Text = "";
            cboMaCN.Text = "";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((cboMaQue.Text == "")
                && (cboMaCN.Text == "")
                && (cboMaKhoa.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM Sinh_Vien WHERE 1=1";
            if (cboMaQue.Text != "")
                sql = sql + " AND MaQue Like N'%" + cboMaQue.SelectedValue + "%'";
            if (cboMaCN.Text != "")
                sql = sql + " AND MaCN Like N'%" + cboMaCN.SelectedValue + "%'";
            if (cboMaKhoa.Text != "")
                sql = sql + " AND MaKhoa Like N'%" + cboMaKhoa.SelectedValue + "%'";
            tblSV = Database.LoadDataToTable(sql);
            if (tblSV.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblSV.Rows.Count + " bản ghi thỏa mãn điều kiện!!!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgvSinhVien.DataSource = tblSV;
            ResetValues();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDSSV f = new frmDSSV();
            f.ShowDialog();
            this.Close();
        }

        private void frmDSSV_Search_Load(object sender, EventArgs e)
        {
            Database.FillDataToCombo("SELECT MaKhoa, TenKhoa FROM Khoa", cboMaKhoa, "MaKhoa", "TenKhoa");
            cboMaKhoa.SelectedIndex = -1;
            Database.FillDataToCombo("SELECT MaQue, TenQue FROM Que", cboMaQue, "MaQue", "TenQue");
            cboMaQue.SelectedIndex = -1;
            Database.FillDataToCombo("SELECT MaCN, TenCN FROM Chuyen_Nganh", cboMaCN, "MaCN", "TenCN");
            cboMaCN.SelectedIndex = -1;
            LoadDSSV();//gọi tới hàm load sinh viên khi form đc load
        }
        private void LoadDSSV()
        {
            string sql;
            sql = "SELECT * FROM Sinh_Vien";
            tblSV = Database.LoadDataToTable(sql);
            dgvSinhVien.DataSource = tblSV;

            dgvSinhVien.Columns["MaSV"].HeaderText = "Mã SV";
            dgvSinhVien.Columns["TenSV"].HeaderText = "Tên SV";
            dgvSinhVien.Columns["MaKhoa"].HeaderText = "Mã Khoa";
            dgvSinhVien.Columns["MaLop"].HeaderText = "Mã Lớp";
            dgvSinhVien.Columns["NgSinh"].HeaderText = "Ngày Sinh";
            dgvSinhVien.Columns["GTinh"].HeaderText = "Giới Tính";
            dgvSinhVien.Columns["MaQue"].HeaderText = "Mã Quê";
            dgvSinhVien.Columns["MaDToc"].HeaderText = "Mã Dân tộc";
            dgvSinhVien.Columns["MaCN"].HeaderText = "Mã Chuyên ngành";
            dgvSinhVien.Columns["MaHeDT"].HeaderText = "Mã Hệ đào tạo";
            dgvSinhVien.Columns["MaChucVu"].HeaderText = "Mã Chức vụ";
        }
    }
}
