using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_LienHe : QuanLyKetNoi
    {
        public void GhiThongTinLienHe(LienHeDTO lienHe)
        {
            DAL_LienHe DAL_LienHe = new DAL_LienHe();
            DAL_LienHe.Open();
            string insertString = string.Format("INSERT INTO LienHe(MaKH, HoTen, DiaChi, Email, SoDienThoai, NoiDung, NgayGui) VALUES({0},N'{1}',N'{2}',N'{3}','{4}',N'{5}','{6}')",
                lienHe.MaKH,
                lienHe.HoTen,
                lienHe.DiaChi,
                lienHe.Email,
                lienHe.SoDienThoai,
                lienHe.NoiDung,
                DateTime.Now.ToString("yyyy/MM/dd")
                );
            SqlCommand cmd = new SqlCommand(insertString, DAL_LienHe.conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            DAL_LienHe.Close();

        }

        public DataTable DanhSachLienHe()
        {
            DataTable ds = new DataTable();
            DAL_LienHe DAL_LienHe = new DAL_LienHe();
            DAL_LienHe.Open();
            string selectString = "select lh.*, kh.TenDangNhap from LienHe lh, KhachHang kh WHERE lh.MaKH = kh.MaKH ORDER BY lh.NgayGui DESC";
            SqlCommand cmd = new SqlCommand(selectString, DAL_LienHe.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            ds.Load(reader);
            DAL_LienHe.Close();
            return ds;
        }

        public LienHeDTO LayThongTinLienHe(int Id)
        {
            DAL_LienHe DAL_LienHe = new DAL_LienHe();
            DAL_LienHe.Open();
            string qry = "select Id, MaKH, HoTen, DiaChi, Email, SoDienThoai, NoiDung, NgayGui from LienHe where Id = " + Id;
            SqlCommand cmd = new SqlCommand(qry, DAL_LienHe.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            LienHeDTO lienHe = new LienHeDTO();
            if (reader.HasRows)
            {
                reader.Read();
                lienHe.Id = reader.GetInt32(0);
                lienHe.MaKH = reader.GetInt32(1);
                lienHe.HoTen = reader.GetValue(2).ToString();
                lienHe.DiaChi = reader.GetValue(3).ToString();
                lienHe.Email = reader.GetValue(4).ToString();
                lienHe.SoDienThoai = reader.GetValue(5).ToString();
                lienHe.NoiDung = reader.GetValue(6).ToString();
                lienHe.NgayGui = reader.GetDateTime(7);
            }
            reader.Dispose();
            cmd.Dispose();
            DAL_LienHe.Close();

            return lienHe;
        }

        public void XoaLienHe(int Id)
        {
            DAL_LienHe DAL_LienHe = new DAL_LienHe();
            DAL_LienHe.Open();
            string deleteString = "delete from LienHe where Id =" + Id;
            SqlCommand cmd = new SqlCommand(deleteString, DAL_LienHe.conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            DAL_LienHe.Close();
        }
    }
}
