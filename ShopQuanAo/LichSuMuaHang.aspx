<%@ Page Title="" Language="C#" MasterPageFile="~/GiaoDien.Master" AutoEventWireup="true" CodeBehind="LichSuMuaHang.aspx.cs" Inherits="ShopQuanAo.LichSuMuaHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding: 15px 5px 5px 5px">
        <asp:GridView ID="gvLichSuMuaHang" runat="server" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" GridLines="None" Height="170px"
            Width="650px" DataKeyNames="MaHD">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="MaHD" HeaderText="Mã hóa đơn">
                <ItemStyle HorizontalAlign="Center" Width="80px" />
                </asp:BoundField>
                 <asp:BoundField DataField="TenKhach" HeaderText="Tên khách">
                <ItemStyle HorizontalAlign="Center" Width="80px" />
                </asp:BoundField>
                 <asp:BoundField DataField="Email" HeaderText="Email">
                <ItemStyle HorizontalAlign="Center" Width="80px" />
                </asp:BoundField>
                 <asp:BoundField DataField="SoDienThoai" HeaderText="Số điện thoại">
                <ItemStyle HorizontalAlign="Center" Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="NgayLapHD" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày Lập HD">
                <ItemStyle HorizontalAlign="Center" Width="120px" />
                </asp:BoundField>
                <asp:BoundField DataField="DiaChiGiaoHang" HeaderText="Địa chỉ giao hàng">
                <ItemStyle HorizontalAlign="Center" Width="250px" />
                </asp:BoundField>
                <asp:BoundField DataField="TongTien" HeaderText="Tổng tiền">
                <ItemStyle HorizontalAlign="Center" Width="250px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText = "Trạng Thái" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <p style="color:#332221;font-weight:bold;"> <%# Eval("TrangThai").Equals(false)? "Chưa duyệt":"Đã duyệt" %></p>
                    </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                 </asp:TemplateField>

            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
</asp:Content>
