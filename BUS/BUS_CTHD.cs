using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DAL;
using DTO;

namespace BUS
{
    public class BUS_CTHD
    {
        DAL_CTHD dal_CTHD = new DAL_CTHD();
        public void ThemCTHD(CTHD cthd)
        {
            dal_CTHD.ThemCTHD(cthd);
        }
        public DataTable LoadCTHD(int MaHD)
        {
            return dal_CTHD.LoadCTHD(MaHD);
        }
        public void XoaCTHD(int MaHD, int masp, string size)
        {
            dal_CTHD.XoaCTHD(MaHD, masp, size);
        }
        public void CapNhatCTHD(CTHD cthd, string s)
        {
            dal_CTHD.Open();
            dal_CTHD.CapNhatCTHD(cthd, s);
            dal_CTHD.Close();
        }
    }
}
