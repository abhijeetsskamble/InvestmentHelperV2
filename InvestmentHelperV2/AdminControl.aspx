<%@ Page Title="Admin Controls" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminControl.aspx.cs" Inherits="InvestmentHelperV2.AdminControl" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Visible="False"></asp:Label>
    
    <asp:GridView ID="gdCustomerInfo" runat="server" Width="924px">
    </asp:GridView>



</asp:Content>

