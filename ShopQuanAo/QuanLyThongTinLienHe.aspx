<%@ Page Title="" Language="C#" MasterPageFile="~/GiaoDienAdmin.Master" AutoEventWireup="true" CodeBehind="QuanLyThongTinLienHe.aspx.cs" Inherits="ShopQuanAo.QuanLyThongTinLienHe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 1024px;">
        <div style="padding: 30px;">

            <asp:GridView ID="gvLienHe" runat="server" CellPadding="4"
                ForeColor="#333333" GridLines="None" Height="109px" Width="884px"
                AutoGenerateColumns="False" DataKeyNames="Id"
                OnRowDeleting="gvLienHe_RowDeleting"
                OnSelectedIndexChanging="gvLienHe_SelectedIndexChanging"
                AllowPaging="True" OnPageIndexChanging="gvLienHe_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField HeaderText="Mã LH" DataField="Id" ReadOnly="true"
                        ItemStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Ngày Gửi" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <p style="color: #332221; font-weight: bold;"><%# Eval("NgayGui") %></p>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNgayGui" runat="server" Text='<%# Eval("NgayGui") %>' Width="100px" />
                        </EditItemTemplate>

                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tên Đăng Nhập" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <p style="color: #332221; font-weight: bold;"><%# Eval("TenDangNhap") %></p>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTenDangNhap" runat="server" Text='<%# Eval("TenDangNhap") %>' Width="100px" />
                        </EditItemTemplate>

                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Họ tên" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <p style="color: #332221; font-weight: bold;"><%# Eval("HoTen") %></p>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtHoTen" runat="server" Text='<%# Eval("HoTen") %>' Width="100px" />
                        </EditItemTemplate>

                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Địa chỉ" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <p style="color: #332221; font-weight: bold;"><%# Eval("DiaChi") %></p>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDiaChi" runat="server" Text='<%# Eval("DiaChi") %>' Width="100px" />
                        </EditItemTemplate>

                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <p style="color: #332221; font-weight: bold;"><%# Eval("Email") %></p>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmail" runat="server" Text='<%# Eval("Email") %>' Width="100px" />
                        </EditItemTemplate>

                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Điện thoại" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <p style="color: #332221; font-weight: bold;"><%# Eval("SoDienThoai") %></p>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDT" runat="server" Text='<%# Eval("SoDienThoai") %>' Width="100px" />
                        </EditItemTemplate>

                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nội dung" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <p style="color: #332221; font-weight: bold;"><%# Eval("NoiDung") %></p>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNoiDung" runat="server" Text='<%# Eval("NoiDung") %>' Width="100px" />
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
        </div>
        <div style="padding: 20px">
            <table style="width: 887px">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Họ Tên"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtHoTen" runat="server" Width="265px" Enabled="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Số điện thoại"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSoDienThoai" runat="server" Width="342px" Enabled="False"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Nội dung liên hệ"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtNoiDung" runat="server" Width="737px" Enabled="False" Height="88px"></asp:TextBox>
                    </td>

                </tr>
                <%--<tr>
                    <td>
                        <asp:Button ID="btnCapNhat" runat="server" Text="Cập nhật"
                            OnClick="btnCapNhat_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <h2>
                            <asp:Label ID="lblThongBao" runat="server" Text="" ForeColor="Red"></asp:Label></h2>
                    </td>
                </tr>--%>
            </table>
        </div>
    </div>
</asp:Content>
