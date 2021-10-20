using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using BUS;
using DTO;
using System.Globalization;

namespace ShopQuanAo
{
    public partial class ThanhToan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["GioHang"] == null)
                {
                    Response.Redirect("TrangChu.aspx");
                    return;
                }
                Session["LoaiSP"] = "thanhtoan";
                LoadGioHang();
                LoadThongTinKH();
                txtTenKH.Enabled = true;
                txtDiaChi.Enabled = true;
                txtEmail.Enabled = true;
                txtSoDT.Enabled = true;
                txtNgayGiao.Enabled = false;
                txtDCNhan.Enabled = true;
            }

        }

        private decimal TinhTongTien()
        {
            decimal tongTien = 0;
            if (Session["GioHang"] != null)
            {
                ArrayList giohang = (ArrayList)Session["GioHang"];
                foreach (SanPham sp in giohang)
                {
                    tongTien = tongTien + sp.SoLuong * sp.GiaBan;
                }
            }
            return tongTien;
        }

        public void LoadGioHang()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaSP");
            dt.Columns.Add("TenSP");
            dt.Columns.Add("Size");
            dt.Columns.Add("SoLuong");
            dt.Columns.Add("GiaBan");

            if (Session["GioHang"] != null)
            {
                ArrayList giohang = (ArrayList)Session["GioHang"];
                BUS_SanPham bus_sp = new BUS_SanPham();
                foreach (SanPham sp in giohang)
                {
                    DataRow dr = dt.NewRow();
                    dr["MaSP"] = sp.MaSP;
                    dr["TenSP"] = sp.TenSP;
                    switch (sp.MASIZE)
                    {
                        case 0:
                            dr["Size"] = "S";
                            break;
                        case 1:
                            dr["Size"] = "M";
                            break;
                        case 2:
                            dr["Size"] = "L";
                            break;
                        case 3:
                            dr["Size"] = "XL";
                            break;
                        case 4:
                            dr["Size"] = "XXL";
                            break;

                    }
                    dr["SoLuong"] = sp.SoLuong;
                    dr["GiaBan"] = sp.GiaBan;
                    dt.Rows.Add(dr);

                }
                gvDSSP.DataSource = dt.DefaultView;
                gvDSSP.DataBind();
                txtNgayGiao.Text = DateTime.Now.AddDays(3)
                    .ToString("dd/MM/yyyy");
                txtTongTien.Text = TinhTongTien().ToString("N0");
                txtGiamGia.Enabled = false;
                txtTongTien.Enabled = false;
            }
        }
        public void LoadThongTinKH()
        {
            if (Session["Username"] != null)
            {
                string uname = (string)Session["Username"];
                BUS_KhachHang busKH = new BUS_KhachHang();

                KhachHang kh = busKH.LayThongTinKhachHang(uname);

                txtTenKH.Text = kh.HOTEN;
                txtDiaChi.Text = kh.DIACHI;
                txtEmail.Text = kh.EMAIL;
                txtSoDT.Text = kh.SODIENTHOAI;
                txtDCNhan.Text = kh.DIACHI;
            }

        }

        protected void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                if (DateTime.Now.CompareTo(DateTime.ParseExact(txtNgayGiao.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture)) > 0)
                {
                    lblNgayGiaoHang.Text = "Ngày giao hàng lớn hơn ngày hiện tại !";
                    return;
                }
                if (Session["Username"] != null && Session["GioHang"] != null)
                {
                    string uname = (string)Session["Username"];
                    BUS_KhachHang busKH = new BUS_KhachHang();


                    int MaKH = busKH.LayMaKH(uname);
                    string ngaylaphd = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                    string ngaygiaohang = DateTime
                        .ParseExact(txtNgayGiao.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        .ToString("yyyy/MM/dd");
                    string dc = txtDCNhan.Text.Trim();

                    // them hoa don
                    BUS_HoaDon busHD = new BUS_HoaDon();
                    HoaDon hd = new HoaDon();
                    hd.TenKhach = txtTenKH.Text;
                    hd.Email = txtEmail.Text;
                    hd.SoDienThoai = txtSoDT.Text;
                    hd.MAHD = int.Parse(DateTime.Now.Millisecond.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Minute.ToString());
                    hd.NGAYLAPHD = ngaylaphd;
                    hd.NGAYGIAOHANG = ngaygiaohang;
                    hd.MAKH = MaKH;
                    hd.DIACHIGIAOHANG = dc;
                    decimal giamGia = 0;
                    decimal.TryParse(txtGiamGia.Text, out giamGia);
                    hd.GiamGia = giamGia;
                    hd.MaGiamGia = txtMaGiamGia.Text;

                    // Tinh tong tien hoa don
                    hd.TongTien = TinhTongTien() - giamGia;
                    if (hd.TongTien < 0)
                        hd.TongTien = 0;

                    busHD.ThemHD(hd);
                    //them chi tiet hoa don
                    BUS_CTHD busCTHD = new BUS_CTHD();
                    ArrayList giohang = (ArrayList)Session["GioHang"];
                    ArrayList chitietHD = new ArrayList();
                    foreach (SanPham sp in giohang)
                    {
                        CTHD cthd = new CTHD();
                        cthd.MAHD = hd.MAHD;
                        cthd.MASP = sp.MaSP;
                        cthd.MASIZE = sp.MASIZE;
                        cthd.SOLUONG = sp.SoLuong;
                        cthd.DONGIA = sp.GiaBan;
                        busCTHD.ThemCTHD(cthd);
                        chitietHD.Add(cthd);
                    }
                    Session["chitietHD"] = chitietHD;
                    Session["GioHang"] = null;
                    Response.Redirect("thanhcong.htm");


                }
            }

        }

        protected void btnApMaGiamGia_Click(object sender, EventArgs e)
        {
            BUS_MaGiamGia busMaGiamGia = new BUS_MaGiamGia();

            if (busMaGiamGia.TonTaiMaGiamGia(txtMaGiamGia.Text))
            {
                decimal soTienGiam = busMaGiamGia.LaySoTienGiamGia(txtMaGiamGia.Text);
                txtGiamGia.Text =  soTienGiam.ToString("N0");
                txtTongTien.Text = (TinhTongTien() - soTienGiam).ToString("N0");
            }
        }

        protected void txtNgayGiao_TextChanged(object sender, EventArgs e)
        {

        }
    }
}