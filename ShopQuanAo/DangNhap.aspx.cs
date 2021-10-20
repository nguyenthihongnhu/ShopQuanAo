using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using BUS;

namespace ShopQuanAo
{
    public partial class DangNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                Response.Redirect("TrangChu.aspx");
            }
        }

        protected void ibtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            string username = txtTendangnhap.Text.Trim();
            string password = txtMatkhau.Text.Trim();

            BUS_KhachHang bus = new BUS_KhachHang();

            int flag = bus.LaDangNhapThanhCong(username,password);

            if (KiemTraKiTuNhap(username) == false)
            {
                lblThongbao.Text = "Thông tin đăng nhập không chính xác !<br />Vui lòng nhập lại.";
                return;
            }

            if (flag == 0)
            {
                Session["Username"] = username;
                Response.Redirect("TrangChu.aspx");
            }
            else
            {
                    Session["Username"] = username;
                    Response.Redirect("QuanLy.aspx");

            }
               
        }
        #region chuỗi kiểm tra
        string chuoiDungKiemTra = "1234567890_QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
        #endregion

        #region hàm kiểm tra nhập kí tự đặc biệt vào textbox TenDangNhap
        private bool KiemTraKiTuNhap(string chuoiCanKiemTra)
        {
            foreach (char kitu in chuoiCanKiemTra)
            {
                bool dung = false;
                foreach (char kitu2 in chuoiDungKiemTra)
                {
                    if (kitu == kitu2)
                    {
                        dung = true;
                    }
                }
                if (dung == false)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        protected void txtMatkhau_TextChanged(object sender, EventArgs e)
        {

        }
    }
}