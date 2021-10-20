<%@ Page Title="" Language="C#" MasterPageFile="~/GiaoDienAdmin.Master" AutoEventWireup="true" CodeBehind="QuanLyMaGiamGia.aspx.cs" Inherits="ShopQuanAo.QuanLyMaGiamGia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 1024px;">
        <div style="padding: 30px;">

            <asp:GridView ID="gvMaGiamGia" runat="server" CellPadding="4"
                ForeColor="#333333" GridLines="None" Height="109px" Width="884px"
                AutoGenerateColumns="False" DataKeyNames="Id"
                OnRowDeleting="gvMaGiamGia_RowDeleting"
                OnSelectedIndexChanging="gvMaGiamGia_SelectedIndexChanging"
                AllowPaging="True" OnPageIndexChanging="gvMaGiamGia_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="Id" ReadOnly="true"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Mã" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <p style="color: #332221; font-weight: bold;"><%# Eval("Ma") %></p>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtMa" runat="server" Text='<%# Eval("Ma") %>' Width="100px" />
                        </EditItemTemplate>

                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mô tả" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <p style="color: #332221; font-weight: bold;"><%# Eval("MoTa") %></p>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNoiDung" runat="server" Text='<%# Eval("MoTa") %>' Width="100px" />
                        </EditItemTemplate>

                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="SoTien" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <p style="color: #332221; font-weight: bold;"><%# Eval("SoTien") %></p>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtSoTien" runat="server" Text='<%# Eval("SoTien") %>' Width="100px" />
                        </EditItemTemplate>

                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                    <asp:CommandField SelectText="Chọn" ShowSelectButton="True">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                    <asp:TemplateField HeaderText="Xóa ?" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <span onclick="return confirm('Bạn có chắc chắn muốn xóa không ?')">
                                <asp:LinkButton ID="lbtnXoa" runat="server" CommandName="Delete">Xóa</asp:LinkButton>
                            </span>
                        </ItemTemplate>

                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                </Columns>
                <EditRowStyle BackColor="Aqua" />
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
            <asp:Button ID="btnThemMoi" runat="server" Text="Thêm Mã Giảm Giá"
            onclick="btnThemMoi_Click" />
        </div>
        <div style="padding: 20px">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Mã Giảm Giá"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMa" runat="server" Width="265px" Enabled="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Nội dung"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMoTa" runat="server" Width="265px" Enabled="False"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Số Tiền"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSoTien" runat="server" Width="265px" Enabled="False"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnLuu" runat="server" Text="Lưu"
                            OnClick="btnLuu_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <h2>
                            <asp:Label ID="lblThongBao" runat="server" Text="" ForeColor="Red"></asp:Label></h2>
                    </td>
                </tr>
            </table>
        </div>
    </div>

</asp:Content>
