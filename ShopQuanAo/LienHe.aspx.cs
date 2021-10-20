using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopQuanAo
{
    public partial class LienHe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Label lblTieuDe = (Label)Master.FindControl("lblTieuDe");
                lblTieuDe.Text = "Liên hệ";
                KhoiTaoThongTinLienHe();
            }
        }

        protected void btnXacnhan_Click(object sender, EventArgs e)
        {
            if ((string)Session["Username"] == null)
            {
                lblThongBao.Text = "Khách hàng phải đăng nhập để gửi liên hệ !";
                return;
            }

            string uname = (string)Session["Username"];
            BUS_KhachHang busKH = new BUS_KhachHang();
            int MaKH = busKH.LayMaKH(uname);
            LienHeDTO lh = new LienHeDTO();
            lh.MaKH = MaKH;
            lh.HoTen = txtHoten.Text;
            lh.SoDienThoai = txtDienthoai.Text;
            lh.DiaChi = txtDiachi.Text;
            lh.Email = txtEmail.Text;
            lh.NoiDung = txtNoiDungLienHe.Text;
            BUS_LienHe busLH = new BUS_LienHe();
            busLH.GhiThongTinLienHe(lh);
            lblThongBao.Text = "Gửi thông tin liên hệ thành công !";
            KhoiTaoThongTinLienHe();
        }

        private void KhoiTaoThongTinLienHe()
        {
            txtHoten.Text = "";
            txtDienthoai.Text = "";
            txtDiachi.Text = "";
            txtEmail.Text = "";
            txtNoiDungLienHe.Text = "";
        }
    }
}