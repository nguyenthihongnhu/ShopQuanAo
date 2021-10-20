using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAL
{
    public class DAL_HoaDon : QuanLyKetNoi
    {
        public void ThemHD(HoaDon hd)
        {
            DAL_HoaDon dal_HD = new DAL_HoaDon();
            dal_HD.Open();
            string insertString = "insert into HoaDon(MaHD, NgayLapHD, NgayGiaoHang, MaKH, DiaChiGiaoHang, TrangThai, TongTien, MaGiamGia, GiamGia, TenKhach, Email, SoDienThoai) values('" + hd.MAHD + "','" + hd.NGAYLAPHD + "','" + hd.NGAYGIAOHANG + "'," + hd.MAKH + ",N'" + hd.DIACHIGIAOHANG + "','False'," + hd.TongTien + ",N'" + hd.MaGiamGia + "' , " + hd.GiamGia + ", N'" + hd.TenKhach + "', N'" + hd.Email + "', N'" + hd.SoDienThoai + "')";
            SqlCommand cmd = new SqlCommand(insertString, dal_HD.conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            dal_HD.Close();
        }

        public DataTable LoadDSHDTheoKhachHang(int maKH)
        {
            DAL_HoaDon dal_HD = new DAL_HoaDon();
            dal_HD.Open();
            string selectString = "select MaHD,NgayLapHD,NgayGiaoHang, HoTen, DiaChiGiaoHang,TrangThai,TongTien, GiamGia, MaGiamGia, h.TenKhach, h.Email, h.SoDienThoai from HoaDon h,KhachHang k where h.MaKH = k.MaKH and h.MaKH = " + maKH + " ORDER BY h.NgayLapHD DESC";
            SqlCommand cmd = new SqlCommand(selectString, dal_HD.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            cmd.Dispose();
            reader.Dispose();
            dal_HD.Close();
            return dt;
        }

        public DataTable LoadDSHD(bool TrangThai)
        {
            DAL_HoaDon dal_HD = new DAL_HoaDon();
            dal_HD.Open();
            string selectString = "select MaHD,NgayLapHD,NgayGiaoHang,HoTen,DiaChiGiaoHang,TrangThai,TongTien, GiamGia, MaGiamGia, h.TenKhach, h.Email, h.SoDienThoai from HoaDon h,KhachHang k where h.MaKH = k.MaKH and h.TrangThai = '" + TrangThai + "' ORDER BY h.NgayLapHD DESC";
            SqlCommand cmd = new SqlCommand(selectString, dal_HD.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            cmd.Dispose();
            reader.Dispose();
            dal_HD.Close();
            return dt;
        }

        public void CapNhatTongTien(int maHD, decimal tongTien)
        {
            DAL_HoaDon dal_HD = new DAL_HoaDon();
            dal_HD.Open();
            string updateString = "update HoaDon set TongTien = " + tongTien.ToString() + " where MaHD = " + maHD.ToString();
            SqlCommand cmd = new SqlCommand(updateString, dal_HD.conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            dal_HD.Close();
        }

        public HoaDon LayThongTinHD(int MaHD)
        {
            DAL_HoaDon dal_HD = new DAL_HoaDon();
            dal_HD.Open();
            string selectString = "select MaHD,HoTen,NgayLapHD,NgayGiaoHang,DiaChiGiaoHang,TrangThai,TongTien,GiamGia,MaGiamGia, h.TenKhach, h.Email, h.SoDienThoai from HoaDon h,KhachHang k where h.MaKH = k.MaKH and h.MaHD =" + MaHD;
            SqlCommand cmd = new SqlCommand(selectString, dal_HD.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            HoaDon hd = new HoaDon();
            hd.MAHD = reader.GetInt32(0);
            hd.HOTEN = reader.GetString(1);
            hd.NGAYLAPHD = reader.GetDateTime(2).ToShortDateString();
            hd.NGAYGIAOHANG = reader.GetDateTime(3).ToShortDateString();
            hd.DIACHIGIAOHANG = reader.GetString(4);
            hd.TRANGTHAI = reader.GetBoolean(5);
            try
            {
                hd.TongTien = reader.GetDecimal(6);

            }
            catch
            {
                hd.TongTien = 0;

            }

            try
            {
                hd.GiamGia = reader.GetDecimal(7);
                hd.MaGiamGia = reader.GetString(8);
            }
            catch
            {

                hd.GiamGia = 0;
                hd.MaGiamGia = "";
            }
            cmd.Dispose();
            reader.Dispose();
            dal_HD.Close();

            return hd;
        }
        public void CapNhatHD(HoaDon hd)
        {
            string updateString = "update HoaDon set TenKhach = N'" + hd.TenKhach + "', Email = N'" + hd.Email +"', SoDienThoai = N'" + hd.SoDienThoai +"', DiaChiGiaoHang = N'" + hd.DIACHIGIAOHANG + "', TrangThai = '" + hd.TRANGTHAI + "' where MaHD = " + hd.MAHD;
            SqlCommand cmd = new SqlCommand(updateString, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        public void CapNhatSoLuong(int MaSP)
        {
            string updateString = "update SanPham_Size set SoLuong = SoLuongTam where MaSP = " + MaSP;
            SqlCommand cmd = new SqlCommand(updateString, conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        public DataTable TinhDoanhThu()
        {
            DataTable dt = new DataTable();
            DAL_HoaDon dal_HD = new DAL_HoaDon();
            dal_HD.Open();
            string selectString = "select sum(A.GiaMua*B.SoLuong) as TongMua ,sum(B.DonGia*B.SoLuong) as TongBan , SUM((B.DonGia*B.SoLuong) - (A.GiaMua*B.SoLuong)) as DoanhThu from SanPham A,ChiTiet_HoaDon B where A.MaSP = B.MaSP";
            SqlCommand cmd = new SqlCommand(selectString, dal_HD.conn);
            SqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            dal_HD.Close();

            return dt;
        }
    }
}
