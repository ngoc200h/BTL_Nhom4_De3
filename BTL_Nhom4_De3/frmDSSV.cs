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
    public partial class frmDSSV : Form
    {
        DataTable tblSV;
        //string gt; //giới tính

        public frmDSSV()
        {
            InitializeComponent();
        }

        private void frmDSSV_Load(object sender, EventArgs e)
        {
            txtMaSV.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = true;
            cboMaCN.Enabled = false;
            LoadDSSV();

            Database.FillDataToCombo("SELECT MaKhoa, TenKhoa FROM Khoa", cboMaKhoa, "MaKhoa", "TenKhoa");
            cboMaKhoa.SelectedIndex = -1;
            cboMaKhoa_SelectedIndexChanged(null, null);
            cboMaCN.Enabled = false;
            Database.FillDataToCombo("SELECT MaLop, TenLop FROM Lop", cboMaLop, "MaLop", "TenLop");
            cboMaLop.SelectedIndex = -1;
            Database.FillDataToCombo("SELECT MaQue, TenQue FROM Que", cboMaQue, "MaQue", "TenQue");
            cboMaQue.SelectedIndex = -1;
            Database.FillDataToCombo("SELECT MaDToc, TenDToc FROM DanToc", cboMaDT, "MaDToc", "TenDToc");
            cboMaDT.SelectedIndex = -1;

            Database.FillDataToCombo("SELECT MaCN, TenCN FROM Chuyen_Nganh", cboMaCN, "MaCN", "TenCN");
            cboMaCN.SelectedIndex = -1;
            /*
            if (cboMaCN.Text != "")
            {
                Database.FillDataToCombo("SELECT MaCN, TenCN FROM Chuyen_Nganh", cboMaCN, "MaCN", "TenCN");
                cboMaCN.SelectedIndex = -1;


                string query = "SELECT `MaKhoa`, `TenKhoa` FROM `Khoa`";
                cboMaCN.DataSource = Database.LoadDataToTable(query);
                cboMaCN.DisplayMember = "MaKhoa";
                cboMaCN.ValueMember = "TenKhoa";
                cboMaCN_SelectedIndexChanged(null, null);
            } */
            Database.FillDataToCombo("SELECT MaHeDT, TenHeDT FROM HeDaoTao", cboMaHeDT, "MaHeDT", "TenHeDT");
            cboMaHeDT.SelectedIndex = -1;
            Database.FillDataToCombo("SELECT MaChucVu, TenChucVu FROM ChucVu", cboMaChucVu, "MaChucVu", "TenChucVu");
            cboMaChucVu.SelectedIndex = -1;
            LoadDSSV();//gọi tới hàm load sinh viên khi form đc load
        }
        private void LoadDSSV()
        {
            string sql;
            sql = "SELECT * FROM Sinh_Vien";
            tblSV = Database.LoadDataToTable(sql);
            dgvSinhVien.DataSource = tblSV;


            //cboMaKhoa.DataSource = Database.LoadDataToTable("SELECT MaKhoa, TenKhoa FROM Khoa");
            //cboMaKhoa.ValueMember = "MaKhoa";
            //cboMaKhoa.DisplayMember = "TenKhoa";
            //cboMaCN.Enabled = false;


            //Sinh_Vien (MaSV, TenSV, MaKhoa, MaLop, NgSinh, GTinh, MaQue, MaDToc, MaCN, MaHeDT, MaChucVu)
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
        private void ResetValues()
        {
            txtMaSV.Text = "";
            txtTenSV.Text = "";
            cboMaKhoa.Text = "";
            cboMaLop.Text = "";
            mtbNgaySinh.Text = "";
            //rbtNam.Text = "";
            cboMaQue.Text = "";
            cboMaDT.Text = "";
            cboMaCN.Text = "";
            cboMaHeDT.Text = "";
            cboMaChucVu.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaSV.Focus();
            txtMaSV.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblSV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaSV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE Sinh_Vien WHERE MaSV=N'" + txtMaSV.Text + "'";
                Database.RunSqlDel(sql);
                LoadDSSV();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblSV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            if (txtMaSV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenSV.Text.Trim().Length == 0
                && cboMaKhoa.Text.Trim().Length == 0
                && cboMaLop.Text.Trim().Length == 0
                && mtbNgaySinh.Text.Trim().Length == 0
                && cboMaQue.Text.Trim().Length == 0
                && cboMaDT.Text.Trim().Length == 0
                && cboMaCN.Text.Trim().Length == 0
                && cboMaHeDT.Text.Trim().Length == 0
                && cboMaChucVu.Text.Trim().Length == 0 )
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu", "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            if (!Database.IsDate(mtbNgaySinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbNgaySinh.Text = "";
                mtbNgaySinh.Focus();
                return;
            }
            string gt = dgvSinhVien.CurrentRow.Cells["GTinh"].Value.ToString();
            if (gt.Trim() == "Nam") //trim() cắt khoản trắng 2 đầu
            {
                rbtNam.Checked = true;
            }
            else
            {
                rbtNu.Checked = true;
            }
            sql = "UPDATE Sinh_Vien SET  TenSV=N'" + txtTenSV.Text.Trim().ToString() +
                    "',MaKhoa=N'" + cboMaKhoa.SelectedValue.ToString() +
                    "',MaLop=N'" + cboMaLop.SelectedValue.ToString() +
                    "',NgSinh='" + Database.ConvertDateTime(mtbNgaySinh.Text) +
                    "',GTinh=N'" + gt.Trim() +
                    "',MaQue=N'" + cboMaQue.SelectedValue.ToString() +
                    "',MaDToc=N'" + cboMaDT.SelectedValue.ToString() +
                    "',MaCN=N'" + cboMaCN.SelectedValue.ToString() +
                    "',MaHeDT=N'" + cboMaHeDT.SelectedValue.ToString() +
                    "',MaChucVu=N'" + cboMaChucVu.SelectedValue.ToString() +
                    "' WHERE MaSV=N'" + txtMaSV.Text + "'";
            Database.RunSql(sql);
            LoadDSSV();
            ResetValues();
            btnBoQua.Enabled = false;
            txtMaSV.Enabled = false;
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
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaSV.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            string gt = dgvSinhVien.CurrentRow.Cells["GTinh"].Value.ToString();
            sql = "SELECT MaSV FROM Sinh_Vien WHERE MaSV=N'" + txtMaSV.Text.Trim() + "'";
            if (gt.Trim() == "Nam") //trim() cắt khoản trắng 2 đầu
            {
                rbtNam.Checked = true;
            }
            else
            {
                rbtNu.Checked = true;
            }
            if (Database.CheckKey(sql))
            {
                MessageBox.Show("Mã SV này đã có, bạn phải nhập mã khác", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                txtMaSV.Text = "";
                return;
            }
            sql = "INSERT INTO Sinh_Vien (MaSV, TenSV, MaKhoa, MaLop, NgSinh, GTinh, MaQue, MaDToc, MaCN, MaHeDT, MaChucVu) " +
                    "VALUES(N'" + txtMaSV.Text.Trim() +
                    "',N'" + txtTenSV.Text.Trim() + 
                    "',N'" + cboMaKhoa.SelectedValue.ToString() + 
                    "',N'" + cboMaLop.SelectedValue.ToString() +
                    "','" + Database.ConvertDateTime(mtbNgaySinh.Text) +
                    "',N'" + gt.Trim() +
                    "',N'" + cboMaQue.SelectedValue.ToString() +
                    "',N'" + cboMaDT.SelectedValue.ToString() +
                    "',N'" + cboMaCN.SelectedValue.ToString() +
                    "',N'" + cboMaHeDT.SelectedValue.ToString() +
                    "',N'" + cboMaChucVu.SelectedValue.ToString() + "')";
            Database.RunSql(sql);
            LoadDSSV();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void dgvSinhVien_Click(object sender, EventArgs e)
        {
            string ma;
            //Giới tính
            string gt = dgvSinhVien.CurrentRow.Cells["GTinh"].Value.ToString();
            if (gt.Trim() == "Nam") //trim() cắt khoản trắng 2 đầu
            {
                rbtNam.Checked = true;
            }
            else
            {
                rbtNu.Checked = true;
            }
            if (tblSV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            } //Sinh_Vien (MaSV, TenSV, MaKhoa, MaLop, NgSinh, GTinh, MaQue, MaDToc, MaCN, MaHeDT, MaChucVu)
            txtMaSV.Text = dgvSinhVien.CurrentRow.Cells["MaSV"].Value.ToString();
            txtTenSV.Text = dgvSinhVien.CurrentRow.Cells["TenSV"].Value.ToString();
            ma = dgvSinhVien.CurrentRow.Cells["MaKhoa"].Value.ToString();
            cboMaKhoa.Text = Database.GetFieldValues("SELECT TenKhoa FROM Khoa WHERE MaKhoa = N'" + ma + "'");
            ma = dgvSinhVien.CurrentRow.Cells["MaLop"].Value.ToString();
            cboMaLop.Text = Database.GetFieldValues("SELECT TenLop FROM Lop WHERE MaLop = N'" + ma + "'");
            mtbNgaySinh.Text = dgvSinhVien.CurrentRow.Cells["NgSinh"].Value.ToString();
            ma = dgvSinhVien.CurrentRow.Cells["MaQue"].Value.ToString();
            cboMaQue.Text = Database.GetFieldValues("SELECT TenQue FROM Que WHERE MaQue = N'" + ma + "'");
            ma = dgvSinhVien.CurrentRow.Cells["MaDToc"].Value.ToString();
            cboMaDT.Text = Database.GetFieldValues("SELECT TenDToc FROM DanToc WHERE MaDToc = N'" + ma + "'");
            ma = dgvSinhVien.CurrentRow.Cells["MaCN"].Value.ToString();
            cboMaCN.Text = Database.GetFieldValues("SELECT TenCN FROM Chuyen_Nganh WHERE MaCN = N'" + ma + "'");
            ma = dgvSinhVien.CurrentRow.Cells["MaHeDT"].Value.ToString();
            cboMaHeDT.Text = Database.GetFieldValues("SELECT TenHeDT FROM HeDaoTao WHERE MaHeDT = N'" + ma + "'");
            ma = dgvSinhVien.CurrentRow.Cells["MaChucVu"].Value.ToString();
            cboMaChucVu.Text = Database.GetFieldValues("SELECT TenChucVu FROM ChucVu WHERE MaChucVu = N'" + ma + "'");
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
            txtMaSV.Enabled = true;
        }

        private void cboMaKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {          
            //Database.FillDataToCombo("SELECT MaKhoa, TenKhoa FROM Khoa", cboMaKhoa, "MaKhoa", "TenKhoa");
            //cboMaKhoa.SelectedIndex = -1;
            //Database.FillDataToCombo("select MaCN, TenCN from Chuyen_Nganh", cboMaCN, "MaCN", "TenCN");
            //cboMaCN.SelectedIndex = -1;

            /*cboMaCN.SelectedValue.ToString();*/
            //Database.FillDataToCombo("select MaCN, TenCN FROM Chuyen_Nganh WHERE MaKhoa = " + cboMaCN.SelectedValue.ToString(), cboMaCN, "MaCN", "TenCN");
            //cboMaCN.SelectedIndex = -1;
            //Database.FillDataToCombo("select MaCN, TenCN from Chuyen_Nganh a join Khoa b on a.MaKhoa=b.MaKhoa where a.MaKhoa=b.MaKhoa", cboMaCN, "MaCN", "TenCN");

            //string ma= cboMaCN.SelectedValue.ToString();
            /*ma = dgvSinhVien.CurrentRow.Cells["MaCN"].Value.ToString();*/
            //Database.FillDataToCombo("select MaCN, TenCN from Chuyen_Nganh WHERE MaKhoa = " + ma, cboMaCN, "MaCN", "TenCN");
            //cboMaCN.SelectedIndex = -1;
            //cboMaCN.SelectedItem = cboMaKhoa.SelectedValue.ToString();

            //int val;
            //Int32.TryParse(cboMaKhoa.SelectedValue.ToString(), out val);
            //string sql = "SELECT MaCN, TenCN, MaKhoa FROM Chuyen_Nganh WHERE MaKhoa = " + val;

            //string ma;
            //ma = dgvSinhVien.CurrentRow.Cells["MaCN"].Value.ToString();
            //cboMaCN.Text = Database.GetFieldValues("SELECT TenCN FROM Chuyen_Nganh WHERE MaCN = N'" + ma + "'");
            //ma = dgvSinhVien.CurrentRow.Cells["MaKhoa"].Value.ToString();
            //cboMaKhoa.Text = Database.GetFieldValues("SELECT TenKhoa FROM Khoa WHERE MaKhoa = N'" + ma + "'");
            //dgvSinhVien_Click(null, null);

            //Database.RunSql(sql);
            //LoadDSSV();
            //ResetValues();
            //dataGridView_Products.DataSource = getData(query); */
        }

        private void cboMaCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int val;
            //Int32.TryParse(cboMaCN.SelectedValue.ToString(), out val);
            //string query = "SELECT `ID_PRO`, `PRO_NAME`, `QTE_IN_STOCK`, `PRICE`, `ID_CAT` FROM `products` WHERE `ID_CAT` = " + val;
            //dataGridView_Products.DataSource = getData(query);
            //int val;
            //Int32.TryParse(cboMaKhoa.SelectedValue.ToString(), out val);
            //string sql = "SELECT MaCN, TenCN, MaKhoa FROM Chuyen_Nganh WHERE MaKhoa = " + val;
        }
    }
}

