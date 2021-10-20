using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_SanPham
    {
        DAL_SanPham dal_SanPham = new DAL_SanPham();
        public DataTable LoadSanPhamChuDe(int ChuDe)
        {
            return dal_SanPham.LoadSPChuDe(ChuDe);
        }
        public DataTable LoadSanPhamTheoLoai(int LoaiSP, int GioiTinh)
        {
            return dal_SanPham.LoadSPTheoLoai(LoaiSP, GioiTinh);
        }
        public SanPham LayThongTinSanPham(int ID, string size)
        {
            return dal_SanPham.LayThongTinSanPham(ID, size);
        }
        public DataTable TimKiemSanPham(string TenSP)
        {
            return dal_SanPham.TimKiemSanPham(TenSP);
        }
        public DataTable LayKichThuocSanPham(int ID)
        {
            return dal_SanPham.LayKichThuocSanPham(ID);
        }
        public void XoaSP(int MaSP)
        {
            dal_SanPham.XoaSP(MaSP);
        }

        public void XoaSPTheoKichThuoc(int maSP, string size)
        {
            dal_SanPham.XoaSPTheoKichThuoc(maSP, size);
        }

        public void ThemSP(SanPham sp)
        {
            dal_SanPham.ThemSP(sp);
        }
        public void ThemSoLuongSanPham(SanPham sp)
        {
            dal_SanPham.ThemSoLuongSanPham(sp);
        }
        public int LayMaSP()
        {
            return dal_SanPham.LayMaSP();
        }
        public void CapNhatSP(SanPham sp)
        {
            dal_SanPham.CapNhatSP(sp);
        }
        public DataTable TopSanPham(int num)
        {
            return dal_SanPham.TopSanPham(num);
        }
        public int LaTrungMaSP(int MaSP)
        {
            return dal_SanPham.LaTrungMaSP(MaSP);
        }
        public DataTable LoadSPTheoLoaiAdmin(int LoaiSP, int Gioitinh)
        {
            return dal_SanPham.LoadSPTheoLoaiAdmin(LoaiSP, Gioitinh);
        }
    }
}
