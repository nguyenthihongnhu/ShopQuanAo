using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_KhachHang
    {
        DAL_KhachHang dal_KhachHang = new DAL_KhachHang();
        public void GhiThongTinKhachHang(KhachHang kh)
        {
            dal_KhachHang.GhiThongTinKhachHang(kh);
        }
        public int LaTrungTenDangNhap(string TenDangNhap)
        {
            return dal_KhachHang.LaTrungTenDangNhap(TenDangNhap);
        }
        public int LaTrungEmail(string Email)
        {
            return dal_KhachHang.LaTrungEmail(Email);
        }

        public bool LaTrungSoDienThoai(string sdt)
        {
            return dal_KhachHang.LaTrungSoDienThoai(sdt);
        }

        public int LaDangNhapThanhCong(string Username,string Password)
        {
            return dal_KhachHang.LaDangNhapThanhCong(Username, Password);
        }
        public int LayMaKH(string username)
        {
            return dal_KhachHang.LayMaKH(username);
        }
        public KhachHang LayThongTinKhachHang(string uname)
        {
            return dal_KhachHang.LayThongTinKhachHang(uname);
        }
        public DataTable DanhSachKhachHang()
        {
            return dal_KhachHang.DanhSachKhachHang();
        }
        public void CapNhatKhachHang(KhachHang kh)
        {
            dal_KhachHang.CapNhatKhachHang(kh);
        }
        public void XoaKhachHang(int MaKH)
        {
            dal_KhachHang.XoaKhachHang(MaKH);
        }
        public DataTable LoadTopKhachHang(int num)
        {
            return dal_KhachHang.LoadTopKhachHang(num);
        }
        public void CapNhatThongTinKH(KhachHang kh)
        {
            dal_KhachHang.CapNhatThongTinKH(kh);
        }

        public void CapNhatThongTinMatKhau(int maKH, string matKhau)
        {
            dal_KhachHang.CapNhatThongTinMatKhau(maKH, matKhau);
        }

        public bool MatKhauKhopMatKhauCu(int maKH, string matKhauCu)
        {
            return dal_KhachHang.MatKhauKhopMatKhauCu(maKH, matKhauCu);
        }

        public bool IsAdmin(int maKH)
        {
            return dal_KhachHang.IsAdmin(maKH);
        }

        public bool DaCoHoaDon(int maKH)
        {
            return dal_KhachHang.DaCoHoaDon(maKH);
        }
    }
}
