using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using BUS;
using DTO;

namespace ShopQuanAo
{
    public partial class QuanLyHoaDon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDSSP(false);
                Session["cthdPage"] = 0;
                Session["hdPage"] = 0;
            }

        }

        protected void btnDuyet_Click(object sender, EventArgs e)
        {

            bool trangthai = bool.Parse(ddlHoaDon.SelectedValue);
            LoadDSSP(trangthai);
        }
        public void LoadDSSP(bool TrangThai)
        {
            BUS_HoaDon bus = new BUS_HoaDon();
            DataTable dt = new DataTable();
            dt = bus.LoadDSHD(TrangThai);
            gvHoaDon.DataSource = dt.DefaultView;
            gvHoaDon.DataBind();
        }

        protected void gvHoaDon_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int mahd = int.Parse(gvHoaDon.DataKeys[e.NewSelectedIndex].Value.ToString());
            Session["MaHoaDon"] = mahd;
            HoaDon hd = new HoaDon();
            BUS_HoaDon bus = new BUS_HoaDon();
            hd = bus.LayThongTinHD(mahd);

            txtMaHD.Text = hd.MAHD.ToString();
            txtTenKH.Text = hd.TenKhach;
            txtEmail.Text = hd.Email;
            txtSoDienThoai.Text = hd.SoDienThoai;
            txtNgayLapHD.Text = hd.NGAYLAPHD;
            txtNgayGiaoHang.Text = hd.NGAYGIAOHANG;
            txtDiaChi.Text = hd.DIACHIGIAOHANG;
            ddlTrangThai.SelectedValue = hd.TRANGTHAI.ToString();

            //load chi tiet hoa don
            DataTable dt = new DataTable();
            BUS_CTHD busCTHD = new BUS_CTHD();

            dt = busCTHD.LoadCTHD(mahd);
            gvCTHD.DataSource = dt.DefaultView;
            gvCTHD.DataBind();

            lblThongBao.Text = "";


        }

        protected void gvHoaDon_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            bool trangthai = bool.Parse(ddlHoaDon.SelectedValue);
            Session["hdPage"] = e.NewPageIndex;
            BUS_HoaDon bus = new BUS_HoaDon();
            DataTable dt = new DataTable();
            dt = bus.LoadDSHD(trangthai);
            gvHoaDon.DataSource = dt.DefaultView;
            gvHoaDon.PageIndex = e.NewPageIndex;
            gvHoaDon.DataBind();

        }

        protected void gvCTHD_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //load chi tiet hoa don
            if (Session["MaHoaDon"] == null)
            {
                lblThongBao.Text = "Chưa chọn hóa đơn cần cập nhật.";
                return;
            }

            DataTable dt = new DataTable();
            BUS_CTHD busCTHD = new BUS_CTHD();
            int mahd = int.Parse(Session["MaHoaDon"].ToString());
            Session["cthdPage"] = e.NewPageIndex;
            dt = busCTHD.LoadCTHD(mahd);
            gvCTHD.DataSource = dt.DefaultView;
            gvCTHD.PageIndex = e.NewPageIndex;
            gvCTHD.DataBind();
        }

        protected void gvCTHD_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Session["MaHoaDon"] == null)
            {
                lblThongBao.Text = "Chưa chọn hóa đơn cần cập nhật.";
                return;
            }

            int mahd = int.Parse(Session["MaHoaDon"].ToString());
            GridViewRow row = gvCTHD.Rows[e.RowIndex];
            BUS_SanPham busSp = new BUS_SanPham();
            int masp = int.Parse(row.Cells[1].Text);
            int masize = 0;

            TextBox txtSoLuong = row.FindControl("txtSoLuong") as TextBox;
            string soluong = txtSoLuong.Text.Trim();

            CTHD ct = new CTHD();
            ct.MAHD = mahd;
            ct.MASP = masp;
            ct.MASIZE = masize;
            ct.SOLUONG = int.Parse(soluong);

            BUS_CTHD bus = new BUS_CTHD();
            bus.CapNhatCTHD(ct, row.Cells[3].Text);

            CapNhatTongTienHoaDon(mahd);

            gvCTHD.EditIndex = -1;
            DataTable dt = new DataTable();
            BUS_CTHD busCTHD = new BUS_CTHD();
            dt = busCTHD.LoadCTHD(mahd);
            gvCTHD.DataSource = dt.DefaultView;
            gvCTHD.PageIndex = int.Parse(Session["cthdPage"].ToString());
            gvCTHD.DataBind();


        }

        protected void gvCTHD_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (Session["MaHoaDon"] == null)
            {
                lblThongBao.Text = "Chưa chọn hóa đơn cần cập nhật.";
                return;
            }

            gvCTHD.EditIndex = e.NewEditIndex;
            DataTable dt = new DataTable();
            BUS_CTHD busCTHD = new BUS_CTHD();
            int mahd = int.Parse(Session["MaHoaDon"].ToString());
            dt = busCTHD.LoadCTHD(mahd);
            gvCTHD.DataSource = dt.DefaultView;
            gvCTHD.PageIndex = int.Parse(Session["cthdPage"].ToString());
            gvCTHD.DataBind();
        }

        protected void gvCTHD_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Session["MaHoaDon"] == null)
            {
                lblThongBao.Text = "Chưa chọn hóa đơn cần cập nhật.";
                return;
            }
            int mahd = int.Parse(Session["MaHoaDon"].ToString());
            GridViewRow row = gvCTHD.Rows[e.RowIndex];
            BUS_SanPham busSp = new BUS_SanPham();
            int masp = int.Parse(row.Cells[1].Text);
            BUS_CTHD bus = new BUS_CTHD();
            bus.XoaCTHD(mahd, masp, row.Cells[3].Text);
            CapNhatTongTienHoaDon(mahd);
            gvCTHD.EditIndex = -1;
            DataTable dt = new DataTable();
            BUS_CTHD busCTHD = new BUS_CTHD();
            dt = busCTHD.LoadCTHD(mahd);
            gvCTHD.DataSource = dt.DefaultView;
            gvCTHD.PageIndex = int.Parse(Session["cthdPage"].ToString());
            gvCTHD.DataBind();

        }

        protected void gvCTHD_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            if (Session["MaHoaDon"] == null)
            {
                lblThongBao.Text = "Chưa chọn hóa đơn cần cập nhật.";
                return;
            }

            gvCTHD.EditIndex = -1;
            int mahd = int.Parse(Session["MaHoaDon"].ToString());
            DataTable dt = new DataTable();
            BUS_CTHD busCTHD = new BUS_CTHD();
            dt = busCTHD.LoadCTHD(mahd);
            gvCTHD.DataSource = dt.DefaultView;
            gvCTHD.PageIndex = int.Parse(Session["cthdPage"].ToString());
            gvCTHD.DataBind();
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (Session["MaHoaDon"] != null)
            {
                BUS_HoaDon bus = new BUS_HoaDon();

                int mahd = int.Parse(Session["MaHoaDon"].ToString());
                HoaDon hd = new HoaDon();
                hd.MAHD = mahd;
                hd.TenKhach = txtTenKH.Text;
                hd.Email = txtEmail.Text;
                hd.SoDienThoai = txtSoDienThoai.Text;
                hd.DIACHIGIAOHANG = txtDiaChi.Text;
                hd.TRANGTHAI = bool.Parse(ddlTrangThai.SelectedValue);

                bus.CapNhatHD(hd);
                if (hd.TRANGTHAI.Equals(true))
                {
                    foreach (GridViewRow row in gvCTHD.Rows)
                    {
                        int masp = int.Parse(row.Cells[1].Text);
                        bus.CapNhatSoLuong(masp);

                    }

                }
                lblThongBao.Text = "";


                CapNhatTongTienHoaDon(hd.MAHD);

                bool trangthai = bool.Parse(ddlHoaDon.SelectedValue);
                int page = int.Parse(Session["hdPage"].ToString());
                DataTable dt = new DataTable();
                dt = bus.LoadDSHD(trangthai);
                gvHoaDon.DataSource = dt.DefaultView;
                gvHoaDon.PageIndex = page;
                gvHoaDon.DataBind();
                Session["MaHoaDon"] = null;

            }
            else
            {
                lblThongBao.Text = "Chưa chọn hóa đơn cần cập nhật.";
            }
        }

        private void LoadDanhSachHoaDon()
        {
                BUS_HoaDon bus = new BUS_HoaDon();
                bool trangthai = bool.Parse(ddlHoaDon.SelectedValue);
                int page = int.Parse(Session["hdPage"].ToString());
                DataTable dt = new DataTable();
                dt = bus.LoadDSHD(trangthai);
                gvHoaDon.DataSource = dt.DefaultView;
                gvHoaDon.PageIndex = page;
                gvHoaDon.DataBind();
        }

        private void CapNhatTongTienHoaDon(int maHD)
        {
            BUS_HoaDon busHoaDon = new BUS_HoaDon();
            BUS_CTHD bus_CTHD = new BUS_CTHD();
            BUS_MaGiamGia busMaGiamGia = new BUS_MaGiamGia();

            // Lay so tien giam gia
            decimal mucGiamGia = 0;
            HoaDon hd = busHoaDon.LayThongTinHD(maHD);
            if (busMaGiamGia.TonTaiMaGiamGia(hd.MaGiamGia))
            {
                mucGiamGia = busMaGiamGia.LaySoTienGiamGia(hd.MaGiamGia);
            }

            // Tinh lai tong tien
            decimal tongTien = 0;
            DataTable tbCTHoaDon = bus_CTHD.LoadCTHD(maHD);
            foreach(DataRow row in tbCTHoaDon.Rows)
            {
                tongTien = tongTien + decimal.Parse(row["SoLuong"].ToString()) * decimal.Parse(row["DonGia"].ToString());
            }

            tongTien = tongTien - mucGiamGia;

            if (tongTien < 0)
                tongTien = 0;

            busHoaDon.CapNhatTongTien(maHD, tongTien);
            LoadDanhSachHoaDon();
        }
    }
}
