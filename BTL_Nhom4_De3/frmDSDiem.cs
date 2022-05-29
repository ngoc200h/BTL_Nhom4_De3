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
            sql = "UPDATE Diem SET MaSV=N'" + txtMaSV.Text.Trim().ToString() +
                "',MaLop=N'" + cboMaLop.SelectedValue.ToString() +
                "',MaMon=N'" + cboMaMon.SelectedValue.ToString() +
                "',HocKy=N'" + cboHocKy.SelectedValue.ToString() +
                "',LanThi=N'" + cboLanThi.SelectedValue.ToString() +
                "',Diem=N'" + txtDiem.Text.Trim().ToString() +
                "' WHERE MaSV=N'" + txtMaSV.Text + "'";
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
                    "VALUES(N'" + txtMaSV.Text.Trim() +
                    "',N'" + cboMaLop.SelectedValue.ToString() +
                    "',N'" + cboMaMon.SelectedValue.ToString() +
                    "',N'" + cboHocKy.SelectedValue.ToString() +
                    "',N'" + cboLanThi.SelectedValue.ToString() +
                    "',N'" + txtDiem.Text.Trim() + "')";
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
            ma = dgvDiem.CurrentRow.Cells["HocKy"].Value.ToString();
            cboHocKy.Text = Database.GetFieldValues("SELECT HocKy FROM Diem WHERE MaSV = N'" + ma + "'");
            ma = dgvDiem.CurrentRow.Cells["MaMon"].Value.ToString();
            cboMaMon.Text = Database.GetFieldValues("SELECT TenMon FROM Mon WHERE MaMon = N'" + ma + "'");
            ma = dgvDiem.CurrentRow.Cells["LanThi"].Value.ToString();
            cboLanThi.Text = Database.GetFieldValues("SELECT LanThi FROM Diem WHERE MaSV = N'" + ma + "'");
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
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM Diem WHERE 1=1";
            if (cboMaLop.Text != "")
                sql = sql + " AND MaLop Like N'%" + cboMaLop.SelectedValue + "%'";
            if (cboHocKy.Text != "")
                sql = sql + " AND HocKy Like N'%" + cboHocKy.SelectedValue + "%'";
            if (cboMaMon.Text != "")
                sql = sql + " AND MaMon Like N'%" + cboMaMon.SelectedValue + "%'";
            if (cboLanThi.Text != "")
                sql = sql + " AND LanThi Like N'%" + cboLanThi.SelectedValue + "%'";
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
    }
}
