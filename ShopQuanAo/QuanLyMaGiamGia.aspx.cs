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
    public partial class QuanLyMaGiamGia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadMaGiamGia();
                AnHienControl(true);
            }
        }

        private void LoadMaGiamGia()
        {
            BUS_MaGiamGia busMaGiamGia = new BUS_MaGiamGia();
            DataTable dsMaGiamGia = busMaGiamGia.DanhSachMaGiamGia();
            gvMaGiamGia.DataSource = dsMaGiamGia;
            gvMaGiamGia.DataBind();
            lblThongBao.Text = "";

        }

        protected void gvMaGiamGia_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(gvMaGiamGia.DataKeys[e.RowIndex].Value.ToString());
            BUS_MaGiamGia bus = new BUS_MaGiamGia();
            MaGiamGiaDTO maGiamGia = bus.LayThongTinMaGiamGia(id);
            if (maGiamGia != null)
            {
                bus.XoaMaGiamGia(maGiamGia.Id);
                LoadMaGiamGia();
                lblThongBao.Text = "Đã xoá Mã giảm giá " + maGiamGia.Ma + " - " + maGiamGia.MoTa;
            }
            else
            {
                lblThongBao.Text = "Không tìm thấy mã giảm giá cần xoá !";
            }

        }

        //btnThemMaGiamGia_Click
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            BUS_MaGiamGia bus = new BUS_MaGiamGia();
            if (trangThai == "THEM_MOI")
            {
                if (bus.TonTaiMaGiamGia(txtMa.Text.Trim()))
                {
                    lblThongBao.Text = "Mã giảm giá bị trùng, vui lòng thay đổi mã giảm giá !";
                    return;
                }

                MaGiamGiaDTO maGiamGia = new MaGiamGiaDTO();
                maGiamGia.Ma = txtMa.Text.Trim();
                maGiamGia.MoTa = txtMoTa.Text.Trim();
                decimal soTien = 0;
                if (!decimal.TryParse(txtSoTien.Text.Trim(), out soTien))
                {
                    lblThongBao.Text = "Số tiền không hợp lệ !";
                    return;
                }
                maGiamGia.SoTien = soTien;
                bus.GhiThongTinMaGiamGia(maGiamGia);
                lblThongBao.Text = "Đã thêm mã giảm giá thành công !";
                LoadMaGiamGia();
                return;
            }

            if (trangThai == "SUA")
            {
                int id = int.Parse(gvMaGiamGia.DataKeys[rowIndex].Value.ToString());
                MaGiamGiaDTO maGiamGia = bus.LayThongTinMaGiamGia(id);
                if (bus.TrungMaDangSua(id, maGiamGia.Ma))
                {
                    lblThongBao.Text = "Mã giảm giá trùng với mã giảm giá khác, vui lòng kiểm tra lại !";
                    return;
                }
                maGiamGia.Ma = txtMa.Text.Trim();
                maGiamGia.MoTa = txtMoTa.Text.Trim();
                decimal soTien = 0;
                if (!decimal.TryParse(txtSoTien.Text.Trim(), out soTien))
                {
                    lblThongBao.Text = "Số tiền không hợp lệ !";
                    return;
                }
                maGiamGia.SoTien = soTien;
                bus.SuaMaGiamGia(maGiamGia);
                lblThongBao.Text = "Đã sửa mã giảm giá thành công !";
                LoadMaGiamGia();
                return;
            }

            lblThongBao.Text = "Không có mã giảm giá nào được chọn !";

        }

        private static string trangThai = "";
        private static int rowIndex = -1;
        protected void gvMaGiamGia_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int id = int.Parse(gvMaGiamGia.DataKeys[e.NewSelectedIndex].Value.ToString());
            BUS_MaGiamGia bus = new BUS_MaGiamGia();
            MaGiamGiaDTO maGiamGia = bus.LayThongTinMaGiamGia(id);
            txtMa.Text = maGiamGia.Ma;
            txtMoTa.Text = maGiamGia.MoTa;
            txtSoTien.Text = maGiamGia.SoTien.ToString("N0");
            trangThai = "SUA";
            rowIndex = e.NewSelectedIndex;
        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtMa.Text = "";
            txtMoTa.Text = "";
            txtSoTien.Text = "";
            trangThai = "THEM_MOI";
            rowIndex = -1;
        }

        protected void gvMaGiamGia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //bool trangthai = bool.Parse(ddlHoaDon.SelectedValue);
            //Session["hdPage"] = e.NewPageIndex;
            //BUS_HoaDon bus = new BUS_HoaDon();
            //DataTable dt = new DataTable();
            //dt = bus.LoadDSHD(trangthai);
            //gvHoaDon.DataSource = dt.DefaultView;
            //gvHoaDon.PageIndex = e.NewPageIndex;
            //gvHoaDon.DataBind();

        }

        private void AnHienControl(bool flag)
        {
            txtMa.Enabled = flag;
            txtMoTa.Enabled = flag;
            txtSoTien.Enabled = flag;

        }
    }
}