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
        private string ConnectionString = "Data Source = NGOC9YO\\SQLEXPRESS;" +
                                        "Initial Catalog = QuanLySinhVien;" +
                                        "Integrated Security = True";

        //internal object SelectData()
        //{
        //    throw new NotImplementedException();
        //}

        //Kết nối

        private SqlConnection conn;
        private string sql;
        private DataTable dt;
        private SqlCommand cmd;
        public Database()
        {
            try
            {
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                //MessageBox.Show("Kết nối thành công! :D");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại :(" + ex.Message);
            }
        }
        public DataTable SelectData(string sql, List<CustomParameter> lstPara)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn);//nội dung sql đc truyền vào
                cmd.CommandType = CommandType.StoredProcedure;//set command type cho cmd
                foreach (var para in lstPara)//gán các tham số cho cmd
                {
                    cmd.Parameters.AddWithValue(para.key, para.value);
                }
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

            public DataRow Select(string sql)
            {
                try
                {
                    conn.Open();//mở kết nối
                    cmd = new SqlCommand(sql, conn);//truyền giá trị vào cmd
                    dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());//thực thi câu lệnh
                    return dt.Rows[0];//trả về kết quả
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi load thông tin chi tiết: " + ex.Message);
                    return null;
                }
                finally
                {
                    conn.Close();//cuối cùng đóng kết nối
                }
            }

            public int ExeCute(string sql, List<CustomParameter> lstPara)
            {
                try
                {
                    conn.Open();//mở kết nối
                    cmd = new SqlCommand(sql, conn);//thực thi câu lệnh sql
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var p in lstPara)//gán các tham số cho cmd
                    {
                        cmd.Parameters.AddWithValue(p.key, p.value);
                    }
                    var rs = cmd.ExecuteNonQuery();//lấy kết quả thực thi truy vấn
                    return (int)rs;//trả về kết quả
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thực thi câu lệnh: " + ex.Message);
                    return -100;
                }
                finally
                {
                    conn.Close();//cuối cùng đóng kết nối
                }


            }

        //internal static object getData(string sql)
        //{
        //    throw new NotImplementedException();
        //}

        //internal static object Database(string sql)
        //{
        //    throw new NotImplementedException();
        //}


        public DataTable Khoa()
        {
            string cmd = "select * from khoa";
            SqlDataAdapter adap = new SqlDataAdapter(cmd, conn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }
        public DataTable SinhVien()
        {
            string cmd = "select * from sinhvien";
            SqlDataAdapter adap = new SqlDataAdapter(cmd, conn);
            DataTable ds = new DataTable();
            adap.Fill(ds);
            return ds;
        }
    }
}
