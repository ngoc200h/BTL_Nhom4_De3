using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace BTL_Nhom4_De3
{
    public partial class frmDSDiem : Form
    {
        DataTable tblDiem;
        public frmDSDiem()
        {
            InitializeComponent();
        }
        private void ResetValues()
        {
            cboMaLop.Text = "";
            cboHocKy.Text = "";
            cboMaMon.Text = "";
            cboLanThi.Text = "";
            txtDiem.Text = "";
            txtMaSV.Text = "";
        }
        private void frmDSDiem_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDSDiem();
            Database.FillDataToCombo("SELECT MaLop, TenLop FROM Lop", cboMaLop,
                                    "MaLop", "TenLop");
            cboMaLop.SelectedIndex = -1;
            Database.FillDataToCombo("SELECT MaMon, TenMon FROM Mon", cboMaMon,
                                    "MaMon", "TenMon");
            cboMaMon.SelectedIndex = -1;
            //cbo Học Kỳ
            string[] hk = { "1", "2"};
            foreach (string x in hk)
            {
                cboHocKy.Items.Add(x);
            }
            //cbo Lần thi
            string[] lt = { "1", "2", "3" };
            foreach (string x in lt)
            {
                cboLanThi.Items.Add(x);
            }
            ResetValues();
        }
        private void LoadDSDiem()
        {
            string sql;
            sql = "SELECT * FROM Diem";
            tblDiem = Database.LoadDataToTable(sql);
            dgvDiem.DataSource = tblDiem;
            //Diem (MaSV, MaLop, MaMon, HocKy, LanThi, Diem)
            dgvDiem.Columns["MaSV"].HeaderText = "Mã Sinh Viên";
            dgvDiem.Columns["MaLop"].HeaderText = "Mã Lớp";
            dgvDiem.Columns["MaMon"].HeaderText = "Mã Môn";
            dgvDiem.Columns["HocKy"].HeaderText = "Học Kỳ";
            dgvDiem.Columns["LanThi"].HeaderText = "Lần Thi";
            dgvDiem.Columns["Diem"].HeaderText = "Điểm";
            //cho phép sửa dữ liệu trực tiếp trên lưới
            dgvDiem.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblDiem.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE Diem WHERE MaLop=N'" + cboMaLop.Text + "'";
                Database.RunSqlDel(sql);
                LoadDSDiem();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblDiem.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            if (cboMaLop.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã lớp", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cboHocKy.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn học kỳ", "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                cboHocKy.Focus();
                return;
            }
            if (cboMaMon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn mã môn", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaMon.Focus();
                return;
            }
            if (cboLanThi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn lần thi", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLanThi.Focus();
                return;
            } //Diem (MaSV, MaLop, MaMon, HocKy, LanThi, Diem)
            sql = "UPDATE Diem SET MaLop='" + cboMaLop.SelectedValue.ToString() +
                "',MaMon='" + cboMaMon.SelectedValue.ToString() +
                "'," + cboHocKy.SelectedItem.ToString() +
                "," + cboLanThi.SelectedItem.ToString() +
                "',Diem='" + txtDiem.Text.Trim().ToString() +
                "' WHERE MaSV='" + txtMaSV.Text + "'";
            Database.RunSql(sql);
            LoadDSDiem();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaSV FROM Diem WHERE MaSV=N'" + txtMaSV.Text.Trim() + "'";
            if (Database.CheckKey(sql))
            {
                MessageBox.Show("Mã này đã có, bạn phải nhập mã khác", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                txtMaSV.Text = "";
                return;
            }
            sql = "INSERT INTO Diem (MaSV, MaLop, MaMon, HocKy, LanThi, Diem) " +
                    "VALUES('" + txtMaSV.Text.Trim() +
                    "','" + cboMaLop.SelectedValue.ToString().Trim() +
                    "'," + cboMaMon.SelectedValue.ToString().Trim() +
                    "," + cboHocKy.SelectedItem.ToString().Trim() +
                    "'," + cboLanThi.SelectedItem.ToString().Trim() +
                    ",'" + txtDiem.Text.Trim() + "')";
            Database.RunSql(sql);
            LoadDSDiem();
            ResetValues();
            btnXoa.Enabled = true;

            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaSV.Enabled = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoQua.Enabled = false;
            btnTimKiem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaSV.Enabled = false;
        }

        private void dgvDiem_Click(object sender, EventArgs e)
        {
            string ma;
            if (tblDiem.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            txtMaSV.Text = dgvDiem.CurrentRow.Cells["MaSV"].Value.ToString();
            txtDiem.Text = dgvDiem.CurrentRow.Cells["Diem"].Value.ToString();
            ma = dgvDiem.CurrentRow.Cells["MaLop"].Value.ToString();
            cboMaLop.Text = Database.GetFieldValues("SELECT TenLop FROM Lop WHERE MaLop = N'" + ma + "'");
            cboHocKy.Text = dgvDiem.CurrentRow.Cells["HocKy"].Value.ToString();
            ma = dgvDiem.CurrentRow.Cells["MaMon"].Value.ToString();
            cboMaMon.Text = Database.GetFieldValues("SELECT TenMon FROM Mon WHERE MaMon = N'" + ma + "'");
            cboLanThi.Text = dgvDiem.CurrentRow.Cells["LanThi"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((cboMaLop.Text == "") 
                && (cboHocKy.Text == "")
                && (cboMaMon.Text == "")
                && (cboLanThi.Text == ""))
            {
                MessageBox.Show("Hãy nhập ít nhất một điều kiện tìm kiếm!!!", "Yêu cầu ...",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM Diem WHERE 1=1";
            if (cboMaLop.Text != "")
                sql = sql + " AND MaLop Like N'%" + cboMaLop.SelectedValue + "%'";
            if (cboHocKy.Text != "")
                sql = sql + " AND HocKy Like N'%" + cboHocKy.SelectedItem + "%'";
            if (cboMaMon.Text != "")
                sql = sql + " AND MaMon Like N'%" + cboMaMon.SelectedValue + "%'";
            if (cboLanThi.Text != "")
                sql = sql + " AND LanThi Like N'%" + cboLanThi.SelectedItem + "%'";
            tblDiem = Database.LoadDataToTable(sql);
            if (tblDiem.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblDiem.Rows.Count + " bản ghi thỏa mãn điều kiện!!!",
"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgvDiem.DataSource = tblDiem;
            ResetValues();
        }
        private void btnInDSDiem_Click_1(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblInDSDiem;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Hệ thống quản lý sinh viên";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Nhóm 2";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "BTL môn Cơ Sở Lập Trình 2";


            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "DANH SÁCH ĐIỂM";
            // Biểu diễn thông tin chung danh sách điểm của các sinh viên theo lớp học, môn học, lần thi
            sql = "SELECT a.MaSV, a.TenSV, b.MaLop, b.TenLop, c.MaMon, c.TenMon, d.LanThi " +
                "From Sinh_Vien a, Lop b, Mon c, Diem d " +
                "Where b.MaLop = N'" + cboMaLop.SelectedItem + "' and c.MaMon = N'" + cboMaMon.SelectedItem + "' and d.LanThi = N'" + cboLanThi.SelectedItem + "'";
            tblInDSDiem = Database.LoadDataToTable(sql);
            //exRange.Range["B6:C9"].Font.Size = 12;
            //exRange.Range["B6:C9"].Font.Name = "Times new roman";
            //exRange.Range["B6:B6"].Value = "Ten:";
            //exRange.Range["C6:E6"].MergeCells = true;
            //exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            //exRange.Range["B7:B7"].Value = "Khách hàng:";
            //exRange.Range["C7:E7"].MergeCells = true;
            //exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            //exRange.Range["B8:B8"].Value = "Địa chỉ:";
            //exRange.Range["C8:E8"].MergeCells = true;
            //exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            //exRange.Range["B9:B9"].Value = "Điện thoại:";
            //exRange.Range["C9:E9"].MergeCells = true;
            //exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
            ////Lấy thông tin các mặt hàng
            //sql = "SELECT b.Tenhang, a.Soluong, b.Dongiaban, a.Giamgia, a.Thanhtien " +
            //      "FROM tblChitietHDBan AS a , tblHang AS b WHERE a.MaHDBan = N'" + 
            //      txtMaHDBan.Text + "' AND a.Mahang = b.Mahang";
            //tblThongtinHang = Functions.GetDataToTable(sql);

        }
    }
}
