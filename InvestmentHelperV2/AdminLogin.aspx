<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="InvestmentHelperV2.AdminLogin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Admin Login.</h2>
    <br />
    <br />

    <Table ID="tblLogin">
        <tr>
            <td style="width: 194px">
                <asp:Label ID="lblAdmEmail" runat="server" Text="Email: " CssClass="la"></asp:Label>
                <br />
            </td>
            <td>
                <asp:TextBox ID="txtAdmEmail" runat="server" Width="177px"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td style="width: 194px">
                <asp:Label ID="lblAdmPwd" runat="server" Text="Label">Password: </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAdmPwd" runat="server" textMode="Password" Width="177px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td style="width: 194px"></td>
            <td>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Width="143px" CssClass="btn focus" Font-Bold="False"></asp:Button>
            </td>
        </tr>

    </Table>
</asp:Content>