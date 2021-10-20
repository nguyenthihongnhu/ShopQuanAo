using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_HoaDon
    {
        DAL_HoaDon dal_HoaDon = new DAL_HoaDon();
        public void ThemHD(HoaDon hd)
        {
            dal_HoaDon.ThemHD(hd);
        }
        public DataTable LoadDSHD(bool TrangThai)
        {
            return dal_HoaDon.LoadDSHD(TrangThai);
        }

        public DataTable LoadDSHDTheoKhachHang(int maKH)
        {
            return dal_HoaDon.LoadDSHDTheoKhachHang(maKH);
        }

        public HoaDon LayThongTinHD(int MaHD)
        {
            return dal_HoaDon.LayThongTinHD(MaHD);
        }
        public void CapNhatHD(HoaDon hd)
        {
            dal_HoaDon.Open();
            dal_HoaDon.CapNhatHD(hd);
            dal_HoaDon.Close();
        }
        public void CapNhatSoLuong(int MaSP)
        {
            dal_HoaDon.Open();
            dal_HoaDon.CapNhatSoLuong(MaSP);
            dal_HoaDon.Close();
        }
        public DataTable TinhDoanhThu()
        {
            return dal_HoaDon.TinhDoanhThu();
        }

        public void CapNhatTongTien(int maHD, decimal tongTien)
        {
            dal_HoaDon.CapNhatTongTien(maHD, tongTien);
        }
    }
}
