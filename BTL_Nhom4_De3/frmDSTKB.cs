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
    public partial class frmDSTKB : Form
    {
        DataTable tblTKB;
        public frmDSTKB()
        {
            InitializeComponent();
        }
        private void ResetValues()
        {
            cboMaLop.Text = "";
            cboMaMon.Text = "";
            cboMaMon.Text = "";
            cboHocKy.Text = "";
            cboThuHoc.Text = "";
            cboCaHoc.Text = "";
            cboMaPhong.Text = "";
        }
        private void frmDSTKB_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDSTKB();
            Database.FillDataToCombo("SELECT MaLop, TenLop FROM Lop", cboMaLop,
                                    "MaLop", "TenLop");
            cboMaLop.SelectedIndex = -1;
            Database.FillDataToCombo("SELECT MaMon, TenMon FROM Mon", cboMaMon,
                                    "MaMon", "TenMon");
            cboMaMon.SelectedIndex = -1;
            Database.FillDataToCombo("SELECT MaPhong, TenPhong FROM Phong_Hoc", cboMaPhong,
                                    "MaPhong", "TenPhong");
            cboMaPhong.SelectedIndex = -1;
            //cbo Học Kỳ
            string[] hk = { "1", "2" };
            foreach (string x in hk)
            {
                cboHocKy.Items.Add(x);
            }
            //cbo Thứ học
            string[] th = { "Thu 2", "Thu ba", "Thu tu", "Thu nam", "Thu sau", "Thu bay", "Chu Nhat" };
            foreach (string x in th)
            {
                cboThuHoc.Items.Add(x);
            }
            //cbo Ca học
            string[] ch = { "1", "2", "3", "4" };
            foreach (string x in ch)
            {
                cboCaHoc.Items.Add(x);
            }
            ResetValues();
        }
        private void LoadDSTKB()
        {
            string sql;
            sql = "SELECT * FROM ThoiKhoaBieu";
            tblTKB = Database.LoadDataToTable(sql);
            dgvTKB.DataSource = tblTKB;
            //ThoiKhoaBieu (MaLop, MaMon, HocKy, ThuHoc, CaHoc, MaPhong)
            dgvTKB.Columns["MaLop"].HeaderText = "Mã Lớp";
            dgvTKB.Columns["MaMon"].HeaderText = "Mã Môn";
            dgvTKB.Columns["HocKy"].HeaderText = "Học Kỳ";
            dgvTKB.Columns["ThuHoc"].HeaderText = "Thứ Học";
            dgvTKB.Columns["CaHoc"].HeaderText = "Ca Học";
            dgvTKB.Columns["MaPhong"].HeaderText = "Mã Phòng";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblTKB.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE Diem WHERE MaLop=N'" + cboMaLop.Text + "'";
                Database.RunSqlDel(sql);
                LoadDSTKB();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblTKB.Rows.Count == 0)
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
            if (cboMaMon.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã môn", "Thông báo",
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
            if (cboThuHoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn thứ học", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboThuHoc.Focus();
                return;
            }
            if (cboMaPhong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn mã Phòng", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaPhong.Focus();
                return;
            }
            if (cboCaHoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ca học", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCaHoc.Focus();
                return;
            } //ThoiKhoaBieu (MaLop, MaMon, HocKy, ThuHoc, CaHoc, MaPhong)
            sql = "UPDATE ThoiKhoaBieu SET MaMon='" + cboMaMon.SelectedValue.ToString() +
                "',HocKy ='" + cboHocKy.SelectedValue.ToString() +
                "',ThuHoc ='" + cboThuHoc.SelectedValue.ToString() +
                "',CaHoc ='" + cboCaHoc.SelectedValue.ToString() +
                "',MaPhong='" + cboMaPhong.SelectedValue.ToString() +
                "' WHERE MaLop='" + cboMaLop.SelectedValue + "'";
            Database.RunSql(sql);
            LoadDSTKB();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            //            sql = "SELECT MaLop FROM ThoiKhoaBieu WHERE MaLop=N'" + cboMaLop.SelectedValue.ToString() + "'";
            //            if (Database.CheckKey(sql))
            //            {
            //                MessageBox.Show("Mã này đã có, bạn phải nhập mã khác", "Thông báo",
            //MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                txtMaSV.Focus();
            //                txtMaSV.Text = "";
            //                return;
            //            }

            //MessageBox.Show(cboMaLop.SelectedValue.ToString());
            //MessageBox.Show(cboMaMon.SelectedValue.ToString());
            //MessageBox.Show(cboHocKy.SelectedItem.ToString());
            //MessageBox.Show(cboThuHoc.SelectedItem.ToString());
            //MessageBox.Show(cboCaHoc.SelectedItem.ToString());
            //MessageBox.Show(cboMaPhong.SelectedValue.ToString());

            sql = "INSERT INTO ThoiKhoaBieu(MaLop, MaMon, HocKy, ThuHoc, CaHoc, MaPhong) " +
                    "VALUES('" + cboMaLop.SelectedValue.ToString() +
                    "','" + cboMaMon.SelectedValue.ToString() +
                    "'," + cboHocKy.SelectedItem.ToString() +
                    "," + cboThuHoc.SelectedItem.ToString() +
                    "'," + cboCaHoc.SelectedItem.ToString() +
                    ",'" + cboMaPhong.SelectedValue.ToString() + "')";
            MessageBox.Show("");
            Database.RunSql(sql);
            LoadDSTKB();
            ResetValues();
            btnXoa.Enabled = true;

            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoQua.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void dgvTKB_Click(object sender, EventArgs e)
        {
            string ma;
            if (tblTKB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            cboHocKy.Text = dgvTKB.CurrentRow.Cells["HocKy"].Value.ToString();
            cboThuHoc.Text = dgvTKB.CurrentRow.Cells["ThuHoc"].Value.ToString();
            cboCaHoc.Text = dgvTKB.CurrentRow.Cells["CaHoc"].Value.ToString();
            ma = dgvTKB.CurrentRow.Cells["MaLop"].Value.ToString();
            cboMaLop.Text = Database.GetFieldValues("SELECT TenLop FROM Lop WHERE MaLop = N'" + ma + "'");
            ma = dgvTKB.CurrentRow.Cells["MaMon"].Value.ToString();
            cboMaMon.Text = Database.GetFieldValues("SELECT TenMon FROM Mon WHERE MaMon = N'" + ma + "'");
            ma = dgvTKB.CurrentRow.Cells["MaPhong"].Value.ToString();
            cboMaPhong.Text = Database.GetFieldValues("SELECT MaPhong FROM Phong_Hoc WHERE MaPhong = N'" + ma + "'");
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnInTKB_Click(object sender, EventArgs e)
        {
            {
                if (cboMaLop.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn Lớp!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cboHocKy.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn Học Kỳ!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                COMExcel.Application exApp = new COMExcel.Application();
                COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
                COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
                COMExcel.Range exRange;
                string sql;
                int hang = 0, cot = 0;
                DataTable tblInTKB;
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
                exRange.Range["D1:D1"].Value = "Nhóm 2";

                exRange.Range["F1:H1"].MergeCells = true;
                exRange.Range["F1:H1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["F1:H1"].Value = "BTL môn Cơ Sở Lập Trình 2";


                exRange.Range["C3:E4"].Font.Size = 20;
                exRange.Range["C3:E4"].Font.Name = "Times new roman";
                exRange.Range["C3:E4"].Font.Bold = true;
                exRange.Range["C3:E4"].Font.ColorIndex = 3; //Màu đỏ
                exRange.Range["C3:E4"].MergeCells = true;
                exRange.Range["C3:E4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["C3:E4"].Value = "тнờι ĸнóα вιểυ";
                // Biểu diễn thông tin lớp và học kỳ
                //sql = "select SV.MaSV, SV.TenSV, D.Diem from Sinh_Vien SV inner join Diem D " +
                //    "on SV.MaSV = D.MaSV where D.LanThi = '" + cboLanThi.SelectedItem + "'";
                sql = "	Select L.MaLop, L.TenLop, T.HocKy from Lop L " +
                    "inner join ThoiKhoaBieu T on L.MaLop = T.MaLop " +
                    "Where T.MaLop = '" + cboMaLop.SelectedValue + "' AND T.HocKy = '" + cboHocKy.SelectedValue + "'";
                //sql = "SELECT MaLop from ThoiKhoaBieu where MaLop = '" + cboMaLop.SelectedItem + "'";
                tblInTKB = Database.LoadDataToTable(sql);
                dgvTKB.DataSource = tblInTKB;

                exRange.Range["B6:C9"].Font.Size = 12;
                exRange.Range["B6:C9"].Font.Name = "Times new roman";

                exRange.Range["C5:E5"].MergeCells = true;
                exRange.Range["C5:E5"].Font.Bold = true;
                exRange.Range["C5:E5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["C5:E5"].Value = "Từng lớp theo học kỳ";

                exRange.Range["B7:D7"].MergeCells = true;
                exRange.Range["B7:D7"].Value = "Thời gian tạo: Hà Nội, ngày " + DateTime.Now.ToString() + "'";

                exRange.Range["B8:B8"].Value = "Mã Lớp:"; //+ txtMaSV.Text.Trim() + "'";
                exRange.Range["C8:E8"].MergeCells = true;
                exRange.Range["C8:E8"].Value = tblInTKB.Rows[0][0].ToString();

                exRange.Range["B9:B9"].Value = "Tên Lớp:";
                exRange.Range["C9:E9"].MergeCells = true;
                exRange.Range["C9:E9"].Value = tblInTKB.Rows[0][1].ToString();

                exRange.Range["B10:B10"].Value = "Học Kỳ:";
                exRange.Range["C10:E10"].MergeCells = true;
                exRange.Range["C10:E10"].Value = tblInTKB.Rows[0][2].ToString();

                // Biểu diễn tkb theo lớp và học kỳ 
                sql = "	Select M.MaMon, M.TenMon, T.ThuHoc, T.CaHoc, T.MaPhong from Mon M " +
                    "inner join ThoiKhoaBieu T on L.MaLop = T.MaLop " +
                    "Where T.MaLop = '" + cboMaLop.SelectedValue + "' AND T.HocKy = '" + cboHocKy.SelectedValue + "'";
                tblInTKB = Database.LoadDataToTable(sql);
                //dgvTKB.DataSource = tblInTKB;

                //Tạo dòng tiêu đề bảng
                exRange.Range["A11:F11"].Font.Bold = true;
                exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["C11:E11"].ColumnWidth = 18;
                exRange.Range["A11:A11"].Value = "STT";
                exRange.Range["B11:B11"].Value = "Mã Môn";
                exRange.Range["C11:C11"].Value = "Tên Môn";
                exRange.Range["D11:D11"].Value = "Thứ Học";
                exRange.Range["E11:E11"].Value = "Ca Học";
                exRange.Range["F11:F11"].Value = "Mã Phòng";
                for (hang = 0; hang <= tblInTKB.Rows.Count - 1; hang++)
                {
                    //Điền số thứ tự vào cột 1 từ dòng 12
                    exSheet.Cells[1][hang + 12] = hang + 1;
                    for (cot = 0; cot <= tblInTKB.Columns.Count - 1; cot++)
                        //Điền thông tin hàng từ cột thứ 2, dòng 12
                        exSheet.Cells[cot + 2][hang + 12] = tblInTKB.Rows[hang][cot].ToString();
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


                exSheet.Name = "Thời Khóa Biểu";

                //exApp.Visible = true;
            }
        }
    }
}
