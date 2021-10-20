using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public class HoaDon
    {
        private int MaHD;

        public int MAHD
        {
            get { return MaHD; }
            set { MaHD = value; }
        }

        private string NgayLapHD;

        public string NGAYLAPHD
        {
            get { return NgayLapHD; }
            set { NgayLapHD = value; }
        }
        private string NgayGiaoHang;

        public string NGAYGIAOHANG
        {
            get { return NgayGiaoHang; }
            set { NgayGiaoHang = value; }
        }
        private string DiaChiGiaoHang;

        public string DIACHIGIAOHANG
        {
            get { return DiaChiGiaoHang; }
            set { DiaChiGiaoHang = value; }
        }
        private int MaKH;

        public int MAKH
        {
            get { return MaKH; }
            set { MaKH = value; }
        }
        private bool TrangThai;

        public bool TRANGTHAI
        {
            get { return TrangThai; }
            set { TrangThai = value; }
        }
        private string HoTen;

        public string HOTEN
        {
            get { return HoTen; }
            set { HoTen = value; }
        }

        private decimal _tongTien;

        public decimal TongTien
        {
            get { return _tongTien; }
            set { _tongTien = value; }
        }

        private decimal _giamGia;

        public decimal GiamGia
        {
            get { return _giamGia; }
            set { _giamGia = value; }
        }

        private string _maGiamGia;

        public string MaGiamGia
        {
            get { return _maGiamGia; }
            set { _maGiamGia = value; }
        }

        private string _tenKhach;
        public string TenKhach
        {
            get { return _tenKhach; }
            set { _tenKhach = value; }
        }
        public string _email;
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public string _soDienThoai;

        public string SoDienThoai
        {
            get
            {
                return _soDienThoai;
            }

            set
            {
                _soDienThoai = value;
            }
        }

    }
}
