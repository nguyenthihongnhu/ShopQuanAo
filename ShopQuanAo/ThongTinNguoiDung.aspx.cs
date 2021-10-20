using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;
using DTO;

namespace ShopQuanAo
{
    public partial class ThongTinNguoiDung : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadThongTinKH();
            }
        }

        protected void btnXacnhan_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            BUS_KhachHang bus = new BUS_KhachHang();

            string uname = (string)Session["Username"];

            int mkh = bus.LayMaKH(uname);

            kh.MAKH = mkh;
            kh.HOTEN = txtHoten.Text;
            kh.DIACHI = txtDiachi.Text;
            kh.SODIENTHOAI = txtDienthoai.Text;
            kh.EMAIL = txtEmail.Text;
            kh.GIOITINH = 0;
            if (rblGioitinh.SelectedIndex == 0)
            {
                kh.GIOITINH = 1;
            }

            bus.CapNhatThongTinKH(kh);

            if (!string.IsNullOrWhiteSpace(txtMatKhauCu.Text))
            {
                if (bus.MatKhauKhopMatKhauCu(mkh, txtMatKhauCu.Text))
                {
                    if (!string.IsNullOrWhiteSpace(txtMatKhauMoi.Text)
                        && !string.IsNullOrWhiteSpace(txtXacNhanMatKhauMoi.Text))
                    {
                        if (txtMatKhauMoi.Text == txtXacNhanMatKhauMoi.Text)
                        {
                            bus.CapNhatThongTinMatKhau(mkh, txtMatKhauMoi.Text);
                            lblThongBao.Text = "Cập nhật mật khẩu mới thành công !";
                        } else
                        {
                            lblThongBao.Text = "Xác nhận lại mật khẩu mới không khớp !";
                        }
                    }
                } else
                {
                    lblThongBao.Text = "Không đúng mật khẩu cũ !";
                }
            } else
            {
                lblThongBao.Text = "Cập nhật thông tin khách hàng thành công !";
            }
        }
        public void LoadThongTinKH()
        {
            if (Session["Username"] != null)
            {
                string uname = (string)Session["Username"];
                BUS_KhachHang bus = new BUS_KhachHang();
                KhachHang kh = new KhachHang();
                kh = bus.LayThongTinKhachHang(uname);

                txtHoten.Text = kh.HOTEN;
                txtEmail.Text = kh.EMAIL;
                txtDienthoai.Text = kh.SODIENTHOAI;
                txtDiachi.Text = kh.DIACHI;
                if (kh.GIOITINH == 1)
                {
                    rblGioitinh.SelectedIndex = 0;
                }
                else
                {
                    rblGioitinh.SelectedIndex = 1;
                }
                lblThongBao.Text = "";
                txtMatKhauCu.Text = "";
                txtMatKhauMoi.Text = "";
                txtXacNhanMatKhauMoi.Text = "";
            }
        }
    }
}