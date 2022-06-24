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
            /*cboMaLop.SelectedIndex = -1;
            Database.FillDataToCombo("SELECT MaMon, TenMon FROM Mon", cboMaMon,
                                    "MaMon", "TenMon");
            cboMaMon.SelectedIndex = -1;*/


            //cbo Học Kỳ
            /*Database.FillDataToCombo("SELECT HocKy FROM ThoiKhoaBieu", cboHocKy,
                                    "MaLop", "TenLop");*/
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
        private void btnInDSDiem_Click_1(object sender, EventArgs e) //CÂU 7!!
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
            exRange.Range["A1:H1"].Font.Size = 10;
            exRange.Range["A1:H1"].Font.Name = "Times new roman";
            exRange.Range["A1:H1"].Font.Bold = true;
            exRange.Range["A1:H1"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Hệ thống quản lý sinh viên";

            exRange.Range["D1:D1"].MergeCells = true;
            exRange.Range["D1:D1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D1:D1"].Value = "Nhóm 4";

            exRange.Range["F1:H1"].MergeCells = true;
            exRange.Range["F1:H1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["F1:H1"].Value = "BTL môn Cơ Sở Lập Trình 2";


            exRange.Range["C3:E4"].Font.Size = 20;
            exRange.Range["C3:E4"].Font.Name = "Times new roman";
            exRange.Range["C3:E4"].Font.Bold = true;
            exRange.Range["C3:E4"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C3:E4"].MergeCells = true;
            exRange.Range["C3:E4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C3:E4"].Value = "DANH SÁCH ĐIỂM";
            // Biểu diễn thông tin chung danh sách điểm của các sinh viên theo lớp học, môn học, lần thi
            string sql2 = "SELECT a.MaSV, a.TenSV, b.MaLop, b.TenLop, c.MaMon, c.TenMon, d.LanThi " +
                "From Sinh_Vien a, Lop b, Mon c, Diem d " +
                "Where b.MaLop = '" + cboMaLop.SelectedItem + "' and c.MaMon = '" + cboMaMon.SelectedItem + "' and d.LanThi = '" + cboLanThi.SelectedItem + "'";

            //sql = "select SV.MaSV, SV.TenSV, D.Diem from Sinh_Vien SV inner join Diem D " +
            //    "on SV.MaSV = D.MaSV where D.LanThi = '" + cboLanThi.SelectedItem + "'";
            sql = "	Select SV.MaSV,SV.TenSV, L.TenLop, M.TenMon, D.HocKy, D.Diem, D.LanThi from Sinh_Vien SV  " +
            "inner join Lop L On SV.MaLop = L.MaLop " +
            "inner join Diem D On SV.MaSV = D.MaSV " +
            "inner join Mon M on D.MaMon = M.MaMon  ";
            tblInDSDiem = Database.LoadDataToTable(sql);
            dgvDiem.DataSource = tblInDSDiem;

            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";

            exRange.Range["B5:F5"].MergeCells = true;
            exRange.Range["B5:F5"].Font.Bold = true;
            exRange.Range["B5:F5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B5:F5"].Value = "Dựa trên lớp học, môn học, lần thi của các sinh viên";

            exRange.Range["B7:D7"].MergeCells = true;
            exRange.Range["B7:D7"].Value = "Thời gian tạo: Hà Nội, ngày " + DateTime.Now.ToString() + "'";

            exRange.Range["B8:B8"].Value = "Giáo viên phụ trách:";
            exRange.Range["B8:B8"].MergeCells = true;

            exRange.Range["B9:B9"].Value = "Được kiểm duyệt bởi:";
            exRange.Range["B9:B9"].MergeCells = true;

            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:E11"].ColumnWidth = 18;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "MSV";
            exRange.Range["C11:C11"].Value = "Họ Tên";
            exRange.Range["D11:D11"].Value = "Lớp Học";
            exRange.Range["E11:E11"].Value = "Môn Học";
            exRange.Range["F11:F11"].Value = "Học Kỳ";
            exRange.Range["G11:G11"].Value = "Điểm";
            exRange.Range["H11:H11"].Value = "Lần Thi";
            for (hang = 0; hang <= tblInDSDiem.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblInDSDiem.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblInDSDiem.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Quản Lý Hệ Thống";
            exRange = exSheet.Cells[cot + 1][hang + 15];
            exRange.Font.Bold = true;
            exRange.Font.Size = 20;
            exRange.Value2 = "𝕆𝕂";

            //exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            //exRange.Range["A1:F1"].MergeCells = true;
            //exRange.Range["A1:F1"].Font.Bold = true;
            //exRange.Range["A1:F1"].Font.Italic = true;
            //exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;

            //exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            //exRange.Range["A1:C1"].MergeCells = true;
            //exRange.Range["A1:C1"].Font.Italic = true;
            //exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;

            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblInDSDiem.Rows[0][6];
            exSheet.Name = "Danh Sách Điểm";

            exApp.Visible = true;
        }

        private void btnInBangDiem_Click(object sender, EventArgs e) //CÂU 8!!
        {
            if (txtMaSV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn Mã Sinh Viên!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblInBangDiem;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:H1"].Font.Size = 10;
            exRange.Range["A1:H1"].Font.Name = "Times new roman";
            exRange.Range["A1:H1"].Font.Bold = true;
            exRange.Range["A1:H1"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Hệ thống quản lý sinh viên";

            exRange.Range["D1:D1"].MergeCells = true;
            exRange.Range["D1:D1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D1:D1"].Value = "Nhóm 4";

            exRange.Range["F1:H1"].MergeCells = true;
            exRange.Range["F1:H1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["F1:H1"].Value = "BTL môn Cơ Sở Lập Trình 2";


            exRange.Range["C3:E4"].Font.Size = 20;
            exRange.Range["C3:E4"].Font.Name = "Times new roman";
            exRange.Range["C3:E4"].Font.Bold = true;
            exRange.Range["C3:E4"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C3:E4"].MergeCells = true;
            exRange.Range["C3:E4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C3:E4"].Value = "BẢNG ĐIỂM";
            // Biểu diễn thông tin danh sách điểm các môn theo mã sinh viên 
            string sql2 = "SELECT a.MaSV, a.TenSV, b.MaLop, b.TenLop, c.MaMon, c.TenMon, d.LanThi " +
                "From Sinh_Vien a, Lop b, Mon c, Diem d " +
                "Where b.MaLop = '" + cboMaLop.SelectedItem + "' and c.MaMon = '" + cboMaMon.SelectedItem + "' and d.LanThi = '" + cboLanThi.SelectedItem + "'";

            //sql = "select SV.MaSV, SV.TenSV, D.Diem from Sinh_Vien SV inner join Diem D " +
            //    "on SV.MaSV = D.MaSV where D.LanThi = '" + cboLanThi.SelectedItem + "'";
            sql = "	Select MaSV, TenSV from Sinh_Vien SV  " +
            "Where MaSV = '" + txtMaSV.Text.Trim() +"'";
            tblInBangDiem = Database.LoadDataToTable(sql);

            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";

            exRange.Range["C5:E5"].MergeCells = true;
            exRange.Range["C5:E5"].Font.Bold = true;
            exRange.Range["C5:E5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C5:E5"].Value = "Từng môn học theo mã sinh viên";

            exRange.Range["B7:D7"].MergeCells = true;
            exRange.Range["B7:D7"].Value = "Thời gian tạo: Hà Nội, ngày " + DateTime.Now.ToString() + "'";

            exRange.Range["B8:B8"].Value = "Mã Sinh Viên:"; //+ txtMaSV.Text.Trim() + "'";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblInBangDiem.Rows[0][0].ToString();

            exRange.Range["B9:B9"].Value = "Họ Tên:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblInBangDiem.Rows[0][1].ToString();

            // Biểu diễn thông tin danh sách điểm các môn theo mã sinh viên 
            sql = "	Select M.TenMon, D.HocKy, D.Diem, D.LanThi from Diem D  " +
            "inner join Mon M on D.MaMon = M.MaMon  " +
            "Where D.MaSV = '" + txtMaSV.Text.Trim() + "'";
            tblInBangDiem = Database.LoadDataToTable(sql);
            dgvDiem.DataSource = tblInBangDiem;

            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:E11"].ColumnWidth = 18;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Môn Học";
            exRange.Range["C11:C11"].Value = "Học Kỳ";
            exRange.Range["D11:D11"].Value = "Điểm";
            exRange.Range["E11:E11"].Value = "Lần Thi";
            for (hang = 0; hang <= tblInBangDiem.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblInBangDiem.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblInBangDiem.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Quản Lý Hệ Thống";
            exRange = exSheet.Cells[cot + 1][hang + 15];
            exRange.Font.Bold = true;
            exRange.Font.Size = 20;
            exRange.Value2 = "𝕆𝕂";

            //exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            //exRange.Range["A1:F1"].MergeCells = true;
            //exRange.Range["A1:F1"].Font.Bold = true;
            //exRange.Range["A1:F1"].Font.Italic = true;
            //exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;

            //exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            //exRange.Range["A1:C1"].MergeCells = true;
            //exRange.Range["A1:C1"].Font.Italic = true;
            //exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;


            exSheet.Name = "Bảng Điểm";

            exApp.Visible = true;
        }

        int cboMaLopVal;
        private void cboMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Int32.TryParse(cboMaLop.SelectedValue.ToString(), out cboMaLopVal);
            string CboMonTheoLop = "SELECT Mon.MaMon, Mon.TenMon FROM Mon, ThoiKhoaBieu " +
            "where ThoiKhoaBieu.MaLop = " + cboMaLopVal + "and ThoiKhoaBieu.MaMon = Mon.MaMon";
            /*Database.FillDataToCombo(CboMonTheoLop, cboMaMon, "MaMon", "Mon.TenMon");*/
        }

        private void cboHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboMaMon.Items.Clear();
            string CboMonTheoLopTheoHK = "SELECT Mon.MaMon, Mon.TenMon FROM Mon, ThoiKhoaBieu where ThoiKhoaBieu.MaLop = " + cboMaLopVal + "and ThoiKhoaBieu.HocKy = '" + cboHocKy.Text + "'and ThoiKhoaBieu.MaMon = Mon.MaMon";
            /*Database.FillDataToCombo(CboMonTheoLopTheoHK, cboMaMon, "MaMon", "TenMon");*/
            Database.GetFieldValuesToCombo(cboMaMon, CboMonTheoLopTheoHK);
        }
    }
}
