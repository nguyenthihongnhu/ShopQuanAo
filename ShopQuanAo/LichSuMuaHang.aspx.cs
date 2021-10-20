using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopQuanAo
{
    public partial class LichSuMuaHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Username"] == null)
                {
                    Response.Redirect("DangNhap.aspx");
                }

                LoadDSHoaDon();
                (this.Master as GiaoDien)
                    .TieuDe = "Lịch Sử Mua Hàng";
            }
        }

        private void LoadDSHoaDon()
        {
            BUS_KhachHang bus_KhachHang = new BUS_KhachHang();
            KhachHang kh = bus_KhachHang.LayThongTinKhachHang(Session["Username"].ToString());
            BUS_HoaDon bus = new BUS_HoaDon();
            DataTable dt = new DataTable();
            dt = bus.LoadDSHDTheoKhachHang(kh.MAKH);
            gvLichSuMuaHang.DataSource = dt.DefaultView;
            gvLichSuMuaHang.DataBind();
        }
    }
}