<%@ Page Title="" Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="ChiTietSanPham.aspx.cs" Inherits="ShopQuanAo.ChiTietSanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div id="ct_content">
        <div id="ct_left_content">
            <asp:Image ID="imgSanPham" runat="server" style="max-height:245px;max-width:180px;min-height:245px;min-width:180px;"/>
        </div>
        <div id="ct_right_content">
            <div id="name_product">
                <asp:Label ID="lblTenSP" runat="server" Text="Áo thun hàn quốc" Font-Size="X-Large" ForeColor="#663300" Height="30px"  Font-Bold="True" ></asp:Label>
            </div>
            <div id="size_product">
                <asp:Label ID="Label1" runat="server" Text="Size :" ForeColor="#663300" Height="30px"  Font-Bold="True" ></asp:Label>
                <asp:DropDownList ID="ddlSize" runat="server" DataTextField="SIZE" 
                    DataValueField="MASIZE" Width="50px">
                </asp:DropDownList>
            </div>
            <div id="detail_product">
                <p runat="server" id="pGiaBan" title="as" ></p>
            </div>
            <div id="add_product">
                <asp:Label ID="lblGiaBan" runat="server" Text="Giá sản phẩm :" ForeColor="#663300" Height="30px"  Font-Bold="True" ></asp:Label>
                <br />
                <asp:Label ID="lblTinhTrang" runat="server" Text="Tình trạng :" ForeColor="#663300" Height="30px"  Font-Bold="True"></asp:Label>
                <br />
                <asp:ImageButton ID="ibtnMua" runat="server" ImageUrl="~/images/cart.png" />
            </div>
            
        </div>
        <div style="clear:both">
        </div>
       
    </div>
</asp:Content>
