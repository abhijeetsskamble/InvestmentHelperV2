<%@ Page Title="Admin Controls" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminControl.aspx.cs" Inherits="InvestmentHelperV2.AdminControl" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Visible="False"></asp:Label>
    <br/>
    <br/>
    <Table ID="tblRegistration">
        <tr>
            <td style="width: 364px" class="modal-sm">
                <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name" CssClass="la"></asp:Label>
            </td>
            <td>
                <asp:Label ID="txtName" runat="server" ReadOnly="true" Text="" Width="364px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 364px" class="modal-sm">
                <asp:Label ID="lblCustomerId" runat="server" Text="Customer ID" CssClass="la"></asp:Label>
            </td>
            <td>
                <asp:Label ID="txtId" runat="server" ReadOnly="true" Text="" Width="364px"></asp:Label>
            </td>
        </tr>
        <tr><td><br/></td></tr>
        
        <tr>
            <td style="width: 364px" class="modal-sm">
                <asp:Label ID="lblMobile" runat="server" TextMode="Number" Text="Mobile" CssClass="la"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMobile" runat="server" Width="364px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 364px" class="modal-sm">
                <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="la"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Width="364px"></asp:TextBox>
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
            </td>
            <td>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" Width="364px" 
                    onclick="btnUpdate_Click" />
            </td>
        </tr>
    </Table>

    <br/>
    <br/>

    <asp:GridView ID="gdCustomerInfo" runat="server" Width="924px" 
        AutoGenerateSelectButton="True" 
        onselectedindexchanged="gdCustomerInfo_SelectedIndexChanged" >
    </asp:GridView>



</asp:Content>

