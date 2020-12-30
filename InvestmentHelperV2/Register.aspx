<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="InvestmentHelperV2.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Welcome to Registration.</h2>
    <h3>If registeration is successful, you will be redirected to log in page</h3>

    <Table ID="tblRegistration">
        <tr><td><br/></td></tr>
        <tr>
            <td style="width: 364px" class="modal-sm">
                <asp:Label ID="lblName" runat="server" Text="Full Name" CssClass="la"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="364px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td style="width: 364px" class="modal-sm">
                <asp:Label ID="lblMobile" runat="server" Text="Mobile Number " CssClass="la"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMobile" TextMode="Number" runat="server" Width="364px" ></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td style="width: 364px" class="modal-sm">
                <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="la"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" Width="364px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td style="width: 364px" class="modal-sm">
                <asp:Label ID="lblAddress" runat="server" Text="Address" CssClass="la"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" Width="364px"></asp:TextBox>
            </td>
        </tr>

        <tr><td><br/></td></tr>

        <tr>
            <td style="width: 364px" class="modal-sm">
                <asp:Label ID="lblPwd" runat="server" Text="Password" CssClass="la"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPwd" TextMode="Password" runat="server" Width="364px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td style="width: 364px" class="modal-sm">
                <asp:Label ID="lblConPwd" runat="server" Text="Confirm Password" CssClass="la"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtConPwd" TextMode="Password" runat="server" Width="364px"></asp:TextBox>
            </td>
        </tr>

        <tr><td><br/></td></tr>

        <tr>
            <td style="width: 194px"></td>
            <td>
                <asp:Button ID="btnRegister" runat="server" Text="Register" Width="143px" CssClass="btn focus" Font-Bold="False" OnClick="btnRegister_Click"></asp:Button>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblErrors" runat="server" Text="Errors:" CssClass="la" Visible="False"></asp:Label>
            </td>
        </tr>
    </Table>
</asp:Content>
