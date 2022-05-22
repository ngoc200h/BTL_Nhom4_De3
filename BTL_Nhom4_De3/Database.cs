using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_Nhom4_De3
{
    public class Database
    {
        private SqlConnection conn;
        private string sql;
        private DataTable dt;
        private SqlCommand cmd;

        public SqlConnection TaoKetNoi()
        {
            return new SqlConnection("Data Source=NGOC9YO\\SQLEXPRESS;" +
                                    "Initial Catalog=QuanLySinhVien;" +
                                    "Integrated Security=True");
        }
        public DataTable TaoBang(string sql) //LoadDataTable
        {
            SqlConnection con = TaoKetNoi();
            SqlDataAdapter Myadapter = new SqlDataAdapter(sql, con);    // Khai báo
            DataTable table = new DataTable();    // Khai báo DataTable nhận dữ liệu trả về
            Myadapter.Fill(table);     //Thực hiện câu lệnh SELECT và đổ dữ liệu vào bảng table
            return table;
        }

        //public static bool CheckKey(string sql)
        //{
        //    SqlConnection con = TaoKetNoi();
        //    SqlCommand myCommand = new SqlCommand(sql, con);
        //    SqlDataReader myReader = myCommand.ExecuteReader();
        //    if (myReader.HasRows)
        //        return true;
        //    else
        //        return false;
        //}

        public void ExcuteNonQuery(string sql)
        {
            SqlConnection con = TaoKetNoi();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
        }

        //dưới ko cần lắm
        public DataTable Khoa()
        {
            string cmd = "select * from Khoa";
            SqlDataAdapter adap = new SqlDataAdapter(cmd, conn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }
        public DataTable SinhVien()
        {
            string cmd = "select * from Sinh_Vien";
            SqlDataAdapter adap = new SqlDataAdapter(cmd, conn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }
        public DataTable Lop()
        {
            string cmd = "select * from Lop";
            SqlDataAdapter adap = new SqlDataAdapter(cmd, conn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }
        public DataTable Mon()
        {
            string cmd = "select * from Mon";
            SqlDataAdapter adap = new SqlDataAdapter(cmd, conn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }
        public DataTable ChucVu()
        {
            string cmd = "select * from ChucVu";
            SqlDataAdapter adap = new SqlDataAdapter(cmd, conn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }
        public DataTable Diem()
        {
            string cmd = "select * from Diem";
            SqlDataAdapter adap = new SqlDataAdapter(cmd, conn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }
        public DataTable DanToc()
        {
            string cmd = "select * from DanToc";
            SqlDataAdapter adap = new SqlDataAdapter(cmd, conn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }
        public DataTable ThoiKhoaBieu()
        {
            string cmd = "select * from ThoiKhoaBieu";
            SqlDataAdapter adap = new SqlDataAdapter(cmd, conn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }
        public DataTable Chuyen_Nganh()
        {
            string cmd = "select * from Chuyen_Nganh";
            SqlDataAdapter adap = new SqlDataAdapter(cmd, conn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }
        public DataTable HeDaoTao()
        {
            string cmd = "select * from HeDaoTao";
            SqlDataAdapter adap = new SqlDataAdapter(cmd, conn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }
        public DataTable Que()
        {
            string cmd = "select * from Que";
            SqlDataAdapter adap = new SqlDataAdapter(cmd, conn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }
        public DataTable Phong_Hoc()
        {
            string cmd = "select * from Phong_Hoc";
            SqlDataAdapter adap = new SqlDataAdapter(cmd, conn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }
    }
}
