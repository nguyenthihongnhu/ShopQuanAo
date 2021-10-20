using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class QuanLyKetNoi
    {
        public SqlConnection conn;
        public QuanLyKetNoi()
        {
            string connString = @"Data Source=DESKTOP-00RFE0R\SQLSERVER;Initial Catalog=Demo_BanHang;Integrated Security=True";
            //string connString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Demo_BanHang;Integrated Security=True";
            conn = new SqlConnection(connString);
        }
        public void Open()
        {
            conn.Open();

        }
        public void Close()
        {
            conn.Close();
        }
    }
}