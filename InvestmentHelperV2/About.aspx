<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="InvestmentHelperV2.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your investment helper</h3>
    <p>Our site will help and suggest you investment options by considering your income details. We will provide you some suggestions on where you 
        can invest your money, save some tax and find out options about future planning. Your data is always safe with us.
    </p>
</asp:Content>

