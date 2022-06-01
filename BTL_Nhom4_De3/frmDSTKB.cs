using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            string[] th = { "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy", "Chủ Nhật" };
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
            sql = "UPDATE ThoiKhoaBieu SET MaMon=N'" + cboMaMon.SelectedValue.ToString() +
                "',HocKy=N'" + cboHocKy.SelectedValue.ToString() +
                "',ThuHoc=N'" + cboThuHoc.SelectedValue.ToString() +
                "',CaHoc=N'" + cboCaHoc.SelectedValue.ToString() +
                "',MaPhong=N'" + cboMaPhong.SelectedValue.ToString() +
                "' WHERE MaLop=N'" + cboMaLop.SelectedValue + "'";
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

            sql = "INSERT INTO ThoiKhoaBieu(MaLop, MaMon, HocKy, ThuHoc, CaHoc, MaPhong) " +
                    "VALUES(N'" + cboMaLop.SelectedValue.ToString() +
                    "',N'" + cboMaMon.SelectedValue.ToString() +
                    "',N'" + cboHocKy.SelectedValue.ToString() +
                    "',N'" + cboThuHoc.SelectedValue.ToString() +
                    "',N'" + cboCaHoc.SelectedValue.ToString() +
                    "',N'" + cboMaPhong.SelectedValue.ToString() + "')";
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
    }
}
