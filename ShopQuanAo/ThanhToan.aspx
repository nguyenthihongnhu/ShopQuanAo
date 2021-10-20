<%@ Page Title="" Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="ThanhToan.aspx.cs" Inherits="ShopQuanAo.ThanhToan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding: 15px 5px 5px 5px">
        <h1 style="padding: 0 0 10px 0; color: #44280E;">Thông tin sản phẩm đặt mua </h1>
        <asp:GridView ID="gvDSSP" runat="server" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" GridLines="None" Height="117px"
            Width="684px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="MaSP" HeaderText="Mã Sản Phẩm">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="TenSP" HeaderText="Tên Sản Phẩm">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Size" HeaderText="Kích cỡ">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="SoLuong" HeaderText="Số Lượng">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="GiaBan" HeaderText="Giá">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <div id="thanhtoan">
            <div style="float: right;">
                <div id="tongsp">
                    <p><font style="color: blue; font-weight: bold;">Tổng sản phẩm : </font><font style="color: red; font-weight: bold;"><%= Session["TongSL"].ToString() %></font></p>
                </div>
                <div class="tongtien1">
                    <p><font style="color: blue; font-weight: bold;">Tổng tiền : </font><font style="color: red; font-weight: bold;"><%= Session["TongTien"].ToString()%> VNĐ</font></p>
                </div>
            </div>
        </div>
        <div style="padding: 15px 5px 5px 5px">
            <table style="width: 640px;">
                <tr>
                    <td colspan="3" style="padding: 0 0 10px 0; color: #44280E;">
                        <h1>Thông tin người mua hàng </h1>
                    </td>
                </tr>
                <tr>
                    <td class="label_thanhtoan">Tên Khách Hàng :</td>
                    <td class="textbox_thanhtoan">
                        <asp:TextBox ID="txtTenKH" runat="server" CssClass="textbox_thanhtoan"
                            Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="label_thanhtoan">Địa chỉ :</td>
                    <td class="textbox_thanhtoan">
                        <asp:TextBox ID="txtDiaChi" runat="server" CssClass="textbox_thanhtoan"
                            Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="label_thanhtoan">Email :</td>
                    <td class="textbox_thanhtoan">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox_thanhtoan"
                            Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="label_thanhtoan">Số điện thoại :</td>
                    <td class="textbox_thanhtoan">
                        <asp:TextBox ID="txtSoDT" runat="server" CssClass="textbox_thanhtoan"
                            Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="label_thanhtoan">Địa chỉ giao hàng:</td>
                    <td class="textbox_thanhtoan">
                        <asp:TextBox ID="txtDCNhan" runat="server" CssClass="textbox_thanhtoan"></asp:TextBox>
                    </td>
                    <td style="width: 150px;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ErrorMessage="Vui lòng nhập địa chỉ giao hàng" ControlToValidate="txtDCNhan"
                            ForeColor="Red"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="lbl_MaGiamGia">Mã giảm giá</td>
                    <td class="textbox_thanhtoan">
                        <asp:TextBox ID="txtMaGiamGia" runat="server" CssClass="textbox_thanhtoan"></asp:TextBox>
                    </td>
                    <td style="width: 150px;">
                        <asp:Button ID="btnApMaGiamGia" runat="server" Text="Áp mã giảm giá"
                            OnClick="btnApMaGiamGia_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="lbl_GiamGia">Giảm giá</td>
                    <td class="textbox_thanhtoan">
                        <asp:TextBox ID="txtGiamGia" runat="server" CssClass="textbox_thanhtoan"></asp:TextBox>
                    </td>
                    <td style="width: 150px;">

                    </td>
                </tr>
                <tr>
                    <td class="lbl_TongTien">Tổng tiền</td>
                    <td class="textbox_thanhtoan">
                        <asp:TextBox ID="txtTongTien" runat="server" CssClass="textbox_thanhtoan"></asp:TextBox>
                    </td>
                    <td style="width: 150px;">
                    </td>
                </tr>
                <tr>
                    <td class="label_thanhtoan">Ngày giao hàng :</td>
                    <td class="textbox_thanhtoan">
                        <asp:TextBox ID="txtNgayGiao" runat="server" CssClass="textbox_thanhtoan"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFiealdValidator2" runat="server"
                            ErrorMessage="Vui lòng nhập ngày giao hàng bạn muốn"
                            ControlToValidate="txtNgayGiao" ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ControlToValidate="txtNgayGiao" ErrorMessage="Nhập sai định dạng ngày tháng"
                            ValidationExpression="^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$"
                            ForeColor="Red"></asp:RegularExpressionValidator>
                        <br />
                        <asp:Label ID="lblNgayGiaoHang" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnXacNhan" runat="server" Text="Xác Nhận"
                            OnClick="btnXacNhan_Click" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
