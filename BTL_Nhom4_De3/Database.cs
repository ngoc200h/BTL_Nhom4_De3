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
                    conn.Open();
                    cmd = new SqlCommand(sql, conn);
                    dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    return dt.Rows[0];
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
                    //cần sửa lại hàm execute như sau
                    //string sql,List<CustomParameter> lstPara là tham số truyền vào 
                    //CustomParameter đã được định nghĩa ở phần trước- Xem lại part 3
                    conn.Open();//mở kết nối
                    cmd = new SqlCommand(sql, conn);//thực thi câu lệnh sql
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var p in lstPara)
                    {
                        cmd.Parameters.AddWithValue(p.key, p.value);
                    }
                    var rs = cmd.ExecuteNonQuery();
                    return (int)rs;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thực thi câu lệnh: " + ex.Message);
                    return -100;
                }
                finally
                {
                    conn.Close();
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
