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
    public class BUS_LienHe
    {
        DAL_LienHe dal_LienHe = new DAL_LienHe();
        public DataTable DanhSachLienHe()
        {
            return dal_LienHe.DanhSachLienHe();
        }
        public void GhiThongTinLienHe(LienHeDTO lienHe)
        {
             dal_LienHe.GhiThongTinLienHe(lienHe);
        }
        public LienHeDTO LayThongTinLienHe(int Id)
        {
             return dal_LienHe.LayThongTinLienHe(Id);
        }
        public void XoaLienHe(int Id)
        {
             dal_LienHe.XoaLienHe(Id);
        }
    }
}
