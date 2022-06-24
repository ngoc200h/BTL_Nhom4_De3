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
    public partial class frmHDSD : Form
    {
        public frmHDSD()
        {
            InitializeComponent();
        }

        private void frmHDSD_Load(object sender, EventArgs e)
        {
            txtChung.Multiline = true;

            txtChung.ReadOnly = true;
            txtSV.Multiline = true;

            txtSV.ReadOnly = true;
            txtQA.Multiline = true;

            txtQA.ReadOnly = true;

            string[] c = { "Người dùng","Thời Khóa Biểu", "Các Form còn lại" };
            foreach (string x in c)
            {
                cboChung.Items.Add(x);
            }

            string[] sv = { "Sinh Viên", "Điểm", "Các Form còn lại" };
            foreach (string x in sv)
            {
                cboSV.Items.Add(x);
            }
            string[] qa = { "Thành Viên?", "Thời gian làm?", "Kết Quả đạt được?", "Cảm xúc?" };
            foreach (string x in qa)
            {
                cboQA.Items.Add(x);
            }

            if (cboChung.Text == "Thông tin Chung")
            {
                txtChung.Text = "Vui lòng chọn dữ kiện mục bên để tìm hiểu cách sử dụng ❤";
            }
            if (cboSV.Text == "Thông tin Sinh Viên")
            {
                txtSV.Text = "Vui lòng chọn dữ kiện mục bên để tìm hiểu cách sử dụng ❤";
            }
            if (cboQA.Text == "Q&A")
            {
                txtQA.Text = "Vui lòng chọn dữ kiện mục bên để tìm hiểu thêm về chúng mình ❤";
            }
        }

        private void cboChung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChung.Text == "Thời Khóa Biểu")
            {
                txtChung.Text = "In TKB: \r\n" +
                    "●Chọn mã lớp và học kỳ ở các combobox \r\n" +
                    "●Kích chọn 'In TKB'\r\n" +
                    "●Tự động Load TKB gồm môn học, ca học, mã phòng, thứ học dựa trên mã lớp và học kỳ đã chọn.";
            }
            if (cboChung.Text == "Người dùng")
            {
                txtChung.Text = "User: xx\r\n" +
                    "Pass: xx\r\n" +
                    "Quyền: xx\r\n" +
                    "┏(-_-)┛┗(-_-﻿ )┓┗(-_-)┛┏(-_-)┓\r\n" +
                    "User: ii\r\n" +
                    "Pass: ii\r\n" +
                    "Quyền: ii";
            }
            if (cboChung.Text == "Các Form còn lại")
            {
                txtChung.Text = "Không có gì ở đây cả";
            }
        }

        private void cboSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSV.Text == "Sinh Viên")
            {
                txtSV.Text = "Tìm Kiếm:\r\n" +
                    "●Chọn mã quê, mã khoa và mã chuyên ngành ở các combobox\r\n" +
                    "●Kích chọn 'Tìm Kiếm'\r\n" +
                    "●Form sẽ thông báo tìm được x bản ghi hoặc không bản ghi nào\r\n" +
                    "●Bản ghi tìm được sẽ được load trong Datagridview";
            }
            if (cboSV.Text == "Các Form còn lại")
            {
                txtSV.Text = "Không có gì ở đây cả";
            }
            if (cboSV.Text == "Điểm")
            {
                txtSV.Text = "In DS Điểm:\r\n" +
                    "●Khi kích chọn sẽ tự động load danh sách điểm của các sinh viên sắp xếp theo lớp, môn và lần thi\r\n" +
                    "●Tự động in ra file Excel\r\n" +
                    "┏(-_-)┛┗(-_-﻿ )┓┗(-_-)┛┏(-_-)┓\r\n" +
                    "In Bảng điểm theo MSV:\r\n" +
                    "●Chọn mã sinh viên bằng cách nhấp chọn 1 dòng trong datagridview, hoặc tự điền theo cú pháp sẵn\r\n" +
                    "●Khi kích chọn sẽ tự động load bảng điểm của sinh viên đó\r\n" +
                    "●Tự động in ra file Excel.";
            }
        }

        private void cboQA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboQA.Text == "Thời gian làm?")
            {
                txtQA.Text = "1m+, 2 tuần đầu code rất chill, 2 tuần cuối code đến sáng vẫn lỗi.";
            }
            if (cboQA.Text == "Kết Quả đạt được?")
            {
                txtQA.Text = "Đăng nhập, Đa dạng các button, In báo cáo, Kinh nghiệm chạy DL cực gắt cực hiệu quả";
            }
            if (cboQA.Text == "Cảm xúc?")
            {
                txtQA.Text = "Vui";
            }
            if (cboQA.Text == "Thành Viên?")
            {
                txtQA.Text = "♡Nhóm 4 môn CSLT2 J02-HTA HVNH♡ \r\n" +
                    "Bùi Hải Ngọc (C)\r\n" +
                    "Nguyễn Cảnh Toàn\r\n" +
                    "Trịnh Minh Hải";
            }
        }
    }
}
