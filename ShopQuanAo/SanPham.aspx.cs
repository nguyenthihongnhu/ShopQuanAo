using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using BUS;
using DTO;

namespace ShopQuanAo
{
    public partial class SanPham1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadSanPham();
        }
        #region LoadSanPham
        public void LoadSanPham()
        {
            if (Request.QueryString["url"] != null)
            {
                string urlString = Request.QueryString["url"];
                Session["url"] = Request.UrlReferrer.ToString();
                BUS_SanPham bus = new BUS_SanPham();
                switch (urlString)
                {
                    case "aosomi":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(0, 1);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "aosomi";
                        break;
                    case "aolencardigan":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(1, 1);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "aolencardigan";
                        break;
                    case "aokhoacnam":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(2, 1);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "aokhoacnam";
                        break;
                    case "quannam":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(3, 1);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "quannam";
                        break;
                    case "dolotnam":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(4, 1);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "dolotnam";
                        break;
                    case "tatnam":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(5, 1);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "tatnam";
                        break;
                    case "giaynam":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(6, 1);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "giaynam";
                        break;
                    case "damnu":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(0, 0);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "damnu";
                        break;
                    case "aokhoacnu":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(1, 0);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "aokhoacnu";
                        break;
                    case "quannu":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(2, 0);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "quannu";
                        break;
                    case "chanvay":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(3, 0);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "chanvay";
                        break;
                    case "dolotnu":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(4, 0);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "dolotnu";
                        break;
                    case "dongu":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(5, 0);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "dongu";
                        break;
                    case "giaynu":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(6, 0);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "giaynu";
                        break;
                    case "kinhmatnam":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(7, 1);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "kinhmatnam";
                        break;
                    case "trangsucnam":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(8, 1);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "trangsucnam";
                        break;
                    case "cavat":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(9, 1);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "cavat";
                        break;
                    case "daynitnam":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(10, 1);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "daynitnam";
                        break;
                    case "gangtay":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(11, 1);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "gangtay";
                        break;
                    case "nonnam":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(12, 1);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "nonnam";
                        break;
                    case "vinam":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(13, 1);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "vinam";
                        break;
                    case "kinhmatnu":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(7, 0);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "kinhmatnu";
                        break;
                    case "trangsucnu":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(8, 0);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "trangsucnu";
                        break;
                    case "khanchoang":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(9, 0);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "khanchoang";
                        break;
                    case "daynitnu":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(10, 0);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "daynitnu";
                        break;
                    case "phukientoc":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(11, 0);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "phukientoc";
                        break;
                    case "nonnu":
                        dtlSanPham.DataSource = bus.LoadSanPhamTheoLoai(12, 0);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "nonnu";
                        break;
                    case "saleoff":
                        dtlSanPham.DataSource = bus.LoadSanPhamChuDe(3);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "saleoff";
                        break;
                    case "new":
                        dtlSanPham.DataSource = bus.LoadSanPhamChuDe(2);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "new";
                        break;
                    case "hot":
                        dtlSanPham.DataSource = bus.LoadSanPhamChuDe(1);
                        dtlSanPham.DataBind();
                        Session["LoaiSP"] = "hot";
                        break;
                    case "tk":
                        string TenSP = Request.QueryString["value"];
                        dtlSanPham.DataSource = bus.TimKiemSanPham(TenSP);
                        dtlSanPham.DataBind();
                        break;
                    default:
                        break;

                }

            }


        }
        #endregion

    }
}
