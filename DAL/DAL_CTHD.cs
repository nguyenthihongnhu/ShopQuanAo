using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAL
{
    public class DAL_CTHD:QuanLyKetNoi
    {
        public void ThemCTHD(CTHD cthd)
        {
            DAL_CTHD dal_CTHD = new DAL_CTHD();

            dal_CTHD.Open();

            string insertString = string.Format("INSERT INTO ChiTiet_HoaDon(MaHD, MaSP, MaSize, SoLuong, DonGia) VALUES({0}, {1}, {2}, {3}, {4})",
                cthd.MAHD,
                cthd.MASP,
                cthd.MASIZE,
                cthd.SOLUONG,
                cthd.DONGIA
                );
            SqlCommand cmd = new SqlCommand(insertString,dal_CTHD.conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            dal_CTHD.Close();
        }

        public DataTable LoadCTHD(int MaHD)
        {
            DataTable dt = new DataTable();
            DAL_CTHD dal_CTHD = new DAL_CTHD();
            dal_CTHD.Open();
            string selectString = "select MaHD,s.MaSP as MaSP,TenSP,Size,SoLuong,DonGia from ChiTiet_HoaDon c , SanPham s,Size si where c.MaSP = s.MaSP and c.MaSize = si.MaSize and c.MaHD = "+MaHD;
            SqlCommand cmd = new SqlCommand(selectString, dal_CTHD.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            cmd.Dispose();
            reader.Dispose();
            dal_CTHD.Close();
            return dt;
        }
        public void XoaCTHD(int MaHD, int masp, string size)
        {
            DAL_CTHD dal_CTHD = new DAL_CTHD();
            dal_CTHD.Open();
            string deleteString = string.Format("delete from ChiTiet_HoaDon where MaHD = {0} AND MaSP = {1} AND MaSize IN (SELECT MaSize FROM Size WHERE Size LIKE '{2}')",
                MaHD,
                masp,
                size
                );
            SqlCommand cmd = new SqlCommand(deleteString, dal_CTHD.conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            dal_CTHD.Close();

        }
        public void CapNhatCTHD(CTHD cthd, string size)
        {
            DAL_CTHD dal_CTHD = new DAL_CTHD();
            dal_CTHD.Open();
            string updateString = string.Format("UPDATE ChiTiet_HoaDon SET SoLuong={0} WHERE MaHD={1} AND MaSP={2} AND MaSize IN (SELECT MaSize FROM Size WHERE Size LIKE '{3}')",
                cthd.SOLUONG,
                cthd.MAHD,
                cthd.MASP,
                size
                );
            SqlCommand cmd = new SqlCommand(updateString,dal_CTHD.conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            dal_CTHD.Close();
        }
    }
}
