﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace BTL_Nhom4_De3
{
    public partial class frmSinhVien : Form
    {
        public frmSinhVien(string msv)
        {
            this.msv = msv;
            InitializeComponent();
        }
        private string msv;
        private SqlConnection conn;
        private string sql;
        private DataTable dt;
        private SqlCommand cmd;

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(msv))
            {
                this.Text = "Thêm mới sinh viên";
            }
            else
            {
                this.Text = "Cập nhật thông tin sinh viên";
                //var r = new Database().Select("selectSV '" + msv + "'");

                //txtTenSV.Text = r["TenSV"].ToString();
                //mtbNgaySinh.Text = r["NgSinh"].ToString();
                //if (int.Parse(r["GTinh"].ToString()) == 1)
                //{
                //    rbtNam.Checked = true;
                //}
                //else
                //{
                //    rbtNu.Checked = true;
                //}

            }
            //txtTenSV.Enabled = false;
            //btnLuu.Enabled = false;
            //btnHuy.Enabled = false;
            //Load_DataGridView();
            //Functions.FillCombo("Select MaKhoa from Khoa", cbKhoa, "MaKhoa", "TenKhoa");   

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void cbKhoa_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string cmd = "SELECT MaKhoa FROM Khoa";
            SqlDataAdapter adap = new SqlDataAdapter(cmd, conn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            cbKhoa.SelectedIndex = -1;
        }

//        private void btnLuu_Click(object sender, EventArgs e)
//        {
//            string sql;
//            if (txtTenSV.Text.Trim().Length == 0)
//            {
//                MessageBox.Show("Bạn phải nhập tên sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                txtTenSV.Focus();
//                return;
//            }
//            if (mtbNgaySinh.Text.Trim().Length == 0)
//            {
//                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo",
//MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                mtbNgaySinh.Focus();
//                return;
//            }

//            sql = "INSERT INTO SinhVien(TenSV,Tenchatlieu) VALUES(N'" + txtTenSV.Text + "',N'" + mtbNgaySinh.Text + "')";
//            Functions.RunSql(sql);
//            btnLuu.Enabled = false;
//            txtTenSV.Enabled = false;

//        }


        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            //button btnLuu sẽ xử lý 1 trong 2 tình huống
            //trường hợp 1: nếu mã sinh viên không có giá trị -> thêm mới sinh viên
            //trường hợp 2: nếu mã sinh viên có giá trị -> cập nhật thông tin sinh viên

            /*ý tưởng
                -- cho dù thêm mới hay cập nhật
                -- thì đều cần các giá trị như: họ, tên đệm, tên, ngày sinh, giới tính
                    quê quán, địa chỉ, điện thoại, email => các giá trị này dùng cho cả 2 trường hợp
                -- riêng cập nhật sinh viên, cần quan tâm tới mã sinh viên        
            */

            string sql = "";
            string ten = txtTenSV.Text;
            DateTime ngaysinh;
            try
            {
                ngaysinh = DateTime.ParseExact(mtbNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                MessageBox.Show("Ngày sinh không hợp lệ");
                mtbNgaySinh.Select();//trỏ chuột về mtbNgaysinh
                return;//không thực hiện các câu lệnh phía dưới
            }
            //vì ngày sinh ở masketbox, chúng ta set theo dạng dd/mm/yyy
            //nhưng trong csdl lại lưu dưới dạng yyyy-mm-dd
            //=> chúng ta cần chuyển từ dd/mm/yyyy sang yyyy-mm-dd


            string gioitinh = rbtNam.Checked ? "1" : "0";//đây là toán tử 2 ngôi
            //nếu radiobutton Nam đc check thì chọn giá trị 1
            //ngược lại chọn giá trị 0 -> phù hợp với giá trị đã được lưu ở csdl

            //khai báo một danh sách tham sô = class CustomParameter -> đã được khai báo ở part 3
            List<CustomParameter> lstPara = new List<CustomParameter>();
            if (string.IsNullOrEmpty(msv))//nếu thêm mới sinh viên
            {
                sql = "ThemMoiSV";//gọi tới procedure thêm mới sinh viên

            }
            else//nếu cập nhật sinh viên
            {
                sql = "updateSV";//gọi tới procedure cập nhật sinh viên
                lstPara.Add(new CustomParameter()
                {
                    key = "@masinhvien",
                    value = msv
                });
            }

            lstPara.Add(new CustomParameter()
            {
                key = "@TenSV",
                value = ten
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@NgSinh",
                value = ngaysinh.ToString("yyyy-MM-dd")
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@GTinh",
                value = gioitinh
            });

            var rs = new Database().ExeCute(sql, lstPara);//truyền 2 tham số là câu lệnh sql
            //và danh sách các tham số
            if (rs == 1)//nếu thuwcjt hi thành công
            {
                if (string.IsNullOrEmpty(msv))//nếu thêm mới
                {
                    MessageBox.Show("Thêm mới sinh viên thành công");
                }
                else//nếu cập nhật
                {
                    MessageBox.Show("Cập nhật thông tin sinh viên thành công");
                }
                this.Dispose();//đóng form sau khi thêm mới/cập nhật thành công
            }
            else//nếu không thành công
            {
                MessageBox.Show("Thực thi thất bại");
            }
        }


        //private void cbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //cbKhoa.ValueMember = "MaKhoa";
        //    //string sql = "select * from Khoa";
        //    //cbKhoa.DataSource = Database.Database(sql);
        //    var cmd = new SqlCommand("select MaKhoa from Khoa", conn);
        //    var dr = cmd.ExecuteReader();
        //    var dt = new DataTable();
        //    dt.Load(dr);
        //    dr.Dispose();
        //    cbKhoa.DisplayMember = "MaKhoa";
        //    cbKhoa.DataSource = dt;
        //}

        //private void cbKhoa_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    var cmd = new SqlCommand("select MaKhoa from Khoa", conn);
        //    var dr = cmd.ExecuteReader();
        //    var dt = new DataTable();
        //    dt.Load(dr);
        //    dr.Dispose();
        //    cbKhoa.DisplayMember = "MaKhoa";
        //    cbKhoa.DataSource = dt;
        //}
    }
}

