<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="WoodenSoft.ObamaInHydePark.Admin.AdminPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="text-align: center">

<div>
    <h2><asp:HyperLink runat="server" NavigateUrl="~/Admin/Billing.aspx" Text="Customer Billing" /></h2>
</div>
<div>
    <h2><asp:HyperLink runat="server" NavigateUrl="~/Admin/SiteManager.aspx" Text="Site Management" /></h2>
</div>
</div>
</asp:Content>
