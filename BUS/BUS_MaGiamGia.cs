using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_MaGiamGia
    {
        DAL_MaGiamGia dal_MaGiamGia = new DAL_MaGiamGia();
        public DataTable DanhSachMaGiamGia()
        {
            return dal_MaGiamGia.DanhSachMaGiamGia();
        }
        public void GhiThongTinMaGiamGia(MaGiamGiaDTO maGiamGia)
        {
            dal_MaGiamGia.GhiThongTinMaGiamGia(maGiamGia);
        }

        public MaGiamGiaDTO LayThongTinMaGiamGia(int Id)
        {
            return dal_MaGiamGia.LayThongTinMaGiamGia(Id);
        }
        public void SuaMaGiamGia(MaGiamGiaDTO maGiamGia)
        {
            dal_MaGiamGia.SuaMaGiamGia(maGiamGia);
        }
        public void XoaMaGiamGia(int Id)
        {
            dal_MaGiamGia.XoaMaGiamGia(Id);
        }

        public bool TonTaiMaGiamGia(string ma)
        {
            return dal_MaGiamGia.TonTaiMaGiamGia(ma);
        }

        public decimal LaySoTienGiamGia(string ma)
        {
           return dal_MaGiamGia.LaySoTienGiamGia(ma);
        }

        public bool TrungMaDangSua(int id, string ma)
        {
            return dal_MaGiamGia.TrungMaDangSua(id, ma);
        }
    }
}
