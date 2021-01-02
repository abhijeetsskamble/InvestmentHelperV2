<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerControl.aspx.cs" Inherits="InvestmentHelperV2.CustomerControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Investment details</h2>

    <br/>
    <br/>
    <br/>

    <Table ID="tlbCustomerView">
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
                <asp:Label ID="lblMobile" runat="server" TextMode="Number" Text="Mobile" CssClass="la"></asp:Label>
            </td>
            <td>
                <asp:Label ID="txtMobile" runat="server" Width="364px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 364px" class="modal-sm">
                <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="la"></asp:Label>
            </td>
            <td>
                <asp:Label ID="txtEmail" runat="server" TextMode="Email" Width="364px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 364px" class="modal-sm">
                <asp:Label ID="lblAddress" runat="server" Text="Address" CssClass="la"></asp:Label>
            </td>
            <td>
                <asp:Label ID="txtAddress" runat="server" Width="364px"></asp:Label>
            </td>
        </tr>

        <tr><td><br/></td></tr>

        <tr>
            <td>
                <asp:Label ID="lblStatus" Visible="false" runat="server" Text="Please enter investment related details below and update info." BackColor="Yellow"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblAlreadyFilled" Visible="false" runat="server" Text="You have already filled the required data." BackColor="Lime"></asp:Label>
            </td>
        </tr>

        <tr>
            <td style="width: 364px" class="modal-sm">
                <asp:Label ID="lblUpdateExisting" runat="server" Visible="false" Text="Do you want to update these values?" CssClass="la"></asp:Label>
            </td>
            <td style="width: 364px" class="modal-sm">
                <asp:Button ID="btnUpdateExisting" runat="server" Visible="false" Text="Yes" 
                    Width="363px" onclick="btnUpdateExisting_Click" />
            </td>
        </tr>

        <tr><td><br/></td></tr>

        <tr>
            <td style="width: 364px" class="modal-sm">
                <asp:Label ID="lblDOB" runat="server" Text="Date of Birth" CssClass="la"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDOB" runat="server" TextMode="Date" Text="" Width="364px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td style="width: 364px" class="modal-sm">
                <asp:Label ID="lblIncome" runat="server" Text="Annual Income" CssClass="la"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAnnualIncome" runat="server" TextMode="Number" Text="" Width="364px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td style="width: 364px" class="modal-sm">
                <asp:Label ID="lblOther" runat="server" Text="Income from other sources" CssClass="la"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtOtherIncome" runat="server" TextMode="Number" Text="" Width="364px"></asp:TextBox>
            </td>
        </tr>


        <tr>
            <td style="width: 364px" class="modal-sm">
                <asp:Label ID="lblEnterRent" runat="server" Text="Please enter rent amount (0 if none)" CssClass="la"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtRentAmount" runat="server" TextMode="Number" Text="" Width="364px"></asp:TextBox>
            </td>
        </tr>



        <tr>
            <td style="width: 364px" class="modal-sm">
                <asp:Label ID="lblPF" runat="server" Text="Select employee fund if any" CssClass="la"></asp:Label>
            </td>
            <td style="width: 364px" class="modal-sm">
            <asp:CheckBoxList ID="cbPF" runat="server">
                <asp:ListItem>GPF</asp:ListItem>
                <asp:ListItem>EPF</asp:ListItem>
                <asp:ListItem>PPF</asp:ListItem>
            </asp:CheckBoxList>
            </td>
        </tr>

        <tr>
            <td style="width: 364px" class="modal-sm">
                <asp:Label ID="lblMps" runat="server" Text="Do you invest in NPS" CssClass="la"></asp:Label>
            </td>
            <td style="width: 364px" class="modal-sm">
                <asp:RadioButtonList ID="rdNps" runat="server" Width="361px">
                    <asp:ListItem Selected="True">No</asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>

        <tr>
            <td style="width: 364px" class="modal-sm">
                <asp:Label ID="lblRisk" runat="server" Text="Select risk" CssClass="la"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="dpRisk" runat="server" Width="364px">
                    <asp:ListItem Value="Minimal"></asp:ListItem>
                    <asp:ListItem Value="Low"></asp:ListItem>
                    <asp:ListItem Value="Moderate"></asp:ListItem>
                    <asp:ListItem Value="High"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td style="width: 364px" class="modal-sm">
            </td>
            <td>
                <asp:Button ID="btnUpdateInvestmentInfo" runat="server" Text="Update Info" 
                    Width="364px" onclick="btnUpdateInvestmentInfo_Click" />
            </td>
        </tr>
    </Table>


    <p>Thank you for filling all the information</p>
</asp:Content>
