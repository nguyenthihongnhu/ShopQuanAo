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
    public partial class QuanLyThongTinLienHe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLienHe();
            }

        }
        public void LoadLienHe()
        {
            BUS_LienHe busLH = new BUS_LienHe();
            gvLienHe.DataSource = busLH.DanhSachLienHe();
            gvLienHe.DataBind();
        }

        protected void gvLienHe_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int maLH = int.Parse(gvLienHe.Rows[e.RowIndex].Cells[0].Text);
            BUS_LienHe busLH = new BUS_LienHe();
            busLH.XoaLienHe(maLH);
            LoadLienHe();
        }

        protected void gvLienHe_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int maLH = int.Parse(gvLienHe.DataKeys[e.NewSelectedIndex].Value.ToString());
            BUS_LienHe busLienHe = new BUS_LienHe();
            LienHeDTO lienHe = busLienHe.LayThongTinLienHe(maLH);
            txtHoTen.Text = lienHe.HoTen;
            txtSoDienThoai.Text = lienHe.SoDienThoai;
            txtNoiDung.Text = lienHe.NoiDung;
        }

        protected void gvLienHe_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
    }
}