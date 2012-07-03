<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Billing.aspx.cs" Inherits="WoodenSoft.ObamaInHydePark.Admin.Billing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
Customer Billing:
</div>
<div>
    <asp:Label runat="server" ID="lblError"></asp:Label>

</div>
<asp:GridView ID="gvUsers" runat="server" AllowSorting="true" AllowPaging="true" AutoGenerateColumns="false" >
    <Columns>
        <asp:BoundField DataField="Email" HeaderText="Email" />
        <asp:BoundField DataField="OrderNumber" HeaderText="Order Number"/>
        <asp:TemplateField>
            <HeaderTemplate>Has Been Processed?</HeaderTemplate>
            <ItemTemplate>
                <%# ((int)Eval("HasBeenProcessed")) %2 == 0  ? "No" : "Yes" %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnEmail" runat="server" Text="Send email To Customer" OnClick="EmailCustomer" CommandArgument='<%# Eval("OrderNumber") %>' />
                <asp:Button runat="server" ID="btnReset" Text="Reset For User" CommandArgument='<%#Eval("OrderNumber") %>' OnClick="ResetOrderNumber" />
            </ItemTemplate>
        </asp:TemplateField>
     </Columns>
</asp:GridView>
</asp:Content>
