<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="InvestmentHelperV2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Login.</h2>
    <br />
    <br />

    <Table ID="tblLogin">
        <tr>
            <td style="width: 194px">
                <asp:Label ID="lblEmail" runat="server" Text="Email: " CssClass="la"></asp:Label>
                <br />
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="177px"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td style="width: 194px">
                <asp:Label ID="lblCustomerPassword" runat="server" Text="Label">Password: </asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPwd" runat="server" textMode="Password" Width="177px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td style="width: 194px"></td>
            <td>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Width="143px" CssClass="btn focus" Font-Bold="False"></asp:Button>
            </td>
        </tr>

        <tr>
            <td style="width: 194px"></td>
            <td>
                <asp:Label ID="lblIncorrect" runat="server" Text="Incorrect login details." ForeColor="Red" Visible="false"></asp:Label>
            </td>
        </tr>

        <tr><td><br/></td></tr>

        <tr>
            <td >
                <asp:Button ID="btnForgotPwd" runat="server" Text="Forgot Password" Width="143px" CssClass="btn"></asp:Button>
            </td>
            <td>
                <asp:Button ID="btnRegister" runat="server" Text="Register" Width="143px" OnClick="btnRegister_Click" CssClass="btn"></asp:Button>
            </td>
        </tr>
    </Table>
</asp:Content>